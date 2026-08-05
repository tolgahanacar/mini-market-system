using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MiniMarket.Models;
using MiniMarket.Services;

namespace MiniMarket;

public class HistoryForm : Form
{
    private readonly ReceiptService _receiptService;
    private DataGridView _dgvHistory = null!;
    private Button _btnViewReceipt = null!;
    private Button _btnClose = null!;
    private List<SaleTransaction> _transactions;

    public HistoryForm(ReceiptService receiptService)
        {
            _receiptService = receiptService;
            _transactions = _receiptService.GetTransactionHistory();
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Geçmiş Alışverişler & Detaylı İşlem Kayıtları";
            this.Size = new Size(720, 440);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            _dgvHistory = new DataGridView
            {
                Location = new Point(12, 12),
                Size = new Size(680, 330),
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            _btnViewReceipt = new Button
            {
                Text = "Fişi Görüntüle",
                Location = new Point(12, 350),
                Size = new Size(130, 35)
            };
            _btnViewReceipt.Click += BtnViewReceipt_Click;

            _btnClose = new Button
            {
                Text = "Kapat",
                Location = new Point(592, 350),
                Size = new Size(100, 35)
            };
            _btnClose.Click += (s, e) => this.Close();

            this.Controls.Add(_dgvHistory);
            this.Controls.Add(_btnViewReceipt);
            this.Controls.Add(_btnClose);

            LoadHistoryData();
        }

        private void LoadHistoryData()
        {
            var displayList = _transactions.Select(t => new
            {
                TransactionId = t.TransactionId,
                Tarih = t.Date.ToString("dd.MM.yyyy HH:mm"),
                UrunSayisi = t.Items.Sum(i => i.Quantity),
                ToplamTutar = $"{t.TotalAmount:N2} ₺",
                OncekiBakiye = $"{t.PreviousBalance:N2} ₺",
                KalanBakiye = $"{t.RemainingBalance:N2} ₺",
                OdemeYontemi = t.PaymentMethod
            }).ToList();

            _dgvHistory.DataSource = displayList;

            if (_dgvHistory.Columns["TransactionId"] != null)
                _dgvHistory.Columns["TransactionId"].HeaderText = "İşlem No";
            if (_dgvHistory.Columns["Tarih"] != null)
                _dgvHistory.Columns["Tarih"].HeaderText = "Tarih";
            if (_dgvHistory.Columns["UrunSayisi"] != null)
                _dgvHistory.Columns["UrunSayisi"].HeaderText = "Adet";
            if (_dgvHistory.Columns["ToplamTutar"] != null)
                _dgvHistory.Columns["ToplamTutar"].HeaderText = "Ödenen Tutar";
            if (_dgvHistory.Columns["OncekiBakiye"] != null)
                _dgvHistory.Columns["OncekiBakiye"].HeaderText = "Önceki Bakiye";
            if (_dgvHistory.Columns["KalanBakiye"] != null)
                _dgvHistory.Columns["KalanBakiye"].HeaderText = "Kalan Bakiye";
            if (_dgvHistory.Columns["OdemeYontemi"] != null)
                _dgvHistory.Columns["OdemeYontemi"].HeaderText = "Ödeme Yöntemi";
        }

        private void BtnViewReceipt_Click(object? sender, EventArgs e)
        {
            if (_dgvHistory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen fişini görüntülemek istediğiniz işlemi seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int index = _dgvHistory.SelectedRows[0].Index;
            if (index >= 0 && index < _transactions.Count)
            {
                var transaction = _transactions[index];
                using var receiptForm = new ReceiptForm(transaction);
                receiptForm.ShowDialog(this);
            }
        }
}
