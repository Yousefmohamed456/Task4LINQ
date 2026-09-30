using HealthCareSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthCareSystem.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("Doctors");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id)
                   .UseIdentityColumn(1, 1);

            builder.Property(d => d.Name)
                   .IsRequired()
                   .HasMaxLength(120)
                   .HasColumnType("nvarchar(120)");

            builder.Property(d => d.Specialization)
                   .IsRequired()
                   .HasMaxLength(100)
                   .HasColumnType("nvarchar(100)");
        }
    }
}
