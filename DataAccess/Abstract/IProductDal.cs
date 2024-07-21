using Core.DataAccess.EntityFramework;
using Core.Enitities;
using Enitites.Concarete;
using Enitites.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepositoryBase<Product>// Burdaki kodlar IEntityRepositoryBase miras alıp crud işlemleri direk tek bir yerden 
        // Yapıldı 
        // Burda sadece Product nesnesinin kendi ait İşlemleri Yapıldı 
    {
        List<ProductDetailDTO> GetProductDetails();
    }
}
