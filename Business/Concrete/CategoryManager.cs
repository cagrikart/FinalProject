﻿
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<List<Category>> GetAll()
        {
            //iş kodları
            return new SuccesDataResult<List<Category>>(_categoryDal.GetAll());
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccesDataResult<Category>(_categoryDal.Get(c => c.CategoryID == categoryId));

        }
    }
}