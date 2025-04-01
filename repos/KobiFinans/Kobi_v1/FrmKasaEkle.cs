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
    public partial class FrmKasaEkle : Form
    {
        public FrmKasaEkle()
        {
            InitializeComponent();
        }
        static string laptopConStr = "Data Source=DESKTOP-NFG00P8\\SQLEXPRESS;Initial Catalog=KobiFinans;Integrated Security=True";
        static string dukkanConStr = "Data Source=EDESSASERDAR\\SQLEXPRESS;Initial Catalog=KobiFinans;Integrated Security=True";
        SqlConnection baglanti = new SqlConnection(laptopConStr);

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                SqlCommand kmt = new SqlCommand("INSERT INTO Kasa (KasaAdi) VALUES (@ad)", baglanti);
                kmt.Parameters.AddWithValue("@ad", txtAd.Text);
                kmt.ExecuteNonQuery();
                MessageBox.Show("Yeni Kasa Eklendi");

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

        private void btniptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
