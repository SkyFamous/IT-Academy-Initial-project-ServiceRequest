using BAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using BAL.Models;

namespace DAL.Repositories
{
    public class CompanyRepository : Repository<Company> , ICompanyRepository
    {
        public CompanyRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public IEnumerable<Company> GetCompaniesByOfferId(int? id)
        {
            var res = unitOfWork.Context.Companies.Where(comp => unitOfWork.Context.CompOffers.Where(compOffer => compOffer.OffersId == id)
            .Select(compOffer => compOffer.CompaniesId).Any(companiesId => comp.Id == companiesId)).ToList();
            return res;
        }
    }
}