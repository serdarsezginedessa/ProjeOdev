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

        private static string connectionString = ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);

        /*  private void musteriAdi()
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
        }*/
      //*********************************************************************
        /*private void UrunListele()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                SqlCommand komut = new SqlCommand(sorguUrunekle, baglanti);
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
        }*/
        private void dtHeader()
        {
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("UrunKodu", "Ürün Kodu");
            dataGridView1.Columns.Add("UrunAdi", "Ürün Adı");
            dataGridView1.Columns.Add("SatisFiyati", "Satış Fiyatı");
            dataGridView1.Columns.Add("Kdv", "KDV");
            dataGridView1.Columns.Add("Adet", "Adet");
            dataGridView1.Columns.Add("Tutar", "Tutar");
            dataGridView1.Rows.Add();
           //dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;



        }
        private void FrmSatis_Load(object sender, EventArgs e)
        {
            //BtnTextComboAcilisForm();
            this.KeyPreview = true;
            this.KeyDown += btnYeniKayit_KeyDown;
            this.KeyDown+=btniptal_KeyDown;
            this.KeyDown += btnKayit_KeyDown;
            this.KeyDown+=btnSil_KeyDown;
            this.KeyDown+=btnFaturaAra_KeyDown;
            txtToplamTutar.Text = "0,00";
            txtKdv.Text = "0,00";
            txtGenelToplam.Text = "0,00";
            txtKdvHaricTutar.Text = "0,00";
            txtToplamTutar.Enabled = false;
            txtKdv.Enabled = false;
            txtGenelToplam.Enabled = false;
            txtKdvHaricTutar.Enabled = false;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            dtHeader();
            OdemeTuruSec();
            KasaSec();
            SatisFromYeniKayitKontrolDisabled();

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
        public void StokBilgileriYukle(
                     int SatirIndex, string stokID, string stokKod, string stokBarkod, string stokAdi, string stokKategori,
                     string stokMarka, string stokModel, string stokAlisFiyati, string stokSatisFiyati, string stokKdv,
                     string stokMiktar, string stokAciklama, string stokResim, string stokDurum, string stokKayitTarihi,
                     string stokBirim)
        {
            _secilenUrunID = stokID;

            dataGridView1.Rows[SatirIndex].Cells["UrunKodu"].Value = stokKod;
            dataGridView1.Rows[SatirIndex].Cells["UrunAdi"].Value = stokAdi;
            dataGridView1.Rows[SatirIndex].Cells["SatisFiyati"].Value = stokSatisFiyati;
            dataGridView1.Rows[SatirIndex].Cells["Kdv"].Value = stokKdv;
            dataGridView1.Rows[SatirIndex].Cells["Adet"].Value = 1;
            decimal tutar = Convert.ToDecimal(stokSatisFiyati) * 1;
            dataGridView1.Rows[SatirIndex].Cells["Tutar"].Value = tutar.ToString("N2");
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
        private void btnAra_Click(object sender, EventArgs e)
        {
            FrmCariListele frmCariListele = new FrmCariListele();
            frmCariListele.CagrilanForm = this;
            frmCariListele.ShowDialog();
            

        }

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
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (txtFaturaNo.Text == "")
                FaturaNo();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                FrmStoklar frmStoklar = new FrmStoklar();
                frmStoklar.CagrilanForm = this;
                frmStoklar.SeciliSatir = e.RowIndex;
                frmStoklar.ShowDialog();

            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
            try
            {
                if (e.ColumnIndex == dataGridView1.Columns["Adet"].Index || e.ColumnIndex == dataGridView1.Columns["SatisFiyati"].Index || e.ColumnIndex == dataGridView1.Columns["Tutar"].Index)
                {
                    // Geçerli satırı al
                    DataGridViewRow currentRow = dataGridView1.Rows[e.RowIndex];

                    // Adet ve Fiyat değerlerini almayı dene
                    if (currentRow.Cells["Adet"].Value != null && currentRow.Cells["SatisFiyati"].Value != null && currentRow.Cells["Tutar"].Value != null)
                    {
                        if (decimal.TryParse(currentRow.Cells["Adet"].Value.ToString(), out decimal adet) &&
                            decimal.TryParse(currentRow.Cells["SatisFiyati"].Value.ToString(), out decimal fiyat) &&
                            decimal.TryParse(currentRow.Cells["Tutar"].Value.ToString(), out decimal tutar))
                        {
                            if (columnName == "SatisFiyati")
                            {
                                tutar = adet * fiyat;
                                // Tutar hücresini güncelle
                                currentRow.Cells["Tutar"].Value = tutar.ToString("N2"); // Virgülden sonra 2 basamaklı format
                            }
                            else if (columnName == "Tutar")
                            {
                                // Fiyat hücresini güncelle
                                fiyat = tutar / adet;
                                currentRow.Cells["SatisFiyati"].Value = fiyat.ToString("N2"); // Virgülden sonra 2 basamaklı format
                            }
                            else if (columnName == "Adet")
                            {
                                // Tutar ve Fiyat hücresini güncelle
                                tutar = adet * fiyat;
                                fiyat = tutar / adet;
                                currentRow.Cells["Tutar"].Value = tutar.ToString("N2"); // Virgülden sonra 2 basamaklı format
                            }
                            ToplamTutarHesapla();
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
                            dataGridView1.Rows.Add();
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
                // Toplam tutarı güncelle
                ToplamTutarHesapla();
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
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            // Son satırın boş olup olmadığını kontrol et
            if (dataGridView1.Rows.Count < 0)
            {
                dataGridView1.Rows.Add();


            }
            else if (dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["UrunKodu"].Value != null && dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["UrunKodu"].Value.ToString() != "")
            {
                dataGridView1.Rows.Add();

            }


        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Düzenlemeye başlanan satırı al
            DataGridViewRow currentRow = dataGridView1.Rows[e.RowIndex];

            // Eğer bu satır henüz herhangi bir veri içermiyorsa (yani "boş" bir satırsa)
            if (SatirBosMu(currentRow))
            {
                // Düzenlemeyi iptal et
                e.Cancel = true;
                MessageBox.Show("Bu satıra doğrudan veri girişi yapamazsınız. Ürün ekranından ekleme yapın.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        // Bir satırın boş olup olmadığını kontrol eden yardımcı fonksiyon
        private bool SatirBosMu(DataGridViewRow row)
        {
            foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell.Value != null && !string.IsNullOrWhiteSpace(cell.Value.ToString()))
                {
                    // Satırda en az bir dolu hücre var
                    return false;
                }
            }
            // Satırdaki tüm hücreler boş
            return true;
        }

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
        private void btnYeniKayit_Click(object sender, EventArgs e)
        {

            
            foreach (Control control in this.Controls)
            {
                if (control is SplitContainer splitContainer)
                {
                    foreach (Control panel1control in splitContainer.Panel2.Controls)
                    {
                        if (panel1control is Panel panel)
                        {
                            foreach (Control innerControl in panel.Controls)
                            {
                                if (innerControl is TextBox textBox)
                                {
                                    textBox.Enabled = true;
                                    
                                }
                                else if (innerControl is ComboBox comboBox)

                                {
                                    if (comboBox.Name == "comboboxOdemeTuru" || comboBox.Name == "comboBoxDurum")
                                    {
                                        comboBox.Enabled = true;
                                    }
                                    else
                                        comboBox.Enabled = false;
                                }
                                else if (innerControl is DateTimePicker dateTimePicker)
                                {
                                    dateTimePicker.Enabled = true;
                                }
                               
                                else if (innerControl is Button button)
                                {
                                    button.Enabled = true;
                                }
                                else if (innerControl is Panel panel1)
                                {
                                    foreach (Control innerControl2 in panel1.Controls)
                                    {
                                        if (innerControl2 is Button button1)
                                        {
                                            if (button1.Name == "btnYeniKayit" || button1.Name=="btnGuncelle"||button1.Name=="btnSil" || button1.Name=="btnKapat")
                                            {
                                                button1.Enabled = false;
                                            }
                                            else
                                            {
                                                button1.Enabled = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            satisKayit();
            
            //textComboTemizle();
            SatisFromYeniKayitKontrolDisabled();
            btnYeniKayit.Enabled = true;
            btnKapat.Enabled = true;
        }
        private void btniptal_Click(object sender, EventArgs e)
        {
            textComboTemizle();
            SatisFromYeniKayitKontrolDisabled();
            
            btnYeniKayit.Enabled = true;
            btnKapat.Enabled = true;
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add();
            /*comboBoxDurum.Text = "Seçiniz";
            comboBoxBanka.Text = "Seçiniz";
            comboBoxKasa.Text = "Seçiniz";
            comboboxOdemeTuru.Text = "Seçiniz";
*/
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
                else if (dataGridView1.Rows.Count < 2)
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
        private void textComboTemizle()
        {
            comboBoxDurum.Text = "Seçiniz";
            comboboxOdemeTuru.Text = "Seçiniz";
            comboBoxKasa.Text = "Seçiniz";
            comboBoxBanka.Text = "Seçiniz";
            txtID.Text = "";
            txtFaturaNo.Text = "";
            txtCariAd.Text = "";
            txtAciklama.Text = "";
            txtGenelToplam.Text = "0,00";
            txtKdv.Text = "0,00";
            txtKdvHaricTutar.Text = "0,00";
            txtToplamTutar.Text = "0,00";
            LblMusteri.Text="Müşteri Adı";
            lblCariID.Text = "Cari No";
            lblCariKod.Text = "Cari Kod";
            lblMusteriTuru.Text = "Müşteri Türü";
            lblTelefon.Text = "Telefon";
            lblEposta.Text = "Eposta";
            lblYetkili.Text = "Yetkili";
            pictureBox1.Image = null;
            txtToplamTutar.Text = "0,00";
            txtKdv.Text = "0,00";
            txtGenelToplam.Text = "0,00";
            txtKdvHaricTutar.Text = "0,00";
            txtToplamTutar.Enabled = false;
            txtKdv.Enabled = false;
            txtGenelToplam.Enabled = false;
            txtKdvHaricTutar.Enabled = false;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;




        }
        private int _currentFaturaNo;

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
        private void SatisFromYeniKayitKontrolDisabled()
        {
            foreach (Control control in this.Controls)
            {
                if (control is SplitContainer  SplitContainer)
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
                                            if(button1.Name!= "btnYeniKayit" && button1.Name!="btnKapat")
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
            txtToplamTutar.Text = "0,00";
            txtKdv.Text = "0,00";
            txtGenelToplam.Text = "0,00";
            txtKdvHaricTutar.Text = "0,00";
            txtToplamTutar.Enabled = false;
            txtKdv.Enabled = false;
            txtGenelToplam.Enabled = false;
            txtKdvHaricTutar.Enabled = false;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private void btnYeniKayit_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.F8)
            {
                btnYeniKayit.PerformClick();
            }
        }

        private void btniptal_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                btniptal.PerformClick();
            }
        }

        private void btnKayit_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F2)
            {
                btnKayit.PerformClick();
            }
        }

        private void btnSil_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control && e.KeyCode==Keys.F10)
            {
                btnSil.PerformClick();
                MessageBox.Show("Silme işlemi başarıyla gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnFaturaAra_Click(object sender, EventArgs e)
        {
            // Fatura arama işlemi için kullanılacak..
        }

        private void btnFaturaAra_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F11)
            {
                btnFaturaAra.PerformClick();
            }
        }

        private void BtnTextComboAcilisForm()
        {
            foreach(Control control  in this.Controls)
            {
                control.Enabled = false;
            }

        }

        
    }
}