using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilites.Security.Hashing
{
    public class HashingHelper
    {
        //Bu kod bloğu, şifrelerin güvenli bir şekilde saklanması ve doğrulanması için iki metot sağlar.
        //Şifreler düz metin olarak saklanmaz; bunun yerine hash ve salt kullanılarak güvenli bir şekilde saklanır.
        //Bu, şifrelerin hashlenmesi ve doğrulanması işlemlerini gerçekleştirir.
        public static void CreatPasswordHash(string password,out byte[] passwordHash,out byte[]passwordSalt)//Bu metot, bir şifrenin hash ve salt değerlerini oluşturur.
        {
            using(var  hmac = new System.Security.Cryptography.HMACSHA512())//HMACSHA512 Nesnesi Oluşturma: HMACSHA512 sınıfından bir nesne oluşturulur. Bu nesne, hashleme işlemi için kullanılır ve aynı zamanda bir anahtar (salt) oluşturur.
            {
                passwordSalt = hmac.Key;//Salt Oluşturma: hmac.Key salt değeri olarak kullanılır.
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));//Hash Oluşturma: hmac.ComputeHash metodu, düz metin şifreyi (password) UTF-8 formatında bayt dizisine çevirir ve bu bayt dizisini hashler. Bu hash değeri passwordHash değişkenine atanır.
            }
        }
        // public static bool VerifyPasswordHash(string password , byte[] passwordHash, byte[] passwordSalt)//Bu metot, verilen bir şifrenin, daha önce oluşturulmuş hash ve salt değerleri ile eşleşip eşleşmediğini kontrol eder.
        // {
        // //Girdi: Düz metin şifre (password), daha önce oluşturulmuş hashlenmiş şifre (passwordHash), ve salt değeri (passwordSalt).
        //// Çıktı: Şifrenin doğruluğunu belirten bir boolean değeri(true / false).

        //     using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
        //     {
        //         var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        //         for (int i = 0; i < computedHash.Length; i++)
        //         {
        //             if (computedHash[i] != passwordHash[i])
        //             {
        //                 return false;
        //             }
        //         }
        //     }
        //     return true;
        // }
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        //reatePasswordHash metodu, güvenli bir şekilde bir şifrenin hash ve salt değerlerini oluşturur.
        // VerifyPasswordHash metodu, girilen şifrenin doğru olup olmadığını kontrol eder.
        //Bu yöntemler, şifrelerin güvenli bir şekilde saklanmasını ve doğrulanmasını sağlar, böylece kullanıcı şifreleri düz metin olarak depolanmaz ve saldırılara karşı daha güvenli hale gelir.
    }
}
