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
    public partial class FrmKasaHareketleri : Form
    {
        public FrmKasaHareketleri()
        {
            InitializeComponent();
            
            gelirToplam();
            giderToplam();
            toplamBakiye();
        }
        static string connectionString = ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);

        private void dtHeader()
        {
            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("kh.HareketID", "İşlem No");
                dataGridView1.Columns.Add("c.CariAdi", "Cari");
                dataGridView1.Columns.Add("k.kasaadi", "Kasa");
                dataGridView1.Columns.Add("kh.Tarih", "Tarih");
                dataGridView1.Columns.Add("kh.HareketTipi", "Gelir/Gider");
                dataGridView1.Columns.Add("kh.Aciklama", "Açıklama");
                dataGridView1.Columns.Add("kh.Tutar", "Tutar");
            }

        }


        private void KasaListele()
        {
            if(baglanti.State == ConnectionState.Closed)baglanti.Open();
            string sorgu = @"Select kh.HareketID, c.CariAdi, k.kasaadi,kh.Tarih, 
                                                            kh.HareketTipi,kh.Aciklama,kh.Tutar
                                                            from KasaHareketleri kh
                                                            INNER JOIN
                                                            Kasa k
                                                            ON
                                                            kh.KasaID=k.id
                                                            INNER JOIN
                                                            Cari c
                                                            ON
                                                            kh.CariID=c.CariID";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);

            dataGridView1.Rows.Clear();
            foreach (DataRow row in dataTable.Rows)
            {
                dataGridView1.Rows.Add(row.ItemArray);
            }
            
        }

        private void gelirToplam()
        {
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();
            string sorgu = "Select Sum(Tutar) From KasaHareketleri where HareketTipi='Gelir'";
            SqlCommand kmt = new SqlCommand(sorgu, baglanti);
            txtGelirTop.Text = kmt.ExecuteScalar().ToString();
            baglanti.Close();
        }
        private void giderToplam()
        {
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();
            string sorgu = "Select Sum(Tutar) From KasaHareketleri where HareketTipi='Gider'";
            SqlCommand kmt = new SqlCommand(sorgu, baglanti);
            txtGiderTop.Text = kmt.ExecuteScalar().ToString();
            baglanti.Close();
        }
        private void toplamBakiye()
        {
            if ((string.IsNullOrEmpty(txtGelirTop.Text) || (string.IsNullOrEmpty(txtGiderTop.Text))))
            {
                txtGenelTop.Text = "0";
            }
            else
            {
                txtGenelTop.Text = (Convert.ToDecimal(txtGelirTop.Text) - Convert.ToDecimal(txtGiderTop.Text)).ToString();

            }
            
        }

        private void FrmKasaHareketleri_Load(object sender, EventArgs e)
        {
            dtHeader(); 
            KasaListele();   
        }
    }
}
