using System;

namespace LibrarySystem.Models
{
    public class Loan
    {
        // Composite Primary Key (BookId + BorrowerId) & Foreign Keys
        public int BookId { get; set; }
        public int BorrowerId { get; set; }

        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        // Navigation Properties
        public  Book Book { get; set; } = null!;
        public  Borrower Borrower { get; set; } = null!;
    }
}
