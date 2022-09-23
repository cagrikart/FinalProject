﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

      

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour ==22 )
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccesDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductListed);
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

        public IResult Add(Product product)
        {
            if(product.ProductName.Length<2 )
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productDal.Add(product);
            return new SuccessResult("Ürün eklendi");
        }

        public IDataResult <Product> GetProductId(int productId)
        {
            return new SuccesDataResult<Product>(_productDal.Get(p => p.ProductID == productId), "id göre listledi ");
        }
    }
}