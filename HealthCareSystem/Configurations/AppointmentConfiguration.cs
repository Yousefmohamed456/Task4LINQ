using HealthCareSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthCareSystem.Configurations
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointments");

            // Composite Primary Key (PatientId + DoctorId + AppointmentDate)
            builder.HasKey(a => new { a.PatientId, a.DoctorId, a.AppointmentDate });

            builder.Property(a => a.AppointmentDate)
                   .IsRequired()
                   .HasColumnType("datetime2");

            // Many-to-Many Relationship via Join Entity Appointment
            builder.HasOne(a => a.Patient)
                   .WithMany(p => p.Appointments)
                   .HasForeignKey(a => a.PatientId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.Doctor)
                   .WithMany(d => d.Appointments)
                   .HasForeignKey(a => a.DoctorId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
