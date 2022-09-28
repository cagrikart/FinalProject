using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;


        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
           IResult result =
                BusinessRules.Run(SameProductName(product.ProductName)
                            , CheckIfProductCountOfCategoryCorrect(product.CategoryID));

            if (result != null)
            {
                   return result;
            }

            _productDal.Add(product);

            return new ErrorResult();
            
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccesDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int categoryId)
        {
            return new SuccesDataResult<List<Product>>
                (_productDal.GetAll(p => p.CategoryID == categoryId), Messages.CategoryListed);
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccesDataResult<List<Product>>
                (_productDal.GetAll(p => p.UnitPrice > min && p.UnitPrice < max), "Listelendi");
        }

        public IDataResult<List<ProductDetailDTO>> GetProductDetails()
        {
            return
                new SuccesDataResult<List<ProductDetailDTO>>(_productDal.GetProductDetails());
        }

       

        public IDataResult<Product> GetProductId(int productId)
        {
            return new SuccesDataResult<Product>(_productDal.Get(p => p.ProductID == productId), "id göre listledi ");
        }
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryID == categoryId).Count;

            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }

        private IResult SameProductName (string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult("Aynı isimle ürün eklenmez ");
            }
            return new SuccessResult();
        }

        private IResult  CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }
    }
}
