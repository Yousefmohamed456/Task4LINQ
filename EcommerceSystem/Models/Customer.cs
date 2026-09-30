using System.Collections.Generic;

namespace EcommerceSystem.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // Navigation Property: One Customer has Many Orders (1 : M)
        public  ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
