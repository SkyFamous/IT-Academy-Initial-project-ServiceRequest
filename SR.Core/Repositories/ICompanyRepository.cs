using BAL.Models;
using BAL.Core;
using System.Collections.Generic;

namespace BAL.Repositories
{
    public interface ICompanyRepository : IRepository<Company>
    {
        IEnumerable<Company> GetCompaniesByOfferId(int? id);
    }
}
