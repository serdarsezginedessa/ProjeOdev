﻿namespace Kobi_v1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmKasaHareketleri));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblGelirTop = new System.Windows.Forms.Label();
            this.lblGiderTop = new System.Windows.Forms.Label();
            this.lblGenelTop = new System.Windows.Forms.Label();
            this.txtGelirTop = new System.Windows.Forms.TextBox();
            this.txtGiderTop = new System.Windows.Forms.TextBox();
            this.txtGenelTop = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(882, 458);
            this.dataGridView1.TabIndex = 0;
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
            // txtGelirTop
            // 
            this.txtGelirTop.Enabled = false;
            this.txtGelirTop.Location = new System.Drawing.Point(171, 10);
            this.txtGelirTop.Name = "txtGelirTop";
            this.txtGelirTop.Size = new System.Drawing.Size(100, 28);
            this.txtGelirTop.TabIndex = 8;
            // 
            // txtGiderTop
            // 
            this.txtGiderTop.Enabled = false;
            this.txtGiderTop.Location = new System.Drawing.Point(460, 10);
            this.txtGiderTop.Name = "txtGiderTop";
            this.txtGiderTop.Size = new System.Drawing.Size(100, 28);
            this.txtGiderTop.TabIndex = 8;
            // 
            // txtGenelTop
            // 
            this.txtGenelTop.Enabled = false;
            this.txtGenelTop.Location = new System.Drawing.Point(750, 10);
            this.txtGenelTop.Name = "txtGenelTop";
            this.txtGenelTop.Size = new System.Drawing.Size(100, 28);
            this.txtGenelTop.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(1, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(882, 458);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.lblGelirTop);
            this.panel2.Controls.Add(this.txtGelirTop);
            this.panel2.Controls.Add(this.txtGenelTop);
            this.panel2.Controls.Add(this.lblGiderTop);
            this.panel2.Controls.Add(this.lblGenelTop);
            this.panel2.Controls.Add(this.txtGiderTop);
            this.panel2.Location = new System.Drawing.Point(1, 504);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(882, 54);
            this.panel2.TabIndex = 10;
            // 
            // FrmKasaHareketleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(208)))), ((int)(((byte)(161)))));
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmKasaHareketleri";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kasa Raporu";
            this.Load += new System.EventHandler(this.FrmKasaHareketleri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblGelirTop;
        private System.Windows.Forms.Label lblGiderTop;
        private System.Windows.Forms.Label lblGenelTop;
        private System.Windows.Forms.TextBox txtGelirTop;
        private System.Windows.Forms.TextBox txtGiderTop;
        private System.Windows.Forms.TextBox txtGenelTop;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}