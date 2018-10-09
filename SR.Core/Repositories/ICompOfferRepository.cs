using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Core;
using BAL.Models;

namespace BAL.Repositories
{
    public interface ICompOfferRepository : IRepository<CompOffer>
    {
        bool IsProviding(int offerId, int companyId);
        bool IsProviding(int offerId, int companyId, out CompOffer recordId);

    }
}
