using SR.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using SR.Model;

namespace SR.Data.Repositories
{
    public class OfferRepository : IBaseRepository<Offer>
    {
        public OfferRepository()
        {

        }

        public IEnumerable<Offer> GetAll(Expression<Func<Offer, bool>> filter = null)
        {
            IEnumerable<Offer> offers;
            using (SRDBContext db = new SRDBContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                if (filter == null)
                {
                    offers = db.Offers.ToList();
                }
                else
                {
                    offers = db.Offers.Where(filter).ToList();
                }
                return offers;
            }
        }

        public Offer Get(int? id)
        {
            using (SRDBContext db = new SRDBContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                return db.Offers.Find(id);
            }
        }

        public void Create(Offer offer)
        {
            using (SRDBContext db = new SRDBContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Offers.Add(offer);
            }
        }

        public void Update(Offer offer)
        {
            using (SRDBContext db = new SRDBContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Entry(offer).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            using (SRDBContext db = new SRDBContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                Offer offer = db.Offers.Find(id);
                if (offer != null)
                    db.Offers.Remove(offer);
            }
        }
    }
}
