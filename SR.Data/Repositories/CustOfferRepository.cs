using SR.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using SR.Model;

namespace SR.Data.Repositories
{
    public class CustOfferRepository : IBaseRepository<CustOffer>
    {
        public CustOfferRepository()
        {

        }

        public IEnumerable<CustOffer> GetAll(Expression<Func<CustOffer, bool>> filter = null)
        {
            IEnumerable<CustOffer> custOffers;
            using (SRDBContext db = new SRDBContext())
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
            using (SRDBContext db = new SRDBContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                return db.CustOffers.Find(id);
            }
        }

        public void Create(CustOffer custOffer)
        {
            using (SRDBContext db = new SRDBContext())
            {
                db.CustOffers.Add(custOffer);
            }
        }

        public void Update(CustOffer custOffer)
        {
            using (SRDBContext db = new SRDBContext())
            {
                db.Entry(custOffer).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            using (SRDBContext db = new SRDBContext())
            {
                CustOffer custOffer = db.CustOffers.Find(id);
                if (custOffer != null)
                    db.CustOffers.Remove(custOffer);
            }
        }
    }
}
