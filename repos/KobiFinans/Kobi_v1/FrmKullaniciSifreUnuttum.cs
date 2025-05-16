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
    public partial class FrmKullaniciSifreUnuttum : Form
    {
        public FrmKullaniciSifreUnuttum()
        {
            InitializeComponent();
        }
        static string connectionString = ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);


        private void SifreDegistir()
        {
            try
            {
                if (txtKad.Text == "")
                {
                    MessageBox.Show("Kullanıcı Adı alanı boş olamaz");
                    return;
                }
                if (txtYeniSifre.Text == "")
                {
                    MessageBox.Show("Yeni Şifre alanı boş olamaz");
                    return;
                }
                if (txtYeniSifre.Text != txtYeniSifreTekrar.Text)
                {
                    MessageBox.Show("Şifreler Eşleşmiyor");
                    return;
                }
                if(txtEposta.Text == "")
                {
                    MessageBox.Show("E-posta alanı boş olamaz");
                    return;
                }
                
                
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                string sorgueposta = "Select * From Kullanici Where Eposta=@eposta and KullaniciAdi=@kad";
                SqlCommand komuteposta = new SqlCommand(sorgueposta, baglanti);
                komuteposta.Parameters.AddWithValue("@kad", txtKad.Text.Trim());
                komuteposta.Parameters.AddWithValue("@eposta", txtEposta.Text.Trim());
                var sonuc = komuteposta.ExecuteScalar();
                if (sonuc == null)
                {
                    MessageBox.Show("Kayıt Bulunamadı! Kullanıcı Adınızı ve E-postanızı Kontrol Ediniz.","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    baglanti.Close();
                    return;
                }
              
                baglanti.Close();
                
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
               
                string sorgu = "Update Kullanici Set Sifre=@sifre Where Eposta=@eposta";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@sifre", txtYeniSifre.Text);
                komut.Parameters.AddWithValue("@eposta", txtEposta.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("Şifre Güncellendi");
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

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SifreDegistir();
        }
    }
}
