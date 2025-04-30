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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cariToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cariListeleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cariHareketlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cariOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kasaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kasaListesiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kasaHareketleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gelirGiderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bankaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bankalarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bankaHareketleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stoklarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stokTanımlamalarıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stokKategorileriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.işlemlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.satışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.satışlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tahsilatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.giderToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.raporlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.satışlarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cariToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.stokToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bankaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.kasaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tahsilaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.giderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tanımlamalarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cariToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.cariToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.cariKategoriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stokToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.stokToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.stokKategoriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bankaToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.bankaToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.kasaToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.kasaToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.giderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.giderKategoriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTime = new System.Windows.Forms.Label();
            this.llblKullanici = new System.Windows.Forms.Label();
            this.lblRol = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblKasaBakiyesi = new System.Windows.Forms.Label();
            this.lblToplamGider = new System.Windows.Forms.Label();
            this.lblToplamGelir = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.chartKasaOzet = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartKasaOzet)).BeginInit();
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
            this.işlemlerToolStripMenuItem,
            this.raporlarToolStripMenuItem,
            this.tanımlamalarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.kasaToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.ShowItemToolTips = true;
            this.menuStrip1.Size = new System.Drawing.Size(1200, 30);
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
            this.cariToolStripMenuItem.Size = new System.Drawing.Size(49, 26);
            this.cariToolStripMenuItem.Text = "Cari";
            // 
            // cariListeleriToolStripMenuItem
            // 
            this.cariListeleriToolStripMenuItem.Name = "cariListeleriToolStripMenuItem";
            this.cariListeleriToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.cariListeleriToolStripMenuItem.Text = "Cariler";
            this.cariListeleriToolStripMenuItem.Click += new System.EventHandler(this.cariListeleriToolStripMenuItem_Click);
            // 
            // cariHareketlerToolStripMenuItem
            // 
            this.cariHareketlerToolStripMenuItem.Name = "cariHareketlerToolStripMenuItem";
            this.cariHareketlerToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.cariHareketlerToolStripMenuItem.Text = "Cari Hareketler";
            this.cariHareketlerToolStripMenuItem.Click += new System.EventHandler(this.cariHareketlerToolStripMenuItem_Click);
            // 
            // cariOToolStripMenuItem
            // 
            this.cariOToolStripMenuItem.Name = "cariOToolStripMenuItem";
            this.cariOToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
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
            this.kasaToolStripMenuItem.Size = new System.Drawing.Size(54, 26);
            this.kasaToolStripMenuItem.Text = "Kasa";
            // 
            // kasaListesiToolStripMenuItem
            // 
            this.kasaListesiToolStripMenuItem.Name = "kasaListesiToolStripMenuItem";
            this.kasaListesiToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.kasaListesiToolStripMenuItem.Text = "Kasalar";
            this.kasaListesiToolStripMenuItem.Click += new System.EventHandler(this.kasaListesiToolStripMenuItem_Click);
            // 
            // kasaHareketleriToolStripMenuItem
            // 
            this.kasaHareketleriToolStripMenuItem.Name = "kasaHareketleriToolStripMenuItem";
            this.kasaHareketleriToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.kasaHareketleriToolStripMenuItem.Text = "Kasa Hareketleri";
            this.kasaHareketleriToolStripMenuItem.Click += new System.EventHandler(this.kasaHareketleriToolStripMenuItem_Click);
            // 
            // gelirGiderToolStripMenuItem
            // 
            this.gelirGiderToolStripMenuItem.Name = "gelirGiderToolStripMenuItem";
            this.gelirGiderToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.gelirGiderToolStripMenuItem.Text = "Gelir Gider";
            // 
            // bankaToolStripMenuItem
            // 
            this.bankaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bankalarToolStripMenuItem,
            this.bankaHareketleriToolStripMenuItem});
            this.bankaToolStripMenuItem.Name = "bankaToolStripMenuItem";
            this.bankaToolStripMenuItem.Size = new System.Drawing.Size(63, 26);
            this.bankaToolStripMenuItem.Text = "Banka";
            // 
            // bankalarToolStripMenuItem
            // 
            this.bankalarToolStripMenuItem.Name = "bankalarToolStripMenuItem";
            this.bankalarToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.bankalarToolStripMenuItem.Text = "Bankalar";
            this.bankalarToolStripMenuItem.Click += new System.EventHandler(this.bankalarToolStripMenuItem_Click);
            // 
            // bankaHareketleriToolStripMenuItem
            // 
            this.bankaHareketleriToolStripMenuItem.Name = "bankaHareketleriToolStripMenuItem";
            this.bankaHareketleriToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
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
            this.stokToolStripMenuItem.Size = new System.Drawing.Size(52, 26);
            this.stokToolStripMenuItem.Text = "Stok";
            // 
            // stoklarToolStripMenuItem
            // 
            this.stoklarToolStripMenuItem.Name = "stoklarToolStripMenuItem";
            this.stoklarToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.stoklarToolStripMenuItem.Text = "Stoklar";
            this.stoklarToolStripMenuItem.Click += new System.EventHandler(this.stoklarToolStripMenuItem_Click);
            // 
            // stokTanımlamalarıToolStripMenuItem
            // 
            this.stokTanımlamalarıToolStripMenuItem.Name = "stokTanımlamalarıToolStripMenuItem";
            this.stokTanımlamalarıToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.stokTanımlamalarıToolStripMenuItem.Text = "Stok Tanımlamaları";
            this.stokTanımlamalarıToolStripMenuItem.Click += new System.EventHandler(this.stokTanımlamalarıToolStripMenuItem_Click);
            // 
            // stokKategorileriToolStripMenuItem
            // 
            this.stokKategorileriToolStripMenuItem.Name = "stokKategorileriToolStripMenuItem";
            this.stokKategorileriToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.stokKategorileriToolStripMenuItem.Text = "Stok Kategorileri";
            this.stokKategorileriToolStripMenuItem.Click += new System.EventHandler(this.stokKategorileriToolStripMenuItem_Click);
            // 
            // işlemlerToolStripMenuItem
            // 
            this.işlemlerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.satışToolStripMenuItem,
            this.alışToolStripMenuItem,
            this.satışlarToolStripMenuItem,
            this.tahsilatToolStripMenuItem,
            this.giderToolStripMenuItem2});
            this.işlemlerToolStripMenuItem.Name = "işlemlerToolStripMenuItem";
            this.işlemlerToolStripMenuItem.Size = new System.Drawing.Size(75, 26);
            this.işlemlerToolStripMenuItem.Text = "İşlemler";
            // 
            // satışToolStripMenuItem
            // 
            this.satışToolStripMenuItem.Name = "satışToolStripMenuItem";
            this.satışToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.satışToolStripMenuItem.Text = "Satış";
            this.satışToolStripMenuItem.Click += new System.EventHandler(this.satışToolStripMenuItem_Click);
            // 
            // alışToolStripMenuItem
            // 
            this.alışToolStripMenuItem.Name = "alışToolStripMenuItem";
            this.alışToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.alışToolStripMenuItem.Text = "Alış";
            // 
            // satışlarToolStripMenuItem
            // 
            this.satışlarToolStripMenuItem.Name = "satışlarToolStripMenuItem";
            this.satışlarToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.satışlarToolStripMenuItem.Text = "Satışlar";
            this.satışlarToolStripMenuItem.Click += new System.EventHandler(this.satışlarToolStripMenuItem_Click);
            // 
            // tahsilatToolStripMenuItem
            // 
            this.tahsilatToolStripMenuItem.Name = "tahsilatToolStripMenuItem";
            this.tahsilatToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.tahsilatToolStripMenuItem.Text = "Tahsilat";
            this.tahsilatToolStripMenuItem.Click += new System.EventHandler(this.tahsilatToolStripMenuItem_Click);
            // 
            // giderToolStripMenuItem2
            // 
            this.giderToolStripMenuItem2.Name = "giderToolStripMenuItem2";
            this.giderToolStripMenuItem2.Size = new System.Drawing.Size(224, 26);
            this.giderToolStripMenuItem2.Text = "Gider";
            this.giderToolStripMenuItem2.Click += new System.EventHandler(this.giderToolStripMenuItem2_Click);
            // 
            // raporlarToolStripMenuItem
            // 
            this.raporlarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.satışlarToolStripMenuItem1,
            this.cariToolStripMenuItem1,
            this.stokToolStripMenuItem1,
            this.bankaToolStripMenuItem1,
            this.kasaToolStripMenuItem1,
            this.tahsilaToolStripMenuItem,
            this.giderToolStripMenuItem});
            this.raporlarToolStripMenuItem.Name = "raporlarToolStripMenuItem";
            this.raporlarToolStripMenuItem.Size = new System.Drawing.Size(80, 26);
            this.raporlarToolStripMenuItem.Text = "Raporlar";
            // 
            // satışlarToolStripMenuItem1
            // 
            this.satışlarToolStripMenuItem1.Name = "satışlarToolStripMenuItem1";
            this.satışlarToolStripMenuItem1.Size = new System.Drawing.Size(141, 26);
            this.satışlarToolStripMenuItem1.Text = "Satışlar";
            // 
            // cariToolStripMenuItem1
            // 
            this.cariToolStripMenuItem1.Name = "cariToolStripMenuItem1";
            this.cariToolStripMenuItem1.Size = new System.Drawing.Size(141, 26);
            this.cariToolStripMenuItem1.Text = "Cari";
            // 
            // stokToolStripMenuItem1
            // 
            this.stokToolStripMenuItem1.Name = "stokToolStripMenuItem1";
            this.stokToolStripMenuItem1.Size = new System.Drawing.Size(141, 26);
            this.stokToolStripMenuItem1.Text = "Stok";
            // 
            // bankaToolStripMenuItem1
            // 
            this.bankaToolStripMenuItem1.Name = "bankaToolStripMenuItem1";
            this.bankaToolStripMenuItem1.Size = new System.Drawing.Size(141, 26);
            this.bankaToolStripMenuItem1.Text = "Banka";
            // 
            // kasaToolStripMenuItem1
            // 
            this.kasaToolStripMenuItem1.Name = "kasaToolStripMenuItem1";
            this.kasaToolStripMenuItem1.Size = new System.Drawing.Size(141, 26);
            this.kasaToolStripMenuItem1.Text = "Kasa";
            // 
            // tahsilaToolStripMenuItem
            // 
            this.tahsilaToolStripMenuItem.Name = "tahsilaToolStripMenuItem";
            this.tahsilaToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.tahsilaToolStripMenuItem.Text = "Tahsilat";
            this.tahsilaToolStripMenuItem.Click += new System.EventHandler(this.tahsilaToolStripMenuItem_Click);
            // 
            // giderToolStripMenuItem
            // 
            this.giderToolStripMenuItem.Name = "giderToolStripMenuItem";
            this.giderToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.giderToolStripMenuItem.Text = "Gider";
            this.giderToolStripMenuItem.Click += new System.EventHandler(this.giderToolStripMenuItem_Click);
            // 
            // tanımlamalarToolStripMenuItem
            // 
            this.tanımlamalarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cariToolStripMenuItem2,
            this.stokToolStripMenuItem2,
            this.bankaToolStripMenuItem2,
            this.kasaToolStripMenuItem2,
            this.giderToolStripMenuItem1});
            this.tanımlamalarToolStripMenuItem.Name = "tanımlamalarToolStripMenuItem";
            this.tanımlamalarToolStripMenuItem.Size = new System.Drawing.Size(112, 26);
            this.tanımlamalarToolStripMenuItem.Text = "Tanımlamalar";
            // 
            // cariToolStripMenuItem2
            // 
            this.cariToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cariToolStripMenuItem3,
            this.cariKategoriToolStripMenuItem});
            this.cariToolStripMenuItem2.Name = "cariToolStripMenuItem2";
            this.cariToolStripMenuItem2.Size = new System.Drawing.Size(132, 26);
            this.cariToolStripMenuItem2.Text = "Cari";
            // 
            // cariToolStripMenuItem3
            // 
            this.cariToolStripMenuItem3.Name = "cariToolStripMenuItem3";
            this.cariToolStripMenuItem3.Size = new System.Drawing.Size(179, 26);
            this.cariToolStripMenuItem3.Text = "Cari";
            // 
            // cariKategoriToolStripMenuItem
            // 
            this.cariKategoriToolStripMenuItem.Name = "cariKategoriToolStripMenuItem";
            this.cariKategoriToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.cariKategoriToolStripMenuItem.Text = "Cari Kategori";
            // 
            // stokToolStripMenuItem2
            // 
            this.stokToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stokToolStripMenuItem3,
            this.stokKategoriToolStripMenuItem});
            this.stokToolStripMenuItem2.Name = "stokToolStripMenuItem2";
            this.stokToolStripMenuItem2.Size = new System.Drawing.Size(132, 26);
            this.stokToolStripMenuItem2.Text = "Stok";
            // 
            // stokToolStripMenuItem3
            // 
            this.stokToolStripMenuItem3.Name = "stokToolStripMenuItem3";
            this.stokToolStripMenuItem3.Size = new System.Drawing.Size(182, 26);
            this.stokToolStripMenuItem3.Text = "Stok";
            // 
            // stokKategoriToolStripMenuItem
            // 
            this.stokKategoriToolStripMenuItem.Name = "stokKategoriToolStripMenuItem";
            this.stokKategoriToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.stokKategoriToolStripMenuItem.Text = "Stok Kategori";
            // 
            // bankaToolStripMenuItem2
            // 
            this.bankaToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bankaToolStripMenuItem3});
            this.bankaToolStripMenuItem2.Name = "bankaToolStripMenuItem2";
            this.bankaToolStripMenuItem2.Size = new System.Drawing.Size(132, 26);
            this.bankaToolStripMenuItem2.Text = "Banka";
            // 
            // bankaToolStripMenuItem3
            // 
            this.bankaToolStripMenuItem3.Name = "bankaToolStripMenuItem3";
            this.bankaToolStripMenuItem3.Size = new System.Drawing.Size(132, 26);
            this.bankaToolStripMenuItem3.Text = "Banka";
            // 
            // kasaToolStripMenuItem2
            // 
            this.kasaToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kasaToolStripMenuItem3});
            this.kasaToolStripMenuItem2.Name = "kasaToolStripMenuItem2";
            this.kasaToolStripMenuItem2.Size = new System.Drawing.Size(132, 26);
            this.kasaToolStripMenuItem2.Text = "Kasa";
            // 
            // kasaToolStripMenuItem3
            // 
            this.kasaToolStripMenuItem3.Name = "kasaToolStripMenuItem3";
            this.kasaToolStripMenuItem3.Size = new System.Drawing.Size(123, 26);
            this.kasaToolStripMenuItem3.Text = "Kasa";
            // 
            // giderToolStripMenuItem1
            // 
            this.giderToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.giderKategoriToolStripMenuItem});
            this.giderToolStripMenuItem1.Name = "giderToolStripMenuItem1";
            this.giderToolStripMenuItem1.Size = new System.Drawing.Size(132, 26);
            this.giderToolStripMenuItem1.Text = "Gider";
            // 
            // giderKategoriToolStripMenuItem
            // 
            this.giderKategoriToolStripMenuItem.Name = "giderKategoriToolStripMenuItem";
            this.giderKategoriToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.giderKategoriToolStripMenuItem.Text = "Gider Kategori";
            // 
            // lblTime
            // 
            this.lblTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTime.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblTime.Font = new System.Drawing.Font("Arial Rounded MT Bold", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(182)))), ((int)(((byte)(149)))));
            this.lblTime.Location = new System.Drawing.Point(3, 82);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(219, 51);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "20:20:20";
            // 
            // llblKullanici
            // 
            this.llblKullanici.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llblKullanici.AutoSize = true;
            this.llblKullanici.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.llblKullanici.ForeColor = System.Drawing.Color.Olive;
            this.llblKullanici.Location = new System.Drawing.Point(99, 6);
            this.llblKullanici.Name = "llblKullanici";
            this.llblKullanici.Size = new System.Drawing.Size(60, 24);
            this.llblKullanici.TabIndex = 3;
            this.llblKullanici.Text = "label1";
            // 
            // lblRol
            // 
            this.lblRol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRol.AutoSize = true;
            this.lblRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblRol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(26)))), ((int)(((byte)(54)))));
            this.lblRol.Location = new System.Drawing.Point(99, 41);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(60, 24);
            this.lblRol.TabIndex = 3;
            this.lblRol.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblRol);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.llblKullanici);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(219, 76);
            this.panel1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Olive;
            this.label3.Location = new System.Drawing.Point(13, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Kullanıcı";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(26)))), ((int)(((byte)(54)))));
            this.label4.Location = new System.Drawing.Point(43, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Rol";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.button2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblTime, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(975, 30);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.92337F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.659658F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.73479F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.408094F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.67116F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.52276F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.58419F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.38425F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(225, 593);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.BackColor = System.Drawing.SystemColors.Highlight;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(3, 249);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(219, 49);
            this.button2.TabIndex = 0;
            this.button2.Text = "Hesap Makinesi";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.58974F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.35897F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.69231F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.18013F));
            this.tableLayoutPanel2.Controls.Add(this.lblToplamGelir, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblToplamGider, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblKasaBakiyesi, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 575);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(975, 48);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Image = global::Kobi_v1.Properties.Resources.User_Groups1;
            this.label1.Location = new System.Drawing.Point(3, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 75);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.IndianRed;
            this.label2.Location = new System.Drawing.Point(3, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // lblKasaBakiyesi
            // 
            this.lblKasaBakiyesi.AutoSize = true;
            this.lblKasaBakiyesi.Location = new System.Drawing.Point(334, 0);
            this.lblKasaBakiyesi.Name = "lblKasaBakiyesi";
            this.lblKasaBakiyesi.Size = new System.Drawing.Size(0, 24);
            this.lblKasaBakiyesi.TabIndex = 1;
            // 
            // lblToplamGider
            // 
            this.lblToplamGider.AutoSize = true;
            this.lblToplamGider.Location = new System.Drawing.Point(155, 0);
            this.lblToplamGider.Name = "lblToplamGider";
            this.lblToplamGider.Size = new System.Drawing.Size(0, 24);
            this.lblToplamGider.TabIndex = 0;
            // 
            // lblToplamGelir
            // 
            this.lblToplamGelir.AutoSize = true;
            this.lblToplamGelir.Location = new System.Drawing.Point(3, 0);
            this.lblToplamGelir.Name = "lblToplamGelir";
            this.lblToplamGelir.Size = new System.Drawing.Size(0, 24);
            this.lblToplamGelir.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.5641F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.4359F));
            this.tableLayoutPanel3.Controls.Add(this.chartKasaOzet, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 30);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.04587F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.95413F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(975, 545);
            this.tableLayoutPanel3.TabIndex = 7;
            // 
            // chartKasaOzet
            // 
            this.chartKasaOzet.BackColor = System.Drawing.Color.IndianRed;
            this.chartKasaOzet.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.DiagonalLeft;
            this.chartKasaOzet.BorderlineColor = System.Drawing.Color.Black;
            this.chartKasaOzet.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
            chartArea1.Name = "ChartArea1";
            this.chartKasaOzet.ChartAreas.Add(chartArea1);
            this.chartKasaOzet.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartKasaOzet.Legends.Add(legend1);
            this.chartKasaOzet.Location = new System.Drawing.Point(3, 303);
            this.chartKasaOzet.Name = "chartKasaOzet";
            this.chartKasaOzet.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            this.chartKasaOzet.RightToLeft = System.Windows.Forms.RightToLeft.No;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartKasaOzet.Series.Add(series1);
            this.chartKasaOzet.Size = new System.Drawing.Size(331, 239);
            this.chartKasaOzet.SuppressExceptions = true;
            this.chartKasaOzet.TabIndex = 0;
            this.chartKasaOzet.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(208)))), ((int)(((byte)(161)))));
            this.ClientSize = new System.Drawing.Size(1200, 623);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartKasaOzet)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem satışlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tahsilatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem raporlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem satışlarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cariToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem stokToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bankaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem kasaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tahsilaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem giderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tanımlamalarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cariToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem cariToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem cariKategoriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stokToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem stokToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem stokKategoriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bankaToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem bankaToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem kasaToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem kasaToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem giderToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem giderKategoriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem giderToolStripMenuItem2;
        private System.Windows.Forms.Label llblKullanici;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblToplamGelir;
        private System.Windows.Forms.Label lblToplamGider;
        private System.Windows.Forms.Label lblKasaBakiyesi;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartKasaOzet;
    }
}

