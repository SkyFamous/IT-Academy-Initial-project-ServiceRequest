using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SR.Data;
using SR.Data.Interface;
using SR.Data.Repositories;

namespace SR.Data
{
    public class UnitOfWork
    {
        private CategoryRepository categoryRepository;
        private CompanyRepository companyRepository;
        private OfferRepository offerRepository;
        private CustomerRepository customerRepository;
        private ExecutorRepository executorRepository;
        private CustOfferRepository custOfferRepository;
        private CompOfferRepository compOfferRepository;
        private AspNetRoleRepository aspNetRoleRepository;
        private AspNetUserClaimRepository aspNetUserClaimRepository;
        private AspNetUserLoginRepository aspNetUserLoginRepository;
        private AspNetUserRepository aspNetUserRepository;


        public CategoryRepository Categories
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository();
                return categoryRepository;
            }
        }

        public CompanyRepository Companies
        {
            get
            {
                if (companyRepository == null)
                    companyRepository = new CompanyRepository();
                return companyRepository;
            }
        }

        public OfferRepository Offers
        {
            get
            {
                if (offerRepository == null)
                    offerRepository = new OfferRepository();
                return offerRepository;
            }
        }

        public CustomerRepository Customers
        {
            get
            {
                if (customerRepository == null)
                    customerRepository = new CustomerRepository();
                return customerRepository;
            }
        }

        public ExecutorRepository Executors
        {
            get
            {
                if (executorRepository == null)
                    executorRepository = new ExecutorRepository();
                return executorRepository;
            }
        }

        public CompOfferRepository CompOffers
        {
            get
            {
                if (compOfferRepository == null)
                    compOfferRepository = new CompOfferRepository();
                return compOfferRepository;
            }
        }
        public CustOfferRepository CustOffers
        {
            get
            {
                if (custOfferRepository == null)
                    custOfferRepository = new CustOfferRepository();
                return custOfferRepository;
            }
        }

        public AspNetRoleRepository AspNetRoles
        {
            get
            {
                if (aspNetRoleRepository == null)
                    aspNetRoleRepository = new AspNetRoleRepository();
                return aspNetRoleRepository;
            }
        }

        public AspNetUserClaimRepository AspNetUserClaims
        {
            get
            {
                if (aspNetUserClaimRepository == null)
                    aspNetUserClaimRepository = new AspNetUserClaimRepository();
                return aspNetUserClaimRepository;
            }
        }

        public AspNetUserLoginRepository AspNetUserLogins
        {
            get
            {
                if (aspNetUserLoginRepository == null)
                    aspNetUserLoginRepository = new AspNetUserLoginRepository();
                return aspNetUserLoginRepository;
            }
        }

        public AspNetUserRepository AspNetUsers
        {
            get
            {
                if (aspNetUserRepository == null)
                    aspNetUserRepository = new AspNetUserRepository();
                return aspNetUserRepository;
            }
        }


        public void Save()
        {
            using (SRDBContext db = new SRDBContext())
            {
                db.SaveChanges();
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            using (SRDBContext db = new SRDBContext())
            {
                if (!this.disposed)
                {
                    if (disposing)
                    {
                        db.Dispose();
                    }
                    this.disposed = true;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
