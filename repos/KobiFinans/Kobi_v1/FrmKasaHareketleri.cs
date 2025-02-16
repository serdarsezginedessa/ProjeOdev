using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            KasaListele();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=EDESSASERDAR\\SQLEXPRESS;Initial Catalog=KobiFinans;Integrated Security=True");
        private void KasaListele()
        {
            if(baglanti.State == ConnectionState.Closed)baglanti.Open();
            string sorgu = "Select * From KasaHareketleri Order BY Tarih DESC";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if(baglanti.State==ConnectionState.Closed)baglanti.Open();
            string sorgu = "Insert into KasaHareketleri (Tutar,Aciklama,HareketTipi) values (@Tutar, @Aciklama, @HareketTipi)";
            SqlCommand kmt =  new SqlCommand(sorgu, baglanti);
            
            kmt.Parameters.AddWithValue("@Tutar",txtTutar.Text);
            kmt.Parameters.AddWithValue("@Aciklama",txtAciklama.Text);
            kmt.Parameters.AddWithValue("@HareketTipi",cmbHareketTipi.Text);

            kmt.ExecuteNonQuery();
            MessageBox.Show("Kayıt Başarılı","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            KasaListele();
            baglanti.Close();
        }
    }
}
