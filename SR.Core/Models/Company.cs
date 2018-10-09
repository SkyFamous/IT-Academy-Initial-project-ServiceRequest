namespace BAL.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Company
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Company()
        {
            CompOffers = new HashSet<CompOffer>();
            Executors = new HashSet<Executor>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Adress { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompOffer> CompOffers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Executor> Executors { get; set; }

        public string UserId { get; set; }
    }
}
