namespace SR.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CustOffer
    {
        public int Id { get; set; }

        public int Price { get; set; }

        [Required]
        public string Term { get; set; }

        public int CustomersId { get; set; }

        public int OffersId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Offer Offer { get; set; }
    }
}
