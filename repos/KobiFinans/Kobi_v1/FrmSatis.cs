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
        private static string connectionString = ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);

        string sorguUrunekle = "Select * from Urunler";

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
        }
        private void dtHeader()
        {
            dataGridView1.Columns.Clear();
           
            dataGridView1.Columns.Add("UrunKodu","Ürün Kodu");           
            dataGridView1.Columns.Add("UrunAdi","Ürün Adı");           
            dataGridView1.Columns.Add("SatisFiyati","Satış Fiyatı");
            dataGridView1.Columns.Add("Kdv","KDV");
            dataGridView1.Columns.Add("Adet","Adet");
            dataGridView1.Columns.Add("Tutar", "Tutar");
            dataGridView1.Rows.Add();
            

            /*          dataGridView1.Columns["Adet"].ReadOnly = false;
                        dataGridView1.Columns["Adet"].DefaultCellStyle.BackColor = Color.LightYellow;
                        dataGridView1.Columns["Adet"].CellTemplate = new DataGridViewTextBoxCell();

                        dataGridView1.Columns["SatisFiyati"].ReadOnly = false;
                        dataGridView1.Columns["SatisFiyati"].DefaultCellStyle.BackColor = Color.LightYellow;
                        dataGridView1.Columns["SatisFiyati"].CellTemplate = new DataGridViewTextBoxCell();

                        dataGridView1.Columns["Tutar"].ReadOnly = false;
                        dataGridView1.Columns["Tutar"].DefaultCellStyle.BackColor = Color.LightGray;
                        dataGridView1.Columns["Tutar"].CellTemplate = new DataGridViewTextBoxCell();

                        dataGridView1.Columns["Kdv"].ReadOnly = false;
                        dataGridView1.Columns["Kdv"].DefaultCellStyle.BackColor = Color.LightGray;
                        dataGridView1.Columns["Kdv"].CellTemplate = new DataGridViewTextBoxCell();
            */
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;



        }
        private void FrmSatis_Load(object sender, EventArgs e)
        {
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
            
        }


        public void CariBilgileriYukle(string cariID,  string CariKod,string CariAdi, string cariTur, string yetkili, string telefon, string ePosta,string resim)
        {
            
            LblMusteri.Text = CariAdi;
            lblCariKod.Text = "Cari Kod: "+CariKod;
            lblTelefon.Text = telefon;
            lblEposta.Text = ePosta;
            lblYetkili.Text = "Yetkili: "+yetkili;
            lblCariID.Text = "Cari No:"+cariID;
            lblMusteriTuru.Text = "Cari Türü: "+cariTur;
            txtCariAd.Text = CariAdi;
            txtID.Text = cariID;

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
                comboboxOdemeTuru.Items.Add("Ödeme Şekli");
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
                comboboxOdemeTuru.SelectedIndex = 0;
            }
        }
        private void KasaSec()
        {

            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                SqlCommand komut = new SqlCommand("select KasaAdi from Kasa", baglanti);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                comboBoxKasa.DataSource = ds.Tables[0];
                comboBoxKasa.DisplayMember = "KasaAdi";
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

        public void StokBilgileriYukle(int SatirIndex,string stokID, string stokKod, string stokBarkod, string stokAdi, string stokKategori,string stokMarka, string stokModel, string stokAlisFiyati, string stokSatisFiyati, string stokKdv, string stokMiktar ,string stokAciklama, string stokResim, string stokDurum, string stokKayitTarihi, string stokBirim)
        {
            
            dataGridView1.Rows[SatirIndex].Cells["UrunKodu"].Value = stokKod;
            dataGridView1.Rows[SatirIndex].Cells["UrunAdi"].Value = stokAdi;
            dataGridView1.Rows[SatirIndex].Cells["SatisFiyati"].Value = stokSatisFiyati;
            dataGridView1.Rows[SatirIndex].Cells["Kdv"].Value = stokKdv;
            dataGridView1.Rows[SatirIndex].Cells["Adet"].Value = 1;
            decimal tutar = Convert.ToDecimal(stokSatisFiyati) * 1;
            dataGridView1.Rows[SatirIndex].Cells["Tutar"].Value = tutar.ToString("N2");

           



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
            if(secilen == "Nakit")
            {
                comboBoxKasa.Enabled = true;
                comboBoxBanka.Enabled = false;
            }
            else if(secilen == "Havale"||secilen == "Kredi Kartı")
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

        private void comboBoxDurum_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxDurum_TextChanged(object sender, EventArgs e)
        {
            
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

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
          
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
            if(e.KeyCode == Keys.Delete && dataGridView1.SelectedRows.Count>0)
            {
                if(MessageBox.Show("Silmek istediğinize emin misiniz?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
            if (dataGridView1.Rows.Count<0)
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
            genelToplam = toplamTutar ;
            txtKdvHaricTutar.Text = kdvHaricTutar.ToString("N2");
            txtToplamTutar.Text = toplamTutar.ToString("N2");
            txtKdv.Text = toplamKdv.ToString("N2");
            txtGenelToplam.Text = genelToplam.ToString("N2");
        }
       
        
    }
    
    
}
