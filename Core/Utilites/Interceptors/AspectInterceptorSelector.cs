using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilites.Interceptors
{

    public class AspectInterceptorSelector : IInterceptorSelector
    {

        // Bu kod bloğu, AspectInterceptorSelector sınıfının IInterceptorSelector arayüzünü uyguladığı ve Castle DynamicProxy gibi bir
        // kütüphane kullanarak bir sınıfın metodlarına uygulanacak kesme (interception) mantığını belirlediği bir yapıdır.
        // Kesme mantığı, metod çağrılarına müdahale ederek ek işlemler yapmayı sağlar.
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();// Sınıf seviyesindeki MethodInterceptionBaseAttribute attribute'larını toplar.
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);// Metod seviyesindeki MethodInterceptionBaseAttribute attribute'larını toplar.


            return classAttributes.OrderBy(x => x.Priority).ToArray(); //Metod attribute'larını sınıf attribute'larının listesine ekler.
        }
    }
}
