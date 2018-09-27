using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SR.Data.Interface
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
        TEntity Get(int? id);
        void Create(TEntity item);
        void Update(TEntity item);
        void Delete(int id);
    }
}