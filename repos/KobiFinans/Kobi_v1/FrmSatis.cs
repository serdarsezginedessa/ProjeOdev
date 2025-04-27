using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace Kobi_v1
{
    public partial class FrmSatis : Form
    {
        public FrmSatis()
        {
            InitializeComponent();
            
            
        }

        //************************Değişkenler**************************************
        #region degiskenler
        private string _secilenCariID; // ekle güncelle sil bu değişkene göre yapılacak..
        private string _secilenUrunID;
        private string _faturaTarihi;
        private string _faturaNo;
        private string _cariKod;
        private string _cariad;
        private int _currentFaturaNo;
        bool isLoading = false;
        #endregion


        private static string connectionString = ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);

        //*********************************************************************

        private void FrmSatis_Load(object sender, EventArgs e)
        {
            isLoading = true;

            dtHeader();
            
            dataGridView1.Rows.Add();
            
            btnYeniKayit.Enabled = true;
            btniptal.Enabled = false;
            btnSil.Enabled = false;
            btnGuncelle.Enabled = false;
            btnKayit.Enabled = false;
            btnKapat.Enabled=true;
            btnTahsilat.Enabled=true;
            txtGenelToplam.ReadOnly = true;
            txtKdvHaricTutar.ReadOnly = true;
            txtKdv.ReadOnly = true;
            txtToplamTutar.ReadOnly = true;
            


            /*if (txtFaturaNo.Text == null || txtFaturaNo.Text == "")
                {
                    btnTahsilat.Enabled = false;
                }*/



            this.KeyDown += btniptal_KeyDown;
            this.KeyDown += btnYeniKayit_KeyDown;
          
            isLoading = false;


           

        }

        //***************** Methot*************************************************************************
        #region Methot

        private void dtHeader()
        {
            if (dataGridView1.Columns.Count == 0)
            {
               
                dataGridView1.Columns.Add("UrunKodu", "Ürün Kodu");
                dataGridView1.Columns.Add("UrunAdi", "Ürün Adı");
                dataGridView1.Columns.Add("Adet", "Adet");
                dataGridView1.Columns.Add("Kdv", "Kdv");
                dataGridView1.Columns.Add("Fiyat", "Fiyat");
                dataGridView1.Columns.Add("Tutar", "Tutar");
                

            }
        }
        private void GelenFaturoNoSql()
        {
            
            try
            {
                DataTable dt = new DataTable();
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                if (_faturaNo == null) return;

                 
                //Fatura Üst Bilgisi Dolduruluyor
                SqlCommand cmd = new SqlCommand(@"SELECT si.SatisID, si.FaturaNo, si.Tarih, si.SatisTarihi
				                                            ,c.CariID,c.CariAdi
                                                            ,si.Durum

                                                            From SatisIslemleri as si

                                                            LEFT Join Cari as c
                                                            On si.CariID=c.CariID
                                                            LEFT Join SatisFaturaNo f
                                                            On si.FaturaNo=f.FaturaID
                                            

                                            Where si.FaturaNo=@faturano", baglanti);

                cmd.Parameters.AddWithValue("@faturano", _faturaNo);

                cmd.ExecuteNonQuery();
                
                dataGridView1.Rows.Clear();
                dtHeader();
                SqlCommand cmdDetay = new SqlCommand(@"
                                                        SELECT 
                                                            sd.UrunID, 
                                                            sd.Adet, 
                                                            sd.BirimFiyat, 
                                                            sd.KdvOrani, 
                                                            u.UrunKodu, 
                                                            u.UrunAdi
                                                        FROM 
                                                            SatisDetaylari sd
                                                        INNER JOIN 
                                                            Urunler u ON sd.UrunID = u.UrunID
                                                        WHERE 
                                                            sd.FaturaID = @faturaNo", baglanti);
                cmdDetay.Parameters.AddWithValue("@faturano", _faturaNo);
                SqlDataReader dr = cmdDetay.ExecuteReader();
                while (dr.Read())
                {
                    string urunID = dr["UrunId"].ToString();
                    string urunKodu = dr["UrunKodu"].ToString();
                    string urunAdi = dr["UrunAdi"].ToString();
                    int adet = Convert.ToInt32(dr["Adet"].ToString());
                    decimal birimFiyat = Convert.ToDecimal(dr["BirimFiyat"].ToString());
                    float kdvOrani = Convert.ToInt32(dr["KdvOrani"].ToString());
                    decimal tutar = adet * (birimFiyat); /// (1 + Convert.ToInt32(kdvOrani) / 100)); kdv hariç hesaplam için lazım olursa

                    dataGridView1.Rows.Add(urunKodu, urunAdi, adet, kdvOrani, birimFiyat, tutar);
                }
                dr.Close();

                 
                // Cari detay Bilgileri Fatura Sol Bölmesine Yükleniyor...
                SqlCommand cmd2 = new SqlCommand(@"SELECT c.CariID, c.CariKod, c.CariAdi, c.Yetkili, c.Eposta, c.Telefon, c.Aciklama, c.Resim
		                                                    
		                                                    ,ct.Ad ,si.Tarih, si.SatisTarihi, si.Durum
		                                                   
                                                            
                                                            From SatisIslemleri as si
                                                            
                                                            Inner Join Cari as c
                                                            On si.CariID=c.CariID
                                                            Inner Join SatisFaturaNo f
                                                            On si.FaturaNo=f.FaturaID                                                            
		                                                    Inner Join CariTuru ct
		                                                    ON c.CariTuru=ct.ID


		                                                    where si.FaturaNo=@faturano

		                                                    group by c.CariID, c.CariAdi,c.CariKod,c.Yetkili,c.Eposta,c.Telefon,c.Aciklama,c.Resim
		                                                    ,ct.Ad
		                                                    ,si.Tarih, si.SatisTarihi,si.Durum", baglanti);

                cmd2.Parameters.AddWithValue("@faturano", _faturaNo);
                SqlDataReader dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {
                    lblMusteriTuru.Text = "Cari Türü :" + dr2["Ad"].ToString();

                    lblCariID.Text = "Cari No :" + dr2["CariID"].ToString();

                    lblCariKod.Text = "Cari Kod :" + dr2["CariKod"].ToString();

                    LblMusteri.Text = dr2["CariAdi"].ToString();



                    if (dr2["Eposta"].ToString() == "")
                        lblEposta.Text = "Eposta :";
                    else lblEposta.Text = dr2["Eposta"].ToString();
                    if (dr2["Telefon"].ToString() == "")
                    {
                        lblTelefon.Text = "Telefon:";
                    }
                    else lblTelefon.Text = "Telelefon: " + dr2["Telefon"].ToString();

                    if (dr2["Yetkili"].ToString() == "")
                        lblYetkili.Text = "Yetkili:";
                    else lblYetkili.Text = "Yetkili : " + dr2["Yetkili"].ToString();


                    txtID.Text = dr2["CariID"].ToString();
                    txtCariAd.Text = dr2["CariAdi"].ToString();


                    comboBoxDurum.Text = dr2["Durum"].ToString();
                    dateKayit.Text = dr2["SatisTarihi"].ToString();

                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    if (dr2["Resim"].ToString() != "")
                    {
                        try
                        {
                            pictureBox1.ImageLocation = Application.StartupPath + dr2["Resim"].ToString();
                        }
                        catch (Exception hata)
                        {
                            MessageBox.Show("Resim Yüklenemedi: " + hata.ToString());
                        }
                    }
                    else
                    {
                        pictureBox1.Image = null;
                    }

                }
                dr2.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Fatura Yüklenirken Hata Oluştu!" + ex.ToString());
            }
            finally
            {

                baglanti.Close();

            }
            
        }
        
        private void FaturaUstBigiKayit()
        {
            try
            {

                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                string sqlAcikHesap = @"Insert into SatisIslemleri (FaturaNo, CariID, SatisTarihi, Durum)
                                                       Values (@faturaNo, @cariID, @tarih, @durum);
                                                        SELECT SCOPE_IDENTITY();";

                SqlCommand kmtAcikHesapInsert = new SqlCommand(sqlAcikHesap, baglanti);
                kmtAcikHesapInsert.Parameters.Clear();
                kmtAcikHesapInsert.Parameters.AddWithValue("@faturaNo", txtFaturaNo.Text);
                kmtAcikHesapInsert.Parameters.AddWithValue("@cariID", txtID.Text);
                kmtAcikHesapInsert.Parameters.AddWithValue("@tarih", dateKayit.Value);
                kmtAcikHesapInsert.Parameters.AddWithValue("@durum", comboBoxDurum.Text);

                int SatisNo = Convert.ToInt32(kmtAcikHesapInsert.ExecuteScalar());
                txtSatisNo.Text = SatisNo.ToString();
                baglanti.Close();


            }

            catch (Exception ex)
            {
                MessageBox.Show("Fatura Üst Bigi Kayıt Edilirken Bir Hata Oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglanti.Close();
            }

        }
        private bool UrunEklenmisMi()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue; // Boş yeni satırı atla

                // Burada senin ürün eklerken doldurduğun kolona bakacağız
                if (row.Cells["UrunKodu"].Value != null && row.Cells["UrunKodu"].Value.ToString() != "")
                {
                    return true; // Ürün eklenmiş
                }
            }
            return false; // Ürün eklenmemiş
        }

        private void SatisDetayKayit()  
        {
            try
            {

            
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();
            

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    if (row.IsNewRow) continue;

                    if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                    string urunKodu = row.Cells["UrunKodu"].Value.ToString();
                    SqlCommand cmdurunkod = new SqlCommand("select UrunID from urunler where UrunKodu=@urunkodu;SELECT SCOPE_IDENTITY();", baglanti);
                    cmdurunkod.Parameters.AddWithValue("@urunkodu", urunKodu);

                    int urunID = Convert.ToInt32(cmdurunkod.ExecuteScalar());

                    int adet = Convert.ToInt32(row.Cells["Adet"].Value);
                    decimal fiyat = Convert.ToDecimal(row.Cells["Fiyat"].Value);
                    decimal kdv = Convert.ToDecimal(row.Cells["Kdv"].Value);

                    SqlCommand cmdDetay = new SqlCommand(@"INSERT INTO SatisDetaylari 
                (FaturaID, UrunID, Adet, BirimFiyat, KdvOrani)
                VALUES (@FaturaID, @UrunID, @Adet, @BirimFiyat, @KdvOrani)", baglanti);

                    cmdDetay.Parameters.AddWithValue("@FaturaID", Convert.ToInt32(txtFaturaNo.Text));
                    cmdDetay.Parameters.AddWithValue("@UrunID", urunID);
                    cmdDetay.Parameters.AddWithValue("@Adet", adet);
                    cmdDetay.Parameters.AddWithValue("@BirimFiyat", fiyat);
                    cmdDetay.Parameters.AddWithValue("@KdvOrani", kdv);

                    cmdDetay.ExecuteNonQuery();
                    
                    baglanti.Close();
                }
                MessageBox.Show("Fatura Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch(Exception ex)
            {
                MessageBox.Show("Ürün Detayları Kaydedilirken Bir Sorun Oluştu.", "Database Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void CariEklenmisMi()
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Lütfen Önce Cari Ekleyiniz", "Cari Seçiniz", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
        }
         
        private void UrunleriTopluGuncelle()
        {
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();
            // Önce var olan kayıtları sil (bu fatura için)
            SqlCommand cmdSil = new SqlCommand("DELETE FROM SatisDetaylari WHERE FaturaID = @faturaNo", baglanti);
            cmdSil.Parameters.AddWithValue("@faturaNo", _faturaNo);
            cmdSil.ExecuteNonQuery();

            // Ürünleri toplamak için sözlük açıyoruz
            Dictionary<string, (string urunAdi, decimal adet, decimal fiyat, int kdv)> urunler = new Dictionary<string, (string, decimal, decimal, int)>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                string urunKodu = row.Cells["UrunKodu"].Value?.ToString();
                string urunAdi = row.Cells["UrunAdi"].Value?.ToString();
                decimal adet = Convert.ToDecimal(row.Cells["Adet"].Value ?? 0);
                decimal fiyat = Convert.ToDecimal(row.Cells["Fiyat"].Value ?? 0);
                int kdv = Convert.ToInt32(row.Cells["Kdv"].Value ?? 0);

                if (urunler.ContainsKey(urunKodu))
                {
                    // Aynı üründen varsa, adeti birleştir
                    urunler[urunKodu] = (urunAdi, urunler[urunKodu].adet + adet, fiyat, kdv);
                }
                else
                {
                    urunler.Add(urunKodu, (urunAdi, adet, fiyat, kdv));
                }
            }

            // Şimdi topladıklarımızı veritabanına kaydedelim
            foreach (var item in urunler)
            {
                string urunKodu = item.Key;
                string urunAdi = item.Value.urunAdi;
                decimal adet = item.Value.adet;
                decimal fiyat = item.Value.fiyat;
                int kdv = item.Value.kdv;

                // UrunID'yi bulmamız gerekiyor
                SqlCommand cmdUrunID = new SqlCommand("SELECT UrunID FROM Urunler WHERE UrunKodu = @kod", baglanti);
                cmdUrunID.Parameters.AddWithValue("@kod", urunKodu);
                object urunIdObj = cmdUrunID.ExecuteScalar();
                if (urunIdObj != null)
                {
                    int urunId = Convert.ToInt32(urunIdObj);

                    // Şimdi kaydedelim
                    SqlCommand cmdInsert = new SqlCommand("INSERT INTO SatisDetaylari (FaturaID, UrunID, Adet, BirimFiyat, KdvOrani) VALUES (@faturaID, @urunID, @adet, @birimFiyat, @kdvOrani)", baglanti);
                    cmdInsert.Parameters.AddWithValue("@faturaID", _faturaNo);
                    cmdInsert.Parameters.AddWithValue("@urunID", urunId);
                    cmdInsert.Parameters.AddWithValue("@adet", adet);
                    cmdInsert.Parameters.AddWithValue("@birimFiyat", fiyat);
                    cmdInsert.Parameters.AddWithValue("@kdvOrani", kdv);
                    cmdInsert.ExecuteNonQuery();
                }
            }
        }



        private void FaturaSil(string faturaNo)
        {
            if (string.IsNullOrEmpty(faturaNo))
            {
                MessageBox.Show("Lütfen silmek için bir fatura seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Fatura No: {faturaNo} olan faturayı silmek istediğinize emin misiniz?",
                "Fatura Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // Önce detaylardan sil
                        SqlCommand cmdDetay = new SqlCommand(
                            "DELETE FROM SatisDetaylari WHERE FaturaID = @FaturaNo",
                            conn, transaction
                        );
                        cmdDetay.Parameters.AddWithValue("@FaturaNo", faturaNo);
                        cmdDetay.ExecuteNonQuery();

                        // Sonra üst bilgiden sil
                        SqlCommand cmdUst = new SqlCommand(
                            "DELETE FROM SatisIslemleri WHERE FaturaNo = @FaturaNo",
                            conn, transaction
                        );
                        cmdUst.Parameters.AddWithValue("@FaturaNo", faturaNo);
                        cmdUst.ExecuteNonQuery();

                        transaction.Commit();

                        MessageBox.Show("Fatura başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Fatura silinirken bir hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                YeniKayitHazirla();
            }
            else
            {
                return;
            }
               
            
        }

        private void FaturaNo()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                SqlCommand komut = new SqlCommand("Insert Into SatisFaturaNo DEFAULT VALUES; SELECT SCOPE_IDENTITY();", baglanti);

                object result = komut.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out _currentFaturaNo))
                {

                    txtFaturaNo.Text = _currentFaturaNo.ToString();
                }
                else
                {
                    MessageBox.Show("Yeni Fatura ID oluşturulurken bir hata oluştu.");
                    _currentFaturaNo = 0; // Hata durumunda sıfırla veya başka bir değer atayın.
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
                _currentFaturaNo = 0;
            }
            finally
            {
                if (baglanti.State == ConnectionState.Open) baglanti.Close();
            }
        }

        private void textComboTemizle()
        {
            comboBoxDurum.SelectedIndex = 0;



            txtID.Text = "";
            txtFaturaNo.Text = "";
            txtCariAd.Text = "";
            txtToplamTutar.Text = "";
            txtKdv.Text = "";
            txtGenelToplam.Text = "";
            txtKdvHaricTutar.Text = "";

            

            LblMusteri.Text = "Müşteri Adı";
            lblCariID.Text = "Cari No";
            lblCariKod.Text = "Cari Kod";
            lblMusteriTuru.Text = "Cari Türü";
            lblTelefon.Text = "Telefon";
            lblEposta.Text = "Eposta";
            lblYetkili.Text = "Yetkili";
            pictureBox1.Image = null;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;





        }//btniptal de kullanılıyor

        private void ToplamlariHesapla()
        {
            decimal kdvHaricToplam = 0;
            decimal kdvToplam = 0;
            decimal genelToplam = 0;
            decimal topTutar = 0;


            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                decimal urunfiyat = Convert.ToDecimal(row.Cells["Fiyat"].Value ?? 0);
                int urunadet = Convert.ToInt32(row.Cells["Adet"].Value ?? 0);
                float urunkdvOran = Convert.ToInt32(row.Cells["Kdv"].Value ?? 0);
                decimal tutar = Convert.ToDecimal(row.Cells["Tutar"].Value ?? 0);

                decimal kdvMatrahi = tutar / Convert.ToDecimal((urunkdvOran / 100) + 1);
                decimal araToplam = tutar;
                decimal kdvTutar = (tutar - kdvMatrahi);
                decimal toplam = (kdvMatrahi + kdvTutar) * urunadet;



                kdvHaricToplam += kdvMatrahi;
                kdvToplam += kdvTutar;
                topTutar += tutar;
                genelToplam = topTutar;


            }

            txtKdvHaricTutar.Text = kdvHaricToplam.ToString("N2");
            txtKdv.Text = kdvToplam.ToString("N2");
            txtToplamTutar.Text = topTutar.ToString("N2");
            txtGenelToplam.Text = genelToplam.ToString("N2");

            

        }//dataGridView1_CellValueChanged olayında kullanılıyor..

        private void YeniKayitHazirla() //btnYeniKayıt butonunda kullanılıyor.
        {
            dataGridView1.Rows.Clear();
            if (dataGridView1.Rows.Count == 0)
            {
                dataGridView1.Rows.Add();
            }
            // Müşteri bilgilerini temizle
            pictureBox1.Image = null;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            LblMusteri.Text = "Müşteri Adı";
            lblCariID.Text = "Cari No";
            lblCariKod.Text = "Cari Kod";
            lblMusteriTuru.Text = "Cari Türü";
            lblYetkili.Text = "Yetkili";
            lblTelefon.Text = "Telefon";
            lblEposta.Text = "Eposta";

            // Form alanlarını temizle
            txtSatisNo.Text = "";
            txtID.Text = "";
            txtCariAd.Text = "";


            txtFaturaNo.Text = ""; // Otomatik atanabilir
            dateKayit.Value = DateTime.Now;
            dateKayit.Enabled = true;

            // ComboBox seçimleri
            comboBoxDurum.SelectedText = "Yeni";

            comboBoxDurum.Enabled = true;

            // Tutarlar
            txtKdvHaricTutar.Text = "";
            txtKdv.Text = "";
            txtToplamTutar.Text = "";
            txtGenelToplam.Text = "";

            // DataGridView temizle

            dataGridView1.Enabled = true;



            // Gerekli buton aktiflikleri
            btnYeniKayit.Enabled = true;
            btnKayit.Enabled = false;
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
            btniptal.Enabled = true;
        }
        /* private void SatisKayit()
        {


            SqlTransaction transaction = null;

            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                if (txtID.Text == null)
                {
                    MessageBox.Show("Lütfen Cari Seçiniz");
                    return;
                }
                else if (txtFaturaNo.Text == "")
                {
                    MessageBox.Show("Lütfen Fatura No Giriniz");
                    return;
                }
                else if (comboBoxDurum.Text == "" || comboBoxDurum.Text == "Seçiniz")
                {
                    MessageBox.Show("Durum Seçiniz");
                    return;
                }
                else if (dataGridView1.Rows.Count < 1)
                {
                    MessageBox.Show("Lütfen En Az 1 Ürün Seçiniz");
                    return;
                }


                else if (comboboxOdemeTuru.Text == "" || comboboxOdemeTuru.Text == "Seçiniz")
                {
                    MessageBox.Show("Ödeme Yöntemi Seçiniz");
                    return;
                }
                if (comboboxOdemeTuru.Text == "Açık Hesap")
                {

                }
                else if (comboboxOdemeTuru.Text == "Nakit")
                {
                    if (comboBoxKasa.Text == "" || comboBoxKasa.Text == "Seçiniz")
                    {
                        MessageBox.Show("Kasa Seçiniz");
                        return;
                    }

                }
                else
                {
                    if (comboBoxBanka.Text == "" || comboBoxBanka.Text == "Banka Seçiniz")
                    {
                        MessageBox.Show("Banka Seçiniz");
                        return;
                    }
                }
                transaction = baglanti.BeginTransaction();
                
               
               
                    string sqlAcikHesap = @"Insert into SatisIslemleri (FaturaNo, CariID, SatisTarihi, Durum)
                                                       Values (@faturaNo, @cariID, @tarih, @durum)";

                    //*************************************************************************************
                    SqlCommand kmtAcikHesapInsert = new SqlCommand(sqlAcikHesap, baglanti, transaction);

                    kmtAcikHesapInsert.Parameters.Clear();
                    kmtAcikHesapInsert.Parameters.AddWithValue("@faturaNo", txtFaturaNo.Text);
                    kmtAcikHesapInsert.Parameters.AddWithValue("@cariID", txtID.Text);
                    kmtAcikHesapInsert.Parameters.AddWithValue("@tarih", dateKayit.Value);
                    kmtAcikHesapInsert.Parameters.AddWithValue("@durum", comboBoxDurum.Text);

                    kmtAcikHesapInsert.ExecuteNonQuery();
                

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    

                    if (!row.IsNewRow && row.Cells["UrunKodu"].Value != null && row.Cells["UrunAdi"].Value != null && row.Cells["Adet"].Value != null && row.Cells["Tutar"].Value != null)
                    {
                        // Her satırdaki ürün bilgilerini alın
                        string urunKodu = row.Cells["UrunKodu"].Value.ToString();
                        string urunAdi = row.Cells["UrunAdi"].Value.ToString();
                        //decimal tahsilat = 0;
                        if (int.TryParse(row.Cells["Adet"].Value.ToString(), out int adet))
                        {
                            if (decimal.TryParse(row.Cells["Tutar"].Value.ToString(), out decimal tutar))
                            {
                                // Ürün kodundan UrunID'yi veritabanından çekiyoruz..
                                int urunID = 0;
                                SqlCommand cmdUrunID = new SqlCommand("SELECT UrunID FROM Urunler WHERE UrunKodu = @urunKodu", baglanti, transaction);
                                cmdUrunID.Parameters.AddWithValue("@urunKodu", urunKodu);
                                object urunIDResult = cmdUrunID.ExecuteScalar();
                                if (urunIDResult != null && int.TryParse(urunIDResult.ToString(), out int urunIDValue))
                                {
                                    urunID = urunIDValue;

                                    int? kasaID = null;  
                                    string kasaAd = comboBoxKasa.Text;
                                    int? bankaID = null;
                                    //string OdemeTuru = comboboxOdemeTuru.Text;
                                    int? odemeID = null; 
                                    DateTime satisTarihi = dateKayit.Value;

                                    // Ödeme türüne göre KasaID veya BankaID belirle ve INSERT sorgusunu çalıştır
                                    if (OdemeTuru == "Açık Hesap")
                                    {
                                        odemeID = Convert.ToInt32(comboboxOdemeTuru.SelectedValue);


                                        
                                       
                                         kmtAcikHesapInsert.Parameters.AddWithValue("@urunID", urunID);
                                         kmtAcikHesapInsert.Parameters.AddWithValue("@adet", adet);
                                         kmtAcikHesapInsert.Parameters.AddWithValue("@odemeID", odemeID);

                                         Decimal.TryParse(row.Cells["Kdv"].Value.ToString() ,out decimal kdv);
                                         decimal kdvmatrahi = tutar / ((kdv / 100) + 1);
                                         kmtAcikHesapInsert.Parameters.AddWithValue("@kdvmatrahi",kdvmatrahi);
                                         decimal kdvtutari =tutar-kdvmatrahi;
                                         kmtAcikHesapInsert.Parameters.AddWithValue("@kdvtutari",kdvtutari);
                                         kmtAcikHesapInsert.Parameters.AddWithValue("@tutar", tutar);
                                         decimal geneltoplam = tutar;
                                         kmtAcikHesapInsert.Parameters.AddWithValue("@geneltoplam", geneltoplam);

                                         if (txtTahsilatTutar.Text==null |txtTahsilatTutar.Text=="" || txtTahsilatTutar.Text=="0")
                                             tahsilat=0;
                                         else tahsilat=Convert.ToDecimal(txtTahsilatTutar.Text);
                                         kmtAcikHesapInsert.Parameters.AddWithValue("@tahsilat",tahsilat);

                                         



                                    }
                                    if (OdemeTuru == "Nakit")
                                    {
                                        odemeID = Convert.ToInt32(comboboxOdemeTuru.SelectedValue);
                                        kasaID = Convert.ToInt32(comboBoxKasa.SelectedValue);
                                        string sqlnakit = @"Insert into SatisIslemleri ([UrunID], [CariID], KasaID,[OdemeID], [SatisTarihi],[Durum],[FaturaNo])
                                                       Values (@urunID, @cariID,@kasaID, @odemeID, @tarih, @durum,@faturaNo)";
                                        SqlCommand kmtNakitInsert = new SqlCommand(sqlnakit, baglanti, transaction);
                                        kmtNakitInsert.Parameters.Clear();

                                        kmtNakitInsert.Parameters.AddWithValue("@faturaNo", txtFaturaNo.Text);
                                        kmtNakitInsert.Parameters.AddWithValue("@cariID", txtID.Text);
                                        kmtNakitInsert.Parameters.AddWithValue("@tarih", satisTarihi);
                                        kmtNakitInsert.Parameters.AddWithValue("@durum", comboBoxDurum.Text);

                                        kmtNakitInsert.ExecuteNonQuery();
                                         
                                            kmtNakitInsert.Parameters.AddWithValue("@adet", adet);
                                            kmtNakitInsert.Parameters.AddWithValue("@urunID", urunID);
                                            kmtNakitInsert.Parameters.AddWithValue("@kasaID", kasaID);
                                            kmtNakitInsert.Parameters.AddWithValue("@odemeID", odemeID);
                                            Decimal.TryParse(row.Cells["Kdv"].Value.ToString(), out decimal kdv);
                                            decimal kdvmatrahi = tutar / ((kdv / 100) + 1);
                                            kmtNakitInsert.Parameters.AddWithValue("@kdvmatrahi", kdvmatrahi);
                                            decimal kdvtutari = tutar - kdvmatrahi;
                                            kmtNakitInsert.Parameters.AddWithValue("@kdvtutari", kdvtutari);
                                            kmtNakitInsert.Parameters.AddWithValue("@tutar", tutar);
                                            decimal geneltoplam = tutar;
                                            kmtNakitInsert.Parameters.AddWithValue("@geneltoplam", geneltoplam);
                                            if (txtTahsilatTutar.Text == null | txtTahsilatTutar.Text == "" || txtTahsilatTutar.Text == "0")
                                                MessageBox.Show("Ödeme Tutarını Giriniz.");
                                            else tahsilat = Convert.ToDecimal(txtTahsilatTutar.Text);

                                            kmtNakitInsert.Parameters.AddWithValue("@tahsilat", tahsilat);
                                        


                                    }
                                    else if (OdemeTuru == "Havale" || OdemeTuru == "Kredi Kartı")
                                    {
                                        odemeID = Convert.ToInt32(comboboxOdemeTuru.SelectedValue);
                                        bankaID = Convert.ToInt32(comboBoxBanka.SelectedValue);

                                        string sqlBanka = @"Insert into SatisIslemleri ([UrunID], [CariID], BankaID,[OdemeID], [SatisTarihi],[Durum],[FaturaNo])
                                                       Values (@urunID, @cariID,@bankaID, @odemeID, @tarih,  @durum,@faturaNo)";
                                        SqlCommand kmtBankaInsert = new SqlCommand(sqlBanka, baglanti, transaction);
                                        kmtBankaInsert.Parameters.Clear();
                                        kmtBankaInsert.Parameters.AddWithValue("@urunID", urunID);
                                        kmtBankaInsert.Parameters.AddWithValue("@cariID", _secilenCariID);
                                        kmtBankaInsert.Parameters.AddWithValue("@bankaID", bankaID);//.HasValue ? (object)bankaID.Value : DBNull.Value);
                                        kmtBankaInsert.Parameters.AddWithValue("@odemeID", odemeID);
                                        kmtBankaInsert.Parameters.AddWithValue("@tarih", satisTarihi);

                                        kmtBankaInsert.Parameters.AddWithValue("@adet", adet);

                                        Decimal.TryParse(row.Cells["Kdv"].Value.ToString(), out decimal kdv);
                                        decimal kdvmatrahi = tutar / ((kdv / 100) + 1);
                                        kmtBankaInsert.Parameters.AddWithValue("@kdvmatrahi", kdvmatrahi);
                                        decimal kdvtutari = tutar - kdvmatrahi;
                                        kmtBankaInsert.Parameters.AddWithValue("@kdvtutari", kdvtutari);
                                        kmtBankaInsert.Parameters.AddWithValue("@tutar", tutar);
                                        decimal geneltoplam = tutar;
                                        kmtBankaInsert.Parameters.AddWithValue("@geneltoplam", geneltoplam);
                                        if (txtTahsilatTutar.Text == null | txtTahsilatTutar.Text == "" || txtTahsilatTutar.Text == "0")
                                            MessageBox.Show("Tahsilat Tutarını Giriniz");
                                        else tahsilat = Convert.ToDecimal(txtTahsilatTutar.Text);

                                        kmtBankaInsert.Parameters.AddWithValue("@tahsilat", tahsilat);
                                        kmtBankaInsert.Parameters.AddWithValue("@durum", comboBoxDurum.Text);
                                        kmtBankaInsert.Parameters.AddWithValue("@faturaNo", txtFaturaNo.Text);
                                        kmtBankaInsert.ExecuteNonQuery();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Ürün kodu '{urunKodu}' ile eşleşen ürün bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    transaction.Rollback();
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show($"Geçersiz tutar değeri: Ürün Kodu {urunKodu}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                transaction.Rollback();
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show($"Geçersiz adet değeri: Ürün Kodu {urunKodu}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            transaction.Rollback();
                            return;
                        }
                    }
                }

                transaction.Commit();
                textComboTemizle();
                dataGridView1.Rows.Clear();
                dataGridView1.Rows.Add();
                btnYeniKayit.Enabled = true;
                btniptal.Enabled = false;
                btnKayit.Enabled = false;
                btnGuncelle.Enabled = false;
                btnSil.Enabled = false;
                MessageBox.Show("Satış işlemleri başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                MessageBox.Show("Veritabanı hatası: " + ex.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (baglanti.State == ConnectionState.Open) baglanti.Close();
            }
        }*/
        /*private void SatisSil()
       {
           try
           {
               if (MessageBox.Show("Bu satışı silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo) == DialogResult.Yes)
               {
                   int faturaNo = Convert.ToInt32(txtFaturaNo.Text);



                   if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                   {

                       SqlCommand cmd2 = new SqlCommand("DELETE FROM SatisIslemleri WHERE FaturaNo = @FaturaNO", baglanti);
                       cmd2.Parameters.AddWithValue("@FaturaNO", faturaNo);
                       cmd2.ExecuteNonQuery();
                   }

                   MessageBox.Show("Satış silindi.");
                   YeniKayitHazirla();
               }
           }
           catch (Exception ex)
           {
               MessageBox.Show("Silme Hatası" + ex.ToString());
           }
           finally
           {
               baglanti.Close();
           }

       }*/
        /*  private void TahsilatYap()
          {
              try
              {

                  //decimal genelToplam = 0;// Convert.ToDecimal(txtGenelToplam.Text);
                  decimal tahsilEdilen=0;
                  if(txtTahsilatTutar.Text=="")
                  {
                      tahsilEdilen = 0;
                  }
                  else
                  {
                      tahsilEdilen = Convert.ToDecimal(txtTahsilatTutar.Text);
                  }

                  //decimal kalan = genelToplam - tahsilEdilen;
                  string odemeTuru = comboboxOdemeTuru.Text;
                  string Havale_KK = comboBoxBanka.Text;
                  int cariID = Convert.ToInt32(txtID.Text);
                  DateTime tarih = DateTime.Now;
                  string aciklama = "Satış Tahsilatı";


                  if (baglanti.State == ConnectionState.Closed) baglanti.Open();


                  SqlCommand cmd = new SqlCommand();
                  cmd.Connection = baglanti;

                  if (odemeTuru == "Nakit" )
                  {
                      if(comboBoxKasa.Text=="Seçiniz" || comboBoxKasa.Text=="" || comboBoxKasa.Text==null)
                      {
                          MessageBox.Show("Lütfen Kasa Seçiniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                          return;
                      }
                      if(txtTahsilatTutar.Text=="" || txtTahsilatTutar.Text==null || txtTahsilatTutar.Text=="0")
                      {
                          MessageBox.Show("Lütfen Tutar Giriniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                          return;

                      }
                      int kasaID =Convert.ToInt32(comboBoxKasa.SelectedValue);



                      cmd.CommandText = "INSERT INTO KasaHareketleri (KasaID, CariID, Tarih, Tutar, Aciklama, HareketTipi) " +
                                        "VALUES (@KasaID, @CariID, @Tarih, @Tutar, @Aciklama, @HareketTipi)";
                      cmd.Parameters.AddWithValue("@KasaID", kasaID);
                      cmd.Parameters.AddWithValue("@CariID", cariID);
                      cmd.Parameters.AddWithValue("@Tarih", tarih);
                      cmd.Parameters.AddWithValue("@Tutar", tahsilEdilen);
                      cmd.Parameters.AddWithValue("@Aciklama", aciklama);
                      cmd.Parameters.AddWithValue("@HareketTipi", "Tahsilat");
                  }

                  else if (odemeTuru=="Havale" || odemeTuru=="Kredi Kartı")
                  {
                      if(Havale_KK ==null || Havale_KK=="" || Havale_KK=="Seçiniz" )
                      {
                          MessageBox.Show("Lütfen Banka Ödeme Türü Seçiniz","Bilgi",  MessageBoxButtons.OK, MessageBoxIcon.Information);
                          return;
                      }
                      else if(txtTahsilatTutar.Text == "" || txtTahsilatTutar.Text == null || txtTahsilatTutar.Text == "0")
                      {
                          MessageBox.Show("Lütfen Tutar Giriniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                          return;
                      }
                      else
                      {
                          int bankaID = Convert.ToInt32(comboBoxBanka.SelectedValue);

                          cmd.CommandText = "INSERT INTO BankaHareket (BankaID, CariID, Tarih, Tutar, Aciklama, HareketTipi, Kaynak) " +
                                            "VALUES (@BankaID, @CariID, @Tarih, @Tutar, @Aciklama, @HareketTipi, @Kaynak)";
                          cmd.Parameters.AddWithValue("@BankaID", bankaID);
                          cmd.Parameters.AddWithValue("@CariID", cariID);
                          cmd.Parameters.AddWithValue("@Tarih", tarih);
                          cmd.Parameters.AddWithValue("@Tutar", tahsilEdilen);
                          cmd.Parameters.AddWithValue("@Aciklama", aciklama);
                          cmd.Parameters.AddWithValue("@HareketTipi", "Tahsilat");
                          cmd.Parameters.AddWithValue("@Kaynak", "Satış");
                      }




                  }

                  cmd.ExecuteNonQuery();
                  baglanti.Close();
                  MessageBox.Show("Tahsilat başarıyla kaydedildi.");

              }
              catch (Exception ex)
              {
                  MessageBox.Show("Hata: " + ex.ToString());
              }
              finally
              {
                  baglanti.Close();
              }
          }*/

        /* private void HesaplaKalanTutar()
         {
             if (decimal.TryParse(txtGenelToplam.Text, out decimal genelToplam) &&
                 decimal.TryParse(txtTahsilatTutar.Text, out decimal tahsilat))
             {

                 decimal kalan = genelToplam - tahsilat;
                 txtKalanTutar.Text = kalan.ToString("N2"); // Binlik ayraçlı, 2 ondalıklı
             }
             else
             {
                 return;
             }
         }*/
        /* private void GridVeriYukle(DataTable dt)
         {
             dataGridView1.Rows.Clear();

             foreach (DataRow row in dt.Rows)
             {
                 dataGridView1.Rows.Add(

                     row["Ürün Kodu"].ToString(),
                     row["Ürün Adı"].ToString(),
                     row["Adet"].ToString(),
                     row["Kdv"].ToString(),
                     row["SatisFiyat"].ToString(),
                     row["Tutar"].ToString()
                 );
             }
         }//StokBilgileriYükle methodunda kullanılıyor.*/
        /*private void BankaBilgileriSec()
 {
     try
     {

         if (baglanti.State == ConnectionState.Closed) baglanti.Open();
         SqlDataAdapter da = new SqlDataAdapter("select BankaID,BankaAd from Bankalar", baglanti);
         DataTable dt = new DataTable();
         da.Fill(dt);

         DataRow row =dt.NewRow();
         row["BankaID"] = DBNull.Value;
         row["BankaAd"] = "Seçiniz";
         dt.Rows.InsertAt(row, 0);
         comboBoxBanka.DataSource = dt;
         comboBoxBanka.DisplayMember = "BankaAd";
         comboBoxBanka.ValueMember = "BankaID";

     }
     catch (Exception hata)
     {
         MessageBox.Show("Hata: " + hata.Message);
     }
     finally
     {
         baglanti.Close();
         comboBoxBanka.SelectedIndex = 0;
     }
 }
 private void OdemeTuruSec()
 {
     try
     {
         if (baglanti.State == ConnectionState.Closed) baglanti.Open();
         SqlDataAdapter da = new SqlDataAdapter("SELECT OdemeID, OdemeAd FROM OdemeTuru", baglanti);
         DataTable dt = new DataTable();
         da.Fill(dt);

         // "Seçiniz" seçeneğini elle ekle
         DataRow row = dt.NewRow();
         row["OdemeID"] = DBNull.Value;
         row["OdemeAd"] = "Seçiniz";
         dt.Rows.InsertAt(row, 0);

         comboboxOdemeTuru.DataSource = dt;
         comboboxOdemeTuru.DisplayMember = "OdemeAd";
         comboboxOdemeTuru.ValueMember = "OdemeID";
         comboboxOdemeTuru.SelectedIndex = 0;
     }
     catch (Exception hata)
     {
         MessageBox.Show("Hata: " + hata.Message);
     }
     finally
     {
         baglanti.Close();
     }
 }

 private void KasaSec()
 {

     try
     {

         if (baglanti.State == ConnectionState.Closed) baglanti.Open();
         SqlDataAdapter da = new SqlDataAdapter("select KasaID, KasaAdi from Kasalar", baglanti);
         DataTable dt = new DataTable();
         da.Fill(dt) ;

         DataRow row = dt.NewRow();
         row["KasaID"] = DBNull.Value;
         row["KasaAdi"] = "Seçiniz";
         dt.Rows.InsertAt (row, 0);

         comboBoxKasa.DataSource = dt;
         comboBoxKasa.DisplayMember = "KasaAdi";
         comboBoxKasa.ValueMember = "KasaID";
         comboBoxKasa.SelectedIndex = 0;
     }
     catch (Exception hata)
     {
         MessageBox.Show("Hata: " + hata.Message);
     }
     finally
     {
         baglanti.Close();
     }
 }*/
        #endregion

        //*****************************Başka Formlardan Veri Çeken Metotlar..******************************
        #region BilgiGetir
        public void SatisBigileriYukle(DataGridViewRow satir, string satisid,string faturaTarihi, string faturaNo, string cariKod, string cariAd /*, string kdvMatrahi, string kdvTutari, string tutar, string genelToplam,string tahsilat*/)
        {
            _faturaTarihi = faturaTarihi;
            _faturaNo = faturaNo;
            _cariKod = cariKod;
            _cariad = cariAd;
            txtSatisNo.Text = satisid;
            txtFaturaNo.Text = _faturaNo;

        }

        public void CariBilgileriYukle(string cariID,
                                    string CariKod,
                                    string CariAdi,
                                    string cariTur,
                                    string yetkili,
                                    string telefon,
                                    string ePosta,
                                    string resim)
        {

            _secilenCariID = cariID;
            LblMusteri.Text = CariAdi;
            lblCariKod.Text = "Cari Kod: " + CariKod;
            lblTelefon.Text = telefon;
            lblEposta.Text = ePosta;
            lblYetkili.Text = "Yetkili: " + yetkili;
            lblCariID.Text = "Cari No:" + _secilenCariID;
            lblMusteriTuru.Text = "Cari Türü: " + cariTur;
            txtCariAd.Text = CariAdi;
            txtID.Text = _secilenCariID;

            if (resim != "")
            {
                try
                {
                    pictureBox1.ImageLocation = Application.StartupPath + resim;
                }
                catch (Exception hata)
                {
                    MessageBox.Show("Resim Yüklenemedi: " + hata.ToString());
                }
            }
            else
            {
                pictureBox1.Image = null;
            }
        }

        public void StokBilgileriYukleEski2(string urunNo, string urunKodu, string urunAdi, string urunSatisFiyati, string urunKdv)
        {
            // Boş bir satır bul, yoksa yeni ekle
            int satirIndex = -1;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                if (row.Cells["UrunKodu"].Value == null || row.Cells["UrunKodu"].Value.ToString() == "")
                {
                    
                    break;
                }
                satirIndex = row.Index;
            }

            if (satirIndex == -1)
            {
                satirIndex = dataGridView1.Rows.Add();
            }

            var satir = dataGridView1.Rows[satirIndex];
            satir.Cells["UrunKodu"].Value = urunKodu;
            satir.Cells["UrunAdi"].Value = urunAdi;
            satir.Cells["Adet"].Value = 1;
            satir.Cells["Kdv"].Value = urunKdv;
            satir.Cells["Fiyat"].Value = urunSatisFiyati;

            // Hesapla
            decimal tutar = Convert.ToDecimal(urunSatisFiyati);
            satir.Cells["Tutar"].Value = tutar;
           
            // Yeni boş satır ekle (her zaman son satır boş olsun)
       /*     if (dataGridView1.Rows[dataGridView1.Rows.Count - 1].IsNewRow == false)
            {
                dataGridView1.Rows.Add();
            }*/

            
        }

        public void StokBilgileriYukle(string urunid,string urunKodu, string urunAdi, string urunSatisFiyati, string urunKdv,int satirIndex)
        {
            if (satirIndex >= dataGridView1.Rows.Count)
                satirIndex = dataGridView1.Rows.Add();

            var satir = dataGridView1.Rows[satirIndex];
            satir.Cells["UrunKodu"].Value = urunKodu;
            satir.Cells["UrunAdi"].Value = urunAdi;
            satir.Cells["Adet"].Value = 1;
            satir.Cells["Kdv"].Value = urunKdv;
            satir.Cells["Fiyat"].Value = urunSatisFiyati;
            satir.Cells["Tutar"].Value = Convert.ToDecimal(urunSatisFiyati);

        }




        #endregion

        //***************** Button************************************************************************* 
        #region Buttons



        private void btnKayit_Click(object sender, EventArgs e)
        {
            SatisDetayKayit();
            btnYeniKayit.Enabled = true;
            btnKayit.Enabled = false;
            btnSil.Enabled = true;
            btniptal.Enabled =false;
            btnGuncelle.Enabled = true;
            btnKapat.Enabled = true;
            
            //SatisKayit();


        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            UrunleriTopluGuncelle();
            
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFaturaNo.Text))
            {
                FaturaSil(txtFaturaNo.Text);
            }
            else
            {
                MessageBox.Show("Önce silmek istediğiniz faturayı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            
            //SatisSil();
        }
        private void btniptal_Click(object sender, EventArgs e)
        {
            textComboTemizle();
            
            dataGridView1.Rows.Clear();
            if(dataGridView1.Rows.Count == 0 )
            {
                dataGridView1.Rows.Add();
            }
           
            btnYeniKayit.Enabled = true;
            btniptal.Enabled = false;
            btnKayit.Enabled = false;
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
           
            


        }

        private void btnYeniKayit_Click(object sender, EventArgs e)
        {
            YeniKayitHazirla();
            btnAra_Click(e, e);
            comboBoxDurum.Text = "";
            comboBoxDurum.SelectedText = "Yeni";
            FaturaNo();
            

            

        }

        private void btnYeniKayit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {
                btnYeniKayit.PerformClick();
               // btnAra_Click(e.KeyValue , e);
                
            }
        }
        private void btnKayit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                btnKayit.PerformClick();
            }

        }

        private void btniptal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btniptal.PerformClick();
            }
            
        }
        private void btnSil_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F10)
            {
                btnSil.PerformClick();
                MessageBox.Show("Silme işlemi başarıyla gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }


        private void btnAra_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "" && txtID.Text!=null)
            {
                DialogResult result = MessageBox.Show("Faturanın Kayıtlı Olduğu Cariyi Değiştirmek İstediğine Eminmisin ?", "Cari Değişecek", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                
                if (result == DialogResult.OK)
                {
                    btnYeniKayit.Enabled = true;
                    btniptal.Enabled = false;
                    btnSil.Enabled = false;
                    btnKayit.Enabled = false;
                    btnGuncelle.Enabled = false;
                    btnKapat.Enabled = true;

                }
                else
                {
                    return;
                }
                                
            }
            
            
                FrmCariListele frmCariListele = new FrmCariListele();
                frmCariListele.CagrilanForm = this;
                frmCariListele.ShowDialog();
                btnYeniKayit.Enabled = false;
                btniptal.Enabled = true;
                btnKayit.Enabled = Enabled;
                btnGuncelle.Enabled = false;
                btnSil.Enabled = false;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            
            


        }
        private void btnAra_KeyDown(object sender, KeyEventArgs e)
        {
           /* if (e.KeyCode == Keys.F8)
            {
                btnAra.PerformClick();
            }*/
        }
        private void btnTahsilat_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtID.Text) || string.IsNullOrEmpty(txtFaturaNo.Text))
            {
                MessageBox.Show("Tahsilat Yapmak İçin Lütfen Önce Fatura Bilgilerini Giriniz", "Uyarı",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FrmTahsilat frmTahsilat =new FrmTahsilat();

            frmTahsilat._cariID=Convert.ToInt32(txtID.Text);
            frmTahsilat._faturaNo=Convert.ToInt32(txtFaturaNo.Text);
            if (decimal.TryParse(txtGenelToplam.Text, out var tutar))
            {
                
                if(tutar==0m)
                {
                    MessageBox.Show("Faturada Tahsil Edilecek Tutar Yok", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //MessageBox.Show("Genel Toplam değeri geçersiz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
             
                
            }
            
            frmTahsilat._tutar = tutar;
             
            frmTahsilat._cariKod = lblCariKod.Text;
            
            frmTahsilat.ShowDialog();
            
        }

        #endregion

        //***************** combobox*************************************************************************

        #region comboBox

        /*        private void comboboxOdemeTuru_SelectedIndexChanged(object sender, EventArgs e)
                {
                    string secilen = comboboxOdemeTuru.Text;
                    if (secilen == "Nakit")
                    {
                        comboBoxKasa.Enabled = true;
                        comboBoxBanka.Enabled = false;
                        comboBoxKasa.Text="Merkez";
                        comboBoxBanka.SelectedIndex = 0;
                        btnTahsilat.Enabled = true;
                    }
                    else if (secilen == "Havale" || secilen == "Kredi Kartı")
                    {
                        comboBoxKasa.Enabled = false;
                        comboBoxBanka.Enabled = true;
                        comboBoxKasa.Text = "Seçiniz";
                        btnTahsilat.Enabled = true;
                    }
           
                    else
                    {
                        comboBoxKasa.Enabled = false;
                        comboBoxBanka.Enabled = false;
                        comboBoxKasa.Text = "Seçiniz";
                        comboBoxBanka.Text = "Seçiniz";
                        btnTahsilat.Enabled = false;
                        txtTahsilatTutar.Text = "";
                    }
                }
        */
        private void comboBoxDurum_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;  // Eğer form yükleniyorsa hiç bir şey yapma!

            string yeniDurum = comboBoxDurum.SelectedItem?.ToString();
            string faturaNo = txtFaturaNo.Text.Trim();

            if (!string.IsNullOrEmpty(yeniDurum) && !string.IsNullOrEmpty(faturaNo))
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE SatisIslemleri SET Durum = @Durum WHERE FaturaNo = @FaturaNo", conn);
                    cmd.Parameters.AddWithValue("@Durum", yeniDurum);
                    cmd.Parameters.AddWithValue("@FaturaNo", faturaNo);
                    cmd.ExecuteNonQuery();
                }
            }
        } 
        #endregion

        //***************** DataGridView*************************************************************************
        #region dataGrid



        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            

            if (!UrunEklenmisMi()&& txtSatisNo.Text =="") // Ürün yoksa
            {
                
                FaturaUstBigiKayit();
            }
            

            if (e.RowIndex >= 0)
            {
                    var row = dataGridView1.Rows[e.RowIndex];

                    // Eğer hücreler boşsa yeni ürün eklenecekse:
                    if (row.Cells["UrunKodu"].Value == null || string.IsNullOrWhiteSpace(row.Cells["UrunKodu"].Value.ToString()))
                    {
                        bosSatirIndex = e.RowIndex; // <<< burada eklersen boş satırı takip eder


                        FrmStoklar stoklar = new FrmStoklar();
                        stoklar.CagrilanForm = this;
                        stoklar.Tag = e.RowIndex;
                        stoklar.ShowDialog();


                    }
                    else
                    {
                        // Ürün değiştirme senaryosu
                        FrmStoklar stoklar = new FrmStoklar();
                        stoklar.CagrilanForm = this;
                        stoklar.Tag = e.RowIndex;
                        stoklar.ShowDialog();
                    }
            }
            



        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
            try
            {
                if (e.ColumnIndex == dataGridView1.Columns["Adet"].Index || e.ColumnIndex == dataGridView1.Columns["Fiyat"].Index || e.ColumnIndex == dataGridView1.Columns["Tutar"].Index)
                {
                    // Geçerli satırı al
                    DataGridViewRow currentRow = dataGridView1.Rows[e.RowIndex];

                    // Adet ve Fiyat değerlerini almayı dene
                    if (currentRow.Cells["Adet"].Value != null && currentRow.Cells["Fiyat"].Value != null && currentRow.Cells["Tutar"].Value != null)
                    {
                        if (decimal.TryParse(currentRow.Cells["Adet"].Value.ToString(), out decimal adet) &&
                            decimal.TryParse(currentRow.Cells["Fiyat"].Value.ToString(), out decimal fiyat) &&
                            decimal.TryParse(currentRow.Cells["Tutar"].Value.ToString(), out decimal tutar) &&
                            decimal.TryParse(currentRow.Cells["Kdv"].Value.ToString(), out decimal kdvOrani))
                        {
                            if (columnName == "Fiyat")
                            {
                                tutar = adet * fiyat;
                                // Tutar hücresini güncelle
                                currentRow.Cells["Tutar"].Value = tutar.ToString("N2"); // Virgülden sonra 2 basamaklı format
                            }

                            else if (columnName == "Tutar")
                            {
                                // Fiyat hücresini güncelle
                                fiyat = tutar / adet;
                                currentRow.Cells["Fiyat"].Value = fiyat.ToString("N2"); // Virgülden sonra 2 basamaklı format
                            }
                            else if (columnName == "Adet")
                            {
                                // Tutar ve Fiyat hücresini güncelle
                                tutar = adet * fiyat;
                                fiyat = tutar / adet;
                                currentRow.Cells["Tutar"].Value = tutar.ToString("N2");
                                currentRow.Cells["Fiyat"].Value = fiyat.ToString("N2");// Virgülden sonra 2 basamaklı format
                            }



                        }
                        else
                        {
                            // Kullanıcıya geçerli sayısal değerler girmesi gerektiğini bildirebilirsiniz.
                            MessageBox.Show("Lütfen geçerli sayısal değerler girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            // Hatalı girişi temizleyebilirsiniz (isteğe bağlı)
                            currentRow.Cells[e.ColumnIndex].Value = null;
                        }

                    }
                    if (dataGridView1.Rows.Count > 0)
                    {
                        int sonSatirIndex = dataGridView1.Rows.Count - 1;
                        if (dataGridView1.Rows[sonSatirIndex].Cells["UrunKodu"].Value != null && dataGridView1.Rows[sonSatirIndex].Cells["UrunKodu"].Value.ToString() != "")
                        {

                        }
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                ToplamlariHesapla();
            }

        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && dataGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Silmek istediğinize emin misiniz?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    for (int i = dataGridView1.SelectedRows.Count - 1; i >= 0; i--)
                    {
                        int rowIndex = dataGridView1.SelectedRows[i].Index;
                        dataGridView1.Rows.RemoveAt(rowIndex);
                    }

                }

            }

            if (e.KeyCode == Keys.Up)
            {
                if (dataGridView1.CurrentRow.Index > 0)
                {
                    int rowIndex = dataGridView1.CurrentRow.Index;
                    int lastNonEmptyRowIndex = -1;

                    while (rowIndex >= 0)
                    {
                        bool isRowEmpty = true;

                        foreach (DataGridViewCell cell in dataGridView1.Rows[rowIndex].Cells)
                        {
                            if (cell.Value != null && cell.Value.ToString().Trim() != "")
                            {
                                isRowEmpty = false;
                                break;
                            }
                        }

                        if (isRowEmpty)
                        {
                            dataGridView1.Rows.RemoveAt(rowIndex);
                            // Satır silindiği için rowIndex değiştirme!
                            // rowIndex--; yapmıyoruz burada
                        }
                        else
                        {
                            lastNonEmptyRowIndex = rowIndex;
                            break;
                        }

                        rowIndex--; // sadece boş satır silinmediyse azalt
                    }

                    if (lastNonEmptyRowIndex >= 0)
                    {
                        if (dataGridView1.Rows.Count > lastNonEmptyRowIndex)
                        {
                            dataGridView1.CurrentCell = dataGridView1.Rows[lastNonEmptyRowIndex].Cells[0];
                            dataGridView1.Rows[lastNonEmptyRowIndex].Selected = true;
                        }
                    }
                }
            }




            if (e.KeyCode == Keys.Down)
            {
                // Şu anki satır son satır mı?
                if (dataGridView1.CurrentRow.Index == dataGridView1.Rows.Count - 1)
                {
                    bool isRowEmpty = true;

                    // Şu anki satırdaki tüm hücreleri kontrol et
                    foreach (DataGridViewCell cell in dataGridView1.CurrentRow.Cells)
                    {
                        if (cell.Value != null && cell.Value.ToString().Trim() != "")
                        {
                            isRowEmpty = false;
                            break; // Satırda veri var, boş değil
                        }
                    }

                    // Eğer son satır doluysa, yeni satır ekle
                    if (!isRowEmpty)
                    {
                        dataGridView1.Rows.Add();
                    }
                }
            }




    /*        if (e.KeyCode == Keys.Insert)
            {
                int emptyRowIndex = -1;

                // Önce mevcut satırlarda boş satır var mı diye bakalım
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    bool isRowEmpty = true;

                    foreach (DataGridViewCell cell in dataGridView1.Rows[i].Cells)
                    {
                        if (cell.Value != null && cell.Value.ToString().Trim() != "")
                        {
                            isRowEmpty = false;
                            break;
                        }
                    }

                    if (isRowEmpty)
                    {
                        emptyRowIndex = i;
                        break; // İlk bulduğumuz boş satırı alıyoruz
                    }
                }

                // Eğer boş satır bulunamadıysa, yeni boş satır ekleyelim
                if (emptyRowIndex == -1)
                {
                    emptyRowIndex = dataGridView1.Rows.Add();
                }

                // Şimdi boş satıra odaklanalım (seçelim)
                if (emptyRowIndex >= 0 && emptyRowIndex < dataGridView1.Rows.Count)
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[emptyRowIndex].Cells[0];
                    dataGridView1.Rows[emptyRowIndex].Selected = true;
                }



                ToplamlariHesapla();
            }*/

         
            if (e.KeyCode == Keys.Insert)
            {
                e.Handled = true;

                // Önce boş satır var mı kontrol edelim
                int bosSatirIndex = -1;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    bool isRowEmpty = true;

                    foreach (DataGridViewCell cell in dataGridView1.Rows[i].Cells)
                    {
                        if (cell.Value != null && cell.Value.ToString().Trim() != "")
                        {
                            isRowEmpty = false;
                            break;
                        }
                    }

                    if (isRowEmpty)
                    {
                        bosSatirIndex = i;
                        break;
                    }
                }

                // Eğer boş satır bulunamadıysa yeni boş satır ekleyelim
                if (bosSatirIndex == -1)
                {
                    bosSatirIndex = dataGridView1.Rows.Add();
                }

                // Boş satıra konumlan
                dataGridView1.CurrentCell = dataGridView1.Rows[bosSatirIndex].Cells[0]; // İlk hücreye konumlan

                // Sonra sanki çift tıklamışız gibi ürün formunu açalım
                dataGridView1_CellDoubleClick(dataGridView1,
                    new DataGridViewCellEventArgs(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex));
            }
        }


        

        private int bosSatirIndex = -1;

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
                        
            /*if (bosSatirIndex >= 0 && bosSatirIndex < dataGridView1.Rows.Count)
            {
                var row = dataGridView1.Rows[bosSatirIndex];

                // Hücredeki değerlerin null veya boş olup olmadığını kontrol et
                bool isUrunKoduEmpty = row.Cells["UrunKodu"].Value == null || string.IsNullOrWhiteSpace(row.Cells["UrunKodu"].Value.ToString());
                bool isUrunAdiEmpty = row.Cells["UrunAdi"].Value == null || string.IsNullOrWhiteSpace(row.Cells["UrunAdi"].Value.ToString());
                bool isFiyatEmpty = row.Cells["Fiyat"].Value == null || string.IsNullOrWhiteSpace(row.Cells["Fiyat"].Value.ToString());

                // Eğer UrunKodu, UrunAdi ve Fiyat boşsa
                if (isUrunKoduEmpty && isUrunAdiEmpty && isFiyatEmpty)
                {
                    // Kullanıcı başka bir satıra geçtiyse, boş satırı sil
                    if (dataGridView1.CurrentRow.Index != bosSatirIndex)
                    {
                        dataGridView1.Rows.RemoveAt(bosSatirIndex);
                        bosSatirIndex = -1;
                    }
                }
            }*/
        }


        #endregion
        public int SeciliSatirIndexi
        {
            get
            {
                if (dataGridView1.CurrentCell != null)
                    return dataGridView1.CurrentCell.RowIndex;
                return -1;
            }
        }
        //***************** Menu*************************************************************************

        private void faturaAraF11ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FrmSatisHareketleri frmSatisHareketleri = new FrmSatisHareketleri();
            frmSatisHareketleri.CagrilanForm = this;
            frmSatisHareketleri.ShowDialog();
          
            btnYeniKayit.Enabled = true;
            btniptal.Enabled = false;
            btnKayit.Enabled = false;
            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;
            btnKapat.Enabled = true;

            GelenFaturoNoSql();            
            ToplamlariHesapla();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CariEklenmisMi();
        }
    }
}