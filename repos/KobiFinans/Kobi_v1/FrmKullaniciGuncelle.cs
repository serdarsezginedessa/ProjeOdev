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
    public partial class FrmKullaniciGuncelle : Form
    {
        public FrmKullaniciGuncelle()
        {
            InitializeComponent();
        }
        static string connectionString = ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);
        public string kad
        {
            get { return txtKad.Text; }
            set { txtKad.Text = value; }
        }

        public string sifre
        {
            get { return txtYeniSifre.Text; }
            set { txtYeniSifre.Text = value; }
        }


        public string buttonText
        {
            get { return btnGuncelle.Text; }
            set { btnGuncelle.Text = value; }
        }
        public object buttonImage
        {
            get { return btnGuncelle.Image; }
            set { btnGuncelle.Image = (Image)value; }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtKad.Text.Trim()))
                {
                    MessageBox.Show("Lütfen Kullanıcı Adını Giriniz");
                    txtKad.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtEposta.Text.Trim()))
                {
                    MessageBox.Show("Lütfen Epostayı Giriniz");
                    txtEposta.Focus();

                }
                if (string.IsNullOrEmpty(txtYeniSifre.Text.Trim()))
                {
                    MessageBox.Show("Lütfen Yeni Şifreyi Giriniz");
                    txtYeniSifre.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtYeniSifreTekrar.Text.Trim()))
                {
                    MessageBox.Show("Lütfen Yeni Şifreyi Tekrar Giriniz");
                    txtYeniSifreTekrar.Focus();
                    return;
                }
                if (txtYeniSifre.Text != txtYeniSifreTekrar.Text)
                {
                    MessageBox.Show("Şifreler Uyuşmuyor Lütfen Kontrol Edin", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtYeniSifre.Clear();
                    txtYeniSifreTekrar.Clear();
                    txtYeniSifre.Focus();

                }

                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                string sorgu = "Select * from Kullanici where Eposta=@Eposta";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@Eposta", txtEposta.Text);
                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                    if (dr["Eposta"].ToString() != txtEposta.Text && dr["KullaniciID"].ToString()!=txtKad.Text)
                    {
                        MessageBox.Show(" Kullanıcı Adı ve Eposta Uyuşmuyor.. Tekrar Deneyiniz. ", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                        txtEposta.Focus();
                        
                    }
                dr.Close();



                
                    if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                    string updateSorgu = "Update Kullanici set Sifre=@Sifre  where Eposta=@eposta";
                    SqlCommand kmt = new SqlCommand(updateSorgu, baglanti);
                   
                    kmt.Parameters.AddWithValue("@Sifre", txtYeniSifre.Text);
                    kmt.Parameters.AddWithValue("@eposta", txtEposta.Text);

                    kmt.ExecuteNonQuery();
                    MessageBox.Show("Şİfreniz Değiştirildi", "Şifre Değişti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
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
    }
}
