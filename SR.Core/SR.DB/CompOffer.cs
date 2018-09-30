namespace SR.Model
{
    public partial class CompOffer
    {
        public int Id { get; set; }

        public int CompaniesId { get; set; }

        public int OffersId { get; set; }

        public virtual Company Company { get; set; }

        public virtual Offer Offer { get; set; }
    }
}
