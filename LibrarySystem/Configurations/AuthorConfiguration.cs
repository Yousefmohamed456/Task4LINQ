using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibrarySystem.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                   .UseIdentityColumn(1, 1);

            builder.Property(a => a.Name)
                   .IsRequired()
                   .HasMaxLength(120)
                   .HasColumnType("nvarchar(120)");

            builder.Property(a => a.BirthDate)
                   .IsRequired()
                   .HasColumnType("date");

            // 1 : M Relationship with Book
            builder.HasMany(a => a.Books)
                   .WithOne(b => b.Author)
                   .HasForeignKey(b => b.AuthorId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
