using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDTO> GetProductDetails()
        {
            using (NorthwindContext northwindContext = new NorthwindContext())
            {
                var result = from p in northwindContext.Products
                             join c in northwindContext.Categories
                             on p.CategoryID equals c.CategoryID
                             select new ProductDetailDTO {ProductId = p.ProductID,
                                                          ProductName = p.ProductName, 
                                                          UnitsInStock = p.UnitsInStock ,
                                                          CategoryName = c.CategoryName
                                                                        };
            return result.ToList(); 
            }
        }
    }
}
