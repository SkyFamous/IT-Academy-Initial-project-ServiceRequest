namespace SR.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using SR.Model;

    public partial class SRDBContext : DbContext
    {
        public SRDBContext()
            : base("name=SRDBContext")
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<CompOffer> CompOffers { get; set; }
        public virtual DbSet<CustOffer> CustOffers { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Executor> Executors { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Offers)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.CategoriesId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.CompOffers)
                .WithRequired(e => e.Company)
                .HasForeignKey(e => e.CompaniesId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.Executors)
                .WithRequired(e => e.Company)
                .HasForeignKey(e => e.CompaniesId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.CustOffers)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.CustomersId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Offer>()
                .HasMany(e => e.CompOffers)
                .WithRequired(e => e.Offer)
                .HasForeignKey(e => e.OffersId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Offer>()
                .HasMany(e => e.CustOffers)
                .WithRequired(e => e.Offer)
                .HasForeignKey(e => e.OffersId)
                .WillCascadeOnDelete(false);
        }
    }
}
