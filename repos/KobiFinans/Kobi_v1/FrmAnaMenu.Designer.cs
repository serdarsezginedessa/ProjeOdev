namespace Kobi_v1
{
    partial class FrmAnaMenu
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
            this.btnKullaniciYonetimi = new System.Windows.Forms.Button();
            this.btnKasaHareketleri = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnKullaniciYonetimi
            // 
            this.btnKullaniciYonetimi.Location = new System.Drawing.Point(721, 13);
            this.btnKullaniciYonetimi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnKullaniciYonetimi.Name = "btnKullaniciYonetimi";
            this.btnKullaniciYonetimi.Size = new System.Drawing.Size(150, 39);
            this.btnKullaniciYonetimi.TabIndex = 0;
            this.btnKullaniciYonetimi.Text = "Kullanıcı Yönetimi";
            this.btnKullaniciYonetimi.UseVisualStyleBackColor = true;
            // 
            // btnKasaHareketleri
            // 
            this.btnKasaHareketleri.Location = new System.Drawing.Point(563, 13);
            this.btnKasaHareketleri.Margin = new System.Windows.Forms.Padding(4);
            this.btnKasaHareketleri.Name = "btnKasaHareketleri";
            this.btnKasaHareketleri.Size = new System.Drawing.Size(150, 39);
            this.btnKasaHareketleri.TabIndex = 0;
            this.btnKasaHareketleri.Text = "Kasa Hareketleri";
            this.btnKasaHareketleri.UseVisualStyleBackColor = true;
            this.btnKasaHareketleri.Click += new System.EventHandler(this.btnKasaHareketleri_Click);
            // 
            // FrmAnaMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.btnKasaHareketleri);
            this.Controls.Add(this.btnKullaniciYonetimi);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmAnaMenu";
            this.Text = "FrmAnaMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnKullaniciYonetimi;
        private System.Windows.Forms.Button btnKasaHareketleri;
    }
}