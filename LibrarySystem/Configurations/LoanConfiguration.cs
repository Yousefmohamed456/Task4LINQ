using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibrarySystem.Configurations
{
    public class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.ToTable("Loans");

            // Composite Primary Key (BookId + BorrowerId)
            builder.HasKey(l => new { l.BookId, l.BorrowerId });

            builder.Property(l => l.LoanDate)
                   .IsRequired()
                   .HasColumnType("date");

            builder.Property(l => l.ReturnDate)
                   .IsRequired(false)
                   .HasColumnType("date");

            // Many-to-Many Relationship via Join Entity Loan
            builder.HasOne(l => l.Book)
                   .WithMany(b => b.Loans)
                   .HasForeignKey(l => l.BookId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(l => l.Borrower)
                   .WithMany(b => b.Loans)
                   .HasForeignKey(l => l.BorrowerId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
