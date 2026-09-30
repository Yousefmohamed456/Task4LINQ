using HealthCareSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthCareSystem.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patients");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .UseIdentityColumn(1, 1);

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(120)
                   .HasColumnType("nvarchar(120)");

            builder.Property(p => p.DateOfBirth)
                   .IsRequired()
                   .HasColumnType("date");
        }
    }
}
