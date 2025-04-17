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
            dataGridView1.Columns.Add("UrunID","Ürün ID");
            dataGridView1.Columns.Add("UrunKodu","Ürün Kodu");
            dataGridView1.Columns.Add("Barkod","Barkod");
            dataGridView1.Columns.Add("Marka","Marka");
            dataGridView1.Columns.Add("Model","Model");
            dataGridView1.Columns.Add("UrunAdi","Ürün Adı");
            dataGridView1.Columns.Add("KategoriID","Kategori ID");
            dataGridView1.Columns.Add("AlisFiyati","Alış Fiyatı");
            dataGridView1.Columns.Add("SatisFiyati","Satış Fiyatı");
            dataGridView1.Columns.Add("Kdv","KDV");
            dataGridView1.Columns.Add("StokMiktari","Stok Miktarı");
            dataGridView1.Columns.Add("Aciklama","Açıklama");
            dataGridView1.Columns.Add("Resim","Resim");
            dataGridView1.Columns.Add("Durum","Durum");
            dataGridView1.Columns.Add("KayitTarihi","Kayıt Tarihi");
            dataGridView1.Columns.Add("Birim","Birim");

        }
        private void FrmSatis_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            dtHeader();
            UrunListele();
        }

        private void SatisUrunEkle()
        {

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
            txtAd.Text = CariAdi;
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
                
            }
        }

        public void StokBilgileriYukle(string stokID, string stokKod, string stokTur, string stokBarkod, string stokModel,string stokAdi,string stokKategori, string stokAlisFiyati, string stokSatisFiyati, string stokKdv, string stokMiktar ,string stokAciklama, string stokResim, string stokDurum, string stokKayitTarihi, string stokBirim)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add(stokID, stokKod, stokTur, stokBarkod, stokModel, stokAdi, stokKategori, stokAlisFiyati, stokSatisFiyati, stokKdv, stokMiktar, stokAciklama, stokResim, stokDurum, stokKayitTarihi, stokBirim);

        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            FrmCariListele frmCariListele = new FrmCariListele();
            frmCariListele.CagrilanForm = this;
            frmCariListele.ShowDialog();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmStoklar frmStoklar = new FrmStoklar();
            frmStoklar.CagrilanForm = this;
            frmStoklar.ShowDialog();
        }
    }
}
