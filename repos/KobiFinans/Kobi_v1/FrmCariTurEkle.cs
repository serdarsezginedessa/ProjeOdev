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
    public partial class FrmCariTurEkle : Form
    {
        public FrmCariTurEkle()
        {
            InitializeComponent();
        }
        static string connectionString = ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                SqlCommand kmt = new SqlCommand("INSERT INTO CariTuru (Ad) VALUES (@ad)", baglanti);
                kmt.Parameters.AddWithValue("@ad", txtAd.Text);
                kmt.ExecuteNonQuery();
                MessageBox.Show("Cari Türü Eklendi");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
                this.Hide();
            }
        }
    }
}
