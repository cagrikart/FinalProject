using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //IDisposable pattern implementation of c#
            using (NorthwindContext northwindContext = new NorthwindContext())
            {
                var addEntity = northwindContext.Entry(entity);
                addEntity.State = EntityState.Added;
                northwindContext.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext northwindContext = new NorthwindContext())
            {
                var deleteEntity = northwindContext.Entry(entity);
                deleteEntity.State = EntityState.Deleted;
                northwindContext.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext northwindContext = new NorthwindContext())
            {
                return northwindContext.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
           using (NorthwindContext northwindContext = new NorthwindContext())
            {
                return filter == null 
                    ? northwindContext.Set<Product>().ToList() 
                    : northwindContext.Set<Product>().Where(filter).ToList();  
            }

        }

        public void Update(Product entity)
        {
            using (NorthwindContext northwindContext = new NorthwindContext())
            {
                var updatedEntity = northwindContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                northwindContext.SaveChanges();
            }
        }
    }
}
