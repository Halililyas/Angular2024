using Core.Enitities.Concrete;

namespace Core.Utilites.Security.JWT
{//
 //    ITokenHelper arayüzü:

    //Bu arayüz, belirli bir işlevselliği tanımlar ve bu işlevselliği sağlayan sınıfların uyması gereken bir sözleşme niteliğindedir.
    //CreateToken yöntemi:

    //User tipi bir kullanıcı ve List<OparationClaim> tipi bir işlem yetki listesi alır.
    //Bu bilgiler doğrultusunda bir AccessToken (erişim belirteci) oluşturur ve geri döner.
    //Parametreler:
    //User user:

    //Bu parametre, token oluşturulacak kullanıcıyı temsil eder. Kullanıcının kimlik bilgilerini içerir.
    //List<OparationClaim> oparationClaims:

    //Bu parametre, kullanıcının sahip olduğu yetkileri temsil eder. Kullanıcının hangi işlemleri yapabileceğini belirten iddialar (claims) listesidir.
    //Dönüş Tipi:
    //AccessToken:
    //Bu dönüş tipi, oluşturulan erişim belirtecini temsil eder. Genellikle belirli bir süre için geçerli olan, kullanıcının kimliğini ve yetkilerini içeren bir JSON Web Token (JWT) olabilir.
    public interface ITokenHelper
    {
       public AccessToken CreateToken(User user, List<OparationClaim> oparationClaims); 
    }
}
