using System;
using System.Collections.Generic;

namespace MiniMarket.Models
{
    public class SaleTransaction
    {
        public string TransactionId { get; set; } = Guid.NewGuid().ToString("N")[..8].ToUpper();
        public DateTime Date { get; set; } = DateTime.Now;
        public List<CartItemSnapshot> Items { get; set; } = new List<CartItemSnapshot>();
        public decimal TotalAmount { get; set; }
        public decimal PreviousBalance { get; set; }
        public decimal RemainingBalance { get; set; }
        public string PaymentMethod { get; set; } = "Cüzdan Bakiyesi";
        public string Cashier { get; set; } = "Kasa #01 (Hızlı Kasa)";
        public string ReceiptText { get; set; } = string.Empty;

        public decimal SubTotal => Math.Round(TotalAmount / 1.10m, 2);
        public decimal TaxAmount => TotalAmount - SubTotal;
    }

    public class CartItemSnapshot
    {
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
