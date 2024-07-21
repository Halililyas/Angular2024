using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constanst;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Cache;
using Core.Aspects.AutoFac.Validation;
using Core.CrossCuttingConcerns.Performance;
using Core.CrossCuttingConcerns.Transiction;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilites;
using Core.Utilites.Business;
using DataAccess.Abstract;
using Enitites.Concarete;
using Enitites.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concarte
{
    public class ProductManager : IProductService
    {
        public IProductDal _productDal;
        public ICategoryService _categoryService;
        public ProductManager(IProductDal productDal,ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
            
        }
        [SecuredOperation("product.add,admin")]
        //[ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
          //IResult result =   BusinessRules.Run(CheckIfProductOfCategoryCorret(product.CategoryID),
          //    SameProductNotAdd(product.ProductName),
          //    CategorySayısı(200));
           
          //  if (result != null) {
          //      return result;            
          //  }
            _productDal.Add(product);
            return new SuccessResult(Mesagess.ProductAdded,true);
           
        }
        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            //if (DateTime.Now.Hour == 22)
            //{
            //    return new ErrorDataResult<List<Product>>(Mesagess.MaintenanceTime);
            //}
            return new SuccessDataResult<List<Product>>(_productDal.GetAll());
        }
        [CacheAspect]
        public List<Product> GetAllProducts()
        {
           return _productDal.GetAll();
        }
        [CacheAspect]

        public IDataResult<List<Product>> GetByID(int id)
        {
           return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.ProductID==id), Mesagess.ProductListed);
        }

        public IDataResult<List<ProductDetailDTO>> GetProductDto()
        {
           return new SuccessDataResult<List<ProductDetailDTO>>(_productDal.GetProductDetails(),Mesagess.ProductListed);
        }
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            var result = _productDal.GetAll(p => p.CategoryID == product.CategoryID).Count;

            if (result > 10)
            {
                return new ErrorResult(Mesagess.ProductCountOfCategoryErrror);
            }
            return new  SuccessResult();
        }
    private IResult CheckIfProductOfCategoryCorret(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryID == categoryId).Count;

            if (result > 10)
            {
                return new ErrorResult(Mesagess.ProductCountOfCategoryErrror);
            }
            return new SuccessResult();
        }
        [TransactionScopeAspect]
        public IResult AddTrasactionTest(Product product)
        {
            _productDal.Update(product);
            _productDal.Add(product);
            return new SuccessResult(Mesagess.ProductAdded,true);
        }

        private IResult SameProductNotAdd(string productName)
        {
            bool Varmı;
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();// Any VARMI DİYE KONTROL EDİLİYOR
            if (result)
            {
                return new ErrorResult(Mesagess.SameProductNoTadd);
            }
            return new SuccessResult();
        }


        private IResult CategorySayısı(int sayı)
        {
            var result = _categoryService.GetAll().Data.Count;
           if (result > sayı)
            {
                return new  ErrorResult(Mesagess.CategoryDalSayıısı);
            }
            return new  SuccessResult();
        }

        
    }
    
}
