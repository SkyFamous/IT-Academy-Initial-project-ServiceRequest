using SR.Data.Repositories;
using System;

namespace SR.Data
{
    public class UnitOfWork
    {
        private readonly SRDBContext db = new SRDBContext();

        private CategoryRepository categoryRepository;
        private CompanyRepository companyRepository;
        private OfferRepository offerRepository;
        private CustomerRepository customerRepository;
        private ExecutorRepository executorRepository;
        private CustOfferRepository custOfferRepository;
        private CompOfferRepository compOfferRepository;

        public UnitOfWork()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        public CategoryRepository Categories
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository(db);
                return categoryRepository;
            }
        }

        public CompanyRepository Companies
        {
            get
            {
                if (companyRepository == null)
                    companyRepository = new CompanyRepository(db);
                return companyRepository;
            }
        }

        public OfferRepository Offers
        {
            get
            {
                if (offerRepository == null)
                    offerRepository = new OfferRepository(db);
                return offerRepository;
            }
        }

        public CustomerRepository Customers
        {
            get
            {
                if (customerRepository == null)
                    customerRepository = new CustomerRepository(db);
                return customerRepository;
            }
        }

        public ExecutorRepository Executors
        {
            get
            {
                if (executorRepository == null)
                    executorRepository = new ExecutorRepository(db);
                return executorRepository;
            }
        }

        public CompOfferRepository CompOffers
        {
            get
            {
                if (compOfferRepository == null)
                    compOfferRepository = new CompOfferRepository(db);
                return compOfferRepository;
            }
        }
        public CustOfferRepository CustOffers
        {
            get
            {
                if (custOfferRepository == null)
                    custOfferRepository = new CustOfferRepository(db);
                return custOfferRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
