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
    public partial class FrmCariTur : Form
    {
        public FrmCariTur()
        {
            InitializeComponent();
        }
        static string laptopConStr = "Data Source=DESKTOP-NFG00P8\\SQLEXPRESS;Initial Catalog=KobiFinans;Integrated Security=True";
        static string dukkanConStr = "Data Source=EDESSASERDAR\\SQLEXPRESS;Initial Catalog=KobiFinans;Integrated Security=True";
        SqlConnection baglanti = new SqlConnection(laptopConStr);
        void load()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                SqlCommand kmt = new SqlCommand("SELECT Ad as 'Cari Türü' FROM CariTuru", baglanti);
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

        private void FrmCariTur_Load(object sender, EventArgs e)
        {
            load();

        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            FrmCariTurEkle frmCariTurEkle = new FrmCariTurEkle();
            frmCariTurEkle.ShowDialog();
            load();
            
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand kmt = new SqlCommand("DELETE FROM CariTuru WHERE Ad = @ad", baglanti);
            kmt.Parameters.AddWithValue("@ad", dataGridView1.CurrentRow.Cells[0].Value.ToString());
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                kmt.ExecuteNonQuery();
                load();
                MessageBox.Show("Cari Türü Silindi");
                
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
    }
}
