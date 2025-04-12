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
    public partial class FrmBankaHareket : Form
    {
        public FrmBankaHareket()
        {
            InitializeComponent();
        }
        static string connectionString = ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);
        private void dtHeader()
        {
            if (dataGridView1.Columns.Count == 0)

            {
                dataGridView1.Columns.Add("ID", "İşlem No");
                dataGridView1.Columns.Add("bh.BankaAd", "Banka Adı");
                dataGridView1.Columns.Add("Tarih", "Tarih");
                dataGridView1.Columns.Add("HareketTipi", "Hareket Tipi");
                dataGridView1.Columns.Add("Kaynak", "Gelir Kaynağı");
                dataGridView1.Columns.Add("Tutar", "Tutar");
                dataGridView1.Columns.Add("Aciklama", "Açıklama");
            }

        }

        void getir()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand kmt = new SqlCommand(@"Select bh.ID,  b.BankaAd, bh.Tarih, bh.HareketTipi, 
                                                    bh.Kaynak, 
                                                    bh.Tutar, bh.Aciklama From 
                                                    Bankalar b
                                                    Inner Join
                                                    BankaHareket bh
                                                    On
                                                    b.ID=bh.BankaID
                                                                ", baglanti);
                    SqlDataAdapter da = new SqlDataAdapter(kmt);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.Rows.Clear(); // Mevcut satırları temizleyin Manuel Eklediğim Başlıklar Bozulmuyor..
                    foreach (DataRow row in dt.Rows)
                    {
                        dataGridView1.Rows.Add(row.ItemArray); // Satırlar ekleniyor..
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void FrmBankaHareket_Load(object sender, EventArgs e)
        {
            dtHeader();
            getir();
        }
    }
}
