using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Enitites.Concarete;
using Enitites.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EFProductDal : EFEntityRepositoryBase<NortwindContext, Product>, IProductDal // Burda Core katmanında oluşturduğumuz EfEntityRepositoryBase
                                                                                              // miras alıyoruz ve bu bütün crud işlemlerini EFEntityRepositoryBase 
                                                                                              // kendi classında yapıyoruz Burda Sadace IProductDal özel olan işlemler yapıldı 
    {
        public List<ProductDetailDTO> GetProductDetails()
        {
            using (NortwindContext context = new NortwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryID equals c.CategoryID
                             select new ProductDetailDTO {
                                 ProductID = p.ProductID,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 UnitsInStock = p.UnitsInStock };

                return result.ToList();
            }
        }
    }
}
