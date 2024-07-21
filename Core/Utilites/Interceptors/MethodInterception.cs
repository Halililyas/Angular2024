using Castle.DynamicProxy;

namespace Core.Utilites.Interceptors
{

    /// <summary>
    /// Bu kodlar, bir kesme (interception) mantığı uygulayan bir sınıfın parçasıdır. Kesme mantığı, genellikle bir nesnenin yöntem 
    /// çağrılarına müdahale etmek ve ek işlevler (örneğin, loglama, hata ayıklama veya güvenlik kontrolleri) eklemek için kullanılır.
    /// Bu tür bir yapıya genellikle "Aspect-Oriented Programming" (AOP) denir. Bu kod, muhtemelen AOP için bir araç olan
    /// Castle DynamicProxy gibi bir kütüphanede kullanılmaktadır.
    /// </summary>
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        // İnvocation suan bir Businessdaki bir Add delete update olabilir gibi düşün 
        protected virtual void OnBefore(IInvocation invocation) { }// invocation çağrısından önce çalışacak kodu içerir.
        protected virtual void OnAfter(IInvocation invocation) { }//çağrısından sonra çalışacak kodu içerir.
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }//  çağrısı sırasında bir hata oluştuğunda çalışacak kodu içerir.
        protected virtual void OnSuccess(IInvocation invocation) { }//çağrısı başarılı bir şekilde tamamlandığında çalışacak kodu içerir.
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();// ifadesi, orijinal metodun çalıştırılmasını sağlar.
              //Eğer invocation.Proceed(); sırasında bir istisna fırlatılırsa, catch bloğu devreye girer:
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }
        //Bu yapı, bir metod çağrısının öncesinde, sonrasında ve hata durumunda çeşitli işlemler gerçekleştirmeye olanak tanır.
    }
}
