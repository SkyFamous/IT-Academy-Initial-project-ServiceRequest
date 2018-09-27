using SR.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace SR.Data.Repositories
{
    public class CustOfferRepository : IBaseRepository<CustOffer>
    {
        private SRDBContext db;

        public CustOfferRepository(SRDBContext context)
        {
            this.db = context;
        }

        public IEnumerable<CustOffer> GetAll(Expression<Func<CustOffer, bool>> filter = null)
        {
            IEnumerable<CustOffer> custOffers;
            using (db)
            {
                if (filter == null)
                {
                    custOffers = db.CustOffers.ToList();
                }
                else
                {
                    custOffers = db.CustOffers.Where(filter).ToList();
                }
                return custOffers;
            }
        }

        public CustOffer Get(int? id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.CustOffers.Find(id);
        }

        public void Create(CustOffer custOffer)
        {
            db.CustOffers.Add(custOffer);
        }

        public void Update(CustOffer custOffer)
        {
            db.Entry(custOffer).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            CustOffer custOffer = db.CustOffers.Find(id);
            if (custOffer != null)
                db.CustOffers.Remove(custOffer);
        }
    }
}
