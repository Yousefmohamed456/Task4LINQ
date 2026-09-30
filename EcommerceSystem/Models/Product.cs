using System.Collections.Generic;

namespace EcommerceSystem.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }

        // Foreign Key
        public int CategoryId { get; set; }

        // Navigation Property: Many Products belong to One Category (M : 1)
        public  Category Category { get; set; } = null!;

        // Navigation Property: Many-to-Many with Order through OrderDetail (M : M)
        public  ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
