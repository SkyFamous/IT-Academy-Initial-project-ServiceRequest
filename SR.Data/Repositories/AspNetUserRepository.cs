using SR.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using SR.Model;

namespace SR.Data.Repositories
{
    public class AspNetUserRepository : IBaseRepository<AspNetUser>
    {
        public AspNetUserRepository()
        {
        }

        public IEnumerable<AspNetUser> GetAll(Expression<Func<AspNetUser, bool>> filter = null)
        {
            using (SRDBContext db = new SRDBContext())
            {
                IEnumerable<AspNetUser> aspNetUsers;
                db.Configuration.ProxyCreationEnabled = false;
                if (filter == null)
                {
                    aspNetUsers = db.AspNetUsers.ToList();
                }
                else
                {
                    aspNetUsers = db.AspNetUsers.Where(filter).ToList();
                }
                return aspNetUsers;
            }
        }

        public AspNetUser Get(int? id)
        {
            using (SRDBContext db = new SRDBContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                return db.AspNetUsers.Find(id);
            }
        }

        public void Create(AspNetUser aspNetUser)
        {
            using (SRDBContext db = new SRDBContext())
            {
                db.AspNetUsers.Add(aspNetUser);
            }
        }

        public void Update(AspNetUser aspNetUser)
        {
            using (SRDBContext db = new SRDBContext())
            {
                db.Entry(aspNetUser).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            using (SRDBContext db = new SRDBContext())
            {
                AspNetUser aspNetUser = db.AspNetUsers.Find(id);
                if (aspNetUser != null)
                    db.AspNetUsers.Remove(aspNetUser);
            }
        }
    }
}
