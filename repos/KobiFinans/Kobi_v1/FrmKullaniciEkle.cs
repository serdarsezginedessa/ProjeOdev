using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kobi_v1
{
    public partial class FrmKullaniciEkle : Form
    {
        public FrmKullaniciEkle()
        {
            InitializeComponent();
           
        }
        public string kad
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public string sifre
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }

        public string rol
        {
            get { return comboBox1.Text; }
            set { comboBox1.Text = value; }
        }
        public string buttonText
        {
            get { return btnEkle.Text; }
            set { btnEkle.Text = value; }
        }
        public object buttonImage
        {
            get { return btnEkle.Image; }
            set { btnEkle.Image = (Image)value; }
        }

        static string connectionString = ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);


        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void ekle()
        {
            try
            {
                if (string.IsNullOrEmpty(textBox1.Text.Trim()) && string.IsNullOrEmpty(textBox2.Text) && string.IsNullOrEmpty(txtEposta.Text) && string.IsNullOrEmpty(comboBox1.Text))
                {
                    MessageBox.Show("Lütfen Kullanıcı Adı, Şifre, Eposta ve Rol Seçiniz");
                    textBox1.Focus();
                    return;
                }
                
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                string sorgu = "insert into Kullanici (KullaniciAdi, Sifre, Eposta, Rol,Durum) values (@user,@pass,@eposta,@rol,@durum)";
                SqlCommand kmt = new SqlCommand(sorgu, baglanti);
                kmt.Parameters.AddWithValue("@user", textBox1.Text);
                kmt.Parameters.AddWithValue("@pass", textBox2.Text);
                kmt.Parameters.AddWithValue("@eposta", txtEposta.Text);
                kmt.Parameters.AddWithValue("@rol", comboBox1.Text);
                if(checkBoxAktif.Checked)
                {
                    kmt.Parameters.AddWithValue("@durum", 1);
                }
                else
                {
                    kmt.Parameters.AddWithValue("@durum", 0);
                }
                kmt.ExecuteNonQuery();
                MessageBox.Show("Kullanıcı Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
                textBox2.Clear();
                comboBox1.Text = "";
                txtEposta.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }
/*        public void guncelle()
        {
            try
            {
                FrmKullanicilar frmKullanicilar = new FrmKullanicilar();
                string id = frmKullanicilar.kullaniciID;
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                string sorgu = "update Kullanici set KullaniciAdi=@user, Sifre=@pass, Rol=@rol where KullaniciID=@Id";
                SqlCommand kmt = new SqlCommand(sorgu, baglanti);
                kmt.Parameters.AddWithValue("@user", textBox1.Text);
                kmt.Parameters.AddWithValue("@pass", textBox2.Text);
                kmt.Parameters.AddWithValue("@rol", comboBox1.Text);

                kmt.Parameters.AddWithValue("@Id", Convert.ToInt32(id));
                kmt.ExecuteNonQuery();
                MessageBox.Show("Kullanıcı Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
                textBox2.Clear();
                comboBox1.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }
*/        private void btnEkle_Click(object sender, EventArgs e)
        {
            ekle();

        }

        private void FrmKullaniciEkle_Load(object sender, EventArgs e)
        {

        }
    }
}
