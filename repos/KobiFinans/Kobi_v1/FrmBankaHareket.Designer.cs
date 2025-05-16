namespace Kobi_v1
{
    partial class FrmBankaHareket
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBankaHareket));
            this.checkBoxTumKayitlar = new System.Windows.Forms.CheckBox();
            this.comboBanka = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSifirla = new System.Windows.Forms.Button();
            this.Date1 = new System.Windows.Forms.DateTimePicker();
            this.Date2 = new System.Windows.Forms.DateTimePicker();
            this.txtislemNo = new System.Windows.Forms.TextBox();
            this.txtCariAD = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblGelirTop = new System.Windows.Forms.Label();
            this.txtGelirTop = new System.Windows.Forms.TextBox();
            this.txtGenelTop = new System.Windows.Forms.TextBox();
            this.lblGiderTop = new System.Windows.Forms.Label();
            this.lblGenelTop = new System.Windows.Forms.Label();
            this.txtGiderTop = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.comboOdemeTuru = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxTumKayitlar
            // 
            this.checkBoxTumKayitlar.AutoSize = true;
            this.checkBoxTumKayitlar.Location = new System.Drawing.Point(914, 25);
            this.checkBoxTumKayitlar.Name = "checkBoxTumKayitlar";
            this.checkBoxTumKayitlar.Size = new System.Drawing.Size(135, 28);
            this.checkBoxTumKayitlar.TabIndex = 45;
            this.checkBoxTumKayitlar.Text = "Tüm Kayıtlar";
            this.checkBoxTumKayitlar.UseVisualStyleBackColor = true;
            this.checkBoxTumKayitlar.CheckedChanged += new System.EventHandler(this.checkBoxTumKayitlar_CheckedChanged);
            // 
            // comboBanka
            // 
            this.comboBanka.FormattingEnabled = true;
            this.comboBanka.Location = new System.Drawing.Point(349, 32);
            this.comboBanka.Name = "comboBanka";
            this.comboBanka.Size = new System.Drawing.Size(178, 30);
            this.comboBanka.TabIndex = 44;
            this.comboBanka.SelectedIndexChanged += new System.EventHandler(this.comboBanka_SelectedIndexChanged);
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
            this.btnSifirla.Location = new System.Drawing.Point(603, 59);
            this.btnSifirla.Name = "btnSifirla";
            this.btnSifirla.Size = new System.Drawing.Size(290, 36);
            this.btnSifirla.TabIndex = 11;
            this.btnSifirla.Text = "Sıfırla";
            this.btnSifirla.UseVisualStyleBackColor = false;
            this.btnSifirla.Click += new System.EventHandler(this.btnSifirla_Click);
            // 
            // Date1
            // 
            this.Date1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Date1.Location = new System.Drawing.Point(603, 25);
            this.Date1.Name = "Date1";
            this.Date1.Size = new System.Drawing.Size(141, 28);
            this.Date1.TabIndex = 8;
            this.Date1.ValueChanged += new System.EventHandler(this.Date1_ValueChanged);
            // 
            // Date2
            // 
            this.Date2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Date2.Location = new System.Drawing.Point(752, 25);
            this.Date2.Name = "Date2";
            this.Date2.Size = new System.Drawing.Size(141, 28);
            this.Date2.TabIndex = 9;
            this.Date2.ValueChanged += new System.EventHandler(this.Date2_ValueChanged);
            // 
            // txtislemNo
            // 
            this.txtislemNo.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtislemNo.Location = new System.Drawing.Point(97, 34);
            this.txtislemNo.Name = "txtislemNo";
            this.txtislemNo.Size = new System.Drawing.Size(178, 28);
            this.txtislemNo.TabIndex = 2;
            this.txtislemNo.TextChanged += new System.EventHandler(this.txtislemNo_TextChanged);
            // 
            // txtCariAD
            // 
            this.txtCariAD.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtCariAD.Location = new System.Drawing.Point(97, 68);
            this.txtCariAD.Name = "txtCariAD";
            this.txtCariAD.Size = new System.Drawing.Size(178, 28);
            this.txtCariAD.TabIndex = 2;
            this.txtCariAD.TextChanged += new System.EventHandler(this.txtCariAD_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(544, 29);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 24);
            this.label14.TabIndex = 13;
            this.label14.Text = "Tarih";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 24);
            this.label5.TabIndex = 12;
            this.label5.Text = "Cari Adı";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(281, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 24);
            this.label6.TabIndex = 12;
            this.label6.Text = "Banka";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 24);
            this.label4.TabIndex = 12;
            this.label4.Text = "İşlem No";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblGelirTop);
            this.panel2.Controls.Add(this.txtGelirTop);
            this.panel2.Controls.Add(this.txtGenelTop);
            this.panel2.Controls.Add(this.lblGiderTop);
            this.panel2.Controls.Add(this.lblGenelTop);
            this.panel2.Controls.Add(this.txtGiderTop);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 688);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1464, 54);
            this.panel2.TabIndex = 13;
            // 
            // lblGelirTop
            // 
            this.lblGelirTop.AutoSize = true;
            this.lblGelirTop.Location = new System.Drawing.Point(19, 12);
            this.lblGelirTop.Name = "lblGelirTop";
            this.lblGelirTop.Size = new System.Drawing.Size(122, 24);
            this.lblGelirTop.TabIndex = 7;
            this.lblGelirTop.Text = "Gelir Toplamı";
            // 
            // txtGelirTop
            // 
            this.txtGelirTop.Enabled = false;
            this.txtGelirTop.Location = new System.Drawing.Point(171, 10);
            this.txtGelirTop.Name = "txtGelirTop";
            this.txtGelirTop.Size = new System.Drawing.Size(100, 28);
            this.txtGelirTop.TabIndex = 8;
            // 
            // txtGenelTop
            // 
            this.txtGenelTop.Enabled = false;
            this.txtGenelTop.Location = new System.Drawing.Point(750, 10);
            this.txtGenelTop.Name = "txtGenelTop";
            this.txtGenelTop.Size = new System.Drawing.Size(100, 28);
            this.txtGenelTop.TabIndex = 8;
            // 
            // lblGiderTop
            // 
            this.lblGiderTop.AutoSize = true;
            this.lblGiderTop.Location = new System.Drawing.Point(301, 12);
            this.lblGiderTop.Name = "lblGiderTop";
            this.lblGiderTop.Size = new System.Drawing.Size(129, 24);
            this.lblGiderTop.TabIndex = 7;
            this.lblGiderTop.Text = "Gider Toplamı";
            // 
            // lblGenelTop
            // 
            this.lblGenelTop.AutoSize = true;
            this.lblGenelTop.Location = new System.Drawing.Point(590, 12);
            this.lblGenelTop.Name = "lblGenelTop";
            this.lblGenelTop.Size = new System.Drawing.Size(130, 24);
            this.lblGenelTop.TabIndex = 7;
            this.lblGenelTop.Text = "Genel Toplam";
            // 
            // txtGiderTop
            // 
            this.txtGiderTop.Enabled = false;
            this.txtGiderTop.Location = new System.Drawing.Point(460, 10);
            this.txtGiderTop.Name = "txtGiderTop";
            this.txtGiderTop.Size = new System.Drawing.Size(100, 28);
            this.txtGiderTop.TabIndex = 8;
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
            this.dataGridView1.Size = new System.Drawing.Size(1464, 626);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 116);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1464, 626);
            this.panel1.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.checkBoxTumKayitlar);
            this.panel3.Controls.Add(this.comboOdemeTuru);
            this.panel3.Controls.Add(this.comboBanka);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.btnSifirla);
            this.panel3.Controls.Add(this.Date1);
            this.panel3.Controls.Add(this.Date2);
            this.panel3.Controls.Add(this.txtislemNo);
            this.panel3.Controls.Add(this.txtCariAD);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.panel3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1464, 116);
            this.panel3.TabIndex = 14;
            // 
            // comboOdemeTuru
            // 
            this.comboOdemeTuru.FormattingEnabled = true;
            this.comboOdemeTuru.Location = new System.Drawing.Point(406, 66);
            this.comboOdemeTuru.Name = "comboOdemeTuru";
            this.comboOdemeTuru.Size = new System.Drawing.Size(121, 30);
            this.comboOdemeTuru.TabIndex = 44;
            this.comboOdemeTuru.SelectedIndexChanged += new System.EventHandler(this.comboOdemeTuru_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(281, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "Ödeme Türü";
            // 
            // FrmBankaHareket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(208)))), ((int)(((byte)(161)))));
            this.ClientSize = new System.Drawing.Size(1464, 742);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBankaHareket";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Banka Raporları";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmBankaHareket_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmBankaHareket_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxTumKayitlar;
        private System.Windows.Forms.ComboBox comboBanka;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSifirla;
        private System.Windows.Forms.DateTimePicker Date1;
        private System.Windows.Forms.DateTimePicker Date2;
        private System.Windows.Forms.TextBox txtislemNo;
        private System.Windows.Forms.TextBox txtCariAD;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblGelirTop;
        private System.Windows.Forms.TextBox txtGelirTop;
        private System.Windows.Forms.TextBox txtGenelTop;
        private System.Windows.Forms.Label lblGiderTop;
        private System.Windows.Forms.Label lblGenelTop;
        private System.Windows.Forms.TextBox txtGiderTop;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox comboOdemeTuru;
        private System.Windows.Forms.Label label2;
    }
}