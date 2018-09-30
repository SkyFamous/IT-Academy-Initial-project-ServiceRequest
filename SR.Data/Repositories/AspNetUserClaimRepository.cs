using SR.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using SR.Model;

namespace SR.Data.Repositories
{
    public class AspNetUserClaimRepository
    {
        public AspNetUserClaimRepository()
        {

        }

        public IEnumerable<AspNetUserClaim> GetAll(Expression<Func<AspNetUserClaim, bool>> filter = null)
        {
            using (SRDBContext db = new SRDBContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                IEnumerable<AspNetUserClaim> aspNetUserClaims;
                if (filter == null)
                {
                    aspNetUserClaims = db.AspNetUserClaims.ToList();
                }
                else
                {
                    aspNetUserClaims = db.AspNetUserClaims.Where(filter).ToList();
                }
                return aspNetUserClaims;
            }
        }

        public AspNetUserClaim Get(int? id)
        {
            using (SRDBContext db = new SRDBContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                return db.AspNetUserClaims.Find(id);
            }
        }

        public void Create(AspNetUserClaim aspNetUserClaim)
        {
            using (SRDBContext db = new SRDBContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.AspNetUserClaims.Add(aspNetUserClaim);
            }
        }

        public void Update(AspNetUserClaim aspNetUserClaim)
        {
            using (SRDBContext db = new SRDBContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Entry(aspNetUserClaim).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            using (SRDBContext db = new SRDBContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                AspNetUserClaim aspNetUserClaim = db.AspNetUserClaims.Find(id);
                if (aspNetUserClaim != null)
                    db.AspNetUserClaims.Remove(aspNetUserClaim);
            }
        }
    }
}
