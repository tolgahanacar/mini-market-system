using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniMarket.Models;

namespace MiniMarket.Services;

public class ReceiptService(IStorageService storageService)
{
    private readonly IStorageService _storageService = storageService;

        public SaleTransaction ProcessCheckout(IReadOnlyList<CartItem> cartItems, decimal paidTotal, decimal previousBalance, decimal remainingBalance)
        {
            var transaction = new SaleTransaction
            {
                Date = DateTime.Now,
                TotalAmount = paidTotal,
                PreviousBalance = previousBalance,
                RemainingBalance = remainingBalance,
                Items = cartItems.Select(i => new CartItemSnapshot
                {
                    ProductName = i.ProductName,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice,
                    TotalPrice = i.TotalPrice
                }).ToList()
            };

            transaction = transaction with { ReceiptText = GenerateReceiptText(transaction) };

            // Save transaction history
            var history = _storageService.LoadTransactions();
            history.Add(transaction);
            _storageService.SaveTransactions(history);

            return transaction;
        }

        public string GenerateReceiptText(SaleTransaction transaction)
        {
            var sb = new StringBuilder();
            sb.AppendLine("=========================================");
            sb.AppendLine("           MİNİ MARKET SİSTEMİ           ");
            sb.AppendLine("            ALIŞVERİŞ FİŞİ               ");
            sb.AppendLine("=========================================");
            sb.AppendLine($"Fiş No   : FIS-{transaction.TransactionId}");
            sb.AppendLine($"Tarih    : {transaction.Date:dd.MM.yyyy HH:mm:ss}");
            sb.AppendLine($"Kasa     : {transaction.Cashier}");
            sb.AppendLine($"Ödeme    : {transaction.PaymentMethod}");
            sb.AppendLine("-----------------------------------------");
            sb.AppendLine(string.Format("{0,-18} {1,5} {2,6} {3,8}", "Ürün Adı", "Adet", "B.Fiyat", "Toplam"));
            sb.AppendLine("-----------------------------------------");

            foreach (var item in transaction.Items)
            {
                string name = item.ProductName.Length > 18 ? item.ProductName.Substring(0, 15) + "..." : item.ProductName;
                sb.AppendLine(string.Format("{0,-18} {1,5} {2,6:N2} {3,8:N2} ₺", name, item.Quantity, item.UnitPrice, item.TotalPrice));
            }

            sb.AppendLine("-----------------------------------------");
            sb.AppendLine($"Ara Toplam (%10 KDV H.): {transaction.SubTotal,12:N2} ₺");
            sb.AppendLine($"Hesaplanan KDV (%10)   : {transaction.TaxAmount,12:N2} ₺");
            sb.AppendLine("-----------------------------------------");
            sb.AppendLine($"GENEL TOPLAM           : {transaction.TotalAmount,12:N2} ₺");
            sb.AppendLine($"ÖNCESİ BAKİYE          : {transaction.PreviousBalance,12:N2} ₺");
            sb.AppendLine($"ÖDENEN TUTAR           : {transaction.TotalAmount,12:N2} ₺");
            sb.AppendLine($"KALAN BAKİYE           : {transaction.RemainingBalance,12:N2} ₺");
            sb.AppendLine("=========================================");
            sb.AppendLine("       Bizi tercih ettiğiniz için        ");
            sb.AppendLine("            teşekkür ederiz!             ");
            sb.AppendLine("=========================================");

            return sb.ToString();
        }

        public List<SaleTransaction> GetTransactionHistory()
        {
            return _storageService.LoadTransactions();
        }
}
