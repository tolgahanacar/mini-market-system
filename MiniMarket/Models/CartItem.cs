namespace MiniMarket.Models
{
    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public string ProductName => Product?.Name;
        public decimal UnitPrice => Product?.Price ?? 0m;
        public decimal TotalPrice => Quantity * UnitPrice;
    }
}
