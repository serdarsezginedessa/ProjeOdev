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
    public partial class FrmKasa : Form
    {
        public FrmKasa()
        {
            InitializeComponent();
        }
        static string connectionString = ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);

        private void btnekle_Click(object sender, EventArgs e)
        {
            FrmKasaEkle frmKasaEkle = new FrmKasaEkle();
            frmKasaEkle.ShowDialog();
            load();
        }
        void load()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                SqlCommand kmt = new SqlCommand("SELECT KasaAdi as 'Kasa Adı' FROM Kasa", baglanti);
                SqlDataAdapter da = new SqlDataAdapter(kmt);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
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
        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand kmt = new SqlCommand("DELETE FROM Kasa WHERE KasaAdi = @ad", baglanti);
            kmt.Parameters.AddWithValue("@ad", dataGridView1.CurrentRow.Cells[0].Value.ToString());
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                kmt.ExecuteNonQuery();
                load();
                MessageBox.Show("Kasa Silindi");

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

        private void FrmKasa_Load(object sender, EventArgs e)
        {
            load();
        }
    }
}
