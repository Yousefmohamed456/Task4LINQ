namespace EcommerceSystem.Models
{
    public class OrderDetail
    {
        // Composite Primary Key (OrderId + ProductId) & Foreign Keys
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        // Navigation Properties
        public  Order Order { get; set; } = null!;
        public  Product Product { get; set; } = null!;
    }
}
