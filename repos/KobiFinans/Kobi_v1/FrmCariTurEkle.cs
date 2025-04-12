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
            string tur=txtAd.Text.Trim();
            if (string.IsNullOrEmpty(tur)) return;

            string prefix =tur.Length>=3?tur.Substring(0, 3).ToUpper() : tur.ToUpper();//ilk 3 harfi al ve buyuk harf yap

            //prefix veritabanında varmı kontrol ediliyor.
            
            

            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                string sorguprefix = "select count(*) from CariTuru where Ad='" + prefix + "'";
                SqlCommand kmt1 = new SqlCommand(sorguprefix, baglanti);
                kmt1.Parameters.AddWithValue("@prefix", prefix);

                int prefixCount = (int)kmt1.ExecuteScalar();
                if (prefixCount > 0)
                {
                    prefix+=prefixCount.ToString();
                }

                SqlCommand kmt = new SqlCommand("INSERT INTO CariTuru (Ad,Prefix) VALUES (@ad,@prefix)", baglanti);
                kmt.Parameters.AddWithValue("@ad", tur);
                kmt.Parameters.AddWithValue("@prefix", prefix);

                kmt.ExecuteNonQuery();
                MessageBox.Show("Cari Türü  Başarıyla Eklendi");

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
