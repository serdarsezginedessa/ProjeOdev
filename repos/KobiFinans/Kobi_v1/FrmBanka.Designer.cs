namespace Kobi_v1
{
    partial class FrmBanka
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBanka));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBankaAdi = new System.Windows.Forms.TextBox();
            this.txtSubeAdi = new System.Windows.Forms.TextBox();
            this.txtHesapNo = new System.Windows.Forms.TextBox();
            this.txtIban = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBankaAra = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btniptal = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnYeniKayit = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Banka Adı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Şube Adı:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Hesap No:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "IBAN:";
            // 
            // txtBankaAdi
            // 
            this.txtBankaAdi.Location = new System.Drawing.Point(126, 64);
            this.txtBankaAdi.Name = "txtBankaAdi";
            this.txtBankaAdi.Size = new System.Drawing.Size(268, 28);
            this.txtBankaAdi.TabIndex = 1;
            // 
            // txtSubeAdi
            // 
            this.txtSubeAdi.Location = new System.Drawing.Point(126, 103);
            this.txtSubeAdi.Name = "txtSubeAdi";
            this.txtSubeAdi.Size = new System.Drawing.Size(268, 28);
            this.txtSubeAdi.TabIndex = 1;
            // 
            // txtHesapNo
            // 
            this.txtHesapNo.Location = new System.Drawing.Point(126, 145);
            this.txtHesapNo.Name = "txtHesapNo";
            this.txtHesapNo.Size = new System.Drawing.Size(268, 28);
            this.txtHesapNo.TabIndex = 1;
            // 
            // txtIban
            // 
            this.txtIban.Location = new System.Drawing.Point(126, 190);
            this.txtIban.Name = "txtIban";
            this.txtIban.Size = new System.Drawing.Size(268, 28);
            this.txtIban.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBankaAra);
            this.groupBox1.Controls.Add(this.btnSil);
            this.groupBox1.Controls.Add(this.btniptal);
            this.groupBox1.Controls.Add(this.btnGuncelle);
            this.groupBox1.Controls.Add(this.btnYeniKayit);
            this.groupBox1.Controls.Add(this.btnEkle);
            this.groupBox1.Location = new System.Drawing.Point(400, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(154, 394);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // btnBankaAra
            // 
            this.btnBankaAra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(208)))), ((int)(((byte)(161)))));
            this.btnBankaAra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBankaAra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBankaAra.Image = global::Kobi_v1.Properties.Resources.Search_More;
            this.btnBankaAra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBankaAra.Location = new System.Drawing.Point(6, 16);
            this.btnBankaAra.Name = "btnBankaAra";
            this.btnBankaAra.Size = new System.Drawing.Size(139, 53);
            this.btnBankaAra.TabIndex = 15;
            this.btnBankaAra.Text = "Banka Ara";
            this.btnBankaAra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBankaAra.UseVisualStyleBackColor = false;
            this.btnBankaAra.Click += new System.EventHandler(this.btnBankaAra_Click);
            // 
            // btnSil
            // 
            this.btnSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSil.Image = global::Kobi_v1.Properties.Resources.DeleteUser;
            this.btnSil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSil.Location = new System.Drawing.Point(7, 256);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(139, 56);
            this.btnSil.TabIndex = 2;
            this.btnSil.Text = "Sil";
            this.btnSil.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btniptal
            // 
            this.btniptal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btniptal.Image = global::Kobi_v1.Properties.Resources.clear;
            this.btniptal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btniptal.Location = new System.Drawing.Point(6, 318);
            this.btniptal.Name = "btniptal";
            this.btniptal.Size = new System.Drawing.Size(139, 56);
            this.btniptal.TabIndex = 3;
            this.btniptal.Text = "İptal";
            this.btniptal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btniptal.UseVisualStyleBackColor = true;
            this.btniptal.Click += new System.EventHandler(this.btniptal_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuncelle.Image = global::Kobi_v1.Properties.Resources.editUser;
            this.btnGuncelle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuncelle.Location = new System.Drawing.Point(7, 194);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(139, 56);
            this.btnGuncelle.TabIndex = 1;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnYeniKayit
            // 
            this.btnYeniKayit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYeniKayit.Image = global::Kobi_v1.Properties.Resources.Add_User_Male;
            this.btnYeniKayit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnYeniKayit.Location = new System.Drawing.Point(6, 75);
            this.btnYeniKayit.Name = "btnYeniKayit";
            this.btnYeniKayit.Size = new System.Drawing.Size(139, 53);
            this.btnYeniKayit.TabIndex = 0;
            this.btnYeniKayit.Text = "Yeni Kayıt";
            this.btnYeniKayit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnYeniKayit.UseVisualStyleBackColor = true;
            this.btnYeniKayit.Click += new System.EventHandler(this.btnYeniKayit_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEkle.Image = global::Kobi_v1.Properties.Resources.Add_User_Male;
            this.btnEkle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEkle.Location = new System.Drawing.Point(7, 135);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(139, 53);
            this.btnEkle.TabIndex = 0;
            this.btnEkle.Text = "Kaydet";
            this.btnEkle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 24);
            this.label5.TabIndex = 0;
            this.label5.Text = "Banka ID";
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(126, 30);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(41, 28);
            this.txtID.TabIndex = 1;
            // 
            // FrmBanka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(208)))), ((int)(((byte)(161)))));
            this.ClientSize = new System.Drawing.Size(559, 418);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtIban);
            this.Controls.Add(this.txtHesapNo);
            this.Controls.Add(this.txtSubeAdi);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtBankaAdi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmBanka";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Banka";
            this.Load += new System.EventHandler(this.FrmBanka_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBankaAdi;
        private System.Windows.Forms.TextBox txtSubeAdi;
        private System.Windows.Forms.TextBox txtHesapNo;
        private System.Windows.Forms.TextBox txtIban;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btniptal;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnYeniKayit;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnBankaAra;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtID;
    }
}