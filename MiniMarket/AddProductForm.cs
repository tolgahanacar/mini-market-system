using System;
using System.Drawing;
using System.Windows.Forms;
using MiniMarket.Models;
using MiniMarket.Services;

namespace MiniMarket;

public class AddProductForm : Form
{
        private readonly ProductService _productService;

        private Label _lblCategory = null!;
        private Label _lblName = null!;
        private Label _lblPrice = null!;
        private ComboBox _cbCategory = null!;
        private TextBox _txtName = null!;
        private NumericUpDown _nudPrice = null!;
        private Button _btnAdd = null!;
        private Button _btnCancel = null!;

        public Product? CreatedProduct { get; private set; }

        public AddProductForm(ProductService productService)
        {
            _productService = productService;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Yeni Ürün Ekle";
            this.Size = new Size(320, 240);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            _lblName = new Label { Text = "Ürün Adı:", Location = new Point(20, 20), AutoSize = true };
            _txtName = new TextBox { Location = new Point(100, 17), Size = new Size(180, 22) };

            _lblCategory = new Label { Text = "Kategori:", Location = new Point(20, 60), AutoSize = true };
            _cbCategory = new ComboBox { Location = new Point(100, 57), Size = new Size(180, 22), DropDownStyle = ComboBoxStyle.DropDown };
            _cbCategory.Items.AddRange(_productService.GetCategories().ToArray());
            _cbCategory.Text = "Genel";

            _lblPrice = new Label { Text = "Fiyat (₺):", Location = new Point(20, 100), AutoSize = true };
            _nudPrice = new NumericUpDown
            {
                Location = new Point(100, 97),
                Size = new Size(180, 22),
                DecimalPlaces = 2,
                Minimum = 0.01m,
                Maximum = 10000m,
                Value = 10.00m
            };

            _btnAdd = new Button { Text = "Ekle", Location = new Point(100, 145), Size = new Size(85, 32) };
            _btnAdd.Click += BtnAdd_Click;

            _btnCancel = new Button { Text = "İptal", Location = new Point(195, 145), Size = new Size(85, 32) };
            _btnCancel.Click += (s, e) => this.Close();

            this.Controls.Add(_lblName);
            this.Controls.Add(_txtName);
            this.Controls.Add(_lblCategory);
            this.Controls.Add(_cbCategory);
            this.Controls.Add(_lblPrice);
            this.Controls.Add(_nudPrice);
            this.Controls.Add(_btnAdd);
            this.Controls.Add(_btnCancel);
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            string name = _txtName.Text.Trim();
            string category = _cbCategory.Text.Trim();
            decimal price = _nudPrice.Value;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Lütfen ürün adını giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CreatedProduct = _productService.AddProduct(name, price, category);
            MessageBox.Show($"'{name}' ürünü başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
}
