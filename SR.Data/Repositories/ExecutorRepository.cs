using SR.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using SR.Model;

namespace SR.Data.Repositories
{
    public class ExecutorRepository : IBaseRepository<Executor>
    {

        public ExecutorRepository()
        {

        }

        public IEnumerable<Executor> GetAll(Expression<Func<Executor, bool>> filter = null)
        {
            IEnumerable<Executor> executors;
            using (SRDBContext db = new SRDBContext())
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
            using (SRDBContext db = new SRDBContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                return db.Executors.Find(id);
            }
        }

        public void Create(Executor executor)
        {
            using (SRDBContext db = new SRDBContext())
            {
                db.Executors.Add(executor);
            }
        }

        public void Update(Executor executor)
        {
            using (SRDBContext db = new SRDBContext())
            {
                db.Entry(executor).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            using (SRDBContext db = new SRDBContext())
            {
                Executor executor = db.Executors.Find(id);
                if (executor != null)
                    db.Executors.Remove(executor);
            }
        }
    }
}
