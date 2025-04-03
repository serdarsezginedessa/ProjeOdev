using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kobi_v1
{
    public partial class FrmAyarlar : Form
    {
        public FrmAyarlar()
        {
            InitializeComponent();
        }
        private void LoadFormIntoPanel(Form form, SplitContainer splitContainer)
        {
            // Önceki kontrolleri temizle
            splitContainer.Panel2.Controls.Clear();

            // Yeni formun özelliklerini ayarla
            form.TopLevel = false; // Form'u bir kontrol gibi yap
            form.Dock = DockStyle.Fill; // Tam paneli kaplasın
            form.FormBorderStyle = FormBorderStyle.None;

            // Panel2'ye ekle
            splitContainer.Panel2.Controls.Add(form);

            // Formu göster
            form.Show();
        }

        private void FrmAyarlar_Load(object sender, EventArgs e)
        {
            Form frm2 = new Form();
            Label lbl = new Label();
            lbl.Text = "AYARLAR MENÜSÜ";
            lbl.Font = new Font("Arial", 12, FontStyle.Bold);
            lbl.ForeColor = Color.Red;
            lbl.Location = new Point(100, 10);
            lbl.Size = new Size(200, 100);
            frm2.Controls.Add(lbl);

            LoadFormIntoPanel(frm2, splitContainer1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm1 = new FrmCariTur(); // Yüklemek istediğiniz form
            LoadFormIntoPanel(frm1, splitContainer1);
        }

        

        private void btnGelirGiderT_Click(object sender, EventArgs e)
        {
            Form frm2 = new FrmGelirGiderTipi(); // Yüklemek istediğiniz form
            LoadFormIntoPanel(frm2, splitContainer1);
        }

        private void btnKasa_Click(object sender, EventArgs e)
        {
            Form frm3 = new FrmKasa(); // Yüklemek istediğiniz form
            LoadFormIntoPanel(frm3, splitContainer1);
        }

        private void FormOlustur()
        {
            Form frmBanka = new Form(); // Yüklemek istediğiniz form
            int r = 252;
            int g = 208;
            int b = 161;
            frmBanka.Text = "Banka Ekle";
            frmBanka.BackColor = Color.FromArgb(r, g, b);
            frmBanka.Size = new Size(825, 499);
            frmBanka.StartPosition = FormStartPosition.CenterScreen;
            frmBanka.FormBorderStyle = FormBorderStyle.FixedSingle;
            frmBanka.MaximizeBox = false;
            frmBanka.MinimizeBox = false;
            frmBanka.ShowInTaskbar = false;
            frmBanka.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold);
            frmBanka.Icon = new Icon(Application.StartupPath + "\\Bank.ico");

            Label lbl = new Label();
            lbl.Text = "Banka Adı: ";
            lbl.Location = new Point(50, 50);
            lbl.Size = new Size(100, 30);
            frmBanka.Controls.Add(lbl);
            Label lbl2 = new Label();
            lbl2.Text = "Şube: ";
            lbl2.Location = new Point(50, 100);
            lbl2.Size = new Size(100, 30);
            frmBanka.Controls.Add(lbl2);
            Label lbl3 = new Label();
            lbl3.Text = "Hesap No: ";
            lbl3.Location = new Point(50, 150);
            lbl3.Size = new Size(100, 30);
            frmBanka.Controls.Add(lbl3);
            Label lbl4 = new Label();
            lbl4.Text = "IBAN: ";
            lbl4.Location = new Point(50, 200);
            lbl4.Size = new Size(100, 30);
            frmBanka.Controls.Add(lbl4);
            Label lbl5 = new Label();
            lbl5.Text = "Tarih: ";
            lbl5.Location = new Point(50, 250);
            lbl5.Size = new Size(100, 30);
            frmBanka.Controls.Add(lbl5);
            TextBox txt1 = new TextBox();
            txt1.Location = new Point(150, 50);
            txt1.Size = new Size(200, 30);
            frmBanka.Controls.Add(txt1);
            TextBox txt2 = new TextBox();
            txt2.Location = new Point(150, 100);
            txt2.Size = new Size(200, 30);
            frmBanka.Controls.Add(txt2);
            TextBox txt3 = new TextBox();
            txt3.Location = new Point(150, 150);
            txt3.Size = new Size(200, 30);
            frmBanka.Controls.Add(txt3);
            TextBox txt4 = new TextBox();
            txt4.Location = new Point(150, 200);
            txt4.Size = new Size(200, 30);
            frmBanka.Controls.Add(txt4);
            DateTimePicker dtp = new DateTimePicker();
            dtp.Location = new Point(150, 250);
            dtp.Size = new Size(200, 30);
            frmBanka.Controls.Add(dtp);
            Button btn = new Button();
            btn.Text = "Kaydet";
            btn.Location = new Point(150, 300);
            btn.Size = new Size(100, 30);
            frmBanka.Controls.Add(btn);
            btn.Click += new EventHandler(btn_Click);
            void btn_Click(object sender, EventArgs e)
            {
                MessageBox.Show("Banka Eklendi");
            }



            LoadFormIntoPanel(frmBanka, splitContainer1);
        }
        private void btnBanka_Click(object sender, EventArgs e)
        {
            
        }
    }
}
