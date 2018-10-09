using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Models;

namespace BAL.Services
{
    public interface ICustomerService
    {
        Customer GetCustomer(int id);

        void CreateCustomer(Customer customer);
    }
}
