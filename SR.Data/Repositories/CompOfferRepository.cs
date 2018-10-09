using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Models;
using BAL.Repositories;

namespace DAL.Repositories
{
    public class CompOfferRepository : Repository<CompOffer>, ICompOfferRepository
    {
        public CompOfferRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public bool IsProviding(int offerId, int companyId)
        {
            return unitOfWork.Context.CompOffers.Any(cf => cf.CompaniesId == companyId && cf.OffersId == offerId);
        }

        public bool IsProviding(int offerId, int companyId, out CompOffer recordId)
        {
            if (!unitOfWork.Context.CompOffers.Any(cf => cf.CompaniesId == companyId && cf.OffersId == offerId))
            {
                recordId = new CompOffer { Id = -1 };
                return false;
            }
            recordId = unitOfWork.Context.CompOffers.First(cf => cf.CompaniesId == companyId && cf.OffersId == offerId); ;
            return true;
        }
    }
}
