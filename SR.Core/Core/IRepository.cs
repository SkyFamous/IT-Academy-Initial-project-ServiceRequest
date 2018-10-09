using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BAL.Core
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null);
        T GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T id);
        void SaveChanges();
        void Dispose();
    }
}