using SR.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using SR.Model;

namespace SR.Data.Repositories
{
    public class CompOfferRepository : IBaseRepository<CompOffer>
    {

        public CompOfferRepository()
        {
        }

        public IEnumerable<CompOffer> GetAll(Expression<Func<CompOffer, bool>> filter = null)
        {
            IEnumerable<CompOffer> compOffers;
            using (SRDBContext db = new SRDBContext())
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
            using (SRDBContext db = new SRDBContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                return db.CompOffers.Find(id);
            }
        }

        public void Create(CompOffer compOffer)
        {
            using (SRDBContext db = new SRDBContext())
            {
                db.CompOffers.Add(compOffer);
            }
        }

        public bool IsProviding(int offerId, int companyId)
        {
            using (SRDBContext db = new SRDBContext())
            {
                return db.CompOffers.Any(cf => cf.CompaniesId == companyId && cf.OffersId == offerId);
            }
        }

        public bool IsProviding(int offerId, int companyId, out int recordId)
        {
            using (SRDBContext db = new SRDBContext())
            {
                if (!db.CompOffers.Any(cf => cf.CompaniesId == companyId && cf.OffersId == offerId))
                {
                    recordId = -1;
                    return false;
                }
                var record = db.CompOffers.First(cf => cf.CompaniesId == companyId && cf.OffersId == offerId);
                recordId = record.Id;
                return true;
            }
        }

        public void Update(CompOffer compOffer)
        {
            using (SRDBContext db = new SRDBContext())
            {
                db.Entry(compOffer).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            using (SRDBContext db = new SRDBContext())
            {
                CompOffer compOffer = db.CompOffers.Find(id);
                if (compOffer != null)
                    db.CompOffers.Remove(compOffer);
            }
        }
    }
}
