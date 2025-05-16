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
            ComboBoxDoldur();
        }
        static string connectionString = ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);

        public string KullaniciID
        {
            get {  return txtkid.Text; }
            set { txtkid.Text = value; }

        }
        public string eposta
        {
            get { return txtEposta.Text; }
            set { txtEposta.Text = value; }
        }
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
        public string rol
        {
            get { return comboKullaniciTuru.Text; }
            set { comboKullaniciTuru.Text = value; }
        }
        public string durum
        {
            get { return comboDurum.Text; }
            set { comboDurum.Text = value; }
        }

        public void ComboBoxDoldur()
        {
            try
            {
                comboDurum.Items.Add("Aktif");
                comboDurum.Items.Add("Pasif");
                comboKullaniciTuru.Items.Add("Admin");
                comboKullaniciTuru.Items.Add("Kullanıcı");

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
                /*else
                {
                    txtKad.Text = txtKad.Text.Trim();
                    if(baglanti.State == ConnectionState.Closed) baglanti.Open();
                    string sorgu = "SELECT COUNT(*) FROM Kullanici WHERE KullaniciAdi = @kadi";
                    SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                    cmd.Parameters.AddWithValue("@kadi", txtKad.Text);

                    int kullaniciSayisi = (int)cmd.ExecuteScalar();

                    if (kullaniciSayisi == 0)
                    {
                        MessageBox.Show("Kullanıcı sistemde yok.");
                        return;
                    }


                }*/
                if (string.IsNullOrEmpty(txtEposta.Text.Trim()))
                {
                    MessageBox.Show("Lütfen Epostayı Giriniz");
                    txtEposta.Focus();

                }
                if (string.IsNullOrEmpty(txtYeniSifre.Text.Trim()))
                {
                    MessageBox.Show("Lütfen Şifreyi Giriniz");
                    txtYeniSifre.Focus();
                    return;
                }

               

                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                
                
                string updateSorgu = "Update Kullanici set KullaniciAdi = @KullaniciAdi, Sifre=@Sifre, Eposta=@eposta, Rol=@rol, Durum=@durum  where KullaniciID = @id";
                SqlCommand kmt = new SqlCommand(updateSorgu, baglanti);
                kmt.Parameters.AddWithValue("@id", Convert.ToInt32(KullaniciID));
                kmt.Parameters.AddWithValue("@KullaniciAdi", txtKad.Text);
                kmt.Parameters.AddWithValue("@Sifre", txtYeniSifre.Text);
                kmt.Parameters.AddWithValue("@eposta", txtEposta.Text);
                kmt.Parameters.AddWithValue("@rol", comboKullaniciTuru.Text);
                if (comboDurum.Text == "Aktif")
                {
                    kmt.Parameters.AddWithValue("@durum", 1);
                }
                else
                {
                    kmt.Parameters.AddWithValue("@durum", 0);
                }
                

                kmt.ExecuteNonQuery();
                
                MessageBox.Show("Kullanıcı Bilgileri Güncellendi", "Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcı Güncellenirken Hata Oluştu","Güncelleme Hatası"+ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }
    }
}
