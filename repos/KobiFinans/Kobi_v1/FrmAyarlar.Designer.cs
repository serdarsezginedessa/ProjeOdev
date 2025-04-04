namespace Kobi_v1
{
    partial class FrmAyarlar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAyarlar));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnKategori = new System.Windows.Forms.Button();
            this.btnBanka = new System.Windows.Forms.Button();
            this.btnKasa = new System.Windows.Forms.Button();
            this.btnGelirGiderT = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(182)))), ((int)(((byte)(149)))));
            this.splitContainer1.Panel1.Controls.Add(this.btnKategori);
            this.splitContainer1.Panel1.Controls.Add(this.btnBanka);
            this.splitContainer1.Panel1.Controls.Add(this.btnKasa);
            this.splitContainer1.Panel1.Controls.Add(this.btnGelirGiderT);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Size = new System.Drawing.Size(838, 461);
            this.splitContainer1.SplitterDistance = 204;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnKategori
            // 
            this.btnKategori.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnKategori.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKategori.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(26)))), ((int)(((byte)(54)))));
            this.btnKategori.Image = global::Kobi_v1.Properties.Resources.Bank_Building;
            this.btnKategori.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKategori.Location = new System.Drawing.Point(4, 231);
            this.btnKategori.Name = "btnKategori";
            this.btnKategori.Size = new System.Drawing.Size(197, 49);
            this.btnKategori.TabIndex = 0;
            this.btnKategori.Text = "Urun Kategori Ekle";
            this.btnKategori.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKategori.UseVisualStyleBackColor = true;
            this.btnKategori.Click += new System.EventHandler(this.btnGelirGiderT_Click);
            // 
            // btnBanka
            // 
            this.btnBanka.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBanka.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBanka.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(26)))), ((int)(((byte)(54)))));
            this.btnBanka.Image = global::Kobi_v1.Properties.Resources.Bank_Building;
            this.btnBanka.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBanka.Location = new System.Drawing.Point(3, 176);
            this.btnBanka.Name = "btnBanka";
            this.btnBanka.Size = new System.Drawing.Size(197, 49);
            this.btnBanka.TabIndex = 0;
            this.btnBanka.Text = "Banka Ekle";
            this.btnBanka.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBanka.UseVisualStyleBackColor = true;
            this.btnBanka.Click += new System.EventHandler(this.btnBanka_Click);
            // 
            // btnKasa
            // 
            this.btnKasa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnKasa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKasa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(26)))), ((int)(((byte)(54)))));
            this.btnKasa.Image = global::Kobi_v1.Properties.Resources.kasa;
            this.btnKasa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKasa.Location = new System.Drawing.Point(3, 121);
            this.btnKasa.Name = "btnKasa";
            this.btnKasa.Size = new System.Drawing.Size(197, 49);
            this.btnKasa.TabIndex = 0;
            this.btnKasa.Text = "Kasa Ekle";
            this.btnKasa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKasa.UseVisualStyleBackColor = true;
            this.btnKasa.Click += new System.EventHandler(this.btnKasa_Click);
            // 
            // btnGelirGiderT
            // 
            this.btnGelirGiderT.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGelirGiderT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGelirGiderT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(26)))), ((int)(((byte)(54)))));
            this.btnGelirGiderT.Image = global::Kobi_v1.Properties.Resources.Add;
            this.btnGelirGiderT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGelirGiderT.Location = new System.Drawing.Point(4, 66);
            this.btnGelirGiderT.Name = "btnGelirGiderT";
            this.btnGelirGiderT.Size = new System.Drawing.Size(197, 49);
            this.btnGelirGiderT.TabIndex = 0;
            this.btnGelirGiderT.Text = "Gelir Gider Türü";
            this.btnGelirGiderT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGelirGiderT.UseVisualStyleBackColor = true;
            this.btnGelirGiderT.Click += new System.EventHandler(this.btnGelirGiderT_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(26)))), ((int)(((byte)(54)))));
            this.button1.Image = global::Kobi_v1.Properties.Resources.User_Groups;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(3, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(197, 49);
            this.button1.TabIndex = 0;
            this.button1.Text = "Cari Türü Ekle";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmAyarlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(208)))), ((int)(((byte)(161)))));
            this.ClientSize = new System.Drawing.Size(838, 461);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAyarlar";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ayarlar";
            this.Load += new System.EventHandler(this.FrmAyarlar_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnGelirGiderT;
        private System.Windows.Forms.Button btnKasa;
        private System.Windows.Forms.Button btnBanka;
        private System.Windows.Forms.Button btnKategori;
    }
}