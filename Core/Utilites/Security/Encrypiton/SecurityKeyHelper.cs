using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Core.Utilites.Security.Encrypiton
{
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
            
    }
    //İşleyişi
//    Girdi: Metot, bir string olarak verilen securityKey parametresini alır.

//    Byte Diziye Dönüştürme: Encoding.UTF8.GetBytes(securityKey) ifadesi, verilen securityKey stringini UTF-8 formatında bir bayt dizisine dönüştürür.Bu, şifreleme algoritmasının çalışması için gereklidir çünkü şifreleme algoritmaları bayt dizileri üzerinde çalışır.
//SymmetricSecurityKey Nesnesi Oluşturma: new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey)) ifadesi, bayt dizisinden bir SymmetricSecurityKey nesnesi oluşturur.Bu nesne, simetrik bir şifreleme anahtarıdır ve JWT gibi güvenlik işlemlerinde kullanılır.
//Dönüş: Oluşturulan SymmetricSecurityKey nesnesi, metodun dönüş değeri olarak döndürülür.
//Kullanım Alanı
}
