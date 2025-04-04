namespace Kobi_v1
{
    partial class FrmCariListele
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.btnBorcAlacak = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btndelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCariAdd = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
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
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(975, 495);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.btnBorcAlacak);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btndelete);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnCariAdd);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(578, 93);
            this.panel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(120, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Cari Düzelt";
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Transparent;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnUpdate.ForeColor = System.Drawing.Color.Transparent;
            this.btnUpdate.Image = global::Kobi_v1.Properties.Resources.editUser;
            this.btnUpdate.Location = new System.Drawing.Point(133, 4);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(59, 51);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(513, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 24);
            this.label5.TabIndex = 0;
            this.label5.Text = "Yazdır";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(344, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Borç/Alacak İşlem";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.button3.ForeColor = System.Drawing.Color.Transparent;
            this.button3.Image = global::Kobi_v1.Properties.Resources.Print;
            this.button3.Location = new System.Drawing.Point(511, 4);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(59, 51);
            this.button3.TabIndex = 2;
            this.button3.Tag = "";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // btnBorcAlacak
            // 
            this.btnBorcAlacak.BackColor = System.Drawing.Color.Transparent;
            this.btnBorcAlacak.FlatAppearance.BorderSize = 0;
            this.btnBorcAlacak.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorcAlacak.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnBorcAlacak.ForeColor = System.Drawing.Color.Transparent;
            this.btnBorcAlacak.Image = global::Kobi_v1.Properties.Resources.Exchange;
            this.btnBorcAlacak.Location = new System.Drawing.Point(381, 4);
            this.btnBorcAlacak.Margin = new System.Windows.Forms.Padding(4);
            this.btnBorcAlacak.Name = "btnBorcAlacak";
            this.btnBorcAlacak.Size = new System.Drawing.Size(59, 51);
            this.btnBorcAlacak.TabIndex = 2;
            this.btnBorcAlacak.Tag = "";
            this.btnBorcAlacak.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBorcAlacak.UseVisualStyleBackColor = false;
            this.btnBorcAlacak.Click += new System.EventHandler(this.btnBorcAlacak_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(246, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Cari Sil";
            // 
            // btndelete
            // 
            this.btndelete.BackColor = System.Drawing.Color.Transparent;
            this.btndelete.FlatAppearance.BorderSize = 0;
            this.btndelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btndelete.ForeColor = System.Drawing.Color.Transparent;
            this.btndelete.Image = global::Kobi_v1.Properties.Resources.DeleteUser;
            this.btndelete.Location = new System.Drawing.Point(243, 4);
            this.btndelete.Margin = new System.Windows.Forms.Padding(4);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(59, 51);
            this.btndelete.TabIndex = 2;
            this.btndelete.Tag = "";
            this.btndelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btndelete.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cari Ekle";
            // 
            // btnCariAdd
            // 
            this.btnCariAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnCariAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCariAdd.FlatAppearance.BorderSize = 0;
            this.btnCariAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCariAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnCariAdd.ForeColor = System.Drawing.Color.Transparent;
            this.btnCariAdd.Image = global::Kobi_v1.Properties.Resources.Add_User_Male;
            this.btnCariAdd.Location = new System.Drawing.Point(18, 4);
            this.btnCariAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnCariAdd.Name = "btnCariAdd";
            this.btnCariAdd.Size = new System.Drawing.Size(61, 51);
            this.btnCariAdd.TabIndex = 3;
            this.btnCariAdd.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCariAdd.UseVisualStyleBackColor = false;
            this.btnCariAdd.Click += new System.EventHandler(this.btnCariAdd_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Image = global::Kobi_v1.Properties.Resources.Close;
            this.button1.Location = new System.Drawing.Point(921, 4);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 51);
            this.button1.TabIndex = 4;
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(12, 112);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(975, 495);
            this.panel2.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(597, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 24);
            this.label6.TabIndex = 2;
            this.label6.Text = "label6";
            // 
            // FrmCariListele
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(208)))), ((int)(((byte)(161)))));
            this.ClientSize = new System.Drawing.Size(1000, 619);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCariListele";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cari Listesi";
            this.Load += new System.EventHandler(this.FrmCariListele_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnCariAdd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBorcAlacak;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label6;
    }
}