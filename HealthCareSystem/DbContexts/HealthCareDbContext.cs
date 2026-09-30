using HealthCareSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCareSystem.DbContexts
{
    public class HealthCareDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; } = null!;
        public DbSet<Doctor> Doctors { get; set; } = null!;
        public DbSet<Appointment> Appointments { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=Task4LINQ_HealthCareDb;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply all entity configurations in this assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HealthCareDbContext).Assembly);
        }
    }
}
