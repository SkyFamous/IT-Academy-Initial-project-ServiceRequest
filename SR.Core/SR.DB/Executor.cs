namespace SR.Model
{
    using System.ComponentModel.DataAnnotations;

    public partial class Executor
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public int OffersId { get; set; }

        public int CompaniesId { get; set; }

        public virtual Company Company { get; set; }
    }
}
