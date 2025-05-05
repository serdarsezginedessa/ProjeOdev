using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Forms.Application;

namespace Kobi_v1
{
    public partial class FrmTahsilat : Form
    {
        public FrmTahsilat()
        {
            InitializeComponent();
        }
        public int _faturaNo { get; set; }
        public int _cariID { get; set; }
        public decimal _tutar { get; set; }
        public string _cariKod { get; set; }
        public string _cariAd { get; set; }
        public Form1 ParetForm { get; set; } // Ana form referansı
        int _tahsilatNO;



        private static string connectionString = ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);




        string sqlKasaHareket = @"INSERT INTO KasaHareketleri
                                        (KasaID, CariID, Tarih, Tutar, Aciklama, HareketTipi)
                                         VALUES
                                        (@kasaID, @cariID, @tarih, @tutar, @aciklama, 'Tahsilat')";

        string sqlBankaHareket = @"INSERT INTO BankaHareketler
                                        (BankaID, CariID, Tarih, Tutar, Aciklama, HareketTipi, Kaynak)
                                        VALUES
                                        (@bankaID, @cariID, @tarih, @tutar, @aciklama, 'Banka Tahsilat', 'Satış Ekranı')";


        /*  if (odemeYontemi == "Kasa")
  {
      SqlCommand cmd = new SqlCommand("INSERT INTO KasaHareketleri (KasaID, CariID, Tarih, Tutar, Aciklama, HareketTipi) VALUES (@kasaID, @cariID, @tarih, @tutar, @aciklama, 'Tahsilat')", baglanti);
          cmd.Parameters.AddWithValue("@kasaID", kasaID);
      cmd.Parameters.AddWithValue("@cariID", cariID);
      cmd.Parameters.AddWithValue("@tarih", DateTime.Now);
      cmd.Parameters.AddWithValue("@tutar", tutar);
      cmd.Parameters.AddWithValue("@aciklama", "Satış ödemesi");
      cmd.ExecuteNonQuery();
  }
  else if (odemeYontemi == "Banka")
  {
      SqlCommand cmd = new SqlCommand("INSERT INTO BankaHareketler (BankaID, CariID, Tarih, Tutar, Aciklama, HareketTipi, Kaynak) VALUES (@bankaID, @cariID, @tarih, @tutar, @aciklama, 'Banka Tahsilat', 'Satış Ekranı')", baglanti);
      cmd.Parameters.AddWithValue("@bankaID", bankaID);
      cmd.Parameters.AddWithValue("@cariID", cariID);
      cmd.Parameters.AddWithValue("@tarih", DateTime.Now);
      cmd.Parameters.AddWithValue("@tutar", tutar);
      cmd.Parameters.AddWithValue("@aciklama", "Satış ödemesi");
      cmd.ExecuteNonQuery();
  }
        */

        private void FrmTahsilat_Load(object sender, EventArgs e)
        {
            OdemeTurleriGetir();
            KasalariGetir();
            BankalariGetir();
            if (_cariID != 0)
                txtCariID.Text = _cariID.ToString();
            if (_faturaNo != 0)
                txtFaturaNo.Text = _faturaNo.ToString();
            if (_cariKod != null)

            {
                string[] parts = _cariKod.Split(':');
                if (parts.Length > 1)
                {
                    txtCariKod.Text = parts[1].Trim();
                }
            }


            if (_tutar > 0)
                txtTutar.Text = _tutar.ToString("N2");
            else
            {
                txtTutar.Text = "0,00";
            }
            txtCariAd.Text = _cariAd;

            btnKaydet.Enabled = true;
            txtFaturaNo.Enabled = false;
            checkBox1FaturaAktif.Checked = false;

        }
        Form1 frm = Application.OpenForms.OfType<Form1>().FirstOrDefault();




        private void TahsilatveHareketKaydet()
        {
            SqlTransaction transaction = null;
            try
            {
                if (string.IsNullOrEmpty(txtCariID.Text))
                {
                    MessageBox.Show("Cari seçilmedi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (comboOdemeTuru.SelectedIndex == -1)
                {
                    MessageBox.Show("Ödeme Türü seçmelisiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }



                if (string.IsNullOrEmpty(txtTutar.Text.Trim()) || txtTutar.Text == "0,00")
                {
                    MessageBox.Show("Tutar girmelisiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (baglanti.State == ConnectionState.Closed) baglanti.Open();


                transaction = baglanti.BeginTransaction();
                int tahsilatID = 0;
                // 1. Tahsilat Kaydı
                SqlCommand cmdTahsilat = new SqlCommand(@"
                                    INSERT INTO Tahsilatlar (FaturaNo, CariID, Tutar, Tarih, OdemeTuruID, KasaID, BankaID, Aciklama)
                                    VALUES (@FaturaNo, @CariID, @Tutar, @Tarih, @OdemeTuruID, @KasaID, @BankaID, @Aciklama);SELECT SCOPE_IDENTITY();", baglanti, transaction);

                cmdTahsilat.Parameters.AddWithValue("@FaturaNo", (object)_faturaNo ?? DBNull.Value); // boş olabilir
                cmdTahsilat.Parameters.AddWithValue("@CariID", txtCariID.Text);
                cmdTahsilat.Parameters.AddWithValue("@Tutar", Convert.ToDecimal(txtTutar.Text));
                cmdTahsilat.Parameters.AddWithValue("@Tarih", dateTarih.Value);
                cmdTahsilat.Parameters.AddWithValue("@OdemeTuruID", comboOdemeTuru.SelectedValue);
                cmdTahsilat.Parameters.AddWithValue("@KasaID", (object)(comboBoxNakit.SelectedValue ?? DBNull.Value));
                cmdTahsilat.Parameters.AddWithValue("@BankaID", (object)(comboBoxBanka.SelectedValue ?? DBNull.Value));
                cmdTahsilat.Parameters.AddWithValue("@Aciklama", txtAciklama.Text);



                object result = cmdTahsilat.ExecuteScalar();
                if (result != null)
                {
                    tahsilatID = Convert.ToInt32(result);
                    txtTahsilatNo.Text = tahsilatID.ToString();
                }



                // 2. Kasa Hareket Kaydı (Ödeme olduğu takdirde)
                if (comboOdemeTuru.Text == "Nakit")
                {

                    SqlCommand cmdKasaHareket = new SqlCommand(@"INSERT INTO KasaHareketleri (KasaID, CariID, Tarih, Aciklama, Tutar, HareketTipi, FaturaNo,TahsilatID)
                                                   VALUES (@KasaID, @CariID, @Tarih, @Aciklama, @Tutar, @HareketTipi, @FaturaNo,@TahsilatID)", baglanti, transaction);

                    cmdKasaHareket.Parameters.AddWithValue("@KasaID", comboBoxNakit.SelectedValue);
                    cmdKasaHareket.Parameters.AddWithValue("@CariID", txtCariID.Text);
                    cmdKasaHareket.Parameters.AddWithValue("@Tarih", dateTarih.Value);
                    cmdKasaHareket.Parameters.AddWithValue("@Aciklama", txtAciklama.Text);
                    cmdKasaHareket.Parameters.AddWithValue("@Tutar", Convert.ToDecimal(txtTutar.Text));
                    cmdKasaHareket.Parameters.AddWithValue("@HareketTipi", "Tahsilat");
                    cmdKasaHareket.Parameters.AddWithValue("@FaturaNo", (object)_faturaNo ?? DBNull.Value);
                    cmdKasaHareket.Parameters.AddWithValue("@TahsilatID", Convert.ToInt32(txtTahsilatNo.Text));


                    cmdKasaHareket.ExecuteNonQuery();
                }
                // 3. Banka Hareket Kaydı (Ödeme olduğu takdirde)
                if (comboOdemeTuru.Text == "Havale" || comboOdemeTuru.Text == "Kredi Kartı" || comboOdemeTuru.Text == "Çek")
                {
                    if (comboBoxBanka.SelectedIndex == -1)
                    {
                        MessageBox.Show("Banka seçmelisiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    SqlCommand cmdBankaHareket = new SqlCommand(@"INSERT INTO BankaHareketleri (BankaID, CariID, Tarih, Aciklama, Tutar, HareketTipi, Kaynak, FaturaNo,TahsilatID)
                                                     VALUES (@BankaID, @CariID, @Tarih, @Aciklama, @Tutar, @HareketTipi, @Kaynak, @FaturaNo,@TahsilatID)", baglanti, transaction);

                    cmdBankaHareket.Parameters.AddWithValue("@BankaID", comboBoxBanka.SelectedValue);
                    cmdBankaHareket.Parameters.AddWithValue("@CariID", txtCariID.Text);
                    cmdBankaHareket.Parameters.AddWithValue("@Tarih", dateTarih.Value);
                    cmdBankaHareket.Parameters.AddWithValue("@Aciklama", txtAciklama.Text);
                    cmdBankaHareket.Parameters.AddWithValue("@Tutar", Convert.ToDecimal(txtTutar.Text));
                    cmdBankaHareket.Parameters.AddWithValue("@HareketTipi", "Tahsilat");
                    cmdBankaHareket.Parameters.AddWithValue("@Kaynak", comboOdemeTuru.Text);
                    cmdBankaHareket.Parameters.AddWithValue("@FaturaNo", (object)_faturaNo ?? DBNull.Value);
                    cmdBankaHareket.Parameters.AddWithValue("@TahsilatID", Convert.ToInt32(txtTahsilatNo.Text));

                    cmdBankaHareket.ExecuteNonQuery();
                }

                // 4. CariHareket Kaydı (Alacak olarak)
                SqlCommand cmdHareket = new SqlCommand(@"
                                                                INSERT INTO CariHareketleri (CariID, KasaID, BankaID, OdemeID, Tarih, Aciklama, Tutar, HareketTipi,TahsilatID)
                                                                VALUES (@CariID, @KasaID, @BankaID, @OdemeID, @Tarih, @Aciklama, @Tutar, @HareketTipi,@TahsilatID)", baglanti, transaction);

                cmdHareket.Parameters.AddWithValue("@CariID", txtCariID.Text);
                cmdHareket.Parameters.AddWithValue("@KasaID", (object)(comboBoxNakit.SelectedValue ?? DBNull.Value));
                cmdHareket.Parameters.AddWithValue("@BankaID", (object)(comboBoxBanka.SelectedValue ?? DBNull.Value));
                cmdHareket.Parameters.AddWithValue("@OdemeID", comboOdemeTuru.SelectedValue);
                cmdHareket.Parameters.AddWithValue("@Tarih", dateTarih.Value);
                cmdHareket.Parameters.AddWithValue("@Aciklama", txtAciklama.Text);
                cmdHareket.Parameters.AddWithValue("@Tutar", Convert.ToDecimal(txtTutar.Text));
                cmdHareket.Parameters.AddWithValue("@HareketTipi", "Alacak");
                cmdHareket.Parameters.AddWithValue("@TahsilatID", Convert.ToInt32(tahsilatID));

                cmdHareket.ExecuteNonQuery();

                transaction.Commit();

                MessageBox.Show("Tahsilat başarıyla kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                if (frm != null)
                {
                    frm.GelirGiderGet(); // Form1'deki fonksiyonu çağır
                }
                else
                {
                    MessageBox.Show("Form1 açık değil.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback(); // Rollback işlemi yapılır
                }

                MessageBox.Show("Hata: " + ex.GetBaseException(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglanti.Close();
            }

        }

        private void TahsilatveHareketGuncelle()
        {
            SqlTransaction transaction = null;
            try
            {
                if (string.IsNullOrEmpty(txtTutar.Text.Trim()) || txtTutar.Text == "0,00")
                {
                    MessageBox.Show("Tutar girmelisiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (comboOdemeTuru.SelectedIndex == -1)
                {
                    MessageBox.Show("Ödeme Türü seçmelisiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(txtCariID.Text))
                {
                    MessageBox.Show("Cari seçilmedi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (baglanti.State == ConnectionState.Closed) baglanti.Open();


                transaction = baglanti.BeginTransaction();

                // Tüm hareketlerden tahsilatlardan etkilenen kayıtları bulacağımız tahsilat Id yi buluyoruz.

                // 1. Tahsilat UPDATE
                SqlCommand cmdTahsilat = new SqlCommand(@"Update Tahsilatlar Set  FaturaNo=@FaturaNo, CariID=@CariID, Tutar=@Tutar, Tarih=@Tarih
                                                        ,OdemeTuruID=@OdemeTuruID, KasaID=@KasaID, BankaID=@BankaID, Aciklama=@Aciklama
                                                        Where TahsilatID=@TahsilatID", baglanti, transaction);

                cmdTahsilat.Parameters.AddWithValue("@TahsilatID", Convert.ToInt32(txtTahsilatNo.Text));
                cmdTahsilat.Parameters.AddWithValue("@FaturaNo", (object)txtFaturaNo.Text ?? DBNull.Value); // boş olabilir
                cmdTahsilat.Parameters.AddWithValue("@CariID", txtCariID.Text);
                cmdTahsilat.Parameters.AddWithValue("@Tutar", Convert.ToDecimal(txtTutar.Text));
                cmdTahsilat.Parameters.AddWithValue("@Tarih", dateTarih.Value);
                cmdTahsilat.Parameters.AddWithValue("@OdemeTuruID", comboOdemeTuru.SelectedValue);
                cmdTahsilat.Parameters.AddWithValue("@KasaID", (object)(comboBoxNakit.SelectedValue ?? DBNull.Value));
                cmdTahsilat.Parameters.AddWithValue("@BankaID", (object)(comboBoxBanka.SelectedValue ?? DBNull.Value));
                cmdTahsilat.Parameters.AddWithValue("@Aciklama", txtAciklama.Text);

                cmdTahsilat.ExecuteNonQuery();

                // 2. CariHareket UPDATE (Alacak olarak)
                SqlCommand cmdHareket = new SqlCommand(@"UPDATE CariHareketleri SET CariID=@CariID, KasaID=@KasaID, BankaID=@BankaID, OdemeID=@OdemeID
                                                        ,Tarih=@Tarih, Aciklama=@Aciklama, Tutar=@Tutar, HareketTipi=@HareketTipi
                                                        WHERE TahsilatID=@TahsilatID", baglanti, transaction);


                cmdHareket.Parameters.AddWithValue("@CariID", txtCariID.Text);
                cmdHareket.Parameters.AddWithValue("@KasaID", (object)(comboBoxNakit.SelectedValue ?? DBNull.Value));
                cmdHareket.Parameters.AddWithValue("@BankaID", (object)(comboBoxBanka.SelectedValue ?? DBNull.Value));
                cmdHareket.Parameters.AddWithValue("@OdemeID", comboOdemeTuru.SelectedValue);
                cmdHareket.Parameters.AddWithValue("@Tarih", dateTarih.Value);
                cmdHareket.Parameters.AddWithValue("@Aciklama", txtAciklama.Text);
                cmdHareket.Parameters.AddWithValue("@Tutar", Convert.ToDecimal(txtTutar.Text));
                cmdHareket.Parameters.AddWithValue("@HareketTipi", "Alacak");
                cmdHareket.Parameters.AddWithValue("@TahsilatID", txtTahsilatNo.Text);

                cmdHareket.ExecuteNonQuery();

                // 3. Kasa Hareket UPDATE (Ödeme olduğu takdirde)
                if (comboBoxNakit.SelectedValue != null)
                {
                    SqlCommand cmdKasaHareket = new SqlCommand(@"UPDATE KasaHareketleri SET KasaID=@KasaID, CariID=@CariID, Tarih=@Tarih, Aciklama=@Aciklama
                                                                ,Tutar=@Tutar, HareketTipi=@HareketTipi, FaturaNo=@FaturaNo
                                                                 WHERE TahsilatID=@TahsilatID", baglanti, transaction);

                    cmdKasaHareket.Parameters.AddWithValue("@KasaID", comboBoxNakit.SelectedValue);
                    cmdKasaHareket.Parameters.AddWithValue("@CariID", txtCariID.Text);
                    cmdKasaHareket.Parameters.AddWithValue("@Tarih", dateTarih.Value);
                    cmdKasaHareket.Parameters.AddWithValue("@Aciklama", txtAciklama.Text);
                    cmdKasaHareket.Parameters.AddWithValue("@Tutar", Convert.ToDecimal(txtTutar.Text));
                    cmdKasaHareket.Parameters.AddWithValue("@HareketTipi", "Tahsilat");
                    cmdKasaHareket.Parameters.AddWithValue("@FaturaNo", (object)_faturaNo ?? DBNull.Value);
                    cmdKasaHareket.Parameters.AddWithValue("@TahsilatID", txtTahsilatNo.Text);

                    cmdKasaHareket.ExecuteNonQuery();
                }
                // 4. Banka Hareket UPDATE (Ödeme olduğu takdirde)
                if (comboBoxBanka.SelectedValue != null)
                {
                    SqlCommand cmdBankaHareket = new SqlCommand(@"UPDATE BankaHareketleri SET BankaID=@BankaID, CariID=@CariID, Tarih=@Tarih, Aciklama=@Aciklama
                                                                ,Tutar=@Tutar, HareketTipi=@HareketTipi, Kaynak=@Kaynak, FaturaNo=@FaturaNo
                                                                WHERE TahsilatID=@TahsilatID", baglanti, transaction);

                    cmdBankaHareket.Parameters.AddWithValue("@BankaID", comboBoxBanka.SelectedValue);
                    cmdBankaHareket.Parameters.AddWithValue("@CariID", txtCariID.Text);
                    cmdBankaHareket.Parameters.AddWithValue("@Tarih", dateTarih.Value);
                    cmdBankaHareket.Parameters.AddWithValue("@Aciklama", txtAciklama.Text);
                    cmdBankaHareket.Parameters.AddWithValue("@Tutar", Convert.ToDecimal(txtTutar.Text));
                    cmdBankaHareket.Parameters.AddWithValue("@HareketTipi", "Tahsilat");
                    cmdBankaHareket.Parameters.AddWithValue("@Kaynak", comboOdemeTuru.Text);
                    cmdBankaHareket.Parameters.AddWithValue("@FaturaNo", (object)_faturaNo ?? DBNull.Value);
                    cmdBankaHareket.Parameters.AddWithValue("@TahsilatID", txtTahsilatNo.Text);

                    cmdBankaHareket.ExecuteNonQuery();
                }

                transaction.Commit();

                MessageBox.Show("Tahsilat Başarıyla Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ParetForm.GelirGiderGet();
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback(); // Rollback işlemi yapılır
                }

                MessageBox.Show("Hata: " + ex.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglanti.Close();
            }

        }

        private void TahsilatSil()
        {
            SqlTransaction transaction = null;
            try
            {

                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                transaction = baglanti.BeginTransaction();

                SqlCommand cmdSil = new SqlCommand("DELETE  FROM Tahsilatlar WHERE TahsilatID = @tahsilatID", baglanti, transaction);
                cmdSil.Parameters.AddWithValue("@tahsilatID", Convert.ToInt32(txtTahsilatNo.Text));
                cmdSil.ExecuteNonQuery();

                if (comboBoxNakit.SelectedValue != null)
                {
                    SqlCommand cmdKasaHareketSil = new SqlCommand("DELETE FROM KasaHareketleri WHERE TahsilatID = @tahsilatID", baglanti, transaction);
                    cmdKasaHareketSil.Parameters.AddWithValue("@tahsilatID", Convert.ToInt32(txtTahsilatNo.Text));
                    cmdKasaHareketSil.ExecuteNonQuery();
                }

                if (comboBoxBanka.SelectedValue != null)
                {
                    SqlCommand cmdBankaHareketSil = new SqlCommand("Delete from BanKaHareketleri where TahsilatID = @tahsilatID", baglanti, transaction);
                    cmdBankaHareketSil.Parameters.AddWithValue("@tahsilatId", Convert.ToInt32(txtTahsilatNo.Text));
                    cmdBankaHareketSil.ExecuteNonQuery();
                }

                //carihareketlerden siiniyor..
                SqlCommand cmdCariHareketSil = new SqlCommand("Delete From CariHareketleri Where TahsilatID = @tahsilatID", baglanti, transaction);
                cmdCariHareketSil.Parameters.AddWithValue("@tahsilatId", Convert.ToInt32(txtTahsilatNo.Text));
                cmdCariHareketSil.ExecuteNonQuery();


                transaction.Commit();
                MessageBox.Show("Kayıt Silme İşlemi Tamamlandı!");
                ParetForm.GelirGiderGet();
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback(); // Rollback işlemi yapılır
                }
                MessageBox.Show("Tahsilat Kaydı Silinirken Bir Hata Oluştu" + ex.ToString());
            }
            finally { baglanti.Close(); }
        }



        private void OdemeTurleriGetir()
        {
            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                baglanti.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT OdemeID, OdemeAd FROM OdemeTuru", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboOdemeTuru.DataSource = dt;
                comboOdemeTuru.DisplayMember = "OdemeAd";
                comboOdemeTuru.ValueMember = "OdemeID";
                comboOdemeTuru.SelectedIndex = -1; // Hiçbiri seçili olmasın
            }
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
        private void BankalariGetir()
        {
            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                baglanti.Open();
                SqlDataAdapter da = new SqlDataAdapter("Select BankaID, BankaAd From Bankalar", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBoxBanka.DataSource = dt;
                comboBoxBanka.DisplayMember = "BankaAd";
                comboBoxBanka.ValueMember = "BankaID";
                comboBoxBanka.SelectedIndex = -1;
            }
        }

        private void Temizle()
        {
            txtFaturaNo.Clear();
            txtCariID.Clear();
            txtTutar.Clear();
            txtAciklama.Clear();
            txtTahsilatNo.Clear();
            txtCariKod.Clear();
            txtCariAd.Clear();
            comboOdemeTuru.SelectedIndex = -1;
            comboBoxNakit.SelectedIndex = -1;
            comboBoxBanka.SelectedIndex = -1;
            dateTarih.Value = DateTime.Now;
        }



        private void BtnFromAcilis()
        {
            /*btnYeniKayit.Enabled = true;
            btnGuncelle.Enabled = false;
            btnKapat.Enabled = true;
            btnKaydet.Enabled = false;
            btnSil.Enabled = false;*/

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

        private void txtTutar_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sadece rakam, virgül ve backspace tuşlarına izin verelim
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Geçersiz tuşa basılırsa engelle
            }

            // Birden fazla virgül kullanımını engelleyelim
            if (e.KeyChar == ',' && (sender as TextBox).Text.Contains(","))
            {
                e.Handled = true;
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void btnYeniKayit_Click(object sender, EventArgs e)
        {
            Temizle();

        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TahsilatveHareketKaydet();
            if (this.Owner is Form1)
            {
                ((Form1)this.Owner).GelirGiderGet();
            }


        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

            TahsilatveHareketGuncelle();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Tahsilat Kaydını Silmek İsteğinize Emin Misiniz?", "Sime Onayı", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                TahsilatSil();
            }

            Temizle();
        }

        private void checkBox1FaturaAktif_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1FaturaAktif.Checked)
            {
                txtFaturaNo.Enabled = true;
                txtFaturaNo.ReadOnly = false;
            }
            else
            {
                txtFaturaNo.Enabled = false;
                txtFaturaNo.ReadOnly = true;
                txtFaturaNo.Clear();
            }
        }


        private void comboOdemeTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboOdemeTuru.Text == "Nakit")
            {
                comboBoxNakit.Enabled = true;
                comboBoxNakit.SelectedIndex = -1;
                comboBoxBanka.Enabled = false;
                comboBoxBanka.SelectedIndex = -1;
            }
            else
            {
                comboBoxBanka.Enabled = true;
                comboBoxBanka.SelectedIndex = -1;
                comboBoxNakit.Enabled = false;
                comboBoxNakit.SelectedIndex = -1;
            }
        }

        private void btnTahsilatAra_Click(object sender, EventArgs e)
        {
            frmTahsilatHareketleri frmTahsilatHareketleri = new frmTahsilatHareketleri();
            DialogResult sonuc = frmTahsilatHareketleri.ShowDialog();


            if (sonuc == DialogResult.OK)
            {
                txtTahsilatNo.Text = frmTahsilatHareketleri.TahsilatIdGonder;
                txtCariKod.Text = frmTahsilatHareketleri.CariKodGonder;
                txtCariID.Text = frmTahsilatHareketleri.CariIdGonder;
                txtCariAd.Text = frmTahsilatHareketleri.CariAdGonder;
                txtFaturaNo.Text = frmTahsilatHareketleri.FaturaNoGonder;
                txtTutar.Text = frmTahsilatHareketleri.TutarGonder;

                dateTarih.Text = Convert.ToDateTime(frmTahsilatHareketleri.TarihGonder).ToString();
                comboOdemeTuru.Text = frmTahsilatHareketleri.OdemeTuruGoner;
                comboBoxBanka.Text = frmTahsilatHareketleri.BankaIdGonder;
                comboBoxNakit.Text = frmTahsilatHareketleri.KasaIdGonder;
                txtAciklama.Text = frmTahsilatHareketleri.AciklamaGonder;
            }
            else
            {

            }
        }

        private void btnCariAra_Click(object sender, EventArgs e)
        {
            FrmCariListele frmCariListele = new FrmCariListele();
            frmCariListele.CagrilanForm = this;

            frmCariListele.ShowDialog();
        }
        public void CariBilgileriYukle(string cariID, string cariKod, string cariAdi)
        {
            txtCariID.Text = cariID;
            txtCariKod.Text = cariKod;
            txtCariAd.Text = cariAdi;
        }
    }
}
