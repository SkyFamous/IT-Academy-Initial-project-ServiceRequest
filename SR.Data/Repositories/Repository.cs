using BAL.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly UnitOfWork unitOfWork;

        public Repository(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }


        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            IEnumerable<TEntity> companies;
            if (filter == null)
            {
                companies = unitOfWork.Context.Set<TEntity>().ToList();
            }
            else
            {
                companies = unitOfWork.Context.Set<TEntity>().Where(filter).ToList();
            }
            return companies;
        }

        public void Create(TEntity entity)
        {
            unitOfWork.Context.Set<TEntity>().Add(entity);
        }

        public TEntity GetById(int id)
        {
            return unitOfWork.Context.Set<TEntity>().Find(id);
        }

        public void Delete(TEntity entity)
        {
            unitOfWork.Context.Set<TEntity>().Attach(entity);
            unitOfWork.Context.Set<TEntity>().Remove(entity);
        }

        public void Update(TEntity entity)
        {
            unitOfWork.Context.Set<TEntity>().Attach(entity);
            unitOfWork.Context.Entry(entity).State = EntityState.Modified;
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
