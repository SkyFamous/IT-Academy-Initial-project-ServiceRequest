using SR.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using SR.Model;

namespace SR.Data.Repositories
{
    public class AspNetRoleRepository : IBaseRepository<AspNetRole>
    {
        public AspNetRoleRepository()
        {

        }

        public IEnumerable<AspNetRole> GetAll(Expression<Func<AspNetRole, bool>> filter = null)
        {
            using (SRDBContext db = new SRDBContext())
            {
                IEnumerable<AspNetRole> aspNetRoles;
                db.Configuration.ProxyCreationEnabled = false;
                if (filter == null)
                {
                    aspNetRoles = db.AspNetRoles.ToList();
                }
                else
                {
                    aspNetRoles = db.AspNetRoles.Where(filter).ToList();
                }
                return aspNetRoles;
            }
        }

        public AspNetRole Get(int? id)
        {
            using (SRDBContext db = new SRDBContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                return db.AspNetRoles.Find(id);
            }
        }

        public void Create(AspNetRole aspNetRole)
        {
            using (SRDBContext db = new SRDBContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.AspNetRoles.Add(aspNetRole);
            }
        }

        public void Update(AspNetRole aspNetRole)
        {
            using (SRDBContext db = new SRDBContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Entry(aspNetRole).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            using (SRDBContext db = new SRDBContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                AspNetRole aspNetRole = db.AspNetRoles.Find(id);
                if (aspNetRole != null)
                    db.AspNetRoles.Remove(aspNetRole);
            }
        }
    }
}
