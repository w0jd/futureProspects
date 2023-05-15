using FutureProspects.Models;

namespace FutureProspects.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)

        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Offer>()
                .HasMany(p => p.EmployeeOffer)
                .WithOne(pc => pc.Offer)
                .HasForeignKey(pc => pc.OfferId);

            modelBuilder.Entity<Employee>()
                .HasMany(c => c.EmployeeOffer)
                .WithOne(pc => pc.Employee)
                .HasForeignKey(pc => pc.EmployeeId);

            modelBuilder.Entity<EmployeeOffer>()
                .HasKey(pc => new { pc.OfferId, pc.EmployeeId });
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Empolyer> Empolyers { get; set; }
        public DbSet<Offer> Offers{ get; set; }
        public DbSet<EmployeeOffer> EmployeeOffers { get; set; }


    }
}
