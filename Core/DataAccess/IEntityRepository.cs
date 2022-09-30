using Core.Entities.Abstract;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    //generic constraint
    //class referans tip
    // IEntity : IEntity olabilir veya IEntity implementeeden bir nesne olabilir 
    // new () : newlenebilir olmalı
    public interface IEntityRepository<T> where T : class,IEntity,new()
    {
          List<T> GetAll(Expression<Func<T, bool>> filter = null);

        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);

        //List<T> GetAllProduct(int productId);
    }
}
