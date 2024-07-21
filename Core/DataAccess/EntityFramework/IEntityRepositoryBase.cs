using Core.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public interface IEntityRepositoryBase<T> where T : class, IEntity, new()// Busınıfın Temel Görevi Sudur Oluşturduğumuz Entitylerin CRUD İşlemini
                                                                            //merkezi Biryerden kontrol Edebilmek Kod kalabalığından kurtulmuş olduk 
                                                                            //Burda where dedikten sonra Generic yapıda gelicek olan T nesnesi için
                                                                            //kural belirtik 
    {

        List<T> GetAll(Expression<Func<T, bool>> filter = null); // Burda gelecek olan T nesnesini listeleme işlemi yapıldı egerki filtre verilmiş olsaydı  ona göre listeleme işlemi yapılcaktı  
        T Get(Expression<Func<T, bool>> filter);// Burasıda tek bir nesene döndürür 
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
