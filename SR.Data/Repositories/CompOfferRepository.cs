using SR.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace SR.Data.Repositories
{
    public class CompOfferRepository : IBaseRepository<CompOffer>
    {
        private SRDBContext db;

        public CompOfferRepository(SRDBContext context)
        {
            this.db = context;
        }

        public IEnumerable<CompOffer> GetAll(Expression<Func<CompOffer, bool>> filter = null)
        {
            IEnumerable<CompOffer> compOffers;
            using (db)
            {
                if (filter == null)
                {
                    compOffers = db.CompOffers.ToList();
                }
                else
                {
                    compOffers = db.CompOffers.Where(filter).ToList();
                }
                return compOffers;
            }
        }

        public CompOffer Get(int? id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.CompOffers.Find(id);
        }

        public void Create(CompOffer compOffer)
        {
            db.CompOffers.Add(compOffer);
        }

        public void Update(CompOffer compOffer)
        {
            db.Entry(compOffer).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            CompOffer compOffer = db.CompOffers.Find(id);
            if (compOffer != null)
                db.CompOffers.Remove(compOffer);
        }
    }
}
