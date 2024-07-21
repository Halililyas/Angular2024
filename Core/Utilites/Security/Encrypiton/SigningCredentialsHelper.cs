using Microsoft.IdentityModel.Tokens;

namespace Core.Utilites.Security.Encrypiton
{
    // CreateSigningCredentials yöntemi, bir güvenlik anahtarı (security key) ve belirli bir
    // güvenlik algoritması kullanarak bir imzalama kimlik bilgisi (signing credentials) oluşturur.
    // Bu kimlik bilgisi, JSON Web Token (JWT) gibi belirteçlerin oluşturulması ve doğrulanmasında kullanılır.

    // Kod parçacığını daha detaylı inceleyelim:
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
