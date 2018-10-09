using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Models;
using BAL.Repositories;

namespace BAL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer GetCustomer(int id)
        {
            return _customerRepository.GetById(id);
        }

        public void CreateCustomer(Customer customer)
        {
            _customerRepository.Create(customer);
            _customerRepository.SaveChanges();
        }
    }
}
