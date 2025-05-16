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
    public partial class FrmStoklar : Form
    {
        public FrmStoklar()
        {
            InitializeComponent();
            
        }
        private static string connectionString = ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);

        public Form CagrilanForm { get; set; }
        public int SeciliSatir { get; set; }

        string sorguUrunListele = @"Select ur.UrunId,ur.UrunKodu,ur.Barkod,ur.UrunAdi,uk.KategoriAdi,ur.Marka,ur.Model,
                                                        ur.AlisFiyat,ur.SatisFiyat,ur.Kdv,ur.StokMiktari,ur.Aciklama,
                                                        ur.Resim,ur.Durum,ur.KayitTarihi,ur.Birim from Urunler ur
                                                        Inner Join 
                                                        UrunKategori uk
                                                        ON ur.KategoriID=uk.KategoriID";

        private void dtHeader()
        {
            if(dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Clear();
                dataGridView1.Columns.Add("ur.UrunId", "Ürün No");
                dataGridView1.Columns.Add("ur.UrunKodu", "Ürün Kodu");
                dataGridView1.Columns.Add("ur.Barkod", "Barkod");                
                dataGridView1.Columns.Add("ur.UrunAdi", "Ürün Adı");
                dataGridView1.Columns.Add("uk.KategoriID", "Kategori");
                dataGridView1.Columns.Add("ur.Marka", "Marka");
                dataGridView1.Columns.Add("ur.Model", "Model");
                dataGridView1.Columns.Add("ur.AlisFiyati", "Alış Fiyatı");
                dataGridView1.Columns.Add("ur.SatisFiyati", "Satış Fiyatı");
                dataGridView1.Columns.Add("ur.Kdv", "KDV");
                dataGridView1.Columns.Add("ur.StokMiktari", "Stok Miktarı");
                dataGridView1.Columns.Add("ur.Aciklama", "Açıklama");
                dataGridView1.Columns.Add("ur.Resim", "Resim");
                dataGridView1.Columns.Add("ur.Durum", "Durum");
                dataGridView1.Columns.Add("ur.KayitTarihi", "Kayıt Tarihi");
                dataGridView1.Columns.Add("ur.Birim", "Birim");
            }
            
                
        }
        private void UrunYukle()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                SqlCommand komut = new SqlCommand(sorguUrunListele, baglanti);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                
                da.Fill(dt);
                dataGridView1.Rows.Clear(); // Mevcut satırları temizle Manuel Eklediğim Başlıklar Bozulmuyor..
                foreach (DataRow row in dt.Rows)
                {
                    object[] values = new object[dt.Columns.Count];

                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (row[i] == DBNull.Value)
                        {
                            values[i] = ""; // Boş değerler için boş string
                        }
                        else if (row[i] is DateTime tarih)
                        {
                            values[i] = tarih.ToString("yyyy-MM-dd"); // Tarihi biçimli stringe çevir
                        }
                        else if (row[i] is bool durum)
                        {
                            values[i] = durum ? "Aktif" : "Pasif"; // Durum kolonu için okunabilir değer
                        }
                        else
                        {
                            values[i] = row[i];
                        }
                    }

                    dataGridView1.Rows.Add(values); // Satırı DataGridView'e ekle
                }

            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata: " + hata.ToString());
            }
            finally
            {
                baglanti.Close();
                
            }
        }

        private void Filtrele()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();

                List<string> filtreler = new List<string>();
                SqlCommand cmd = new SqlCommand();
                string sorgu = @"Select ur.UrunId,ur.UrunKodu,ur.Barkod,ur.UrunAdi,uk.KategoriAdi,ur.Marka,ur.Model,
                                                        ur.AlisFiyat,ur.SatisFiyat,ur.Kdv,ur.StokMiktari,ur.Aciklama,
                                                        ur.Resim,ur.Durum,ur.KayitTarihi,ur.Birim from Urunler ur
                                                        Inner Join 
                                                        UrunKategori uk
                                                        ON ur.KategoriID=uk.KategoriID 
                                                        WHERE 1=1";

                // Metin filtreleri
                if (!string.IsNullOrWhiteSpace(txtUrunKod.Text))
                {
                    filtreler.Add("ur.UrunKodu LIKE @UrunKod");
                    cmd.Parameters.AddWithValue("@UrunKod", "%" + txtUrunKod.Text + "%");
                }

                if (!string.IsNullOrWhiteSpace(txtUrunAd.Text))
                {
                    filtreler.Add("ur.UrunAdi LIKE @UrunAdi");
                    cmd.Parameters.AddWithValue("@UrunAdi", "%" + txtUrunAd.Text + "%");
                }
                if(comboDurum.SelectedIndex>-1)
                {
                    
                    filtreler.Add("ur.Durum = @Durum");
                    cmd.Parameters.AddWithValue("@Durum", comboDurum.SelectedItem.ToString() == "Aktif");
                }




                // Tüm filtreleri sorguya ekle
                if (filtreler.Count > 0)
                {
                    sorgu += " AND " + string.Join(" AND ", filtreler);
                }

                cmd.CommandText = sorgu;
                cmd.Connection = baglanti;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.Rows.Clear(); // Mevcut satırları temizle Manuel Eklediğim Başlıklar Bozulmuyor..
                foreach (DataRow row in dt.Rows)
                {
                    object[] values = new object[dt.Columns.Count];

                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (row[i] == DBNull.Value)
                        {
                            values[i] = ""; // Boş değerler için boş string
                        }
                        else if (row[i] is DateTime tarih)
                        {
                            values[i] = tarih.ToString("yyyy-MM-dd"); // Tarihi biçimli stringe çevir
                        }
                        else if (row[i] is bool durum)
                        {
                            values[i] = durum ? "Aktif" : "Pasif"; // Durum kolonu için okunabilir değer
                        }
                        else
                        {
                            values[i] = row[i];
                        }
                    }

                    dataGridView1.Rows.Add(values); // Satırı DataGridView'e ekle
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Filtreleme Hatası: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          

            try
            {
                if (e.RowIndex >= 0)
                {
                    // Seçilen ürün satırını alalım
                    DataGridViewRow secilenSatir = dataGridView1.Rows[e.RowIndex];

                    // Ürün bilgilerini al
                    string urunNo = secilenSatir.Cells[0].Value?.ToString();         // Ürün ID (opsiyonel)
                    string urunKodu = secilenSatir.Cells[1].Value?.ToString();
                    string barkod = secilenSatir.Cells[2].Value?.ToString();
                    string urunAdi = secilenSatir.Cells[3].Value?.ToString();
                    string kategori = secilenSatir.Cells[4].Value?.ToString();
                    string marka = secilenSatir.Cells[5].Value?.ToString();
                    string model = secilenSatir.Cells[6].Value?.ToString();
                    string alisFiyati = secilenSatir.Cells[7].Value?.ToString();
                    string urunFiyat = secilenSatir.Cells[8].Value?.ToString();
                    string urunKdv = secilenSatir.Cells[9].Value?.ToString();
                    string stokMiktari = secilenSatir.Cells[10].Value?.ToString();
                    string aciklama = secilenSatir.Cells[11].Value?.ToString();
                    string resim = secilenSatir.Cells[12].Value?.ToString();
                    string durum = secilenSatir.Cells[13].Value?.ToString();
                    string kayitTarihi = secilenSatir.Cells[14].Value?.ToString();
                    string birim = secilenSatir.Cells[15].Value?.ToString();


                    /*string urunNo = secilenSatir.Cells["ur.UrunID"].Value?.ToString();         // Ürün ID (opsiyonel)
                    string urunKodu = secilenSatir.Cells["ur.UrunKodu"].Value?.ToString();
                    string barkod = secilenSatir.Cells["ur.Barkod"].Value?.ToString();
                    string urunAdi = secilenSatir.Cells["ur.UrunAdi"].Value?.ToString();
                    string kategori = secilenSatir.Cells["uk.KategoriID"].Value?.ToString();
                    string marka = secilenSatir.Cells["ur.Marka"].Value?.ToString();
                    string model = secilenSatir.Cells["ur.Model"].Value?.ToString();
                    string alisFiyati = secilenSatir.Cells["ur.AlisFiyati"].Value?.ToString();
                    string urunFiyat = secilenSatir.Cells["ur.SatisFiyati"].Value?.ToString();
                    string urunKdv = secilenSatir.Cells["ur.Kdv"].Value?.ToString();
                    string stokMiktari = secilenSatir.Cells["ur.StokMiktari"].Value?.ToString();
                    string aciklama = secilenSatir.Cells["ur.Aciklama"].Value?.ToString();
                    string resim = secilenSatir.Cells["ur.Resim"].Value?.ToString();
                    string durum = secilenSatir.Cells["ur.Durum"].Value?.ToString();
                    string kayitTarihi = secilenSatir.Cells["ur.KayitTarihi"].Value?.ToString();
                    string birim = secilenSatir.Cells["ur.Birim"].Value?.ToString();
*/
                    // Ürünü çağıran forma aktar
                    if (this.CagrilanForm is FrmSatis satisFormu)
                    {
                        int satirIndex = Convert.ToInt32(this.Tag); // hangi satıra ürün eklenecek

                        satisFormu.StokBilgileriYukle(urunNo, urunKodu, urunAdi, urunFiyat, urunKdv, satirIndex);
                        this.Close();
                    }
                    if (this.CagrilanForm is FrmStokEkle stokEkleFormu)
                    {

                        stokEkleFormu.StokBilgileriYukle(urunNo, urunKodu, barkod, urunAdi, kategori, marka, model, alisFiyati, urunFiyat, urunKdv, stokMiktari, aciklama, resim, durum, kayitTarihi, birim);
                    }
                    else
                    {
                        return;
                    }

                    this.Close();
                }
                else
                {
                    return;

                }
            }
            catch(Exception hata)
            {
                MessageBox.Show("Hata: " + hata.ToString());
            }
           
        }

        private void FrmStoklar_Load(object sender, EventArgs e)
        {

            dtHeader();
            UrunYukle();
  
        }


        public DataGridViewRow SecilenUrun { get; private set; } // Seçilen ürünü tutar

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Seçilen satırı al
                SecilenUrun = dataGridView1.Rows[e.RowIndex];
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.ImageLocation =Application.StartupPath+ SecilenUrun.Cells["ur.Resim"].Value?.ToString();
            }
        }

        private void txtUrunKod_TextChanged(object sender, EventArgs e) =>Filtrele();


        private void txtUrunAd_TextChanged(object sender, EventArgs e) =>Filtrele();

        private void comboDurum_SelectedIndexChanged(object sender, EventArgs e)=>Filtrele();

        private void btnSifirla_Click(object sender, EventArgs e)
        {
            txtUrunAd.Text = "";
            txtUrunKod.Text = "";
            comboDurum.SelectedIndex = -1;
            UrunYukle();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmStokEkle frmStoklarekle = new FrmStokEkle();
            
            frmStoklarekle.ShowDialog();
            UrunYukle();
        }

        private void FrmStoklar_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
