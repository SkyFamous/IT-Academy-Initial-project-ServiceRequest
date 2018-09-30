using SR.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using SR.Model;

namespace SR.Data.Repositories
{
    public class AspNetUserLoginRepository
    {
        public AspNetUserLoginRepository()
        {

        }

        public IEnumerable<AspNetUserLogin> GetAll(Expression<Func<AspNetUserLogin, bool>> filter = null)
        {
            using (SRDBContext db = new SRDBContext())
            {
                IEnumerable<AspNetUserLogin> aspNetUserLogins;
                db.Configuration.ProxyCreationEnabled = false;
                if (filter == null)
                {
                    aspNetUserLogins = db.AspNetUserLogins.ToList();
                }
                else
                {
                    aspNetUserLogins = db.AspNetUserLogins.Where(filter).ToList();
                }
                return aspNetUserLogins;
            }
        }

        public AspNetUserLogin Get(int? id)
        {
            using (SRDBContext db = new SRDBContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                return db.AspNetUserLogins.Find(id);
            }
        }

        public void Create(AspNetUserLogin aspNetUserLogin)
        {
            using (SRDBContext db = new SRDBContext())
            {
                db.AspNetUserLogins.Add(aspNetUserLogin);
            }
        }

        public void Update(AspNetUserLogin aspNetUserLogin)
        {
            using (SRDBContext db = new SRDBContext())
            {
                db.Entry(aspNetUserLogin).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            using (SRDBContext db = new SRDBContext())
            {
                AspNetUserLogin aspNetUserLogin = db.AspNetUserLogins.Find(id);
                if (aspNetUserLogin != null)
                    db.AspNetUserLogins.Remove(aspNetUserLogin);
            }
        }
    }
}