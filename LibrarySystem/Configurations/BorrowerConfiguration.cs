using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibrarySystem.Configurations
{
    public class BorrowerConfiguration : IEntityTypeConfiguration<Borrower>
    {
        public void Configure(EntityTypeBuilder<Borrower> builder)
        {
            builder.ToTable("Borrowers");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                   .UseIdentityColumn(1, 1);

            builder.Property(b => b.Name)
                   .IsRequired()
                   .HasMaxLength(120)
                   .HasColumnType("nvarchar(120)");

            builder.Property(b => b.MembershipDate)
                   .IsRequired()
                   .HasColumnType("date");
        }
    }
}
