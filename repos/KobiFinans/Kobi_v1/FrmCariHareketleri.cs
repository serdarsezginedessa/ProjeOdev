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
    public partial class FrmCariHareketleri : Form
    {
        public FrmCariHareketleri()
        {
            InitializeComponent();
        }
      
        static string connectionString = ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);

        private void FrmCariHareketleri_Load(object sender, EventArgs e)
        {
            dtHeader();
            listele();
            
        }

        private void dtHeader()
        {
            if (dataGridView1.Columns.Count == 0)
            {

                dataGridView1.Columns.Add("ch.HareketID","İşlem No");
                dataGridView1.Columns.Add("c.CariAdi", "Cari Adı");
                dataGridView1.Columns.Add("k.KasaAdi", "Kasa Adı");
                dataGridView1.Columns.Add("b.BankaAD","Banka Adı");
                dataGridView1.Columns.Add("o.OdemeAD","Ödeme Türü");
                dataGridView1.Columns.Add("ch.Tarih","Tarih");
                dataGridView1.Columns.Add("ch.Aciklama","Açıklama");
                dataGridView1.Columns.Add("ch.Tutar","Tutar");
                dataGridView1.Columns.Add("ch.HareketTipi","Hareket Tipi");
                dataGridView1.Columns.Add("ch.TahsilatID","Tahsilat No");
                dataGridView1.Columns.Add("ch.GiderID","Gider No");
                
            }
        }
        void listele()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                string sorgu = @"SELECT
                                ch.HareketID, c.CariAdi, k.KasaAdi, b.BankaAd, o.OdemeAD,
                                ch.Tarih,
                                ch.Aciklama,
                                ch.Tutar,
                                ch.HareketTipi,
	                            ch.TahsilatID,
                                ch.GiderID
                            FROM  carihareketleri AS ch
                            LEFT JOIN cari AS c
                            ON ch.CariID = c.CariID
                            LEFT JOIN Kasalar AS k
                            ON ch.KasaID = k.KasaID
                            LEFT JOIN Bankalar AS b
                            ON ch.BankaID = b.BankaID
                            LEFT JOIN OdemeTuru AS o
                            ON ch.OdemeID = o.OdemeID
                            LEFT JOIN gider AS g
                            ON ch.GiderID = g.GiderID";

                SqlCommand kmt = new SqlCommand(sorgu, baglanti);
                SqlDataAdapter da = new SqlDataAdapter(kmt);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    dataGridView1.Rows.Add(row.ItemArray);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }
    }
}
