using Core.Enitities.Concrete;
using Core.Extensions;
using Core.Utilites.Security.Encrypiton;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Core.Utilites.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        //Bu kod parçacığı, JSON Web Token (JWT) oluşturma ve yönetme işlemlerini gerçekleştiren bir JwtHelper sınıfını içerir.
        //ITokenHelper arayüzünü uygular ve belirli bir kullanıcı ve kullanıcıya ait yetki iddiaları (claims)
        //için JWT oluşturur. Aşağıda, kodun her bir parçasının ne işe yaradığı detaylı bir şekilde açıklanmıştır:
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;

        //JwtHelper sınıfının yapıcı metodu, uygulamanın yapılandırma ayarlarından TokenOptions adlı bir bölümünü okur
        //ve bu bölümdeki değerleri _tokenOptions adlı bir TokenOptions nesnesine atar. Bu işlem, JWT oluşturma ve doğrulama
        //işlemleri sırasında kullanılacak ayarların elde edilmesi amacıyla yapılır.
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();//Get<TokenOptions>() metodu, bu bölümdeki değerleri TokenOptions türüne dönüştürür ve _tokenOptions alanına atar.

        }
        //CreateToken yöntemi: Bir kullanıcı ve işlem yetkileri için JWT oluşturur.


        public AccessToken CreateToken(User user, List<OparationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);// Oluşturmadığımız sınıf

            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
            
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, List<OparationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
            claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OparationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }
    }
    }
