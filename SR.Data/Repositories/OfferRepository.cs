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
        private SRDBContext db;

        public OfferRepository(SRDBContext db)
        {
            this.db = db;
        }

        public IEnumerable<Offer> GetAll(Expression<Func<Offer, bool>> filter = null)
        {
            IEnumerable<Offer> offers;
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

        public Offer Get(int? id)
        {
            return db.Offers.Find(id);
        }

        public void Create(Offer offer)
        {
            db.Offers.Add(offer);
        }

        public void Update(Offer offer)
        {
            db.Entry(offer).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Offer offer = db.Offers.Find(id);
            if (offer != null)
                db.Offers.Remove(offer);
        }
    }
}
