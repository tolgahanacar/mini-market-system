using System;
using System.Collections.Generic;

namespace MiniMarket.Models;

public record SaleTransaction
{
    public string TransactionId { get; init; } = Guid.NewGuid().ToString("N")[..8].ToUpper();
    public DateTime Date { get; init; } = DateTime.Now;
    public List<CartItemSnapshot> Items { get; init; } = [];
    public decimal TotalAmount { get; init; }
    public decimal PreviousBalance { get; init; }
    public decimal RemainingBalance { get; init; }
    public string PaymentMethod { get; init; } = "Cüzdan Bakiyesi";
    public string Cashier { get; init; } = "Kasa #01 (Hızlı Kasa)";
    public string ReceiptText { get; init; } = string.Empty;

    /// <summary>Vergi oranı (varsayılan %10 KDV). Örn: 0.10 = %10</summary>
    public decimal TaxRate { get; init; } = 0.10m;

    public decimal SubTotal => Math.Round(TotalAmount / (1 + TaxRate), 2);
    public decimal TaxAmount => TotalAmount - SubTotal;
}

public record CartItemSnapshot
{
    public string ProductName { get; init; } = string.Empty;
    public int Quantity { get; init; }
    public decimal UnitPrice { get; init; }
    public decimal TotalPrice { get; init; }
}
