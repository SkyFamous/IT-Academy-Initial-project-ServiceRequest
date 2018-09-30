using SR.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SR.Model;

namespace SR.Data.Repositories
{
    public class CustomerRepository : IBaseRepository<Customer>
    {
        public CustomerRepository()
        {

        }

        public IEnumerable<Customer> GetAll(Expression<Func<Customer, bool>> filter = null)
        {
            using (SRDBContext db = new SRDBContext())
            {
                IEnumerable<Customer> customers;
                db.Configuration.ProxyCreationEnabled = false;
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
            using (SRDBContext db = new SRDBContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                return db.Customers.Find(id);
            }
        }

        public void Create(Customer customer)
        {
            using (SRDBContext db = new SRDBContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Customers.Add(customer);
            }
        }

        public void Update(Customer customer)
        {
            using (SRDBContext db = new SRDBContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Entry(customer).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            using (SRDBContext db = new SRDBContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                Customer customer = db.Customers.Find(id);
                if (customer != null)
                    db.Customers.Remove(customer);
            }
        }
    }
}
