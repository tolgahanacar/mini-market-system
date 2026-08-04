using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MiniMarket.Models;

namespace MiniMarket
{
    public class ReceiptForm : Form
    {
        private readonly SaleTransaction _transaction;
        private TextBox _txtReceipt = null!;
        private Button _btnCopy = null!;
        private Button _btnSave = null!;
        private Button _btnClose = null!;

        public ReceiptForm(SaleTransaction transaction)
        {
            _transaction = transaction;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = $"Alışveriş Fişi (#{_transaction.TransactionId})";
            this.Size = new Size(420, 500);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            _txtReceipt = new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                Font = new Font("Consolas", 9.5F, FontStyle.Regular),
                Text = _transaction.ReceiptText,
                Location = new Point(12, 12),
                Size = new Size(380, 380),
                BackColor = Color.White
            };

            _btnCopy = new Button
            {
                Text = "Kopyala",
                Location = new Point(12, 405),
                Size = new Size(100, 35)
            };
            _btnCopy.Click += (s, e) =>
            {
                Clipboard.SetText(_txtReceipt.Text);
                MessageBox.Show("Fiş metni panoya kopyalandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            _btnSave = new Button
            {
                Text = "Dosyaya Kaydet",
                Location = new Point(120, 405),
                Size = new Size(120, 35)
            };
            _btnSave.Click += (s, e) =>
            {
                using var sfd = new SaveFileDialog
                {
                    Filter = "Metin Dosyası (*.txt)|*.txt",
                    FileName = $"Fis_{_transaction.TransactionId}_{_transaction.Date:yyyyMMdd_HHmmss}.txt"
                };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, _txtReceipt.Text);
                    MessageBox.Show("Fiş başarıyla kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            _btnClose = new Button
            {
                Text = "Kapat",
                Location = new Point(292, 405),
                Size = new Size(100, 35)
            };
            _btnClose.Click += (s, e) => this.Close();

            this.Controls.Add(_txtReceipt);
            this.Controls.Add(_btnCopy);
            this.Controls.Add(_btnSave);
            this.Controls.Add(_btnClose);
        }
    }
}
