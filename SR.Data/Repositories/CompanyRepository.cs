using SR.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using SR.Model;

namespace SR.Data.Repositories
{
    public class CompanyRepository : IBaseRepository<Company>
    {
        public CompanyRepository()
        {

        }

        public IEnumerable<Company> GetAll(Expression<Func<Company, bool>> filter = null)
        {
            using (SRDBContext db = new SRDBContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                IEnumerable<Company> companies;
                if (filter == null)
                {
                    companies = db.Companies.ToList();
                }
                else
                {
                    companies = db.Companies.Where(filter).ToList();
                }
                return companies;
            }
        }

        public Company Get(int? id)
        {
            using (SRDBContext db = new SRDBContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                return db.Companies.Find(id);
            }
        }

        public IEnumerable<Company> GetCompaniesByOfferId(int? id)
        {
            using (SRDBContext db = new SRDBContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                var res = db.Companies.Where(comp => db.CompOffers.Where(compOffer => compOffer.OffersId == id).Select(compOffer => compOffer.CompaniesId).Any(companiesId => comp.Id == companiesId)).ToList();
                return res;
            }
        }

        public void Create(Company company)
        {
            using (SRDBContext db = new SRDBContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Companies.Add(company);
            }
        }

        public void Update(Company company)
        {
            using (SRDBContext db = new SRDBContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Entry(company).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            using (SRDBContext db = new SRDBContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                Company company = db.Companies.Find(id);
                if (company != null)
                    db.Companies.Remove(company);
            }
        }
    }
}
