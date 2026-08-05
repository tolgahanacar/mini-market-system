using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MiniMarket.Models;
using MiniMarket.Services;

namespace MiniMarket;

public partial class MainForm : Form
{

        private readonly ProductService _productService;
        private readonly WalletService _walletService;
        private readonly CartService _cartService;
        private readonly ReceiptService _receiptService;

        public MainForm(ProductService productService, WalletService walletService, CartService cartService, ReceiptService receiptService)
        {
            InitializeComponent();

            _productService = productService;
            _walletService = walletService;
            _cartService = cartService;
            _receiptService = receiptService;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Setup icons dynamically to fit buttons perfectly
            try
            {
                btnRemove.Image = new Bitmap(Properties.Resources.delete_icon, new Size(20, 20));
                btnClear.Image = new Bitmap(Properties.Resources.delete_icon, new Size(20, 20));
                btnAddBalance.Image = new Bitmap(Properties.Resources.credit, new Size(20, 20));
            }
            catch { }

            RefreshProductGrid();
            RefreshCartGrid();
            UpdateBalanceDisplay();
        }

        private void RefreshProductGrid(string searchKeyword = "")
        {
            var products = _productService.SearchProducts(searchKeyword);
            dgvProducts.DataSource = null;
            dgvProducts.DataSource = products;

            if (dgvProducts.Columns["Id"] != null) dgvProducts.Columns["Id"].Visible = false;
            if (dgvProducts.Columns["Category"] != null)
            {
                dgvProducts.Columns["Category"].HeaderText = "Kategori";
                dgvProducts.Columns["Category"].Width = 90;
            }
            if (dgvProducts.Columns["Name"] != null)
            {
                dgvProducts.Columns["Name"].HeaderText = "Ürün Adı";
                dgvProducts.Columns["Name"].Width = 120;
            }
            if (dgvProducts.Columns["Price"] != null)
            {
                dgvProducts.Columns["Price"].HeaderText = "Fiyat (₺)";
                dgvProducts.Columns["Price"].DefaultCellStyle.Format = "N2";
                dgvProducts.Columns["Price"].Width = 80;
            }
        }

        private void RefreshCartGrid()
        {
            dgvCart.DataSource = null;
            dgvCart.DataSource = _cartService.Items.ToList();

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
            txtTotal.Text = _cartService.TotalAmount.ToString("N2");
        }

        private void UpdateBalanceDisplay()
        {
            txtBalance.Text = _walletService.Balance.ToString("N2");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshProductGrid(txtSearch.Text);
        }

        private void btnAddNewProduct_Click(object sender, EventArgs e)
        {
            using var addForm = new AddProductForm(_productService);
            if (addForm.ShowDialog(this) == DialogResult.OK)
            {
                RefreshProductGrid(txtSearch.Text);
            }
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen düzenlenecek ürünü seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedProduct = (Product)dgvProducts.SelectedRows[0].DataBoundItem;
            using var editForm = new EditProductForm(_productService, selectedProduct);
            if (editForm.ShowDialog(this) == DialogResult.OK)
            {
                RefreshProductGrid(txtSearch.Text);
                RefreshCartGrid();
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silinecek ürünü seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedProduct = (Product)dgvProducts.SelectedRows[0].DataBoundItem;
            var result = MessageBox.Show(
                $"'{selectedProduct.Name}' ürünü kalıcı olarak silinecek.\nDevam etmek istiyor musunuz?",
                "Ürün Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _productService.DeleteProduct(selectedProduct.Id);
                RefreshProductGrid(txtSearch.Text);
                MessageBox.Show("Ürün başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

            _cartService.AddItem(selectedProduct, quantity);

            RefreshCartGrid();
            nudQuantity.Value = 1;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen sepetten silinecek ürünü seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedCartItem = (CartItem)dgvCart.SelectedRows[0].DataBoundItem;
            _cartService.RemoveItem(selectedCartItem);
            RefreshCartGrid();
        }

        private void btnDecreaseQuantity_Click(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen miktarı azaltılacak ürünü seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedCartItem = (CartItem)dgvCart.SelectedRows[0].DataBoundItem;
            _cartService.DecreaseQuantity(selectedCartItem);
            RefreshCartGrid();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _cartService.Clear();
            RefreshCartGrid();
        }

        private void btnAddBalance_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtAddBalance.Text, out decimal amount) && amount > 0)
            {
                _walletService.Deposit(amount);
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
            if (_cartService.Items.Count == 0)
            {
                MessageBox.Show("Sepetiniz boş. Satın alınacak ürün yok.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal total = _cartService.TotalAmount;
            decimal previousBalance = _walletService.Balance;

            if (_walletService.CanAfford(total))
            {
                _walletService.Withdraw(total);

                var transaction = _receiptService.ProcessCheckout(_cartService.Items, total, previousBalance, _walletService.Balance);

                // Show formatted receipt form dialog
                using (var receiptForm = new ReceiptForm(transaction))
                {
                    receiptForm.ShowDialog(this);
                }

                _cartService.Clear();
                RefreshCartGrid();
                UpdateBalanceDisplay();
            }
            else
            {
                decimal missing = total - _walletService.Balance;
                MessageBox.Show($"Bakiye yetersiz! Eksik tutar: {missing:N2} ₺", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            using var historyForm = new HistoryForm(_receiptService);
            historyForm.ShowDialog(this);
        }
}
