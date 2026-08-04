using System;
using System.Drawing;
using System.Windows.Forms;
using MiniMarket.Models;
using MiniMarket.Services;

namespace MiniMarket
{
    public class EditProductForm : Form
    {
        private readonly ProductService _productService;
        private readonly Product _targetProduct;

        private Label _lblCategory = null!;
        private Label _lblName = null!;
        private Label _lblPrice = null!;
        private TextBox _txtCategory = null!;
        private TextBox _txtName = null!;
        private NumericUpDown _nudPrice = null!;
        private Button _btnSave = null!;
        private Button _btnCancel = null!;

        public EditProductForm(ProductService productService, Product targetProduct)
        {
            _productService = productService;
            _targetProduct = targetProduct;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = $"Ürün & Fiyat Düzenle (#{_targetProduct.Id})";
            this.Size = new Size(320, 240);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            _lblName = new Label { Text = "Ürün Adı:", Location = new Point(20, 20), AutoSize = true };
            _txtName = new TextBox { Location = new Point(100, 17), Size = new Size(180, 22), Text = _targetProduct.Name };

            _lblCategory = new Label { Text = "Kategori:", Location = new Point(20, 60), AutoSize = true };
            _txtCategory = new TextBox { Location = new Point(100, 57), Size = new Size(180, 22), Text = _targetProduct.Category };

            _lblPrice = new Label { Text = "Fiyat (₺):", Location = new Point(20, 100), AutoSize = true };
            _nudPrice = new NumericUpDown
            {
                Location = new Point(100, 97),
                Size = new Size(180, 22),
                DecimalPlaces = 2,
                Minimum = 0.01m,
                Maximum = 10000m,
                Value = _targetProduct.Price
            };

            _btnSave = new Button { Text = "Kaydet", Location = new Point(100, 145), Size = new Size(85, 32) };
            _btnSave.Click += BtnSave_Click;

            _btnCancel = new Button { Text = "İptal", Location = new Point(195, 145), Size = new Size(85, 32) };
            _btnCancel.Click += (s, e) => this.Close();

            this.Controls.Add(_lblName);
            this.Controls.Add(_txtName);
            this.Controls.Add(_lblCategory);
            this.Controls.Add(_txtCategory);
            this.Controls.Add(_lblPrice);
            this.Controls.Add(_nudPrice);
            this.Controls.Add(_btnSave);
            this.Controls.Add(_btnCancel);
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            string name = _txtName.Text.Trim();
            string category = _txtCategory.Text.Trim();
            decimal price = _nudPrice.Value;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Lütfen ürün adını giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool success = _productService.UpdateProduct(_targetProduct.Id, name, price, category);
            if (success)
            {
                MessageBox.Show($"Ürün bilgileri başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Güncelleme başarısız oldu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
