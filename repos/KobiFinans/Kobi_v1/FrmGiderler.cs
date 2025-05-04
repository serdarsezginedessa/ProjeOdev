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
    public partial class FrmGiderler : Form
    {
        public FrmGiderler()
        {
            InitializeComponent();
        }

        private static string connectionString = ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);

        private void FrmGiderler_Load(object sender, EventArgs e)
        {
            txtTutar.Text = "0,00";
            GiderTuruGetir();
            KasalariGetir();
            
            btnCariAra.Enabled = false;
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
            btnKaydet.Enabled = false;
            btniptal.Enabled = false;
           

        }

        private void GiderTuruGetir()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                SqlDataAdapter da = new SqlDataAdapter("select ID, Ad from giderTipi", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboGiderTuru.DataSource = dt;
                comboGiderTuru.DisplayMember = "AD";
                comboGiderTuru.ValueMember = "ID";
                comboGiderTuru.SelectedIndex = -1;
                baglanti.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Gider Türü Yüklenirken Hata Oluştu " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { baglanti.Close(); }
        }
        private void KasalariGetir()
        {
            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                baglanti.Open();
                SqlDataAdapter da = new SqlDataAdapter("Select KasaID, KasaAdi From Kasalar", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBoxNakit.DataSource = dt;
                comboBoxNakit.DisplayMember = "KasaAdi";
                comboBoxNakit.ValueMember = "KasaID";
                comboBoxNakit.SelectedIndex = -1;
                baglanti.Close();
            }
        }


        private void ekle()
        {
            SqlTransaction transaction = null;
            try
            {

                if (string.IsNullOrEmpty(txtCariID.Text))
                {
                    MessageBox.Show("Cari seçilmedi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

                if (string.IsNullOrEmpty(comboGiderTuru.Text) || string.IsNullOrEmpty(comboBoxNakit.Text))
                {
                    MessageBox.Show("Gider Türü ve Kasa Seçmelisiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                if (string.IsNullOrEmpty(txtTutar.Text.Trim()) || txtTutar.Text == "0,00")
                {
                    MessageBox.Show("Tutar girmelisiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

                if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                transaction = baglanti.BeginTransaction();
                int giderId = 0;
                // 1- Gider Ekleniyor
                SqlCommand cmd = new SqlCommand(@"Insert into Gider (CariID,KasaID,Aciklama,Tarih,Tutar,Tipi) Values 
                                                (@cariId,@kasaId,@aciklama,@tarih,@tutar,@tip);SELECT SCOPE_IDENTITY();", baglanti, transaction);
                cmd.Parameters.AddWithValue("@cariId", txtCariID.Text);

                cmd.Parameters.AddWithValue("@kasaId", comboBoxNakit.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@aciklama", txtAciklama.Text);
                cmd.Parameters.AddWithValue("@tarih", dateTarih.Value);
                cmd.Parameters.AddWithValue("@tutar", Convert.ToDecimal(txtTutar.Text));
                cmd.Parameters.AddWithValue("@tip", comboGiderTuru.SelectedValue.ToString());


                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    giderId = Convert.ToInt32(result);
                    txtGiderNo.Text = giderId.ToString();
                }

                SqlCommand cmdCariHareket = new SqlCommand(@"Insert into CariHareketleri (CariID,KasaID,OdemeID,Tarih,Aciklama,Tutar,HareketTipi,GiderId) Values
                                                            (@cariId,@kasaId,@odemeId,@tarih,@aciklama,@tutar,@tip,@giderId)", baglanti, transaction);


                cmdCariHareket.Parameters.AddWithValue("@cariId", Convert.ToInt32(txtCariID.Text));
                cmdCariHareket.Parameters.AddWithValue("@kasaId", comboBoxNakit.SelectedValue);
                cmdCariHareket.Parameters.AddWithValue("@odemeId", 1);
                cmdCariHareket.Parameters.AddWithValue("@tarih", dateTarih.Value);
                cmdCariHareket.Parameters.AddWithValue("@aciklama", txtAciklama.Text);
                cmdCariHareket.Parameters.AddWithValue("@tutar", Convert.ToDecimal(txtTutar.Text));
                cmdCariHareket.Parameters.AddWithValue("@tip", "Borç");
                cmdCariHareket.Parameters.AddWithValue("@giderId", giderId);

                cmdCariHareket.ExecuteNonQuery();

                SqlCommand cmdKasaHareket = new SqlCommand(@"Insert into KasaHareketleri (KasaID,CariID,Tutar,Tarih,Aciklama,HareketTipi,GiderId) Values 
                                                            (@kasaId,@cariId,@tutar, @tarih, @aciklama, @tip, @giderId)", baglanti, transaction);



                cmdKasaHareket.Parameters.AddWithValue("@kasaId", comboBoxNakit.SelectedValue);
                cmdKasaHareket.Parameters.AddWithValue("@cariId", txtCariID.Text);
                cmdKasaHareket.Parameters.AddWithValue("@tutar", Convert.ToDecimal(txtTutar.Text));
                cmdKasaHareket.Parameters.AddWithValue("@tarih", dateTarih.Value);
                cmdKasaHareket.Parameters.AddWithValue("@aciklama", txtAciklama.Text);
                cmdKasaHareket.Parameters.AddWithValue("@tip", "Gider");
                cmdKasaHareket.Parameters.AddWithValue("@giderId", giderId);

                cmdKasaHareket.ExecuteNonQuery();

                transaction.Commit();

                MessageBox.Show("Gider başarıyla kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btniptal.Enabled = false;
                btnCariAra.Enabled = false;
                btnGiderAra.Enabled = true;
                txtAciklama.Clear();
                txtAciklama.Enabled = false;
                txtTutar.Text="0,00";
                dateTarih.Value = DateTime.Now;
                comboGiderTuru.SelectedIndex = -1;
                comboBoxNakit.SelectedIndex = -1;
                txtCariID.Text = "";
                txtCariKod.Text = "";
                txtCariAd.Text = "";
                txtGiderNo.Text = "";
                txtCariID.Focus();
                btnKaydet.Enabled = false;



            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback(); // Rollback işlemi yapılır
                }
                MessageBox.Show("Gider Kaydedilirken Bir Hata Oluştu" + ex.ToString(), "Kayıt Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { baglanti.Close(); }
        }


        private void guncelle()
        {
            SqlTransaction transaction = null;
            try
            {
                if (string.IsNullOrEmpty(txtGiderNo.Text))
                {
                    MessageBox.Show("Önce Güncellenecek Kayıt Seçmelisiniz", "Cari Seç", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (string.IsNullOrEmpty(txtCariID.Text))
                {
                    MessageBox.Show("Cari seçilmedi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

                if (string.IsNullOrEmpty(comboGiderTuru.Text) || string.IsNullOrEmpty(comboBoxNakit.Text))
                {
                    MessageBox.Show("Gider Türü ve Kasa Seçmelisiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                if (string.IsNullOrEmpty(txtTutar.Text.Trim()) || txtTutar.Text == "0,00")
                {
                    MessageBox.Show("Tutar girmelisiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                }

                

                if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                transaction = baglanti.BeginTransaction();

                // 1- Gider Güncelleniyor
                SqlCommand cmd = new SqlCommand(@"UPDATE Gider SET  CariID=@cariId, KasaID=@kasaId, Aciklama=@aciklama,
                                                Tarih=@tarih, Tutar=@tutar, Tipi=@tip Where GiderID = @giderId", baglanti, transaction);

                cmd.Parameters.AddWithValue("@cariId", txtCariID.Text);
                cmd.Parameters.AddWithValue("@kasaId", comboBoxNakit.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@aciklama", txtAciklama.Text);
                cmd.Parameters.AddWithValue("@tarih", dateTarih.Value);
                cmd.Parameters.AddWithValue("@tutar", Convert.ToDecimal(txtTutar.Text));
                cmd.Parameters.AddWithValue("@tip", comboGiderTuru.SelectedValue.ToString());

                cmd.Parameters.AddWithValue("@giderId", Convert.ToInt32(txtGiderNo.Text));

                 
                cmd.ExecuteNonQuery();


                SqlCommand cmdCariHareket = new SqlCommand(@"UPDATE CariHareketleri SET  CariID=@cariId,KasaID=@kasaId,OdemeID=@odemeId,
                                  Tarih=@tarih,Aciklama=@aciklama,Tutar=@tutar,HareketTipi=@tip,GiderId=@giderId", baglanti, transaction);


                cmdCariHareket.Parameters.AddWithValue("@cariId", Convert.ToInt32(txtCariID.Text));
                cmdCariHareket.Parameters.AddWithValue("@kasaId", comboBoxNakit.SelectedValue);
                cmdCariHareket.Parameters.AddWithValue("@odemeId", 1);
                cmdCariHareket.Parameters.AddWithValue("@tarih", dateTarih.Value);
                cmdCariHareket.Parameters.AddWithValue("@aciklama", txtAciklama.Text);
                cmdCariHareket.Parameters.AddWithValue("@tutar", Convert.ToDecimal(txtTutar.Text));
                cmdCariHareket.Parameters.AddWithValue("@tip", "Borç");
                cmdCariHareket.Parameters.AddWithValue("@giderId", Convert.ToInt32(txtGiderNo.Text));

                cmdCariHareket.ExecuteNonQuery();

                SqlCommand cmdKasaHareket = new SqlCommand(@"UPDATE KasaHareketleri SET KasaID=@kasaId, CariID=@cariId,Tarih=@tarih,
                                  Aciklama=@aciklama,Tutar=@tutar,HareketTipi=@tip,GiderId=@giderId", baglanti, transaction);



                cmdKasaHareket.Parameters.AddWithValue("@kasaId", comboBoxNakit.SelectedValue);
                cmdKasaHareket.Parameters.AddWithValue("@cariId", txtCariID.Text);
                cmdKasaHareket.Parameters.AddWithValue("@tutar", Convert.ToDecimal(txtTutar.Text));
                cmdKasaHareket.Parameters.AddWithValue("@tarih", dateTarih.Value);
                cmdKasaHareket.Parameters.AddWithValue("@aciklama", txtAciklama.Text);
                cmdKasaHareket.Parameters.AddWithValue("@tip", "Gider");
                cmdKasaHareket.Parameters.AddWithValue("@giderId", Convert.ToInt32(txtGiderNo.Text));

                cmdKasaHareket.ExecuteNonQuery();

                transaction.Commit();

                MessageBox.Show("Gider Başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback(); // Rollback işlemi yapılır
                }
                MessageBox.Show("Gider Güncellenirken Bir Hata Oluştu" + ex.ToString(), "Güncelleme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { baglanti.Close(); }
        }

        private void sil()
        {

            SqlTransaction transaction = null;
            try
            {

                if (string.IsNullOrEmpty(txtGiderNo.Text))
                {
                    MessageBox.Show("Önce Silinecek Kayıt Seçmelisiniz", "Cari Seç", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                transaction = baglanti.BeginTransaction();

                SqlCommand cmdSil = new SqlCommand("DELETE  FROM Gider WHERE GiderID = @giderId", baglanti, transaction);
                cmdSil.Parameters.AddWithValue("@giderId", Convert.ToInt32(txtGiderNo.Text));
                cmdSil.ExecuteNonQuery();
                // 2- Cari Hareket Siliniyor
                SqlCommand cmdSilCari = new SqlCommand("DELETE  FROM CariHareketleri WHERE GiderId = @giderId", baglanti, transaction);
                cmdSilCari.Parameters.AddWithValue("@giderId", Convert.ToInt32(txtGiderNo.Text));
                cmdSilCari.ExecuteNonQuery();
                // 3- Kasa Hareket Siliniyor

                SqlCommand cmdSilKasa = new SqlCommand("DELETE  FROM KasaHareketleri WHERE GiderId = @giderId", baglanti, transaction);
                cmdSilKasa.Parameters.AddWithValue("@giderId", Convert.ToInt32(txtGiderNo.Text));
                cmdSilKasa.ExecuteNonQuery();
                MessageBox.Show("Gider Başarıyla Silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);



                transaction.Commit();
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback(); // Rollback işlemi yapılır
                }

                MessageBox.Show("Hata: " + ex.GetBaseException(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { baglanti.Close(); }
        }
 
        public void CariBilgileriYukle(string cariID, string cariKod, string cariAdi)//Yeni Kayıt işleminde cari getirme fonsiyonu
        {
            txtCariID.Text = cariID;
            txtCariKod.Text = cariKod;
            txtCariAd.Text = cariAdi;

        }
        public void GiderKayitGetir(DateTime tarih, string giderno, string carino, string gideradi, string carikod, string kasa, string aciklama, Decimal tutar, string giderturu) // //güncellem işlemi için gider getirme fonksiyonu FrmGiderHareketlir
        {
            txtGiderNo.Text = giderno;
            txtCariID.Text = carino;
            txtCariAd.Text = gideradi;
            txtCariKod.Text = carikod;
            txtAciklama.Text = aciklama;
            dateTarih.Value = tarih;
            comboGiderTuru.Text = giderturu;
            comboBoxNakit.Text = kasa;
            txtTutar.Text = tutar.ToString();
        }

        private void txtTutar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTutar.Text))
            {
                txtTutar.Text = "0,00";
            }
            else
            {
                decimal tutar;
                if (decimal.TryParse(txtTutar.Text, out tutar))
                {
                    txtTutar.Text = tutar.ToString("N2"); // 2 basamaklı formatla
                }
                else
                {
                    txtTutar.Text = "0,00"; // Geçersizse sıfırla
                }
            }
        }



        private void txtTutar_Enter(object sender, EventArgs e)
        {
            txtTutar.SelectAll();
        }

        private void txtTutar_Click(object sender, EventArgs e)
        {
            txtTutar.SelectAll();
        }

        private void btnGiderAra_Click(object sender, EventArgs e)//Güncellem yapmak için
        {
            FrmGiderHareketleri frmGiderHareketleri = new FrmGiderHareketleri();
            frmGiderHareketleri.CagrilanForm = this;
            frmGiderHareketleri.ShowDialog();

            if (!string.IsNullOrEmpty(txtGiderNo.Text))
            {
                
                btniptal.Enabled = true;
                btnKaydet.Enabled = false;
                btnGuncelle.Enabled = true;
                btnSil.Enabled = true;
                txtAciklama.Enabled = true;
                txtAciklama.ReadOnly = false;
            }

            




        }

        private void btnCariAra_Click(object sender, EventArgs e)
        {
            FrmCariListele frmCariListele = new FrmCariListele();
            frmCariListele.CagrilanForm = this;

            frmCariListele.ShowDialog();

            btniptal.Enabled = true;
            btnKaydet.Enabled = true;
            txtAciklama.Enabled = true;
            txtAciklama.ReadOnly = false;
            txtAciklama.Focus();
            txtAciklama.Text = "";
            txtTutar.Text = "0,00";
            dateTarih.Value = DateTime.Now;
            comboGiderTuru.SelectedIndex = -1;
            comboBoxNakit.SelectedIndex = -1;


        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            ekle();
           
          
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            guncelle();
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
            btniptal.Enabled = false;
            txtGiderNo.Text = "";
            txtCariID.Text = "";
            txtCariAd.Text = "";
            txtCariKod.Text = "";
            txtAciklama.Text = "";
            txtTutar.Text = "0,00";
            comboBoxNakit.SelectedIndex = -1;
            comboGiderTuru.SelectedIndex = -1;

        }

        

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Silmek istediğinize emin misiniz?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sil();
                btniptal.Enabled = false;
                btnGuncelle.Enabled = false;
                btnSil.Enabled = false;
                txtGiderNo.Text = "";
                txtCariID.Text = "";
                txtCariAd.Text = "";
                txtCariKod.Text = "";
                txtAciklama.Text = "";
                txtTutar.Text = "0,00";
                dateTarih.Value = DateTime.Now;
                comboGiderTuru.SelectedIndex = -1;
                comboBoxNakit.SelectedIndex = -1;
                txtCariID.Focus();
            }
            else
            {
                
            }
        }

        private void btnYeniKayit_Click(object sender, EventArgs e)
        {
            btnKaydet.Enabled = true;
            btniptal.Enabled = true;
            btnCariAra.Enabled = true;
            btnGiderAra.Enabled=false;

            txtGiderNo.Text = "";
            txtCariID.Text = "";
            txtCariAd.Text = "";
            txtCariKod.Text = "";
            txtAciklama.Enabled = true;
            txtAciklama.ReadOnly = false;
            txtAciklama.Text = "";
            txtTutar.Text = "0,00";
            dateTarih.Value = DateTime.Now;
            comboGiderTuru.SelectedIndex = -1;
            comboBoxNakit.SelectedIndex = -1;
            txtCariID.Focus();
            btnCariAra.PerformClick();

        }

        private void btniptal_Click(object sender, EventArgs e)
        {
            btniptal.Enabled = false;
            btnKaydet.Enabled = false;
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
            txtGiderNo.Text = "";
            txtCariID.Text = "";
            txtCariAd.Text = "";
            txtCariKod.Text = "";
            txtAciklama.Enabled = false;
            txtAciklama.ReadOnly = false;
            txtAciklama.Text = "";
            txtTutar.Text = "0,00";
            dateTarih.Value = DateTime.Now;
            comboGiderTuru.SelectedIndex = -1;
            comboBoxNakit.SelectedIndex = -1;
            txtCariID.Focus();
        }
    }
}
