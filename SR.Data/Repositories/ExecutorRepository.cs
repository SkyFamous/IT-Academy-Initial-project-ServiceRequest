using SR.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace SR.Data.Repositories
{
    public class ExecutorRepository : IBaseRepository<Executor>
    {
        private SRDBContext db;

        public ExecutorRepository(SRDBContext context)
        {
            this.db = context;
        }

        public IEnumerable<Executor> GetAll(Expression<Func<Executor, bool>> filter = null)
        {
            IEnumerable<Executor> executors;
            using (db)
            {
                if (filter == null)
                {
                    executors = db.Executors.ToList();
                }
                else
                {
                    executors = db.Executors.Where(filter).ToList();
                }
                return executors;
            }
        }

        public Executor Get(int? id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Executors.Find(id);
        }

        public void Create(Executor executor)
        {
            db.Executors.Add(executor);
        }

        public void Update(Executor executor)
        {
            db.Entry(executor).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Executor executor = db.Executors.Find(id);
            if (executor != null)
                db.Executors.Remove(executor);
        }
    }
}
