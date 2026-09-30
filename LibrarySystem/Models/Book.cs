using System.Collections.Generic;

namespace LibrarySystem.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;

        // Foreign Key
        public int AuthorId { get; set; }

        // Navigation Property: Many Books belong to One Author (M : 1)
        public  Author Author { get; set; } = null!;

        // Navigation Property: Many-to-Many with Borrower through Loan (M : M)
        public  ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}
