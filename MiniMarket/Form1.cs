using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiniMarket.Models;

namespace MiniMarket
{
    public partial class Form1 : Form
    {
        private List<Product> _products;
        private List<CartItem> _cartItems;
        private decimal _balance = 0m;

        public Form1()
        {
            InitializeComponent();
            _products = new List<Product>();
            _cartItems = new List<CartItem>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Setup icons dynamically to fit buttons perfectly
            btnRemove.Image = new System.Drawing.Bitmap(Properties.Resources.delete_icon, new System.Drawing.Size(24, 24));
            btnClear.Image = new System.Drawing.Bitmap(Properties.Resources.delete_icon, new System.Drawing.Size(24, 24));
            btnAddBalance.Image = new System.Drawing.Bitmap(Properties.Resources.credit, new System.Drawing.Size(24, 24));

            // Seed products
            _products.Add(new Product { Id = 1, Name = "Hamburger", Price = 22m });
            _products.Add(new Product { Id = 2, Name = "Patates Kızartması", Price = 13m });
            _products.Add(new Product { Id = 3, Name = "Coca Cola", Price = 6m });
            _products.Add(new Product { Id = 4, Name = "Su", Price = 3m });
            _products.Add(new Product { Id = 5, Name = "Tatlı", Price = 9m });

            RefreshProductGrid();
            RefreshCartGrid();
            UpdateBalanceDisplay();
        }

        private void RefreshProductGrid()
        {
            dgvProducts.DataSource = null;
            dgvProducts.DataSource = _products;
            dgvProducts.Columns["Id"].Visible = false;
            dgvProducts.Columns["Name"].HeaderText = "Ürün Adı";
            dgvProducts.Columns["Name"].Width = 150;
            dgvProducts.Columns["Price"].HeaderText = "Fiyat (₺)";
            dgvProducts.Columns["Price"].DefaultCellStyle.Format = "N2";
        }

        private void RefreshCartGrid()
        {
            dgvCart.DataSource = null;
            dgvCart.DataSource = _cartItems;

            if (dgvCart.Columns["Product"] != null) dgvCart.Columns["Product"].Visible = false;

            if (dgvCart.Columns["ProductName"] != null)
            {
                dgvCart.Columns["ProductName"].HeaderText = "Ürün Adı";
                dgvCart.Columns["ProductName"].Width = 120;
            }
            if (dgvCart.Columns["Quantity"] != null)
            {
                dgvCart.Columns["Quantity"].HeaderText = "Adet";
                dgvCart.Columns["Quantity"].Width = 60;
            }
            if (dgvCart.Columns["UnitPrice"] != null)
            {
                dgvCart.Columns["UnitPrice"].HeaderText = "Birim Fiyat";
                dgvCart.Columns["UnitPrice"].DefaultCellStyle.Format = "N2";
                dgvCart.Columns["UnitPrice"].Width = 80;
            }
            if (dgvCart.Columns["TotalPrice"] != null)
            {
                dgvCart.Columns["TotalPrice"].HeaderText = "Toplam";
                dgvCart.Columns["TotalPrice"].DefaultCellStyle.Format = "N2";
                dgvCart.Columns["TotalPrice"].Width = 80;
            }

            UpdateCartTotal();
        }

        private void UpdateCartTotal()
        {
            decimal total = _cartItems.Sum(c => c.TotalPrice);
            txtTotal.Text = total.ToString("N2");
        }

        private void UpdateBalanceDisplay()
        {
            txtBalance.Text = _balance.ToString("N2");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen eklenecek ürünü seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedProduct = (Product)dgvProducts.SelectedRows[0].DataBoundItem;
            int quantity = (int)nudQuantity.Value;

            var existingItem = _cartItems.FirstOrDefault(c => c.Product.Id == selectedProduct.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                _cartItems.Add(new CartItem { Product = selectedProduct, Quantity = quantity });
            }

            RefreshCartGrid();
            nudQuantity.Value = 1; // Reset quantity
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen sepetten silinecek ürünü seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedCartItem = (CartItem)dgvCart.SelectedRows[0].DataBoundItem;
            _cartItems.Remove(selectedCartItem);
            RefreshCartGrid();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _cartItems.Clear();
            RefreshCartGrid();
        }

        private void btnAddBalance_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtAddBalance.Text, out decimal amount) && amount > 0)
            {
                _balance += amount;
                UpdateBalanceDisplay();
                txtAddBalance.Clear();
                MessageBox.Show($"{amount:N2} ₺ başarıyla yüklendi.", "Bakiye Yüklendi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Geçerli bir miktar giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (_cartItems.Count == 0)
            {
                MessageBox.Show("Sepetiniz boş. Satın alınacak ürün yok.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal total = _cartItems.Sum(c => c.TotalPrice);
            if (_balance >= total)
            {
                _balance -= total;
                
                // Prepare receipt
                StringBuilder receipt = new StringBuilder();
                receipt.AppendLine("=== ALIŞVERİŞ FİŞİ ===");
                receipt.AppendLine($"Tarih: {DateTime.Now}");
                receipt.AppendLine("-----------------------------");
                foreach (var item in _cartItems)
                {
                    receipt.AppendLine($"{item.ProductName,-15} x{item.Quantity,-3} {item.TotalPrice,7:N2} ₺");
                }
                receipt.AppendLine("-----------------------------");
                receipt.AppendLine($"TOPLAM TUTAR:      {total,7:N2} ₺");
                receipt.AppendLine($"KALAN BAKİYE:      {_balance,7:N2} ₺");
                receipt.AppendLine("=============================");
                receipt.AppendLine("Bizi tercih ettiğiniz için teşekkürler!");

                // Show receipt and clear
                MessageBox.Show(receipt.ToString(), "Satın Alma Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                _cartItems.Clear();
                RefreshCartGrid();
                UpdateBalanceDisplay();
            }
            else
            {
                MessageBox.Show($"Bakiye yetersiz! Eksik tutar: {(total - _balance):N2} ₺", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
