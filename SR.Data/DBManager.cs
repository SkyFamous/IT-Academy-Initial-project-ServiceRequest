using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SR.Data
{
    public class DBManager
    {
        public IEnumerable<Category> GetAllCategories()
        {
            using (SRDBContext db = new SRDBContext())
            {
                var categories = db.Categories.ToList();
                return categories;
            }
        }

        public IEnumerable<Offer> GetAllOffers(Expression<Func<Offer, bool>> filter = null)
        {
            IEnumerable<Offer> offers;
            using (SRDBContext db = new SRDBContext())
            {
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

        public List<Company> GetAllCompanies(int? id)
        {
            //System.Diagnostics.Debugger.Launch();
            using (SRDBContext db = new SRDBContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                var compoffers = db.CompOffers;
                var offers = db.Offers;
                var companies = db.Companies;
                List<Company> result = new List<Company>();
                foreach (CompOffer a in compoffers)
                {
                    foreach (Offer c in offers)
                    {
                        foreach (Company b in companies)
                        {
                            if (a.OffersId == c.Id && b.Id == a.CompaniesId && c.Id == id)
                            {
                                result.Add(b);
                            }
                        }
                    }
                }
                return result;
            }
        }

        public IEnumerable<Executor> GetAllExecutors(Expression<Func<Executor, bool>> filter = null)
        {
            IEnumerable<Executor> executors;
            using (SRDBContext db = new SRDBContext())
            {
                if (filter == null)
                {
                    executors = db.Executors.ToList();
                }
                else
                {
                    executors = db.Executors.Where(filter).ToList();
                }
                return executors;
            }
        }
    }
}
