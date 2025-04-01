namespace Kobi_v1
{
    partial class FrmKasaHareketleri
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.txtTutar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.cmbHareketTipi = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnSil = new System.Windows.Forms.Button();
            this.lblGelirTop = new System.Windows.Forms.Label();
            this.lblGiderTop = new System.Windows.Forms.Label();
            this.lblGenelTop = new System.Windows.Forms.Label();
            this.txtGelirTop = new System.Windows.Forms.TextBox();
            this.txtGiderTop = new System.Windows.Forms.TextBox();
            this.txtGenelTop = new System.Windows.Forms.TextBox();
            this.btnGuncelle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 158);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(858, 351);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(26)))), ((int)(((byte)(54)))));
            this.btnKaydet.FlatAppearance.BorderSize = 0;
            this.btnKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKaydet.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnKaydet.Location = new System.Drawing.Point(517, 121);
            this.btnKaydet.Margin = new System.Windows.Forms.Padding(4);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(112, 32);
            this.btnKaydet.TabIndex = 1;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // txtTutar
            // 
            this.txtTutar.Location = new System.Drawing.Point(126, 44);
            this.txtTutar.Name = "txtTutar";
            this.txtTutar.Size = new System.Drawing.Size(236, 28);
            this.txtTutar.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tutar:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Açıklama";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Hareket Tipi";
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(126, 80);
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(236, 28);
            this.txtAciklama.TabIndex = 2;
            // 
            // cmbHareketTipi
            // 
            this.cmbHareketTipi.FormattingEnabled = true;
            this.cmbHareketTipi.Items.AddRange(new object[] {
            "Gelir",
            "Gider"});
            this.cmbHareketTipi.Location = new System.Drawing.Point(126, 118);
            this.cmbHareketTipi.Name = "cmbHareketTipi";
            this.cmbHareketTipi.Size = new System.Drawing.Size(236, 30);
            this.cmbHareketTipi.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tarih:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(126, 9);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(236, 28);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(26)))), ((int)(((byte)(54)))));
            this.btnSil.FlatAppearance.BorderSize = 0;
            this.btnSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSil.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSil.Location = new System.Drawing.Point(757, 121);
            this.btnSil.Margin = new System.Windows.Forms.Padding(4);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(112, 32);
            this.btnSil.TabIndex = 1;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // lblGelirTop
            // 
            this.lblGelirTop.AutoSize = true;
            this.lblGelirTop.Location = new System.Drawing.Point(16, 516);
            this.lblGelirTop.Name = "lblGelirTop";
            this.lblGelirTop.Size = new System.Drawing.Size(122, 24);
            this.lblGelirTop.TabIndex = 7;
            this.lblGelirTop.Text = "Gelir Toplamı";
            // 
            // lblGiderTop
            // 
            this.lblGiderTop.AutoSize = true;
            this.lblGiderTop.Location = new System.Drawing.Point(308, 516);
            this.lblGiderTop.Name = "lblGiderTop";
            this.lblGiderTop.Size = new System.Drawing.Size(129, 24);
            this.lblGiderTop.TabIndex = 7;
            this.lblGiderTop.Text = "Gider Toplamı";
            // 
            // lblGenelTop
            // 
            this.lblGenelTop.AutoSize = true;
            this.lblGenelTop.Location = new System.Drawing.Point(607, 516);
            this.lblGenelTop.Name = "lblGenelTop";
            this.lblGenelTop.Size = new System.Drawing.Size(130, 24);
            this.lblGenelTop.TabIndex = 7;
            this.lblGenelTop.Text = "Genel Toplam";
            // 
            // txtGelirTop
            // 
            this.txtGelirTop.Enabled = false;
            this.txtGelirTop.Location = new System.Drawing.Point(173, 514);
            this.txtGelirTop.Name = "txtGelirTop";
            this.txtGelirTop.Size = new System.Drawing.Size(100, 28);
            this.txtGelirTop.TabIndex = 8;
            // 
            // txtGiderTop
            // 
            this.txtGiderTop.Enabled = false;
            this.txtGiderTop.Location = new System.Drawing.Point(472, 514);
            this.txtGiderTop.Name = "txtGiderTop";
            this.txtGiderTop.Size = new System.Drawing.Size(100, 28);
            this.txtGiderTop.TabIndex = 8;
            // 
            // txtGenelTop
            // 
            this.txtGenelTop.Enabled = false;
            this.txtGenelTop.Location = new System.Drawing.Point(772, 514);
            this.txtGenelTop.Name = "txtGenelTop";
            this.txtGenelTop.Size = new System.Drawing.Size(100, 28);
            this.txtGenelTop.TabIndex = 8;
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(26)))), ((int)(((byte)(54)))));
            this.btnGuncelle.FlatAppearance.BorderSize = 0;
            this.btnGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuncelle.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGuncelle.Location = new System.Drawing.Point(637, 121);
            this.btnGuncelle.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(112, 32);
            this.btnGuncelle.TabIndex = 1;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = false;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // FrmKasaHareketleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(208)))), ((int)(((byte)(161)))));
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.txtGenelTop);
            this.Controls.Add(this.txtGiderTop);
            this.Controls.Add(this.txtGelirTop);
            this.Controls.Add(this.lblGenelTop);
            this.Controls.Add(this.lblGiderTop);
            this.Controls.Add(this.lblGelirTop);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.cmbHareketTipi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAciklama);
            this.Controls.Add(this.txtTutar);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmKasaHareketleri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmKasaHareketleri";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.TextBox txtTutar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.ComboBox cmbHareketTipi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Label lblGelirTop;
        private System.Windows.Forms.Label lblGiderTop;
        private System.Windows.Forms.Label lblGenelTop;
        private System.Windows.Forms.TextBox txtGelirTop;
        private System.Windows.Forms.TextBox txtGiderTop;
        private System.Windows.Forms.TextBox txtGenelTop;
        private System.Windows.Forms.Button btnGuncelle;
    }
}