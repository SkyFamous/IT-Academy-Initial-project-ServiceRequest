using SR.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SR.Data.Repositories
{
    public class CustomerRepository : IBaseRepository<Customer>
    {
        private SRDBContext db;

        public CustomerRepository(SRDBContext context)
        {
            this.db = context;
        }

        public IEnumerable<Customer> GetAll(Expression<Func<Customer, bool>> filter = null)
        {
            IEnumerable<Customer> customers;
            using (db)
            {
                if (filter == null)
                {
                    customers = db.Customers.ToList();
                }
                else
                {
                    customers = db.Customers.Where(filter).ToList();
                }
                return customers;
            }
        }

        public Customer Get(int? id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Customers.Find(id);
        }

        public void Create(Customer customer)
        {
            db.Customers.Add(customer);
        }

        public void Update(Customer customer)
        {
            db.Entry(customer).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Customer customer = db.Customers.Find(id);
            if (customer != null)
                db.Customers.Remove(customer);
        }
    }
}
