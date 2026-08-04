namespace MiniMarket
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.groupBoxProducts = new System.Windows.Forms.GroupBox();
            this.labelSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnAddNewProduct = new System.Windows.Forms.Button();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.labelQuantity = new System.Windows.Forms.Label();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEditProduct = new System.Windows.Forms.Button();
            this.groupBoxCart = new System.Windows.Forms.GroupBox();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.labelTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.btnHistory = new System.Windows.Forms.Button();
            this.groupBoxWallet = new System.Windows.Forms.GroupBox();
            this.labelBalance = new System.Windows.Forms.Label();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.labelAddBalance = new System.Windows.Forms.Label();
            this.txtAddBalance = new System.Windows.Forms.TextBox();
            this.btnAddBalance = new System.Windows.Forms.Button();
            this.groupBoxProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.groupBoxCart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.groupBoxWallet.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxProducts
            // 
            this.groupBoxProducts.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxProducts.Controls.Add(this.btnEditProduct);
            this.groupBoxProducts.Controls.Add(this.labelSearch);
            this.groupBoxProducts.Controls.Add(this.txtSearch);
            this.groupBoxProducts.Controls.Add(this.btnAddNewProduct);
            this.groupBoxProducts.Controls.Add(this.dgvProducts);
            this.groupBoxProducts.Controls.Add(this.labelQuantity);
            this.groupBoxProducts.Controls.Add(this.nudQuantity);
            this.groupBoxProducts.Controls.Add(this.btnAdd);
            this.groupBoxProducts.Location = new System.Drawing.Point(12, 12);
            this.groupBoxProducts.Name = "groupBoxProducts";
            this.groupBoxProducts.Size = new System.Drawing.Size(350, 275);
            this.groupBoxProducts.TabIndex = 0;
            this.groupBoxProducts.TabStop = false;
            this.groupBoxProducts.Text = "Ürün Kataloğu";
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Location = new System.Drawing.Point(6, 23);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(26, 13);
            this.labelSearch.TabIndex = 0;
            this.labelSearch.Text = "Ara:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(38, 20);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(185, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnAddNewProduct
            // 
            this.btnAddNewProduct.Location = new System.Drawing.Point(230, 18);
            this.btnAddNewProduct.Name = "btnAddNewProduct";
            this.btnAddNewProduct.Size = new System.Drawing.Size(114, 23);
            this.btnAddNewProduct.TabIndex = 2;
            this.btnAddNewProduct.Text = "+ Yeni Ürün";
            this.btnAddNewProduct.UseVisualStyleBackColor = true;
            this.btnAddNewProduct.Click += new System.EventHandler(this.btnAddNewProduct_Click);
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(6, 48);
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(338, 180);
            this.dgvProducts.TabIndex = 3;
            // 
            // labelQuantity
            // 
            this.labelQuantity.AutoSize = true;
            this.labelQuantity.Location = new System.Drawing.Point(6, 241);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Size = new System.Drawing.Size(32, 13);
            this.labelQuantity.TabIndex = 4;
            this.labelQuantity.Text = "Adet:";
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(44, 238);
            this.nudQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(55, 20);
            this.nudQuantity.TabIndex = 5;
            this.nudQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(105, 236);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(115, 25);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Sepete Ekle";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEditProduct
            // 
            this.btnEditProduct.Location = new System.Drawing.Point(226, 236);
            this.btnEditProduct.Name = "btnEditProduct";
            this.btnEditProduct.Size = new System.Drawing.Size(118, 25);
            this.btnEditProduct.TabIndex = 7;
            this.btnEditProduct.Text = "✏️ Düzenle";
            this.btnEditProduct.UseVisualStyleBackColor = true;
            this.btnEditProduct.Click += new System.EventHandler(this.btnEditProduct_Click);
            // 
            // groupBoxCart
            // 
            this.groupBoxCart.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxCart.Controls.Add(this.btnHistory);
            this.groupBoxCart.Controls.Add(this.labelTotal);
            this.groupBoxCart.Controls.Add(this.txtTotal);
            this.groupBoxCart.Controls.Add(this.btnCheckout);
            this.groupBoxCart.Controls.Add(this.btnClear);
            this.groupBoxCart.Controls.Add(this.btnRemove);
            this.groupBoxCart.Controls.Add(this.dgvCart);
            this.groupBoxCart.Location = new System.Drawing.Point(380, 12);
            this.groupBoxCart.Name = "groupBoxCart";
            this.groupBoxCart.Size = new System.Drawing.Size(400, 310);
            this.groupBoxCart.TabIndex = 1;
            this.groupBoxCart.TabStop = false;
            this.groupBoxCart.Text = "Sepet";
            // 
            // dgvCart
            // 
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Location = new System.Drawing.Point(6, 19);
            this.dgvCart.MultiSelect = false;
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.ReadOnly = true;
            this.dgvCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCart.Size = new System.Drawing.Size(388, 190);
            this.dgvCart.TabIndex = 0;
            // 
            // btnRemove
            // 
            this.btnRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemove.Location = new System.Drawing.Point(6, 216);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(85, 35);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "Sil";
            this.btnRemove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnClear
            // 
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(97, 216);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(85, 35);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Temizle";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(220, 221);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(45, 13);
            this.labelTotal.TabIndex = 3;
            this.labelTotal.Text = "Toplam:";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(271, 218);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(123, 20);
            this.txtTotal.TabIndex = 4;
            this.txtTotal.Text = "0.00";
            // 
            // btnCheckout
            // 
            this.btnCheckout.Location = new System.Drawing.Point(271, 254);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(123, 40);
            this.btnCheckout.TabIndex = 5;
            this.btnCheckout.Text = "Satın Al";
            this.btnCheckout.UseVisualStyleBackColor = true;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.Location = new System.Drawing.Point(6, 259);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(176, 35);
            this.btnHistory.TabIndex = 6;
            this.btnHistory.Text = "📜 İşlem Geçmişi";
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // groupBoxWallet
            // 
            this.groupBoxWallet.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxWallet.Controls.Add(this.btnAddBalance);
            this.groupBoxWallet.Controls.Add(this.txtAddBalance);
            this.groupBoxWallet.Controls.Add(this.labelAddBalance);
            this.groupBoxWallet.Controls.Add(this.txtBalance);
            this.groupBoxWallet.Controls.Add(this.labelBalance);
            this.groupBoxWallet.Location = new System.Drawing.Point(12, 295);
            this.groupBoxWallet.Name = "groupBoxWallet";
            this.groupBoxWallet.Size = new System.Drawing.Size(350, 115);
            this.groupBoxWallet.TabIndex = 2;
            this.groupBoxWallet.TabStop = false;
            this.groupBoxWallet.Text = "Cüzdan";
            // 
            // labelBalance
            // 
            this.labelBalance.AutoSize = true;
            this.labelBalance.Location = new System.Drawing.Point(6, 26);
            this.labelBalance.Name = "labelBalance";
            this.labelBalance.Size = new System.Drawing.Size(42, 13);
            this.labelBalance.TabIndex = 0;
            this.labelBalance.Text = "Bakiye:";
            // 
            // txtBalance
            // 
            this.txtBalance.Location = new System.Drawing.Point(54, 23);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.ReadOnly = true;
            this.txtBalance.Size = new System.Drawing.Size(100, 20);
            this.txtBalance.TabIndex = 1;
            this.txtBalance.Text = "0.00";
            // 
            // labelAddBalance
            // 
            this.labelAddBalance.AutoSize = true;
            this.labelAddBalance.Location = new System.Drawing.Point(170, 26);
            this.labelAddBalance.Name = "labelAddBalance";
            this.labelAddBalance.Size = new System.Drawing.Size(40, 13);
            this.labelAddBalance.TabIndex = 2;
            this.labelAddBalance.Text = "Miktar:";
            // 
            // txtAddBalance
            // 
            this.txtAddBalance.Location = new System.Drawing.Point(216, 23);
            this.txtAddBalance.Name = "txtAddBalance";
            this.txtAddBalance.Size = new System.Drawing.Size(60, 20);
            this.txtAddBalance.TabIndex = 3;
            // 
            // btnAddBalance
            // 
            this.btnAddBalance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddBalance.Location = new System.Drawing.Point(216, 49);
            this.btnAddBalance.Name = "btnAddBalance";
            this.btnAddBalance.Size = new System.Drawing.Size(85, 35);
            this.btnAddBalance.TabIndex = 4;
            this.btnAddBalance.Text = "Yükle";
            this.btnAddBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddBalance.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddBalance.UseVisualStyleBackColor = true;
            this.btnAddBalance.Click += new System.EventHandler(this.btnAddBalance_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MiniMarket.Properties.Resources.background_main;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(790, 420);
            this.Controls.Add(this.groupBoxWallet);
            this.Controls.Add(this.groupBoxCart);
            this.Controls.Add(this.groupBoxProducts);
            this.Name = "Form1";
            this.Text = "Mini Market Sistemi v2.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxProducts.ResumeLayout(false);
            this.groupBoxProducts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.groupBoxCart.ResumeLayout(false);
            this.groupBoxCart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.groupBoxWallet.ResumeLayout(false);
            this.groupBoxWallet.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox groupBoxProducts;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnAddNewProduct;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEditProduct;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.GroupBox groupBoxCart;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.GroupBox groupBoxWallet;
        private System.Windows.Forms.Label labelBalance;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.Label labelAddBalance;
        private System.Windows.Forms.TextBox txtAddBalance;
        private System.Windows.Forms.Button btnAddBalance;
    }
}
