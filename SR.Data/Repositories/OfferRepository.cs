using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Models;
using BAL.Repositories;

namespace DAL.Repositories
{
    public class OfferRepository : Repository<Offer>, IOfferRepository
    {
        public OfferRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
