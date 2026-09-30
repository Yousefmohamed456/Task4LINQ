using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibrarySystem.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                   .UseIdentityColumn(1, 1);

            builder.Property(b => b.Title)
                   .IsRequired()
                   .HasMaxLength(200)
                   .HasColumnType("nvarchar(200)");

            builder.Property(b => b.ISBN)
                   .IsRequired()
                   .HasMaxLength(20)
                   .HasColumnType("varchar(20)");

            // M : 1 Relationship with Author
            builder.HasOne(b => b.Author)
                   .WithMany(a => a.Books)
                   .HasForeignKey(b => b.AuthorId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
