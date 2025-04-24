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
            this.labelMusteri = new System.Windows.Forms.Label();
            this.lbltoplamTutar = new System.Windows.Forms.Label();
            this.comboOdemeTuru = new System.Windows.Forms.ComboBox();
            this.txtTutar = new System.Windows.Forms.TextBox();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.dateTarih = new System.Windows.Forms.DateTimePicker();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.labelOdemeTutar = new System.Windows.Forms.Label();
            this.labelAciklama = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelMusteri
            // 
            this.labelMusteri.AutoSize = true;
            this.labelMusteri.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelMusteri.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(182)))), ((int)(((byte)(149)))));
            this.labelMusteri.Location = new System.Drawing.Point(169, 9);
            this.labelMusteri.Name = "labelMusteri";
            this.labelMusteri.Size = new System.Drawing.Size(151, 29);
            this.labelMusteri.TabIndex = 0;
            this.labelMusteri.Text = "Müşteri Adı:";
            // 
            // lbltoplamTutar
            // 
            this.lbltoplamTutar.AutoSize = true;
            this.lbltoplamTutar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbltoplamTutar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(26)))), ((int)(((byte)(54)))));
            this.lbltoplamTutar.Location = new System.Drawing.Point(154, 49);
            this.lbltoplamTutar.Name = "lbltoplamTutar";
            this.lbltoplamTutar.Size = new System.Drawing.Size(181, 29);
            this.lbltoplamTutar.TabIndex = 0;
            this.lbltoplamTutar.Text = "Satış Toplamı:";
            // 
            // comboOdemeTuru
            // 
            this.comboOdemeTuru.FormattingEnabled = true;
            this.comboOdemeTuru.Location = new System.Drawing.Point(214, 94);
            this.comboOdemeTuru.Name = "comboOdemeTuru";
            this.comboOdemeTuru.Size = new System.Drawing.Size(100, 26);
            this.comboOdemeTuru.TabIndex = 1;
            this.comboOdemeTuru.Text = "Ödeme Türü";
            // 
            // txtTutar
            // 
            this.txtTutar.Location = new System.Drawing.Point(214, 126);
            this.txtTutar.Name = "txtTutar";
            this.txtTutar.Size = new System.Drawing.Size(100, 24);
            this.txtTutar.TabIndex = 2;
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(129, 248);
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(206, 102);
            this.txtAciklama.TabIndex = 3;
            // 
            // dateTarih
            // 
            this.dateTarih.Location = new System.Drawing.Point(129, 167);
            this.dateTarih.Name = "dateTarih";
            this.dateTarih.Size = new System.Drawing.Size(206, 24);
            this.dateTarih.TabIndex = 4;
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(83)))), ((int)(((byte)(91)))));
            this.btnKaydet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydet.ForeColor = System.Drawing.Color.Transparent;
            this.btnKaydet.Image = global::Kobi_v1.Properties.Resources.Add_File36px1;
            this.btnKaydet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKaydet.Location = new System.Drawing.Point(129, 356);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(100, 42);
            this.btnKaydet.TabIndex = 23;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(83)))), ((int)(((byte)(91)))));
            this.btnIptal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnIptal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnIptal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIptal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnIptal.ForeColor = System.Drawing.Color.Transparent;
            this.btnIptal.Image = global::Kobi_v1.Properties.Resources.Close_Pane3px;
            this.btnIptal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIptal.Location = new System.Drawing.Point(235, 356);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(100, 42);
            this.btnIptal.TabIndex = 24;
            this.btnIptal.Text = "Kapat";
            this.btnIptal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIptal.UseVisualStyleBackColor = false;
            // 
            // labelOdemeTutar
            // 
            this.labelOdemeTutar.AutoSize = true;
            this.labelOdemeTutar.Location = new System.Drawing.Point(106, 129);
            this.labelOdemeTutar.Name = "labelOdemeTutar";
            this.labelOdemeTutar.Size = new System.Drawing.Size(102, 18);
            this.labelOdemeTutar.TabIndex = 0;
            this.labelOdemeTutar.Text = "Ödeme Tutarı:";
            // 
            // labelAciklama
            // 
            this.labelAciklama.AutoSize = true;
            this.labelAciklama.Location = new System.Drawing.Point(126, 227);
            this.labelAciklama.Name = "labelAciklama";
            this.labelAciklama.Size = new System.Drawing.Size(68, 18);
            this.labelAciklama.TabIndex = 0;
            this.labelAciklama.Text = "Açıklama";
            // 
            // FrmTahsilat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(208)))), ((int)(((byte)(161)))));
            this.ClientSize = new System.Drawing.Size(488, 481);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.dateTarih);
            this.Controls.Add(this.txtAciklama);
            this.Controls.Add(this.txtTutar);
            this.Controls.Add(this.comboOdemeTuru);
            this.Controls.Add(this.lbltoplamTutar);
            this.Controls.Add(this.labelAciklama);
            this.Controls.Add(this.labelOdemeTutar);
            this.Controls.Add(this.labelMusteri);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmTahsilat";
            this.Text = "FrmTahsilat";
            this.Load += new System.EventHandler(this.FrmTahsilat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMusteri;
        private System.Windows.Forms.Label lbltoplamTutar;
        private System.Windows.Forms.ComboBox comboOdemeTuru;
        private System.Windows.Forms.TextBox txtTutar;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.DateTimePicker dateTarih;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnIptal;
        private System.Windows.Forms.Label labelOdemeTutar;
        private System.Windows.Forms.Label labelAciklama;
    }
}