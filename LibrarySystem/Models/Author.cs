using System;
using System.Collections.Generic;

namespace LibrarySystem.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }

        // Navigation Property: One Author has Many Books (1 : M)
        public  ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
