using System.Collections.Generic;

namespace SR.Web.Models
{
    public class OffersCollectionViewModel
    {
        public List<OfferViewModel> OfferViewModels { get; set; }
        public int CompanyId { get; set; }
    }
}