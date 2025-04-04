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
            KasaListele();
            gelirToplam();
            giderToplam();
            toplamBakiye();
        }
        static string connectionString = ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);
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
            string sorgu = "Insert into KasaHareketleri (Tarih,Tutar,Aciklama,HareketTipi) values (@Tarih, @Tutar, @Aciklama, @HareketTipi)";
            SqlCommand kmt =  new SqlCommand(sorgu, baglanti);
            
            kmt.Parameters.AddWithValue("@Tarih", dateTimePicker1.Value);
            kmt.Parameters.AddWithValue("@Tutar",txtTutar.Text);
            kmt.Parameters.AddWithValue("@Aciklama",txtAciklama.Text);
            kmt.Parameters.AddWithValue("@HareketTipi",cmbHareketTipi.Text);

            kmt.ExecuteNonQuery();
            MessageBox.Show("Kayıt Başarılı","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            KasaListele();
            baglanti.Close();
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int iD = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();
            string updateSorgu = "Update KasaHareketleri set Tarih=@Tarih, Tutar=@Tutar, Aciklama=@Aciklama, HareketTipi=@HareketTipi where HareketID=@Id";
            SqlCommand kmt = new SqlCommand(updateSorgu, baglanti);
            kmt.Parameters.AddWithValue("@Tarih", dateTimePicker1.Value);
            kmt.Parameters.AddWithValue("@Tutar", Convert.ToDecimal(txtTutar.Text));
            kmt.Parameters.AddWithValue("@Aciklama", txtAciklama.Text);
            kmt.Parameters.AddWithValue("@HareketTipi", cmbHareketTipi.Text);
            kmt.Parameters.AddWithValue("@Id", dataGridView1.CurrentRow.Cells[0].Value);
            kmt.ExecuteNonQuery();
            MessageBox.Show("Güncelleme İşlemi Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            KasaListele();
            gelirToplam();
            giderToplam();
            toplamBakiye();
            baglanti.Close();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();
            string deleteSorgu = "Delete From KasaHareketleri where HareketID=@Id";
            SqlCommand kmt = new SqlCommand(deleteSorgu, baglanti);
            kmt.Parameters.AddWithValue("@Id", dataGridView1.CurrentRow.Cells[0].Value);
            kmt.ExecuteNonQuery();
            MessageBox.Show("Silme İşlemi Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            KasaListele();
            baglanti.Close();
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int secilen = e.RowIndex;
            if(secilen == -1) return;
            dateTimePicker1.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtTutar.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtAciklama.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            cmbHareketTipi.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
        }

        void gelirToplam()
        {
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();
            string sorgu = "Select Sum(Tutar) From KasaHareketleri where HareketTipi='Gelir'";
            SqlCommand kmt = new SqlCommand(sorgu, baglanti);
            txtGelirTop.Text = kmt.ExecuteScalar().ToString();
            baglanti.Close();
        }
        void giderToplam()
        {
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();
            string sorgu = "Select Sum(Tutar) From KasaHareketleri where HareketTipi='Gider'";
            SqlCommand kmt = new SqlCommand(sorgu, baglanti);
            txtGiderTop.Text = kmt.ExecuteScalar().ToString();
            baglanti.Close();
        }

        void toplamBakiye()
        {
            txtGenelTop.Text = (Convert.ToDecimal(txtGelirTop.Text) - Convert.ToDecimal(txtGiderTop.Text)).ToString();
        }

    }
}
