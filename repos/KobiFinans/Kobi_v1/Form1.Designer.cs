namespace Kobi_v1
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cariToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cariListeleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cariHareketlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cariOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kasaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kasaListesiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kasaHareketleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bankaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bankalarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bankaHareketleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stoklarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stokTanımlamalarıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTime = new System.Windows.Forms.Label();
            this.stokKategorileriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gelirGiderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.işlemlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.satışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cariToolStripMenuItem,
            this.kasaToolStripMenuItem,
            this.bankaToolStripMenuItem,
            this.stokToolStripMenuItem,
            this.işlemlerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.kasaToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.ShowItemToolTips = true;
            this.menuStrip1.Size = new System.Drawing.Size(1200, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cariToolStripMenuItem
            // 
            this.cariToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cariListeleriToolStripMenuItem,
            this.cariHareketlerToolStripMenuItem,
            this.cariOToolStripMenuItem});
            this.cariToolStripMenuItem.Name = "cariToolStripMenuItem";
            this.cariToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.cariToolStripMenuItem.Text = "Cari";
            // 
            // cariListeleriToolStripMenuItem
            // 
            this.cariListeleriToolStripMenuItem.Name = "cariListeleriToolStripMenuItem";
            this.cariListeleriToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cariListeleriToolStripMenuItem.Text = "Cariler";
            this.cariListeleriToolStripMenuItem.Click += new System.EventHandler(this.cariListeleriToolStripMenuItem_Click);
            // 
            // cariHareketlerToolStripMenuItem
            // 
            this.cariHareketlerToolStripMenuItem.Name = "cariHareketlerToolStripMenuItem";
            this.cariHareketlerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cariHareketlerToolStripMenuItem.Text = "Cari Hareketler";
            this.cariHareketlerToolStripMenuItem.Click += new System.EventHandler(this.cariHareketlerToolStripMenuItem_Click);
            // 
            // cariOToolStripMenuItem
            // 
            this.cariOToolStripMenuItem.Name = "cariOToolStripMenuItem";
            this.cariOToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cariOToolStripMenuItem.Text = "Cari Tanımla";
            this.cariOToolStripMenuItem.Click += new System.EventHandler(this.cariOToolStripMenuItem_Click);
            // 
            // kasaToolStripMenuItem
            // 
            this.kasaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kasaListesiToolStripMenuItem,
            this.kasaHareketleriToolStripMenuItem,
            this.gelirGiderToolStripMenuItem});
            this.kasaToolStripMenuItem.Name = "kasaToolStripMenuItem";
            this.kasaToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.kasaToolStripMenuItem.Text = "Kasa";
            // 
            // kasaListesiToolStripMenuItem
            // 
            this.kasaListesiToolStripMenuItem.Name = "kasaListesiToolStripMenuItem";
            this.kasaListesiToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.kasaListesiToolStripMenuItem.Text = "Kasalar";
            this.kasaListesiToolStripMenuItem.Click += new System.EventHandler(this.kasaListesiToolStripMenuItem_Click);
            // 
            // kasaHareketleriToolStripMenuItem
            // 
            this.kasaHareketleriToolStripMenuItem.Name = "kasaHareketleriToolStripMenuItem";
            this.kasaHareketleriToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.kasaHareketleriToolStripMenuItem.Text = "Kasa Hareketleri";
            this.kasaHareketleriToolStripMenuItem.Click += new System.EventHandler(this.kasaHareketleriToolStripMenuItem_Click);
            // 
            // bankaToolStripMenuItem
            // 
            this.bankaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bankalarToolStripMenuItem,
            this.bankaHareketleriToolStripMenuItem});
            this.bankaToolStripMenuItem.Name = "bankaToolStripMenuItem";
            this.bankaToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.bankaToolStripMenuItem.Text = "Banka";
            // 
            // bankalarToolStripMenuItem
            // 
            this.bankalarToolStripMenuItem.Name = "bankalarToolStripMenuItem";
            this.bankalarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bankalarToolStripMenuItem.Text = "Bankalar";
            this.bankalarToolStripMenuItem.Click += new System.EventHandler(this.bankalarToolStripMenuItem_Click);
            // 
            // bankaHareketleriToolStripMenuItem
            // 
            this.bankaHareketleriToolStripMenuItem.Name = "bankaHareketleriToolStripMenuItem";
            this.bankaHareketleriToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bankaHareketleriToolStripMenuItem.Text = "Banka Hareketleri";
            this.bankaHareketleriToolStripMenuItem.Click += new System.EventHandler(this.bankaHareketleriToolStripMenuItem_Click);
            // 
            // stokToolStripMenuItem
            // 
            this.stokToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stoklarToolStripMenuItem,
            this.stokTanımlamalarıToolStripMenuItem,
            this.stokKategorileriToolStripMenuItem});
            this.stokToolStripMenuItem.Name = "stokToolStripMenuItem";
            this.stokToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.stokToolStripMenuItem.Text = "Stok";
            // 
            // stoklarToolStripMenuItem
            // 
            this.stoklarToolStripMenuItem.Name = "stoklarToolStripMenuItem";
            this.stoklarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stoklarToolStripMenuItem.Text = "Stoklar";
            this.stoklarToolStripMenuItem.Click += new System.EventHandler(this.stoklarToolStripMenuItem_Click);
            // 
            // stokTanımlamalarıToolStripMenuItem
            // 
            this.stokTanımlamalarıToolStripMenuItem.Name = "stokTanımlamalarıToolStripMenuItem";
            this.stokTanımlamalarıToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stokTanımlamalarıToolStripMenuItem.Text = "Stok Tanımlamaları";
            this.stokTanımlamalarıToolStripMenuItem.Click += new System.EventHandler(this.stokTanımlamalarıToolStripMenuItem_Click);
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTime.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblTime.Font = new System.Drawing.Font("Arial Rounded MT Bold", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(182)))), ((int)(((byte)(149)))));
            this.lblTime.Location = new System.Drawing.Point(1016, 33);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(172, 40);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "20:20:20";
            // 
            // stokKategorileriToolStripMenuItem
            // 
            this.stokKategorileriToolStripMenuItem.Name = "stokKategorileriToolStripMenuItem";
            this.stokKategorileriToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stokKategorileriToolStripMenuItem.Text = "Stok Kategorileri";
            this.stokKategorileriToolStripMenuItem.Click += new System.EventHandler(this.stokKategorileriToolStripMenuItem_Click);
            // 
            // gelirGiderToolStripMenuItem
            // 
            this.gelirGiderToolStripMenuItem.Name = "gelirGiderToolStripMenuItem";
            this.gelirGiderToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gelirGiderToolStripMenuItem.Text = "Gelir Gider";
            // 
            // işlemlerToolStripMenuItem
            // 
            this.işlemlerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.satışToolStripMenuItem,
            this.alışToolStripMenuItem});
            this.işlemlerToolStripMenuItem.Name = "işlemlerToolStripMenuItem";
            this.işlemlerToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.işlemlerToolStripMenuItem.Text = "İşlemler";
            // 
            // satışToolStripMenuItem
            // 
            this.satışToolStripMenuItem.Name = "satışToolStripMenuItem";
            this.satışToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.satışToolStripMenuItem.Text = "Satış";
            this.satışToolStripMenuItem.Click += new System.EventHandler(this.satışToolStripMenuItem_Click);
            // 
            // alışToolStripMenuItem
            // 
            this.alışToolStripMenuItem.Name = "alışToolStripMenuItem";
            this.alışToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.alışToolStripMenuItem.Text = "Alış";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(208)))), ((int)(((byte)(161)))));
            this.ClientSize = new System.Drawing.Size(1200, 623);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kobi Finans";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kasaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cariToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bankaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cariListeleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kasaListesiToolStripMenuItem;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.ToolStripMenuItem cariHareketlerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cariOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kasaHareketleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bankaHareketleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bankalarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stokToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stoklarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stokTanımlamalarıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stokKategorileriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gelirGiderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem işlemlerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem satışToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alışToolStripMenuItem;
    }
}

