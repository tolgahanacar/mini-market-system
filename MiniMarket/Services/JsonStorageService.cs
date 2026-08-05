using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using MiniMarket.Models;

namespace MiniMarket.Services;

public class JsonStorageService : IStorageService
{
        private readonly string _dataDir;
        private readonly string _productsFile;
        private readonly string _balanceFile;
        private readonly string _transactionsFile;

        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };

        public JsonStorageService(string? customDataDir = null)
        {
            _dataDir = customDataDir ?? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data");
            Directory.CreateDirectory(_dataDir);

            _productsFile = Path.Combine(_dataDir, "products.json");
            _balanceFile = Path.Combine(_dataDir, "balance.json");
            _transactionsFile = Path.Combine(_dataDir, "transactions.json");
        }

        public List<Product> LoadProducts()
        {
            try
            {
                if (File.Exists(_productsFile))
                {
                    string json = File.ReadAllText(_productsFile);
                    var products = JsonSerializer.Deserialize<List<Product>>(json, _jsonOptions);
                    if (products != null && products.Count > 0) return products;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[JsonStorageService] Ürünler yüklenirken hata: {ex.Message}");
            }

            // Default seed products if file doesn't exist or is invalid
            var seedProducts = GetDefaultProducts();
            SaveProducts(seedProducts);
            return seedProducts;
        }

        public void SaveProducts(List<Product> products)
        {
            try
            {
                string json = JsonSerializer.Serialize(products, _jsonOptions);
                File.WriteAllText(_productsFile, json);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[JsonStorageService] Ürünler kaydedilirken hata: {ex.Message}");
            }
        }

        public decimal LoadBalance()
        {
            try
            {
                if (File.Exists(_balanceFile))
                {
                    string json = File.ReadAllText(_balanceFile);
                    return JsonSerializer.Deserialize<decimal>(json, _jsonOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[JsonStorageService] Bakiye yüklenirken hata: {ex.Message}");
            }

            return 0m;
        }

        public void SaveBalance(decimal balance)
        {
            try
            {
                string json = JsonSerializer.Serialize(balance, _jsonOptions);
                File.WriteAllText(_balanceFile, json);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[JsonStorageService] Bakiye kaydedilirken hata: {ex.Message}");
            }
        }

        public List<SaleTransaction> LoadTransactions()
        {
            try
            {
                if (File.Exists(_transactionsFile))
                {
                    string json = File.ReadAllText(_transactionsFile);
                    var transactions = JsonSerializer.Deserialize<List<SaleTransaction>>(json, _jsonOptions);
                    if (transactions != null) return transactions;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[JsonStorageService] İşlem geçmişi yüklenirken hata: {ex.Message}");
            }

            return [];
        }

        public void SaveTransactions(List<SaleTransaction> transactions)
        {
            try
            {
                string json = JsonSerializer.Serialize(transactions, _jsonOptions);
                File.WriteAllText(_transactionsFile, json);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[JsonStorageService] İşlem geçmişi kaydedilirken hata: {ex.Message}");
            }
        }

        public static List<Product> GetDefaultProducts()
        {
            return
            [
                new Product { Id = 1, Name = "Hamburger", Price = 22m, Category = "Yiyecek" },
                new Product { Id = 2, Name = "Patates Kızartması", Price = 13m, Category = "Yiyecek" },
                new Product { Id = 3, Name = "Coca Cola", Price = 6m, Category = "İçecek" },
                new Product { Id = 4, Name = "Su", Price = 3m, Category = "İçecek" },
                new Product { Id = 5, Name = "Tatlı", Price = 9m, Category = "Tatlı" }
            ];
        }
    }
