using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Kobi_v1
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        static string connectionString=ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);

        string rol;

        public static string kullaniciAdi { get; set; }
        public static string rolOku {  get; set; }
        int hak = 3;
        
        private void btnGiris_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtKullaniciAdi.Text.Trim())  || string.IsNullOrEmpty(txtSifre.Text.Trim()))
            {
                MessageBox.Show("Lütfen Kullanıcı Adı ve Şifre Giriniz");
                txtKullaniciAdi.Focus();
                return;
            }

            if (baglanti.State == ConnectionState.Closed)baglanti.Open();

            string sorgu ="Select Rol from Kullanici where KullaniciAdi=@KullaniciAdi and Sifre=@Sifre";
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@KullaniciAdi",txtKullaniciAdi.Text);
            komut.Parameters.AddWithValue("@Sifre",txtSifre.Text);

            kullaniciAdi = txtKullaniciAdi.Text;

            var result = komut.ExecuteScalar();
            
            if(result != null)
            {
                rolOku = result.ToString();
                rol = result.ToString();
                if (rol == "Admin")
                MessageBox.Show("Yönetici Olarak Oturum Açtınız","Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (rol == "Kullanici")
                    MessageBox.Show("Kullanıcı Olarak Oturum Açtınız", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                /*FrmAnaMenu anaMenu = new FrmAnaMenu(rol);
                anaMenu.ShowDialog();*/
                Form1 frm1 = new Form1();
                frm1.ShowDialog();
                this.Close();

}
            else
            {
                if (hak == 1)
                {
                    MessageBox.Show("3 Hakkınız Dolmuştur. Program Kapatılacaktır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("Kullanıcı Adı veya Şifre Yanlış", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtKullaniciAdi.Clear();
                    txtSifre.Clear();
                    txtKullaniciAdi.Focus();
                    hak--;
                    lblHak.Text = "' " + hak.ToString() + " '";
                    return;
                }
                
            }
            
        }

        private void btn_iptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            lblHak.Text = "' " + hak.ToString()+" '";

        }

        private void label3_Click(object sender, EventArgs e)
        {
            FrmKullaniciSifreUnuttum frmKullaniciSifreUnuttum = new FrmKullaniciSifreUnuttum();
            frmKullaniciSifreUnuttum.ShowDialog();
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            FrmKullaniciEkle frmKullaniciEkle = new FrmKullaniciEkle();
            frmKullaniciEkle.ShowDialog();
        }
    }
}
