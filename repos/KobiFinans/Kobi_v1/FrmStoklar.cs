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


        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.IndianRed;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Transparent;
        }

        /// <summary>
        /// //Sql Sorguları Buraya yazılacak
        /// </summary>
        string sorguUrunListele = @"Select ur.UrunId,ur.UrunKodu,ur.Barkod,ur.UrunAdi,uk.KategoriAdi,ur.Marka,ur.Model,
                                                        ur.AlisFiyat,ur.SatisFiyat,ur.Kdv,ur.StokMiktari,ur.Aciklama,
                                                        ur.Resim,ur.Durum,ur.KayitTarihi,ur.Birim from Urunler ur
                                                        Inner Join 
                                                        UrunKategori uk
                                                         ON ur.KategoriID=uk.
KategoriID";

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
                    object[] values = row.ItemArray;

                    // Diyelim ki "Durum" alanı 5. sırada (index 4), bu index'i kendi tablonun yapısına göre ayarla
                    bool durum = Convert.ToBoolean(row["Durum"]);
                    string durumYazi = durum ? "Aktif" : "Pasif";

                    // ItemArray üzerine müdahale edemeyeceğimiz için yeni bir dizi oluşturuyoruz
                    object[] yeniSatir = new object[values.Length];
                    values.CopyTo(yeniSatir, 0);

                    // "Durum" sütununu değiştiriyoruz
                    int durumIndex = dt.Columns["Durum"].Ordinal;
                    yeniSatir[durumIndex] = durumYazi;

                    dataGridView1.Rows.Add(yeniSatir); // Satırlar ekleniyor..
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                string stokID = row.Cells["ur.UrunID"].Value.ToString();
                string stokKod = row.Cells["ur.UrunKodu"].Value.ToString();
                string stokBarkod = row.Cells["ur.Barkod"].Value.ToString();
                string stokAdi = row.Cells["ur.UrunAdi"].Value.ToString();
                string stokKategori = row.Cells["uk.KategoriID"].Value.ToString();
                string stokMarka = row.Cells["ur.Marka"].Value.ToString();
                string stokModel = row.Cells["ur.Model"].Value.ToString();
                
                string stokAlisFiyati = row.Cells["ur.AlisFiyati"].Value.ToString();
                string stokSatisFiyati = row.Cells["ur.SatisFiyati"].Value.ToString();
                string stokKdv = row.Cells["ur.Kdv"].Value.ToString();
                string stokMiktar = row.Cells["ur.StokMiktari"].Value.ToString();
                string stokAciklama = row.Cells["ur.Aciklama"].Value.ToString();
                string stokResim = row.Cells["ur.Resim"].Value.ToString();
                string stokDurum = row.Cells["ur.Durum"].Value.ToString();
                string stokKayitTarihi = row.Cells["ur.KayitTarihi"].Value.ToString();
                string stokBirim = row.Cells["ur.Birim"].Value.ToString();

                if (CagrilanForm is FrmSatis)
                {
                    FrmSatis frmSatis = (FrmSatis)CagrilanForm;
                    frmSatis.StokBilgileriYukle(SeciliSatir, stokID, stokKod, stokBarkod,
                        stokAdi, stokKategori,stokMarka, stokModel, stokAlisFiyati, stokSatisFiyati, stokKdv, stokMiktar, stokAciklama, stokResim, stokDurum, stokKayitTarihi, stokBirim);
                    

                }
                this.Close();
            }
        }

        private void FrmStoklar_Load(object sender, EventArgs e)
        {

            dtHeader();
            UrunYukle();
        }
    }
}
