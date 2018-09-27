using SR.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace SR.Data.Repositories
{
    public class CompanyRepository : IBaseRepository<Company>
    {
        private SRDBContext db;

        public CompanyRepository(SRDBContext context)
        {
            this.db = context;
        }

        public IEnumerable<Company> GetAll(Expression<Func<Company, bool>> filter = null)
        {
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable<Company> companies;
            using (db)
            {
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
            db.Configuration.ProxyCreationEnabled = false;
            return db.Companies.Find(id);
        }

        public void Create(Company company)
        {
            db.Configuration.ProxyCreationEnabled = false;
            db.Companies.Add(company);
        }

        public void Update(Company company)
        {
            db.Configuration.ProxyCreationEnabled = false;
            db.Entry(company).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            Company company = db.Companies.Find(id);
            if (company != null)
                db.Companies.Remove(company);
        }
    }
}
