using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Models;
using BAL.Repositories;

namespace DAL.Repositories
{
    public class CustOfferRepository : Repository<CustOffer>, ICustOfferRepository
    {
        public CustOfferRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
