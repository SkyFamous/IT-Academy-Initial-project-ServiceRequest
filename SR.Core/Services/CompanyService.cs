using BAL.Models;
using BAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public Company GetCompany(int id)
        {
            return _companyRepository.GetById(id);
        }

        public void CreateCompany(Company company)
        {
            _companyRepository.Create(company);
            _companyRepository.SaveChanges();
        }
    }
}
