using Appointments.Entities;
using Microsoft.EntityFrameworkCore;

namespace Appointments.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<AppointmentEntity> Appointments { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<OffDayEntity> OffDays { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppointmentEntity>()
                .HasOne(a => a.Customer)
                .WithMany(c => c.Appointments)
                .HasForeignKey(a => a.CustomerID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CustomerEntity>()
                .HasIndex(a => a.Email)
                .IsUnique();
        }
    }
}
