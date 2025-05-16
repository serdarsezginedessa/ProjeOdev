namespace Kobi_v1
{
    partial class frmTahsilatHareketleri
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTahsilatHareketleri));
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cariEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cariBilgileriDüzeltToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cariSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtFaturaNo = new System.Windows.Forms.TextBox();
            this.txtCariKOD = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSifirla = new System.Windows.Forms.Button();
            this.Date1 = new System.Windows.Forms.DateTimePicker();
            this.Date2 = new System.Windows.Forms.DateTimePicker();
            this.txtTahsilatNo = new System.Windows.Forms.TextBox();
            this.txtCariAD = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(0, 114);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1464, 628);
            this.panel2.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowTemplate.DefaultCellStyle.NullValue = null;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1464, 628);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cariEkleToolStripMenuItem,
            this.cariBilgileriDüzeltToolStripMenuItem,
            this.cariSilToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(207, 76);
            // 
            // cariEkleToolStripMenuItem
            // 
            this.cariEkleToolStripMenuItem.Name = "cariEkleToolStripMenuItem";
            this.cariEkleToolStripMenuItem.Size = new System.Drawing.Size(206, 24);
            this.cariEkleToolStripMenuItem.Text = "Cari Ekle";
            // 
            // cariBilgileriDüzeltToolStripMenuItem
            // 
            this.cariBilgileriDüzeltToolStripMenuItem.Name = "cariBilgileriDüzeltToolStripMenuItem";
            this.cariBilgileriDüzeltToolStripMenuItem.Size = new System.Drawing.Size(206, 24);
            this.cariBilgileriDüzeltToolStripMenuItem.Text = "Cari Bilgileri Düzelt";
            // 
            // cariSilToolStripMenuItem
            // 
            this.cariSilToolStripMenuItem.Name = "cariSilToolStripMenuItem";
            this.cariSilToolStripMenuItem.Size = new System.Drawing.Size(206, 24);
            this.cariSilToolStripMenuItem.Text = "Cari Sil";
            // 
            // txtFaturaNo
            // 
            this.txtFaturaNo.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtFaturaNo.Location = new System.Drawing.Point(97, 64);
            this.txtFaturaNo.Name = "txtFaturaNo";
            this.txtFaturaNo.Size = new System.Drawing.Size(178, 28);
            this.txtFaturaNo.TabIndex = 1;
            this.txtFaturaNo.TextChanged += new System.EventHandler(this.txtFaturaNo_TextChanged);
            // 
            // txtCariKOD
            // 
            this.txtCariKOD.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtCariKOD.Location = new System.Drawing.Point(97, 34);
            this.txtCariKOD.Name = "txtCariKOD";
            this.txtCariKOD.Size = new System.Drawing.Size(178, 28);
            this.txtCariKOD.TabIndex = 1;
            this.txtCariKOD.TextChanged += new System.EventHandler(this.txtCariKOD_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(621, 36);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 24);
            this.label14.TabIndex = 13;
            this.label14.Text = "Tarih";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 24);
            this.label3.TabIndex = 14;
            this.label3.Text = "Fatura No";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(281, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 24);
            this.label4.TabIndex = 12;
            this.label4.Text = "Tahsilat No";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnSifirla);
            this.panel1.Controls.Add(this.Date1);
            this.panel1.Controls.Add(this.Date2);
            this.panel1.Controls.Add(this.txtTahsilatNo);
            this.panel1.Controls.Add(this.txtCariAD);
            this.panel1.Controls.Add(this.txtFaturaNo);
            this.panel1.Controls.Add(this.txtCariKOD);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1464, 112);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 25);
            this.label1.TabIndex = 30;
            this.label1.Text = "Arama Filtreleri";
            // 
            // btnSifirla
            // 
            this.btnSifirla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(83)))), ((int)(((byte)(91)))));
            this.btnSifirla.FlatAppearance.BorderSize = 0;
            this.btnSifirla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSifirla.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSifirla.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSifirla.Location = new System.Drawing.Point(680, 67);
            this.btnSifirla.Name = "btnSifirla";
            this.btnSifirla.Size = new System.Drawing.Size(282, 36);
            this.btnSifirla.TabIndex = 11;
            this.btnSifirla.Text = "Sıfırla";
            this.btnSifirla.UseVisualStyleBackColor = false;
            this.btnSifirla.Click += new System.EventHandler(this.btnSifirla_Click);
            // 
            // Date1
            // 
            this.Date1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Date1.Location = new System.Drawing.Point(680, 33);
            this.Date1.Name = "Date1";
            this.Date1.Size = new System.Drawing.Size(137, 28);
            this.Date1.TabIndex = 8;
            this.Date1.ValueChanged += new System.EventHandler(this.Date1_ValueChanged);
            // 
            // Date2
            // 
            this.Date2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Date2.Location = new System.Drawing.Point(823, 33);
            this.Date2.Name = "Date2";
            this.Date2.Size = new System.Drawing.Size(139, 28);
            this.Date2.TabIndex = 9;
            this.Date2.ValueChanged += new System.EventHandler(this.Date2_ValueChanged);
            // 
            // txtTahsilatNo
            // 
            this.txtTahsilatNo.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtTahsilatNo.Location = new System.Drawing.Point(390, 35);
            this.txtTahsilatNo.Name = "txtTahsilatNo";
            this.txtTahsilatNo.Size = new System.Drawing.Size(178, 28);
            this.txtTahsilatNo.TabIndex = 2;
            this.txtTahsilatNo.TextChanged += new System.EventHandler(this.txtTahsilatNo_TextChanged);
            // 
            // txtCariAD
            // 
            this.txtCariAD.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtCariAD.Location = new System.Drawing.Point(390, 69);
            this.txtCariAD.Name = "txtCariAD";
            this.txtCariAD.Size = new System.Drawing.Size(178, 28);
            this.txtCariAD.TabIndex = 2;
            this.txtCariAD.TextChanged += new System.EventHandler(this.txtCariAD_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(281, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 24);
            this.label5.TabIndex = 12;
            this.label5.Text = "Ad Soyad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 14;
            this.label2.Text = "Cari Kod";
            // 
            // frmTahsilatHareketleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(208)))), ((int)(((byte)(161)))));
            this.ClientSize = new System.Drawing.Size(1464, 742);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTahsilatHareketleri";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tahsilatlar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTahsilatHareketleri_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTahsilatHareketleri_KeyDown);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cariEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cariBilgileriDüzeltToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cariSilToolStripMenuItem;
        private System.Windows.Forms.TextBox txtFaturaNo;
        private System.Windows.Forms.TextBox txtCariKOD;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSifirla;
        private System.Windows.Forms.DateTimePicker Date1;
        private System.Windows.Forms.DateTimePicker Date2;
        private System.Windows.Forms.TextBox txtCariAD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTahsilatNo;
        private System.Windows.Forms.Label label5;
    }
}