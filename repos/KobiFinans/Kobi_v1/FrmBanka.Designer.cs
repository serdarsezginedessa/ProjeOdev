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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBankaAra = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btniptal = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnYeniKayit = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Banka Adı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Şube Adı:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Hesap No:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "IBAN:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(102, 64);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(268, 24);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(102, 103);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(268, 24);
            this.textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(102, 145);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(268, 24);
            this.textBox3.TabIndex = 1;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(102, 190);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(268, 24);
            this.textBox4.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSil);
            this.groupBox1.Controls.Add(this.btniptal);
            this.groupBox1.Controls.Add(this.btnGuncelle);
            this.groupBox1.Controls.Add(this.btnYeniKayit);
            this.groupBox1.Controls.Add(this.btnEkle);
            this.groupBox1.Location = new System.Drawing.Point(831, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(154, 329);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // btnBankaAra
            // 
            this.btnBankaAra.FlatAppearance.BorderSize = 0;
            this.btnBankaAra.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBankaAra.Image = global::Kobi_v1.Properties.Resources.Bank_Building1;
            this.btnBankaAra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBankaAra.Location = new System.Drawing.Point(376, 64);
            this.btnBankaAra.Name = "btnBankaAra";
            this.btnBankaAra.Size = new System.Drawing.Size(68, 24);
            this.btnBankaAra.TabIndex = 15;
            this.btnBankaAra.Text = "Ara";
            this.btnBankaAra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBankaAra.UseVisualStyleBackColor = true;
            this.btnBankaAra.Click += new System.EventHandler(this.btnBankaAra_Click);
            // 
            // btnSil
            // 
            this.btnSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSil.Image = global::Kobi_v1.Properties.Resources.DeleteUser;
            this.btnSil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSil.Location = new System.Drawing.Point(7, 200);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(139, 56);
            this.btnSil.TabIndex = 2;
            this.btnSil.Text = "Sil";
            this.btnSil.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSil.UseVisualStyleBackColor = true;
            // 
            // btniptal
            // 
            this.btniptal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btniptal.Image = global::Kobi_v1.Properties.Resources.clear;
            this.btniptal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btniptal.Location = new System.Drawing.Point(6, 262);
            this.btniptal.Name = "btniptal";
            this.btniptal.Size = new System.Drawing.Size(139, 56);
            this.btniptal.TabIndex = 3;
            this.btniptal.Text = "İptal";
            this.btniptal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btniptal.UseVisualStyleBackColor = true;
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuncelle.Image = global::Kobi_v1.Properties.Resources.editUser;
            this.btnGuncelle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuncelle.Location = new System.Drawing.Point(7, 138);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(139, 56);
            this.btnGuncelle.TabIndex = 1;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuncelle.UseVisualStyleBackColor = true;
            // 
            // btnYeniKayit
            // 
            this.btnYeniKayit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYeniKayit.Image = global::Kobi_v1.Properties.Resources.Add_User_Male;
            this.btnYeniKayit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnYeniKayit.Location = new System.Drawing.Point(6, 19);
            this.btnYeniKayit.Name = "btnYeniKayit";
            this.btnYeniKayit.Size = new System.Drawing.Size(139, 53);
            this.btnYeniKayit.TabIndex = 0;
            this.btnYeniKayit.Text = "Yeni Kayıt";
            this.btnYeniKayit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnYeniKayit.UseVisualStyleBackColor = true;
            // 
            // btnEkle
            // 
            this.btnEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEkle.Image = global::Kobi_v1.Properties.Resources.Add_User_Male;
            this.btnEkle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEkle.Location = new System.Drawing.Point(7, 79);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(139, 53);
            this.btnEkle.TabIndex = 0;
            this.btnEkle.Text = "Kaydet";
            this.btnEkle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEkle.UseVisualStyleBackColor = true;
            // 
            // FrmBanka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(208)))), ((int)(((byte)(161)))));
            this.ClientSize = new System.Drawing.Size(997, 390);
            this.Controls.Add(this.btnBankaAra);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmBanka";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmBanka";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btniptal;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnYeniKayit;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnBankaAra;
    }
}