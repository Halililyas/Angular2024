using Castle.DynamicProxy;

namespace Core.Utilites.Interceptors

    // sınıfı  AttributeUsage
//Bu kod bloğu, .NET platformunda metod müdahalesi (method interception) yapmak için kullanılan bir temel (base) attribute sınıfını tanımlar.
//Bu sınıf, belirli metodlara veya sınıflara uygulandığında, bu metodlara yapılan çağrıları kesip özel davranışlar (interceptions) eklemeyi sağlar.
//Kodun detaylarına bakalım:
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    //AttributeTargets.Class | AttributeTargets.Method: == Bu attribute'un hem sınıflara hem de metodlara uygulanabileceğini belirtir.
    //AllowMultiple = true: Bir sınıfa veya metoda birden fazla bu attribute'dan eklenebileceğini belirtir.
    //Inherited = true:== Bu attribute'un, türetilmiş sınıflara da miras alınacağını belirtir
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    //abstract: Bu sınıfın soyut (abstract) olduğunu ve doğrudan örneklendirilemeyeceğini belirtir.
    // Attribute: Bu sınıfın bir attribute olduğunu belirtir.
    // IInterceptor: Bu sınıfın, metod müdahaleleri yapmak için gerekli olan IInterceptor arayüzünü implement ettiğini belirtir.
    {
        public int Priority { get; set; }
        // Bu özellik, müdahalenin önceliğini belirlemek için kullanılır. Müdahaleler sıraya konulurken bu öncelik değeri göz önünde bulundurulabilir.

        public virtual void Intercept(IInvocation invocation)
        {

        }
        //Intercept metodu, IInvocation nesnesi alır. Bu nesne, yapılan metod çağrısının tüm bilgilerini içerir (metod adı, parametreler, vb.).
       // Bu metodun içinde, metod çağrısını kesip(intercept) özel bir davranış eklemek mümkündür.Örneğin,
       // metod çağrısından önce veya sonra özel bir işlem yapılabilir.
    }


    /*
     * Özet 
     * Bu kod bloğu, metod veya sınıf seviyesinde müdahaleler (interceptions) yapabilmek için bir temel attribute tanımlar.
     * MethodInterceptionBaseAttribute sınıfı, metod müdahaleleri için temel işlevselliği sağlar ve türetilmiş sınıflar tarafından özelleştirilebilir. 
     * Müdahale edilen metod çağrıları sırasında ek işlemler yapmak için Intercept metodu override edilerek özel davranışlar tanımlanabilir.
     * Bu şekilde, çapraz kesen (cross-cutting) konular (loglama, hata yönetimi, yetkilendirme, vb.) merkezi bir şekilde yönetilebilir.
     */
}
