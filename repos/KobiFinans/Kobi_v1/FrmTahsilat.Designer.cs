namespace Kobi_v1
{
    partial class FrmTahsilat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTahsilat));
            this.comboOdemeTuru = new System.Windows.Forms.ComboBox();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.dateTarih = new System.Windows.Forms.DateTimePicker();
            this.labelAciklama = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTahsilatNo = new System.Windows.Forms.TextBox();
            this.txtFaturaNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCariID = new System.Windows.Forms.TextBox();
            this.lblNakit = new System.Windows.Forms.Label();
            this.lblBanka = new System.Windows.Forms.Label();
            this.comboBoxBanka = new System.Windows.Forms.ComboBox();
            this.comboBoxNakit = new System.Windows.Forms.ComboBox();
            this.txtTutar = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnKapat = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnYeniKayit = new System.Windows.Forms.Button();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.checkBox1FaturaAktif = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCariKod = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboOdemeTuru
            // 
            this.comboOdemeTuru.FormattingEnabled = true;
            this.comboOdemeTuru.Location = new System.Drawing.Point(406, 46);
            this.comboOdemeTuru.Name = "comboOdemeTuru";
            this.comboOdemeTuru.Size = new System.Drawing.Size(143, 30);
            this.comboOdemeTuru.TabIndex = 1;
            this.comboOdemeTuru.Text = "Ödeme Türü";
            this.comboOdemeTuru.SelectedIndexChanged += new System.EventHandler(this.comboOdemeTuru_SelectedIndexChanged);
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(16, 185);
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(212, 114);
            this.txtAciklama.TabIndex = 3;
            // 
            // dateTarih
            // 
            this.dateTarih.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTarih.Location = new System.Drawing.Point(406, 5);
            this.dateTarih.Name = "dateTarih";
            this.dateTarih.Size = new System.Drawing.Size(143, 28);
            this.dateTarih.TabIndex = 4;
            // 
            // labelAciklama
            // 
            this.labelAciklama.AutoSize = true;
            this.labelAciklama.Location = new System.Drawing.Point(12, 151);
            this.labelAciklama.Name = "labelAciklama";
            this.labelAciklama.Size = new System.Drawing.Size(86, 24);
            this.labelAciklama.TabIndex = 0;
            this.labelAciklama.Text = "Açıklama";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tahsilat No:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(564, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 39);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tutar:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(276, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tarih:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(276, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ödeme Türü:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 24);
            this.label7.TabIndex = 0;
            this.label7.Text = "Fatura No:";
            // 
            // txtTahsilatNo
            // 
            this.txtTahsilatNo.Enabled = false;
            this.txtTahsilatNo.Location = new System.Drawing.Point(122, 6);
            this.txtTahsilatNo.Name = "txtTahsilatNo";
            this.txtTahsilatNo.ReadOnly = true;
            this.txtTahsilatNo.Size = new System.Drawing.Size(106, 28);
            this.txtTahsilatNo.TabIndex = 2;
            // 
            // txtFaturaNo
            // 
            this.txtFaturaNo.Location = new System.Drawing.Point(122, 40);
            this.txtFaturaNo.Name = "txtFaturaNo";
            this.txtFaturaNo.ReadOnly = true;
            this.txtFaturaNo.Size = new System.Drawing.Size(106, 28);
            this.txtFaturaNo.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 24);
            this.label5.TabIndex = 0;
            this.label5.Text = "Cari No:";
            // 
            // txtCariID
            // 
            this.txtCariID.Location = new System.Drawing.Point(122, 74);
            this.txtCariID.Name = "txtCariID";
            this.txtCariID.Size = new System.Drawing.Size(106, 28);
            this.txtCariID.TabIndex = 2;
            // 
            // lblNakit
            // 
            this.lblNakit.AutoSize = true;
            this.lblNakit.Location = new System.Drawing.Point(253, 90);
            this.lblNakit.Name = "lblNakit";
            this.lblNakit.Size = new System.Drawing.Size(102, 24);
            this.lblNakit.TabIndex = 0;
            this.lblNakit.Text = "Nakit Kasa:";
            // 
            // lblBanka
            // 
            this.lblBanka.AutoSize = true;
            this.lblBanka.Location = new System.Drawing.Point(411, 91);
            this.lblBanka.Name = "lblBanka";
            this.lblBanka.Size = new System.Drawing.Size(113, 24);
            this.lblBanka.TabIndex = 0;
            this.lblBanka.Text = "Banka Kasa:";
            // 
            // comboBoxBanka
            // 
            this.comboBoxBanka.FormattingEnabled = true;
            this.comboBoxBanka.Location = new System.Drawing.Point(406, 118);
            this.comboBoxBanka.Name = "comboBoxBanka";
            this.comboBoxBanka.Size = new System.Drawing.Size(143, 30);
            this.comboBoxBanka.TabIndex = 1;
            this.comboBoxBanka.Text = "Ödeme Türü";
            // 
            // comboBoxNakit
            // 
            this.comboBoxNakit.FormattingEnabled = true;
            this.comboBoxNakit.Location = new System.Drawing.Point(257, 117);
            this.comboBoxNakit.Name = "comboBoxNakit";
            this.comboBoxNakit.Size = new System.Drawing.Size(143, 30);
            this.comboBoxNakit.TabIndex = 1;
            this.comboBoxNakit.Text = "Ödeme Türü";
            // 
            // txtTutar
            // 
            this.txtTutar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTutar.Location = new System.Drawing.Point(675, 187);
            this.txtTutar.Name = "txtTutar";
            this.txtTutar.Size = new System.Drawing.Size(168, 41);
            this.txtTutar.TabIndex = 25;
            this.txtTutar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTutar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTutar_KeyPress);
            this.txtTutar.Leave += new System.EventHandler(this.txtTutar_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(849, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 39);
            this.label6.TabIndex = 0;
            this.label6.Text = "₺";
            // 
            // panel2
            // 
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnSil);
            this.panel2.Controls.Add(this.btnYeniKayit);
            this.panel2.Controls.Add(this.btnKapat);
            this.panel2.Controls.Add(this.btnKaydet);
            this.panel2.Controls.Add(this.btnGuncelle);
            this.panel2.Location = new System.Drawing.Point(582, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(304, 148);
            this.panel2.TabIndex = 26;
            // 
            // btnKapat
            // 
            this.btnKapat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(83)))), ((int)(((byte)(91)))));
            this.btnKapat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnKapat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnKapat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnKapat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKapat.ForeColor = System.Drawing.Color.Transparent;
            this.btnKapat.Image = global::Kobi_v1.Properties.Resources.Close_Pane3px;
            this.btnKapat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKapat.Location = new System.Drawing.Point(148, 94);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(144, 42);
            this.btnKapat.TabIndex = 22;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKapat.UseVisualStyleBackColor = false;
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(83)))), ((int)(((byte)(91)))));
            this.btnSil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSil.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSil.ForeColor = System.Drawing.Color.Transparent;
            this.btnSil.Image = global::Kobi_v1.Properties.Resources.Minus36px;
            this.btnSil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSil.Location = new System.Drawing.Point(7, 94);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(135, 42);
            this.btnSil.TabIndex = 23;
            this.btnSil.Text = "Sil";
            this.btnSil.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnYeniKayit
            // 
            this.btnYeniKayit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(83)))), ((int)(((byte)(91)))));
            this.btnYeniKayit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnYeniKayit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnYeniKayit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYeniKayit.ForeColor = System.Drawing.Color.Transparent;
            this.btnYeniKayit.Image = global::Kobi_v1.Properties.Resources.clear36px;
            this.btnYeniKayit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnYeniKayit.Location = new System.Drawing.Point(7, 4);
            this.btnYeniKayit.Name = "btnYeniKayit";
            this.btnYeniKayit.Size = new System.Drawing.Size(285, 42);
            this.btnYeniKayit.TabIndex = 22;
            this.btnYeniKayit.Text = "Yeni (F8)";
            this.btnYeniKayit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnYeniKayit.UseVisualStyleBackColor = false;
            this.btnYeniKayit.Click += new System.EventHandler(this.btnYeniKayit_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(83)))), ((int)(((byte)(91)))));
            this.btnKaydet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnKaydet.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnKaydet.FlatAppearance.BorderSize = 0;
            this.btnKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydet.ForeColor = System.Drawing.Color.Transparent;
            this.btnKaydet.Image = global::Kobi_v1.Properties.Resources.Money_Bag_Lira36;
            this.btnKaydet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKaydet.Location = new System.Drawing.Point(7, 48);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(135, 42);
            this.btnKaydet.TabIndex = 23;
            this.btnKaydet.Text = "Tahsilat";
            this.btnKaydet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(83)))), ((int)(((byte)(91)))));
            this.btnGuncelle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGuncelle.ForeColor = System.Drawing.Color.Transparent;
            this.btnGuncelle.Image = global::Kobi_v1.Properties.Resources.Edit36px;
            this.btnGuncelle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuncelle.Location = new System.Drawing.Point(148, 48);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(144, 42);
            this.btnGuncelle.TabIndex = 22;
            this.btnGuncelle.Text = "Düzelt";
            this.btnGuncelle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuncelle.UseVisualStyleBackColor = false;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // checkBox1FaturaAktif
            // 
            this.checkBox1FaturaAktif.AutoSize = true;
            this.checkBox1FaturaAktif.Location = new System.Drawing.Point(235, 46);
            this.checkBox1FaturaAktif.Name = "checkBox1FaturaAktif";
            this.checkBox1FaturaAktif.Size = new System.Drawing.Size(18, 17);
            this.checkBox1FaturaAktif.TabIndex = 27;
            this.checkBox1FaturaAktif.UseVisualStyleBackColor = true;
            this.checkBox1FaturaAktif.CheckedChanged += new System.EventHandler(this.checkBox1FaturaAktif_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 24);
            this.label8.TabIndex = 0;
            this.label8.Text = "Cari Kod:";
            // 
            // txtCariKod
            // 
            this.txtCariKod.Enabled = false;
            this.txtCariKod.Location = new System.Drawing.Point(122, 108);
            this.txtCariKod.Name = "txtCariKod";
            this.txtCariKod.ReadOnly = true;
            this.txtCariKod.Size = new System.Drawing.Size(106, 28);
            this.txtCariKod.TabIndex = 2;
            // 
            // FrmTahsilat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(208)))), ((int)(((byte)(161)))));
            this.CancelButton = this.btnKapat;
            this.ClientSize = new System.Drawing.Size(898, 314);
            this.Controls.Add(this.checkBox1FaturaAktif);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtTutar);
            this.Controls.Add(this.dateTarih);
            this.Controls.Add(this.txtAciklama);
            this.Controls.Add(this.txtFaturaNo);
            this.Controls.Add(this.txtCariKod);
            this.Controls.Add(this.txtCariID);
            this.Controls.Add(this.txtTahsilatNo);
            this.Controls.Add(this.comboBoxNakit);
            this.Controls.Add(this.comboBoxBanka);
            this.Controls.Add(this.comboOdemeTuru);
            this.Controls.Add(this.labelAciklama);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblBanka);
            this.Controls.Add(this.lblNakit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTahsilat";
            this.ShowInTaskbar = false;
            this.Text = "Tahsilat Ekle";
            this.TransparencyKey = System.Drawing.Color.Lime;
            this.Load += new System.EventHandler(this.FrmTahsilat_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboOdemeTuru;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.DateTimePicker dateTarih;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Label labelAciklama;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTahsilatNo;
        private System.Windows.Forms.TextBox txtFaturaNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCariID;
        private System.Windows.Forms.Label lblNakit;
        private System.Windows.Forms.Label lblBanka;
        private System.Windows.Forms.ComboBox comboBoxBanka;
        private System.Windows.Forms.ComboBox comboBoxNakit;
        private System.Windows.Forms.TextBox txtTutar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnYeniKayit;
        private System.Windows.Forms.Button btnKapat;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.CheckBox checkBox1FaturaAktif;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCariKod;
    }
}