using System;
using System.Collections.Generic;

namespace EcommerceSystem.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        // Foreign Key
        public int CustomerId { get; set; }

        // Navigation Property: Many Orders belong to One Customer (M : 1)
        public  Customer Customer { get; set; } = null!;

        // Navigation Property: Many-to-Many with Product through OrderDetail (M : M)
        public  ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
