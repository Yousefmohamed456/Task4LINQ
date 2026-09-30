using System.Collections.Generic;

namespace EcommerceSystem.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Navigation Property: One Category has Many Products (1 : M)
        public  ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
