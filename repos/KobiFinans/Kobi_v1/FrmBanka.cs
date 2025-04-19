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
    public partial class FrmBanka : Form
    {
        public FrmBanka()
        {
            InitializeComponent();
        }
        static string connectionString = ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);
        SqlCommand kmt;
        void ekle()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    if (txtBankaAdi.Text == "" || txtSubeAdi.Text == "" || txtHesapNo.Text == "" || txtIban.Text == "")
                    {
                        MessageBox.Show("Lütfen tüm alanları doldurunuz.");
                    }
                    else
                    {
                        kmt = new SqlCommand("INSERT INTO Bankalar(BankaAd,BankaSube,HesapNo,IBAN) VALUES(@BankaAd,@SubeAd,@HesapNo,@Iban)", baglanti);
                        kmt.Parameters.AddWithValue("@BankaAd", txtBankaAdi.Text);
                        kmt.Parameters.AddWithValue("@SubeAd", txtSubeAdi.Text);
                        kmt.Parameters.AddWithValue("@HesapNo", txtHesapNo.Text);
                        kmt.Parameters.AddWithValue("@Iban", txtIban.Text);
                        kmt.ExecuteNonQuery();
                        MessageBox.Show("Kayıt işlemi başarılı.");
                        textboxTemizle();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
            }
        }
        
        void guncelle()
        {
            try
            {
                if(baglanti.State== ConnectionState.Closed)
                {
                    baglanti.Open();
                    if(txtBankaAdi.Text == "" || txtSubeAdi.Text == "" || txtHesapNo.Text == "" || txtIban.Text == "")
                    {
                        MessageBox.Show("Lütfen tüm alanları doldurunuz.");
                    }
                    else
                    {
                        kmt = new SqlCommand("UPDATE Bankalar SET BankaAd=@BankaAd,BankaSube=@SubeAd, HesapNo=@HesapNo, Iban=@Iban WHERE ID=@Id", baglanti);
                        kmt.Parameters.AddWithValue("@Id", txtID.Text);
                        kmt.Parameters.AddWithValue("@BankaAd", txtBankaAdi.Text);
                        kmt.Parameters.AddWithValue("@SubeAd", txtSubeAdi.Text);
                        kmt.Parameters.AddWithValue("@HesapNo", txtHesapNo.Text);
                        kmt.Parameters.AddWithValue("@Iban", txtIban.Text);
                        kmt.ExecuteNonQuery();
                        MessageBox.Show("Güncelleme işlemi başarılı.");
                        textboxTemizle();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
            }
        }

        void sil()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    if (txtID.Text == "")
                    {
                        MessageBox.Show("Lütfen silinecek kaydı seçiniz.");
                    }
                    else
                    {
                        kmt = new SqlCommand("DELETE FROM Bankalar WHERE ID=@Id", baglanti);
                        kmt.Parameters.AddWithValue("@Id", txtID.Text);
                        kmt.ExecuteNonQuery();
                        MessageBox.Show("Silme işlemi başarılı.");
                        textboxTemizle();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
            }
        }

        void btngizle()
        {
            btnYeniKayit.Enabled = true;
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
            btnEkle.Enabled = false;
            btniptal.Enabled = false;

        }

        void textboxTemizle()
        {
            txtID.Clear();
            txtBankaAdi.Clear();
            txtSubeAdi.Clear();
            txtHesapNo.Clear();
            txtIban.Clear();
            btngizle();
        }

        void textBoxPasifle()
        {
            txtID.Enabled = false;
            txtBankaAdi.Enabled = false;
            txtSubeAdi.Enabled = false;
            txtHesapNo.Enabled = false;
            txtIban.Enabled = false;
        }

        void textBoxAktifle()
        {
            txtID.Enabled = false;
            txtBankaAdi.Enabled = true;
            txtSubeAdi.Enabled = true;
            txtHesapNo.Enabled = true;
            txtIban.Enabled = true;
        }

        public void SetBankaBilgileri(string id, string BankaAd, string SubeAd, string HesapNo, string Iban)
        {
            if(string.IsNullOrEmpty(txtID.Text) || string.IsNullOrEmpty(txtBankaAdi.Text) || string.IsNullOrEmpty(txtSubeAdi.Text) || string.IsNullOrEmpty(txtHesapNo.Text) || string.IsNullOrEmpty(txtIban.Text))
            {
                textBoxPasifle();
                btngizle();
                
            }
            txtID.Text = id;
            txtBankaAdi.Text = BankaAd;
            txtSubeAdi.Text = SubeAd;
            txtHesapNo.Text = HesapNo;
            txtIban.Text = Iban;
        }

        private void btnBankaAra_Click(object sender, EventArgs e)
        {
            FrmBankaListe frmBankaListe = new FrmBankaListe();
            frmBankaListe.Owner = this;
            frmBankaListe.ShowDialog();
            btnYeniKayit.Enabled = false;
            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;
            btniptal.Enabled = true;
            btnEkle.Enabled = false;
            textBoxAktifle();
        }

        private void FrmBanka_Load(object sender, EventArgs e)
        {
            btngizle();
            textBoxPasifle();
        }

        private void btnYeniKayit_Click(object sender, EventArgs e)
        {
            btnYeniKayit.Enabled = false;
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
            btniptal.Enabled = true;
            btnEkle.Enabled = true;
            textBoxAktifle();

        }

        private void btniptal_Click(object sender, EventArgs e)
        {
            textboxTemizle();
            textBoxPasifle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            guncelle();
            textBoxPasifle();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            ekle();
            textBoxPasifle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            sil();
            textBoxPasifle();
        }
    }
}
