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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cariToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cariListeleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kasaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kasaListesiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bankaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bankaListesiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cariToolStripMenuItem,
            this.kasaToolStripMenuItem,
            this.bankaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.kasaToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.ShowItemToolTips = true;
            this.menuStrip1.Size = new System.Drawing.Size(1200, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cariToolStripMenuItem
            // 
            this.cariToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cariListeleriToolStripMenuItem});
            this.cariToolStripMenuItem.Name = "cariToolStripMenuItem";
            this.cariToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.cariToolStripMenuItem.Text = "Cari";
            // 
            // cariListeleriToolStripMenuItem
            // 
            this.cariListeleriToolStripMenuItem.Name = "cariListeleriToolStripMenuItem";
            this.cariListeleriToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.cariListeleriToolStripMenuItem.Text = "Cari Listeleri";
            this.cariListeleriToolStripMenuItem.Click += new System.EventHandler(this.cariListeleriToolStripMenuItem_Click);
            // 
            // kasaToolStripMenuItem
            // 
            this.kasaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kasaListesiToolStripMenuItem});
            this.kasaToolStripMenuItem.Name = "kasaToolStripMenuItem";
            this.kasaToolStripMenuItem.Size = new System.Drawing.Size(54, 24);
            this.kasaToolStripMenuItem.Text = "Kasa";
            // 
            // kasaListesiToolStripMenuItem
            // 
            this.kasaListesiToolStripMenuItem.Name = "kasaListesiToolStripMenuItem";
            this.kasaListesiToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.kasaListesiToolStripMenuItem.Text = "Kasa Listesi";
            // 
            // bankaToolStripMenuItem
            // 
            this.bankaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bankaListesiToolStripMenuItem});
            this.bankaToolStripMenuItem.Name = "bankaToolStripMenuItem";
            this.bankaToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
            this.bankaToolStripMenuItem.Text = "Banka";
            // 
            // bankaListesiToolStripMenuItem
            // 
            this.bankaListesiToolStripMenuItem.Name = "bankaListesiToolStripMenuItem";
            this.bankaListesiToolStripMenuItem.Size = new System.Drawing.Size(176, 26);
            this.bankaListesiToolStripMenuItem.Text = "Banka Listesi";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(208)))), ((int)(((byte)(161)))));
            this.ClientSize = new System.Drawing.Size(1200, 623);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kobi Finans";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem bankaListesiToolStripMenuItem;
    }
}

