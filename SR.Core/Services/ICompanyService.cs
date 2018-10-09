using BAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public interface ICompanyService
    {
        Company GetCompany(int id);

        void CreateCompany(Company company);
    }
}
