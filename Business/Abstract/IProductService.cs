   using Core.Utilites;
using Enitites.Concarete;
using Enitites.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<ProductDetailDTO>> GetProductDto();
        IResult Add(Product product);
        IResult Update(Product product);
        IDataResult<List<Product>> GetByID(int id);
        List<Product> GetAllProducts();
        IResult AddTrasactionTest(Product product);

    }
}
