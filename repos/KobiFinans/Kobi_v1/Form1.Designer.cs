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
            this.lblTime = new System.Windows.Forms.Label();
            this.llblKullanici = new System.Windows.Forms.Label();
            this.lblRol = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblToplamGelir = new System.Windows.Forms.Label();
            this.lblToplamGider = new System.Windows.Forms.Label();
            this.lblKasaBakiyesi = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.chartKasaOzet = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnCikis = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cariToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cariListeleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cariOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CariKategorileritoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.stokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stoklarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stokTanımlamalarıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stokKategorileriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FaturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.satışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gelirGiderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TahsilatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.giderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kasaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kasaListesiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bankaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bankalarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bankaHareketleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.raporlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.satışlarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tahsilatlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.giderlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kasaRaporToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bankaRaporToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.carilerHareketleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StokHareketleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cariToolStripMenuItem,
            this.stokToolStripMenuItem,
            this.FaturaToolStripMenuItem,
            this.gelirGiderToolStripMenuItem,
            this.kasaToolStripMenuItem,
            this.bankaToolStripMenuItem,
            this.raporlarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.kasaToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.ShowItemToolTips = true;
            this.menuStrip1.Size = new System.Drawing.Size(1200, 48);
            this.menuStrip1.Stretch = false;
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // lblTime
            // 
            this.lblTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTime.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTime.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblTime.Font = new System.Drawing.Font("Arial Rounded MT Bold", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(182)))), ((int)(((byte)(149)))));
            this.lblTime.Location = new System.Drawing.Point(3, 72);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(219, 72);
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
            this.panel1.Size = new System.Drawing.Size(219, 66);
            this.panel1.TabIndex = 4;
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnCikis, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.btnLogout, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.button2, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblTime, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(975, 48);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.56281F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.56281F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.56281F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.56281F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.56281F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.56281F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.56281F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.0603F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(225, 575);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.IndianRed;
            this.label2.Location = new System.Drawing.Point(3, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
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
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(975, 48);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // lblToplamGelir
            // 
            this.lblToplamGelir.AutoSize = true;
            this.lblToplamGelir.Location = new System.Drawing.Point(3, 0);
            this.lblToplamGelir.Name = "lblToplamGelir";
            this.lblToplamGelir.Size = new System.Drawing.Size(0, 24);
            this.lblToplamGelir.TabIndex = 0;
            // 
            // lblToplamGider
            // 
            this.lblToplamGider.AutoSize = true;
            this.lblToplamGider.Location = new System.Drawing.Point(155, 0);
            this.lblToplamGider.Name = "lblToplamGider";
            this.lblToplamGider.Size = new System.Drawing.Size(0, 24);
            this.lblToplamGider.TabIndex = 0;
            // 
            // lblKasaBakiyesi
            // 
            this.lblKasaBakiyesi.AutoSize = true;
            this.lblKasaBakiyesi.Location = new System.Drawing.Point(334, 0);
            this.lblKasaBakiyesi.Name = "lblKasaBakiyesi";
            this.lblKasaBakiyesi.Size = new System.Drawing.Size(0, 24);
            this.lblKasaBakiyesi.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.5641F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.4359F));
            this.tableLayoutPanel3.Controls.Add(this.chartKasaOzet, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 48);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.04587F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.95413F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(975, 527);
            this.tableLayoutPanel3.TabIndex = 7;
            this.tableLayoutPanel3.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel3_Paint);
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
            this.chartKasaOzet.Location = new System.Drawing.Point(3, 293);
            this.chartKasaOzet.Name = "chartKasaOzet";
            this.chartKasaOzet.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            this.chartKasaOzet.RightToLeft = System.Windows.Forms.RightToLeft.No;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartKasaOzet.Series.Add(series1);
            this.chartKasaOzet.Size = new System.Drawing.Size(330, 231);
            this.chartKasaOzet.SuppressExceptions = true;
            this.chartKasaOzet.TabIndex = 0;
            this.chartKasaOzet.Text = "chart1";
            // 
            // btnCikis
            // 
            this.btnCikis.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCikis.BackColor = System.Drawing.Color.Transparent;
            this.btnCikis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCikis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCikis.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.btnCikis.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnCikis.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnCikis.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCikis.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCikis.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCikis.Image = global::Kobi_v1.Properties.Resources.Export80;
            this.btnCikis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCikis.Location = new System.Drawing.Point(3, 507);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(219, 65);
            this.btnCikis.TabIndex = 6;
            this.btnCikis.Text = "            Çıkış";
            this.btnCikis.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCikis.UseVisualStyleBackColor = false;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.AutoSize = true;
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(182)))), ((int)(((byte)(149)))));
            this.btnLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogout.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.btnLogout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogout.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLogout.Image = global::Kobi_v1.Properties.Resources.Logout80;
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(3, 435);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(219, 66);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Oturum Kapat";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.BackColor = System.Drawing.SystemColors.Highlight;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Image = global::Kobi_v1.Properties.Resources.Calculator80;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(3, 363);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(219, 66);
            this.button2.TabIndex = 0;
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Image = global::Kobi_v1.Properties.Resources.User_Groups1;
            this.label1.Location = new System.Drawing.Point(3, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 72);
            this.label1.TabIndex = 0;
            // 
            // cariToolStripMenuItem
            // 
            this.cariToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cariToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cariListeleriToolStripMenuItem,
            this.cariOToolStripMenuItem,
            this.CariKategorileritoolStripMenuItem1});
            this.cariToolStripMenuItem.Image = global::Kobi_v1.Properties.Resources.Users801;
            this.cariToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cariToolStripMenuItem.Name = "cariToolStripMenuItem";
            this.cariToolStripMenuItem.Size = new System.Drawing.Size(54, 44);
            this.cariToolStripMenuItem.Text = "Cari";
            this.cariToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.cariToolStripMenuItem.ToolTipText = "Cari İşlemleri";
            // 
            // cariListeleriToolStripMenuItem
            // 
            this.cariListeleriToolStripMenuItem.Image = global::Kobi_v1.Properties.Resources.Group481;
            this.cariListeleriToolStripMenuItem.Name = "cariListeleriToolStripMenuItem";
            this.cariListeleriToolStripMenuItem.Size = new System.Drawing.Size(220, 46);
            this.cariListeleriToolStripMenuItem.Text = "Cariler";
            this.cariListeleriToolStripMenuItem.Click += new System.EventHandler(this.cariListeleriToolStripMenuItem_Click);
            // 
            // cariOToolStripMenuItem
            // 
            this.cariOToolStripMenuItem.Image = global::Kobi_v1.Properties.Resources.Add_User_Group_Woman_Man80;
            this.cariOToolStripMenuItem.Name = "cariOToolStripMenuItem";
            this.cariOToolStripMenuItem.Size = new System.Drawing.Size(220, 46);
            this.cariOToolStripMenuItem.Text = "Cari Ekle";
            this.cariOToolStripMenuItem.Click += new System.EventHandler(this.cariOToolStripMenuItem_Click);
            // 
            // CariKategorileritoolStripMenuItem1
            // 
            this.CariKategorileritoolStripMenuItem1.Image = global::Kobi_v1.Properties.Resources.Diversity80;
            this.CariKategorileritoolStripMenuItem1.Name = "CariKategorileritoolStripMenuItem1";
            this.CariKategorileritoolStripMenuItem1.Size = new System.Drawing.Size(220, 46);
            this.CariKategorileritoolStripMenuItem1.Text = "Cari Kategorileri";
            this.CariKategorileritoolStripMenuItem1.Click += new System.EventHandler(this.CariKategorileritoolStripMenuItem1_Click);
            // 
            // stokToolStripMenuItem
            // 
            this.stokToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stoklarToolStripMenuItem,
            this.stokTanımlamalarıToolStripMenuItem,
            this.stokKategorileriToolStripMenuItem});
            this.stokToolStripMenuItem.Image = global::Kobi_v1.Properties.Resources.Sell_Stock80;
            this.stokToolStripMenuItem.Name = "stokToolStripMenuItem";
            this.stokToolStripMenuItem.Size = new System.Drawing.Size(54, 44);
            this.stokToolStripMenuItem.ToolTipText = "Stok İşlemleri";
            // 
            // stoklarToolStripMenuItem
            // 
            this.stoklarToolStripMenuItem.Image = global::Kobi_v1.Properties.Resources.Product96px1;
            this.stoklarToolStripMenuItem.Name = "stoklarToolStripMenuItem";
            this.stoklarToolStripMenuItem.Size = new System.Drawing.Size(238, 46);
            this.stoklarToolStripMenuItem.Text = "Stoklar";
            this.stoklarToolStripMenuItem.Click += new System.EventHandler(this.stoklarToolStripMenuItem_Click);
            // 
            // stokTanımlamalarıToolStripMenuItem
            // 
            this.stokTanımlamalarıToolStripMenuItem.Image = global::Kobi_v1.Properties.Resources.Delivered_Box80;
            this.stokTanımlamalarıToolStripMenuItem.Name = "stokTanımlamalarıToolStripMenuItem";
            this.stokTanımlamalarıToolStripMenuItem.Size = new System.Drawing.Size(238, 46);
            this.stokTanımlamalarıToolStripMenuItem.Text = "Stok Tanımlamaları";
            this.stokTanımlamalarıToolStripMenuItem.Click += new System.EventHandler(this.stokTanımlamalarıToolStripMenuItem_Click);
            // 
            // stokKategorileriToolStripMenuItem
            // 
            this.stokKategorileriToolStripMenuItem.Image = global::Kobi_v1.Properties.Resources.Diversity80;
            this.stokKategorileriToolStripMenuItem.Name = "stokKategorileriToolStripMenuItem";
            this.stokKategorileriToolStripMenuItem.Size = new System.Drawing.Size(238, 46);
            this.stokKategorileriToolStripMenuItem.Text = "Stok Kategorileri";
            this.stokKategorileriToolStripMenuItem.Click += new System.EventHandler(this.stokKategorileriToolStripMenuItem_Click);
            // 
            // FaturaToolStripMenuItem
            // 
            this.FaturaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.satışToolStripMenuItem});
            this.FaturaToolStripMenuItem.Image = global::Kobi_v1.Properties.Resources.Receipt80;
            this.FaturaToolStripMenuItem.Name = "FaturaToolStripMenuItem";
            this.FaturaToolStripMenuItem.Size = new System.Drawing.Size(54, 44);
            this.FaturaToolStripMenuItem.ToolTipText = "Fatura İşlemleri";
            // 
            // satışToolStripMenuItem
            // 
            this.satışToolStripMenuItem.Image = global::Kobi_v1.Properties.Resources.Purchase_Order80;
            this.satışToolStripMenuItem.Name = "satışToolStripMenuItem";
            this.satışToolStripMenuItem.Size = new System.Drawing.Size(143, 46);
            this.satışToolStripMenuItem.Text = "Satış";
            this.satışToolStripMenuItem.Click += new System.EventHandler(this.satışToolStripMenuItem_Click);
            // 
            // gelirGiderToolStripMenuItem
            // 
            this.gelirGiderToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.gelirGiderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TahsilatToolStripMenuItem,
            this.giderToolStripMenuItem});
            this.gelirGiderToolStripMenuItem.Image = global::Kobi_v1.Properties.Resources.Budget80;
            this.gelirGiderToolStripMenuItem.Name = "gelirGiderToolStripMenuItem";
            this.gelirGiderToolStripMenuItem.Size = new System.Drawing.Size(54, 44);
            this.gelirGiderToolStripMenuItem.Text = "Gelir Gider";
            this.gelirGiderToolStripMenuItem.ToolTipText = "Gelir Gider İşlemleri";
            // 
            // TahsilatToolStripMenuItem
            // 
            this.TahsilatToolStripMenuItem.Image = global::Kobi_v1.Properties.Resources.Money_Bag_Lira80;
            this.TahsilatToolStripMenuItem.Name = "TahsilatToolStripMenuItem";
            this.TahsilatToolStripMenuItem.Size = new System.Drawing.Size(161, 46);
            this.TahsilatToolStripMenuItem.Text = "Tahsilat";
            this.TahsilatToolStripMenuItem.Click += new System.EventHandler(this.TahsilatToolStripMenuItem_Click_1);
            // 
            // giderToolStripMenuItem
            // 
            this.giderToolStripMenuItem.Image = global::Kobi_v1.Properties.Resources.Cash_in_Hand80;
            this.giderToolStripMenuItem.Name = "giderToolStripMenuItem";
            this.giderToolStripMenuItem.Size = new System.Drawing.Size(161, 46);
            this.giderToolStripMenuItem.Text = "Gider";
            this.giderToolStripMenuItem.Click += new System.EventHandler(this.giderToolStripMenuItem_Click_1);
            // 
            // kasaToolStripMenuItem
            // 
            this.kasaToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.kasaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kasaListesiToolStripMenuItem});
            this.kasaToolStripMenuItem.Image = global::Kobi_v1.Properties.Resources.Cash_Register80;
            this.kasaToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.kasaToolStripMenuItem.Name = "kasaToolStripMenuItem";
            this.kasaToolStripMenuItem.Size = new System.Drawing.Size(54, 44);
            this.kasaToolStripMenuItem.Text = "Kasa";
            this.kasaToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.kasaToolStripMenuItem.ToolTipText = "Kasa İşlemleri";
            // 
            // kasaListesiToolStripMenuItem
            // 
            this.kasaListesiToolStripMenuItem.Image = global::Kobi_v1.Properties.Resources.kasa1;
            this.kasaListesiToolStripMenuItem.Name = "kasaListesiToolStripMenuItem";
            this.kasaListesiToolStripMenuItem.Size = new System.Drawing.Size(160, 46);
            this.kasaListesiToolStripMenuItem.Text = "Kasalar";
            this.kasaListesiToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.kasaListesiToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.kasaListesiToolStripMenuItem.Click += new System.EventHandler(this.kasaListesiToolStripMenuItem_Click);
            // 
            // bankaToolStripMenuItem
            // 
            this.bankaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bankalarToolStripMenuItem,
            this.bankaHareketleriToolStripMenuItem});
            this.bankaToolStripMenuItem.Image = global::Kobi_v1.Properties.Resources.Card_Wallet80;
            this.bankaToolStripMenuItem.Name = "bankaToolStripMenuItem";
            this.bankaToolStripMenuItem.Size = new System.Drawing.Size(54, 44);
            this.bankaToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.bankaToolStripMenuItem.ToolTipText = "Banka İşlemleri";
            // 
            // bankalarToolStripMenuItem
            // 
            this.bankalarToolStripMenuItem.Image = global::Kobi_v1.Properties.Resources.Merchant_Account80;
            this.bankalarToolStripMenuItem.Name = "bankalarToolStripMenuItem";
            this.bankalarToolStripMenuItem.Size = new System.Drawing.Size(229, 46);
            this.bankalarToolStripMenuItem.Text = "Bankalar";
            this.bankalarToolStripMenuItem.Click += new System.EventHandler(this.bankalarToolStripMenuItem_Click);
            // 
            // bankaHareketleriToolStripMenuItem
            // 
            this.bankaHareketleriToolStripMenuItem.Name = "bankaHareketleriToolStripMenuItem";
            this.bankaHareketleriToolStripMenuItem.Size = new System.Drawing.Size(229, 46);
            this.bankaHareketleriToolStripMenuItem.Text = "Banka Hareketleri";
            this.bankaHareketleriToolStripMenuItem.Visible = false;
            this.bankaHareketleriToolStripMenuItem.Click += new System.EventHandler(this.bankaHareketleriToolStripMenuItem_Click);
            // 
            // raporlarToolStripMenuItem
            // 
            this.raporlarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.satışlarToolStripMenuItem1,
            this.tahsilatlarToolStripMenuItem,
            this.giderlerToolStripMenuItem,
            this.kasaRaporToolStripMenuItem1,
            this.bankaRaporToolStripMenuItem1,
            this.carilerHareketleriToolStripMenuItem,
            this.StokHareketleriToolStripMenuItem});
            this.raporlarToolStripMenuItem.Image = global::Kobi_v1.Properties.Resources.Total_Sales80;
            this.raporlarToolStripMenuItem.Name = "raporlarToolStripMenuItem";
            this.raporlarToolStripMenuItem.Size = new System.Drawing.Size(54, 44);
            this.raporlarToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.raporlarToolStripMenuItem.ToolTipText = "Raporlar";
            // 
            // satışlarToolStripMenuItem1
            // 
            this.satışlarToolStripMenuItem1.Image = global::Kobi_v1.Properties.Resources.Purchase_Order80;
            this.satışlarToolStripMenuItem1.Name = "satışlarToolStripMenuItem1";
            this.satışlarToolStripMenuItem1.Size = new System.Drawing.Size(238, 46);
            this.satışlarToolStripMenuItem1.Text = "Satış Hareketleri";
            this.satışlarToolStripMenuItem1.Click += new System.EventHandler(this.satışlarToolStripMenuItem1_Click);
            // 
            // tahsilatlarToolStripMenuItem
            // 
            this.tahsilatlarToolStripMenuItem.Image = global::Kobi_v1.Properties.Resources.Money_Bag_Lira80;
            this.tahsilatlarToolStripMenuItem.Name = "tahsilatlarToolStripMenuItem";
            this.tahsilatlarToolStripMenuItem.Size = new System.Drawing.Size(238, 46);
            this.tahsilatlarToolStripMenuItem.Text = "Tahsilat Hareketleri";
            this.tahsilatlarToolStripMenuItem.Click += new System.EventHandler(this.tahsilatlarToolStripMenuItem_Click);
            // 
            // giderlerToolStripMenuItem
            // 
            this.giderlerToolStripMenuItem.Image = global::Kobi_v1.Properties.Resources.Cash_in_Hand80;
            this.giderlerToolStripMenuItem.Name = "giderlerToolStripMenuItem";
            this.giderlerToolStripMenuItem.Size = new System.Drawing.Size(238, 46);
            this.giderlerToolStripMenuItem.Text = "Gider Hareketleri";
            this.giderlerToolStripMenuItem.Click += new System.EventHandler(this.giderlerToolStripMenuItem_Click);
            // 
            // kasaRaporToolStripMenuItem1
            // 
            this.kasaRaporToolStripMenuItem1.Image = global::Kobi_v1.Properties.Resources.Total_Salesa80;
            this.kasaRaporToolStripMenuItem1.Name = "kasaRaporToolStripMenuItem1";
            this.kasaRaporToolStripMenuItem1.Size = new System.Drawing.Size(238, 46);
            this.kasaRaporToolStripMenuItem1.Text = "Kasa Hareketleri";
            this.kasaRaporToolStripMenuItem1.Click += new System.EventHandler(this.kasaRaporToolStripMenuItem1_Click);
            // 
            // bankaRaporToolStripMenuItem1
            // 
            this.bankaRaporToolStripMenuItem1.Image = global::Kobi_v1.Properties.Resources.Money_Yours80;
            this.bankaRaporToolStripMenuItem1.Name = "bankaRaporToolStripMenuItem1";
            this.bankaRaporToolStripMenuItem1.Size = new System.Drawing.Size(238, 46);
            this.bankaRaporToolStripMenuItem1.Text = "Banka Hareketleri";
            this.bankaRaporToolStripMenuItem1.Click += new System.EventHandler(this.bankaRaporToolStripMenuItem1_Click);
            // 
            // carilerHareketleriToolStripMenuItem
            // 
            this.carilerHareketleriToolStripMenuItem.Image = global::Kobi_v1.Properties.Resources.Users80;
            this.carilerHareketleriToolStripMenuItem.Name = "carilerHareketleriToolStripMenuItem";
            this.carilerHareketleriToolStripMenuItem.Size = new System.Drawing.Size(238, 46);
            this.carilerHareketleriToolStripMenuItem.Text = "Cari Hareketleri";
            this.carilerHareketleriToolStripMenuItem.Click += new System.EventHandler(this.carilerListesiToolStripMenuItem_Click);
            // 
            // StokHareketleriToolStripMenuItem
            // 
            this.StokHareketleriToolStripMenuItem.Image = global::Kobi_v1.Properties.Resources.Parcel_Cost80;
            this.StokHareketleriToolStripMenuItem.Name = "StokHareketleriToolStripMenuItem";
            this.StokHareketleriToolStripMenuItem.Size = new System.Drawing.Size(238, 46);
            this.StokHareketleriToolStripMenuItem.Text = "Stok Hareketleri";
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
        private System.Windows.Forms.ToolStripMenuItem cariOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bankaHareketleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bankalarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stokToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stoklarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stokTanımlamalarıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stokKategorileriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FaturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem satışToolStripMenuItem;
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
        private System.Windows.Forms.ToolStripMenuItem raporlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem satışlarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tahsilatlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem giderlerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kasaRaporToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bankaRaporToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem carilerHareketleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StokHareketleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gelirGiderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TahsilatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem giderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CariKategorileritoolStripMenuItem1;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Button btnLogout;
    }
}

