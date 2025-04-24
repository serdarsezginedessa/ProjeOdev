using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kobi_v1
{
    public partial class FrmSatis : Form
    {
        public FrmSatis()
        {
            InitializeComponent();
            
            
        }
        private string _secilenCariID;
        private string _secilenUrunID;
        private string _faturaTarihi;
        private string _faturaNo;
        private string _cariKod;
        private string _cariad;
        private string _kdvMatrahi;
        private string _kdvTutari;
        private string _tutar;
        private string _genelToplam;
        private int _currentFaturaNo;

        private static string connectionString = ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);


        //*********************************************************************


        private void FrmSatis_Load(object sender, EventArgs e)
        {
            dtHeader();
            
            dataGridView1.Rows.Add();
            
            btnYeniKayit.Enabled = true;
            btniptal.Enabled = false;
            btnSil.Enabled = false;
            btnGuncelle.Enabled = false;
            btnKayit.Enabled = false;
            btnKapat.Enabled=true;
            
            txtGenelToplam.ReadOnly = true;
            txtKdvHaricTutar.ReadOnly = true;
            txtKdv.ReadOnly = true;
            txtToplamTutar.ReadOnly = true;
            comboboxOdemeTuru.Enabled = true;
            comboBoxKasa.Enabled = false;
            comboBoxBanka.Enabled = false;

            this.KeyDown += btniptal_KeyDown;
            this.KeyDown += btnYeniKayit_KeyDown;


           

        }



        #region Methot
        //***************** Methot*************************************************************************
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


        private void satisKayit()
        {


            SqlTransaction transaction = null;

            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                if (_secilenCariID == null)
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

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow && row.Cells["UrunKodu"].Value != null && row.Cells["UrunAdi"].Value != null && row.Cells["Adet"].Value != null && row.Cells["Tutar"].Value != null)
                    {
                        // Her satırdaki ürün bilgilerini alın
                        string urunKodu = row.Cells["UrunKodu"].Value.ToString();
                        string urunAdi = row.Cells["UrunAdi"].Value.ToString();
                        if (int.TryParse(row.Cells["Adet"].Value.ToString(), out int adet))
                        {
                            if (decimal.TryParse(row.Cells["Tutar"].Value.ToString(), out decimal tutar))
                            {
                                // Ürün kodundan UrunID'yi veritabanından çekmeniz gerekecek.
                                int urunID = 0;
                                SqlCommand cmdUrunID = new SqlCommand("SELECT UrunID FROM Urunler WHERE UrunKodu = @urunKodu", baglanti, transaction);
                                cmdUrunID.Parameters.AddWithValue("@urunKodu", urunKodu);
                                object urunIDResult = cmdUrunID.ExecuteScalar();
                                if (urunIDResult != null && int.TryParse(urunIDResult.ToString(), out int urunIDValue))
                                {
                                    urunID = urunIDValue;

                                    int? kasaID = null;
                                    int? bankaID = null;
                                    int odemeID = 0;
                                    DateTime satisTarihi = Convert.ToDateTime(dateKayit.Text);

                                    // Ödeme türüne göre KasaID veya BankaID belirle ve INSERT sorgusunu çalıştır
                                    if (comboboxOdemeTuru.Text == "Açık Hesap")
                                    {
                                        string sqlAcikHesap = @"Insert into SatisIslemleri ([UrunID], [CariID], [OdemeID], [SatisTarihi], [Adet], [Tutar], [Durum],[FaturaNo])
                                                       Values (@urunID, @cariID, @odemeID, @tarih, @adet, @tutar, @durum,@faturaNo)";

                                        SqlCommand kmtOdemeTuru = new SqlCommand("Select OdemeID from OdemeTuru where OdemeAd=@odemeAd", baglanti, transaction);
                                        kmtOdemeTuru.Parameters.Clear();
                                        kmtOdemeTuru.Parameters.AddWithValue("@odemeAd", comboboxOdemeTuru.Text);
                                        object odemeIDResult = kmtOdemeTuru.ExecuteScalar();
                                        if (odemeIDResult != null && int.TryParse(odemeIDResult.ToString(), out int odemeIdValue))
                                        {
                                            odemeID = odemeIdValue;
                                        }
                                        SqlCommand kmtAcikHesapInsert = new SqlCommand(sqlAcikHesap, baglanti, transaction);
                                        kmtAcikHesapInsert.Parameters.Clear();
                                        kmtAcikHesapInsert.Parameters.AddWithValue("@urunID", urunID);
                                        kmtAcikHesapInsert.Parameters.AddWithValue("@cariID", _secilenCariID);
                                        kmtAcikHesapInsert.Parameters.AddWithValue("@odemeID", odemeID);
                                        kmtAcikHesapInsert.Parameters.AddWithValue("@tarih", satisTarihi);
                                        kmtAcikHesapInsert.Parameters.AddWithValue("@adet", adet);
                                        kmtAcikHesapInsert.Parameters.AddWithValue("@tutar", tutar);
                                        kmtAcikHesapInsert.Parameters.AddWithValue("@durum", comboBoxDurum.Text);
                                        kmtAcikHesapInsert.Parameters.AddWithValue("@faturaNo", txtFaturaNo.Text);
                                        kmtAcikHesapInsert.ExecuteNonQuery();

                                    }
                                    if (comboboxOdemeTuru.Text == "Nakit")
                                    {
                                        SqlCommand kmtkasaID = new SqlCommand("Select id from Kasa where KasaAdi=@kasaAdi", baglanti, transaction);
                                        kmtkasaID.Parameters.Clear();
                                        kmtkasaID.Parameters.AddWithValue("@kasaAdi", comboBoxKasa.Text);
                                        object kasaIDResult = kmtkasaID.ExecuteScalar();
                                        if (kasaIDResult != null && int.TryParse(kasaIDResult.ToString(), out int kasaIdValue))
                                        {
                                            kasaID = kasaIdValue;
                                        }

                                        SqlCommand kmtOdemeTuruNakit = new SqlCommand("Select OdemeID from OdemeTuru where OdemeAd=@odemeAd", baglanti, transaction);
                                        kmtOdemeTuruNakit.Parameters.Clear();
                                        kmtOdemeTuruNakit.Parameters.AddWithValue("@odemeAd", comboboxOdemeTuru.Text);
                                        object odemeIDResultNakit = kmtOdemeTuruNakit.ExecuteScalar();
                                        if (odemeIDResultNakit != null && int.TryParse(odemeIDResultNakit.ToString(), out int odemeIdValueNakit))
                                        {
                                            odemeID = odemeIdValueNakit;
                                        }

                                        string sqlnakit = @"Insert into SatisIslemleri ([UrunID], [CariID], [KasaID], [OdemeID], [SatisTarihi], [Adet], [Tutar], [Durum],[FaturaNo])
                                                       Values (@urunID, @cariID, @kasaID, @odemeID, @tarih, @adet, @tutar, @durum,@faturaNo)";
                                        SqlCommand kmtNakitInsert = new SqlCommand(sqlnakit, baglanti, transaction);
                                        kmtNakitInsert.Parameters.Clear();
                                        kmtNakitInsert.Parameters.AddWithValue("@urunID", urunID);
                                        kmtNakitInsert.Parameters.AddWithValue("@cariID", _secilenCariID);
                                        kmtNakitInsert.Parameters.AddWithValue("@kasaID", kasaID.HasValue ? (object)kasaID.Value : DBNull.Value);
                                        kmtNakitInsert.Parameters.AddWithValue("@odemeID", odemeID);
                                        kmtNakitInsert.Parameters.AddWithValue("@tarih", satisTarihi);
                                        kmtNakitInsert.Parameters.AddWithValue("@adet", adet);
                                        kmtNakitInsert.Parameters.AddWithValue("@tutar", tutar);
                                        kmtNakitInsert.Parameters.AddWithValue("@durum", comboBoxDurum.Text);
                                        kmtNakitInsert.Parameters.AddWithValue("@faturaNo", txtFaturaNo.Text);
                                        kmtNakitInsert.ExecuteNonQuery();
                                    }
                                    else if (comboboxOdemeTuru.Text == "Havale" || comboboxOdemeTuru.Text == "Kredi Kartı")
                                    {
                                        SqlCommand kmtBankaID = new SqlCommand("Select ID from Bankalar where BankaAd=@bankaAdi", baglanti, transaction);
                                        kmtBankaID.Parameters.Clear();
                                        kmtBankaID.Parameters.AddWithValue("@bankaAdi", comboBoxBanka.Text);
                                        object bankaIDResult = kmtBankaID.ExecuteScalar();
                                        if (bankaIDResult != null && int.TryParse(bankaIDResult.ToString(), out int bankaIdValue))
                                        {
                                            bankaID = bankaIdValue;
                                        }

                                        SqlCommand kmtOdemeTuruBanka = new SqlCommand("Select OdemeID from OdemeTuru where OdemeAd=@odemeAd", baglanti, transaction);
                                        kmtOdemeTuruBanka.Parameters.Clear();
                                        kmtOdemeTuruBanka.Parameters.AddWithValue("@odemeAd", comboboxOdemeTuru.Text);
                                        object odemeIDResultBanka = kmtOdemeTuruBanka.ExecuteScalar();
                                        if (odemeIDResultBanka != null && int.TryParse(odemeIDResultBanka.ToString(), out int odemeIdValueBanka))
                                        {
                                            odemeID = odemeIdValueBanka;
                                        }

                                        string sqlBanka = @"Insert into SatisIslemleri ([UrunID], [CariID], [BankaID], [OdemeID], [SatisTarihi], [Adet], [Tutar], [Durum],[FaturaNo])
                                                       Values (@urunID, @cariID, @bankaID, @odemeID, @tarih, @adet, @tutar, @durum,@faturaNo)";
                                        SqlCommand kmtBankaInsert = new SqlCommand(sqlBanka, baglanti, transaction);
                                        kmtBankaInsert.Parameters.Clear();
                                        kmtBankaInsert.Parameters.AddWithValue("@urunID", urunID);
                                        kmtBankaInsert.Parameters.AddWithValue("@cariID", _secilenCariID);
                                        kmtBankaInsert.Parameters.AddWithValue("@bankaID", bankaID.HasValue ? (object)bankaID.Value : DBNull.Value);
                                        kmtBankaInsert.Parameters.AddWithValue("@odemeID", odemeID);
                                        kmtBankaInsert.Parameters.AddWithValue("@tarih", satisTarihi);
                                        kmtBankaInsert.Parameters.AddWithValue("@adet", adet);
                                        kmtBankaInsert.Parameters.AddWithValue("@tutar", tutar);
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
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (baglanti.State == ConnectionState.Open) baglanti.Close();
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

        //***********************************************Yeni Methot*************************************************************
        private void GelenFaturoNoSql()
        {
            try
            {
                DataTable dt = new DataTable();
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                SqlCommand cmd = new SqlCommand(@"SELECT 
				                            u.UrunKodu,
				                            u.UrunAdi,
                                            si.Adet,
                                            u.Kdv,
				                            u.SatisFiyat,
				                            si.Tutar

                                            From SatisIslemleri as si
                                            Left Join Urunler as u
                                            On si.UrunID=u.UrunID
                                            LEFT Join Cari as c
                                            On si.CariID=c.CariID
                                            LEFT Join SatisFaturaNo f
                                            On si.FaturaNo=f.FaturaID
                                            Left Join Kasa as k
                                            On si.KasaID=k.id
                                            Left Join Bankalar as b
                                            On si.BankaID=b.ID
                                            Left Join OdemeTuru od
                                            On si.OdemeID=od.OdemeID

                                            Where si.FaturaNo=@faturano", baglanti);

                cmd.Parameters.AddWithValue("@faturano", _faturaNo);
                
                SqlDataReader dr = cmd.ExecuteReader();
                
                dt.Load(dr);

                dtHeader();
                dataGridView1.Rows.Clear(); // Mevcut satırları temizle Manuel Eklediğim Başlıklar Bozulmuyor..
                                            //dataGridView1.Rows.Add();                            // Yeni satırları ekle


                GridVeriYukle(dt);

                SqlCommand cmd2 = new SqlCommand(@"SELECT c.CariID,c.CariKod,c.CariAdi,c.Yetkili,c.Eposta,c.Telefon,c.Aciklama,c.Resim,
		                                                    ct.Ad,
		                                                    si.Durum, si.SatisTarihi,
		                                                    od.OdemeAD,
		                                                    k.KasaAdi,
		                                                    b.BankaAd
                                                            
                                                            From SatisIslemleri as si
                                                            Left Join Urunler as u
                                                            On si.UrunID=u.UrunID
                                                            LEFT Join Cari as c
                                                            On si.CariID=c.CariID
                                                            LEFT Join SatisFaturaNo f
                                                            On si.FaturaNo=f.FaturaID
                                                            Left Join Kasa as k
                                                            On si.KasaID=k.id
                                                            Left Join Bankalar as b
                                                            On si.BankaID=b.ID
                                                            Left Join OdemeTuru od
                                                            On si.OdemeID=od.OdemeID
		                                                    Left Join CariTuru ct
		                                                    ON c.CariTuru=ct.ID

		                                                    where si.FaturaNo=@faturano

		                                                    group by c.CariID, c.CariAdi,c.CariKod,c.Yetkili,c.Eposta,c.Telefon,c.Aciklama,c.Resim,
		                                                    ct.Ad,
		                                                    si.Durum, si.SatisTarihi,
		                                                    od.OdemeAD,
		                                                    k.KasaAdi,
		                                                    b.BankaAd", baglanti);

                cmd2.Parameters.AddWithValue("@faturano", _faturaNo);
                SqlDataReader dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {
                    lblMusteriTuru.Text = "Cari Türü :" + dr2["Ad"].ToString();

                    lblCariID.Text ="Cari No :"+ dr2["CariID"].ToString();

                    lblCariKod.Text ="Cari Kod :"+ dr2["CariKod"].ToString();

                    LblMusteri.Text = dr2["CariAdi"].ToString();

                    
                    
                    if (dr2["Eposta"].ToString() == "")
                        lblEposta.Text = "Eposta :";
                    else lblEposta.Text = dr2["Eposta"].ToString();
                    if (dr2["Telefon"].ToString() == "")
                    {
                        lblTelefon.Text = "Telefon:";
                    }
                    else lblTelefon.Text = "Telelefon: " + dr2["Telefon"].ToString(); 

                    if(dr2["Yetkili"].ToString() == "")
                        lblYetkili.Text="Yetkili:";
                    else lblYetkili.Text = "Yetkili : "+dr2["Yetkili"].ToString();
                    

                    txtID.Text = dr2["CariID"].ToString();
                    txtCariAd.Text = dr2["CariAdi"].ToString();
                    
                    comboBoxDurum.Text = dr2["Durum"].ToString();
                    dateKayit.Text = dr2["SatisTarihi"].ToString();
                    comboboxOdemeTuru.Text = dr2["OdemeAD"].ToString();
                    comboBoxKasa.Text = dr2["KasaAdi"].ToString();
                    comboBoxBanka.Text = dr2["BankaAd"].ToString();
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
        private void GridVeriYukle(DataTable dt)
        {
            dataGridView1.Rows.Clear();

            foreach (DataRow row in dt.Rows)
            {
                dataGridView1.Rows.Add(
                    
                    row["UrunKodu"].ToString(),
                    row["UrunAdi"].ToString(),
                    row["Adet"].ToString(),
                    row["Kdv"].ToString(),
                    row["SatisFiyat"].ToString(),
                    row["Tutar"].ToString()
                );
            }
        }//StokBilgileriYükle methodunda kullanılıyor.
        private void YeniKayitHazirla() //btnYeniKayıt butonunda kullanılıyor.
        {
            dataGridView1.Rows.Clear();
            if (dataGridView1.Rows.Count == 0)
            {
                dataGridView1.Rows.Add();
            }
            // Müşteri bilgilerini temizle
            pictureBox1.Image = null;
            pictureBox1.SizeMode    = PictureBoxSizeMode.StretchImage;
            LblMusteri.Text = "Müşteri Adı";
            lblCariID.Text = "Cari No";
            lblCariKod.Text = "Cari Kod";
            lblMusteriTuru.Text = "Cari Türü";
            lblYetkili.Text = "Yetkili";
            lblTelefon.Text = "Telefon";
            lblEposta.Text = "Eposta";

            // Form alanlarını temizle
            txtID.Text = "";
            txtCariAd.Text = "";
            
            
            txtFaturaNo.Text = ""; // Otomatik atanabilir
            dateKayit.Value = DateTime.Now;
            dateKayit.Enabled = true;

            // ComboBox seçimleri
            comboBoxDurum.Text = "Seçiniz";
            comboboxOdemeTuru.Text = "Seçiniz";
            comboBoxKasa.Text = "Seçiniz";
            comboBoxBanka.Text = "Seçiniz";
            comboBoxDurum.Enabled = true;
            comboboxOdemeTuru.Enabled = true;
            comboBoxKasa.Enabled = false;
            comboBoxBanka.Enabled = false;

            // Tutarlar
            txtKdvHaricTutar.Text = "";
            txtKdv.Text = "";
            txtToplamTutar.Text = "";
            txtGenelToplam.Text = "";

            // DataGridView temizle

            dataGridView1.Enabled = true;
           /* dtHeader();                 // Eğer yoksa başlıkları oluşturur
            dataGridView1.Rows.Clear(); // Tüm satırları temizler*/
           
            
            

            // Gerekli buton aktiflikleri
            btnYeniKayit.Enabled = false;
            btnKayit.Enabled = true;
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
            btniptal.Enabled = true;
        }
        
        private void YeniKayit()
        {
            if (dataGridView1.Rows.Count == 0 || string.IsNullOrWhiteSpace(txtCariAd.Text))
            {
                MessageBox.Show("Lütfen müşteri ve ürün bilgilerini eksiksiz giriniz.");
                return;
            }


            baglanti.Open();
            SqlTransaction trans = baglanti.BeginTransaction();

            try
            {
                // 1. Satış İşlemleri kaydı
                SqlCommand cmd = new SqlCommand(@"INSERT INTO SatisIslemleri 
        (CariID, Aciklama, FaturaNo, Tarih, OdemeTuruID, KasaID, BankaID, KdvHaricTutar, KdvTutari, ToplamTutar, GenelToplam, Durum)
        VALUES (@CariID, @Aciklama, @FaturaNo, @Tarih, @OdemeTuruID, @KasaID, @BankaID, @KdvHaricTutar, @KdvTutari, @ToplamTutar, @GenelToplam, @Durum);
        SELECT SCOPE_IDENTITY()", baglanti, trans);

                cmd.Parameters.AddWithValue("@CariID", Convert.ToInt32(lblCariID.Text));
                
                cmd.Parameters.AddWithValue("@FaturaNo", txtFaturaNo.Text);
                cmd.Parameters.AddWithValue("@Tarih", dateKayit.Value);
                cmd.Parameters.AddWithValue("@OdemeTuruID", comboboxOdemeTuru.SelectedValue ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@KasaID", comboBoxKasa.SelectedValue ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@BankaID", comboBoxBanka.SelectedValue ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@KdvHaricTutar", Convert.ToDecimal(txtKdvHaricTutar.Text));
                cmd.Parameters.AddWithValue("@KdvTutari", Convert.ToDecimal(txtKdv.Text));
                cmd.Parameters.AddWithValue("@ToplamTutar", Convert.ToDecimal(txtToplamTutar.Text));
                cmd.Parameters.AddWithValue("@GenelToplam", Convert.ToDecimal(txtGenelToplam.Text));
                cmd.Parameters.AddWithValue("@Durum", comboBoxDurum.Text);

                int satisID = Convert.ToInt32(cmd.ExecuteScalar());

                // 2. Satış Hareketleri detaylarını kaydet
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;

                    SqlCommand cmdDetay = new SqlCommand(@"INSERT INTO SatisHareketleri 
            (SatisID, UrunKodu, UrunAdi, Adet, KdvOrani, Fiyat, Tutar)
            VALUES (@SatisID, @UrunKodu, @UrunAdi, @Adet, @KdvOrani, @Fiyat, @Tutar)", baglanti, trans);

                    cmdDetay.Parameters.AddWithValue("@SatisID", satisID);
                    cmdDetay.Parameters.AddWithValue("@UrunKodu", row.Cells["UrunKodu"].Value.ToString());
                    cmdDetay.Parameters.AddWithValue("@UrunAdi", row.Cells["UrunAdi"].Value.ToString());
                    cmdDetay.Parameters.AddWithValue("@Adet", Convert.ToDecimal(row.Cells["Adet"].Value));
                    cmdDetay.Parameters.AddWithValue("@KdvOrani", Convert.ToDecimal(row.Cells["Kdv"].Value));
                    cmdDetay.Parameters.AddWithValue("@Fiyat", Convert.ToDecimal(row.Cells["Fiyat"].Value));
                    cmdDetay.Parameters.AddWithValue("@Tutar", Convert.ToDecimal(row.Cells["Tutar"].Value));

                    cmdDetay.ExecuteNonQuery();
                }

                trans.Commit();
                MessageBox.Show("Satış kaydı başarıyla oluşturuldu.");
                YeniKayitHazirla(); // formu temizle
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show("Kayıt sırasında hata oluştu:\n" + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }
        private void Guncelle()
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            SqlTransaction trans = baglanti.BeginTransaction();

            try
            {
                int satisID = Convert.ToInt32(txtID.Text);

                SqlCommand cmd = new SqlCommand(@"UPDATE SatisIslemleri SET
            Aciklama=@Aciklama, Tarih=@Tarih, OdemeTuruID=@OdemeTuruID,
            KasaID=@KasaID, BankaID=@BankaID, KdvHaricTutar=@KdvHaricTutar,
            KdvTutari=@KdvTutari, ToplamTutar=@ToplamTutar, GenelToplam=@GenelToplam,
            Durum=@Durum WHERE ID=@ID", baglanti, trans);

                cmd.Parameters.AddWithValue("@ID", satisID);
                
                cmd.Parameters.AddWithValue("@Tarih", dateKayit.Value);
                cmd.Parameters.AddWithValue("@OdemeTuruID", comboboxOdemeTuru.SelectedValue ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@KasaID", comboBoxKasa.SelectedValue ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@BankaID", comboBoxBanka.SelectedValue ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@KdvHaricTutar", Convert.ToDecimal(txtKdvHaricTutar.Text));
                cmd.Parameters.AddWithValue("@KdvTutari", Convert.ToDecimal(txtKdv.Text));
                cmd.Parameters.AddWithValue("@ToplamTutar", Convert.ToDecimal(txtToplamTutar.Text));
                cmd.Parameters.AddWithValue("@GenelToplam", Convert.ToDecimal(txtGenelToplam.Text));
                cmd.Parameters.AddWithValue("@Durum", comboBoxDurum.Text);
                cmd.ExecuteNonQuery();

                // Önceki satış hareketlerini sil
                SqlCommand cmdSil = new SqlCommand("DELETE FROM SatisHareketleri WHERE SatisID=@SatisID", baglanti, trans);
                cmdSil.Parameters.AddWithValue("@SatisID", satisID);
                cmdSil.ExecuteNonQuery();

                // Yeni satış hareketlerini ekle
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;

                    SqlCommand cmdDetay = new SqlCommand(@"INSERT INTO SatisHareketleri 
            (SatisID, UrunKodu, UrunAdi, Adet, KdvOrani, Fiyat, Tutar)
            VALUES (@SatisID, @UrunKodu, @UrunAdi, @Adet, @KdvOrani, @Fiyat, @Tutar)", baglanti, trans);

                    cmdDetay.Parameters.AddWithValue("@SatisID", satisID);
                    cmdDetay.Parameters.AddWithValue("@UrunKodu", row.Cells["UrunKodu"].Value.ToString());
                    cmdDetay.Parameters.AddWithValue("@UrunAdi", row.Cells["UrunAdi"].Value.ToString());
                    cmdDetay.Parameters.AddWithValue("@Adet", Convert.ToDecimal(row.Cells["Adet"].Value));
                    cmdDetay.Parameters.AddWithValue("@KdvOrani", Convert.ToDecimal(row.Cells["Kdv"].Value));
                    cmdDetay.Parameters.AddWithValue("@Fiyat", Convert.ToDecimal(row.Cells["Fiyat"].Value));
                    cmdDetay.Parameters.AddWithValue("@Tutar", Convert.ToDecimal(row.Cells["Tutar"].Value));

                    cmdDetay.ExecuteNonQuery();
                }

                trans.Commit();
                MessageBox.Show("Kayıt başarıyla güncellendi.");
                YeniKayitHazirla();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show("Güncelleme hatası:\n" + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }
        private void Sil()
        {
            try
            {
                if (MessageBox.Show("Bu satışı silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int satisID = Convert.ToInt32(txtID.Text);

                    if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                    {


                        SqlCommand cmd1 = new SqlCommand("DELETE FROM SatisHareketleri WHERE SatisID = @SatisID", baglanti);
                        cmd1.Parameters.AddWithValue("@SatisID", satisID);
                        cmd1.ExecuteNonQuery();

                        SqlCommand cmd2 = new SqlCommand("DELETE FROM SatisIslemleri WHERE ID = @ID", baglanti);
                        cmd2.Parameters.AddWithValue("@ID", satisID);
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

        }


        #region BilgiGetir
        public void SatisBigileriYukle(DataGridViewRow satir, string faturaTarihi, string faturaNo, string cariKod, string cariAd, string kdvMatrahi, string kdvTutari, string tutar, string genelToplam)
        {
            _faturaTarihi = faturaTarihi;
            _faturaNo = faturaNo;
            _cariKod = cariKod;
            _cariad = cariAd;
            _kdvMatrahi = kdvMatrahi;
            _tutar = tutar;
            _genelToplam = genelToplam;

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

        private void BankaBilgileriSec()
        {
            try
            {
                comboBoxBanka.Items.Clear();
                comboBoxBanka.Items.Add("Banka Seçiniz");
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                SqlCommand komut = new SqlCommand("select BankaAd from Bankalar", baglanti);
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    comboBoxBanka.Items.Add(dr["BankaAd"].ToString());
                }
                dr.Close();

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
                comboboxOdemeTuru.Items.Clear();
                comboboxOdemeTuru.Items.Add("Seçiniz");
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                SqlCommand komut = new SqlCommand("select OdemeAd from OdemeTuru", baglanti);
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    comboboxOdemeTuru.Items.Add(dr["OdemeAd"].ToString());
                }
                dr.Close();


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
                comboBoxKasa.Items.Clear();
                comboBoxKasa.Items.Add("Seçiniz");
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                SqlCommand komut = new SqlCommand("select KasaAdi from Kasa", baglanti);
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    comboBoxKasa.Items.Add(dr["KasaAdi"].ToString());
                }
                dr.Close();
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
        #endregion


        // Satış Hareket Detay Sorgulama faturaNo ya göre  faturaAraF11ToolStripMenuItem_Click Olayında Kullanılıyor.
       


        // Bir satırın boş olup olmadığını kontrol eden yardımcı fonksiyon

        private bool SatirBosMu(DataGridViewRow row)
        {
            foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell.Value != null && !string.IsNullOrWhiteSpace(cell.Value.ToString()))
                {
                    return false;
                }
            }
            return true;
        }

        private bool SatirBosMuEski(DataGridViewRow row)
        {
            /*foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell.Value != null && !string.IsNullOrWhiteSpace(cell.Value.ToString()))
                {
                    // Satırda en az bir dolu hücre var
                    return false;
                }
            }
            // Satırdaki tüm hücreler */
            return true;
        }

        private void BosSatirlariSil()
        {
            for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow row = dataGridView1.Rows[i];

                // Satır yeni satır değilse ve tüm hücreleri boşsa sil
                if (!row.IsNewRow && SatirBosMu(row))
                {
                    dataGridView1.Rows.RemoveAt(i);
                }
            }
        }
        private void SatirlariSil()
        {
            for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (!row.IsNewRow && cell.Value != null && !string.IsNullOrWhiteSpace(cell.Value.ToString()))
                    {
                        dataGridView1.Rows.RemoveAt(i);
                    }
                }

            }
        }

        private void musteriAdi()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                SqlCommand komut = new SqlCommand("select CariID, CariAdi from Cari where CariAdi = 'Serdar Sezgin' ", baglanti);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                LblMusteri.Text = ds.Tables[0].Rows[0]["CariAdi"].ToString();
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
        private void UrunListele()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                SqlCommand komut = new SqlCommand("sorguUrunekle", baglanti);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                dt.Clear();
                da.Fill(dt);
                dataGridView1.Rows.Clear(); // Mevcut satırları temizle Manuel Eklediğim Başlıklar Bozulmuyor..
                foreach (DataRow row in dt.Rows)
                {
                    dataGridView1.Rows.Add(row.ItemArray); // Satırlar ekleniyor..
                }
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

        private void SatisFromYeniKayitKontrolDisabled()
        {
            foreach (Control control in this.Controls)
            {
                if (control is SplitContainer SplitContainer)
                {
                    foreach (Control panel1control in splitContainer1.Panel2.Controls)
                    {
                        if (panel1control is Panel panel)
                        {
                            foreach (Control innerControl in panel.Controls)
                            {
                                if (innerControl is TextBox textBox)
                                {
                                    textBox.Enabled = false;

                                }
                                else if (innerControl is ComboBox comboBox)
                                {
                                    comboBox.Enabled = false;
                                }
                                else if (innerControl is DateTimePicker dateTimePicker)
                                {
                                    dateTimePicker.Enabled = false;
                                }

                                else if (innerControl is Button button)
                                {
                                    button.Enabled = false;
                                }
                                else if (innerControl is Panel panel1)
                                {
                                    foreach (Control innerControl2 in panel1.Controls)
                                    {
                                        if (innerControl2 is Button button1)
                                        {
                                            if (button1.Name != "btnYeniKayit" && button1.Name != "btnKapat")
                                            {
                                                button1.Enabled = false;
                                            }

                                        }

                                    }
                                }
                            }
                        }
                    }
                }

            }



        }//Kullanılmıyor.

        private void textComboTemizle()
        {
            comboBoxDurum.Text = "Seçiniz";
            comboboxOdemeTuru.Text = "Seçiniz";
            comboBoxKasa.Text = "Seçiniz";
            comboBoxBanka.Text = "Seçiniz";
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

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                decimal urunfiyat = Convert.ToDecimal(row.Cells["Fiyat"].Value ?? 0);
                int urunadet = Convert.ToInt32(row.Cells["Adet"].Value ?? 0);
                float urunkdvOran = Convert.ToInt32(row.Cells["Kdv"].Value ?? 0);

                decimal kdvMatrahi = urunfiyat / Convert.ToDecimal((urunkdvOran / 100) + 1);
                decimal araToplam = urunfiyat * urunadet;
                decimal kdvTutar = (urunfiyat- kdvMatrahi);
                decimal toplam = (kdvMatrahi + kdvTutar)*urunadet;



                kdvHaricToplam += kdvMatrahi;
                kdvToplam += kdvTutar;
                genelToplam += toplam;
            }

            txtKdvHaricTutar.Text = kdvHaricToplam.ToString("C2");
            txtKdv.Text = kdvToplam.ToString("C2");
            txtToplamTutar.Text = genelToplam.ToString("C2");
            txtGenelToplam.Text = genelToplam.ToString("C2");
        }//dataGridView1_CellValueChanged olayında kullanılıyor..
        private void ToplamTutarHesapla()
        {
            decimal toplamTutar = 0;
            decimal toplamKdv = 0;
            decimal genelToplam = 0;
            decimal kdvHaricTutar = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Tutar"].Value != null)
                {
                    toplamTutar += Convert.ToDecimal(row.Cells["Tutar"].Value);
                }


            }
            toplamKdv += Convert.ToDecimal(txtToplamTutar.Text) - Convert.ToDecimal(Convert.ToInt32((toplamTutar)) / (1 + .20));
            kdvHaricTutar = toplamTutar - toplamKdv;
            genelToplam = toplamTutar;
            txtKdvHaricTutar.Text = kdvHaricTutar.ToString("N2");
            txtToplamTutar.Text = toplamTutar.ToString("N2");
            txtKdv.Text = toplamKdv.ToString("N2");
            txtGenelToplam.Text = genelToplam.ToString("N2");
        }


        #endregion


        #region Buttons
        //***************** Button************************************************************************* 


        private void btnKayit_Click(object sender, EventArgs e)
        {
            satisKayit();
            
            
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
            
            //txtFaturaNo.Text = YeniFaturaNoGetir();

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
                MessageBox.Show("Eğer Bu Butona Tıkladıysan Satış Faturasının Carisini Değiştirmek İstiyorsun Emin misin ?", "Bilgi", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                var result = DialogResult;
                if (result == DialogResult.Cancel)
                {
                    btnYeniKayit.Enabled = true;
                    btniptal.Enabled = false;
                    btnSil.Enabled = false;
                    btnKayit.Enabled = false;
                    btnGuncelle.Enabled = false;
                    btnKapat.Enabled = true;
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
        #endregion
        //***************** combobox*************************************************************************

        private void comboboxOdemeTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            string secilen = comboboxOdemeTuru.SelectedItem.ToString();
            if (secilen == "Nakit")
            {
                comboBoxKasa.Enabled = true;
                comboBoxBanka.Enabled = false;
            }
            else if (secilen == "Havale" || secilen == "Kredi Kartı")
            {
                comboBoxKasa.Enabled = false;
                comboBoxBanka.Enabled = true;
                BankaBilgileriSec();
            }
            else
            {
                comboBoxKasa.Enabled = false;
                comboBoxBanka.Enabled = false;
            }
        }

        #region dataGrid
        //***************** DataGridView*************************************************************************

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];

                // Eğer hücreler boşsa yeni ürün eklenecekse:
                if (row.Cells["UrunKodu"].Value == null || string.IsNullOrWhiteSpace(row.Cells["UrunKodu"].Value.ToString()))
                {
                    bosSatirIndex = e.RowIndex; // <<< burada eklersen boş satırı takip eder
                    
                    if (bosSatirIndex == 0)
                    {
                        FaturaNo();
                    }
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
            OdemeTuruSec();
            KasaSec();

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
            if (e.KeyCode == Keys.Down)
            {
                // Son satırdaysa ve boşsa yeni satır ekle
                if (dataGridView1.CurrentRow.Index == dataGridView1.Rows.Count - 1)
                {
                    bosSatirIndex = dataGridView1.Rows.Add(); // <<< Buraya ekle
                    
                }
            }
            
            ToplamlariHesapla();
        }

        private int bosSatirIndex = -1;
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (bosSatirIndex >= 0 && bosSatirIndex < dataGridView1.Rows.Count)
            {
                var row = dataGridView1.Rows[bosSatirIndex];

                // Eğer UrunKodu, UrunAdi ve Fiyat gibi alanlar boşsa
                if ((row.Cells["UrunKodu"].Value == null || string.IsNullOrWhiteSpace(row.Cells["UrunKodu"].Value.ToString())) &&
                    (row.Cells["UrunAdi"].Value == null || string.IsNullOrWhiteSpace(row.Cells["UrunAdi"].Value.ToString())) &&
                    (row.Cells["Fiyat"].Value == null || string.IsNullOrWhiteSpace(row.Cells["Fiyat"].Value.ToString())))
                {
                    // Kullanıcı başka bir satıra geçtiyse sil
                    if (dataGridView1.CurrentRow.Index != bosSatirIndex)
                    {
                        dataGridView1.Rows.RemoveAt(bosSatirIndex);
                        bosSatirIndex = -1;
                    }
                }
            }
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
        
    }
}