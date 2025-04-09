using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kobi_v1
{
    public partial class FrmBankaListe : Form
    {
        public FrmBankaListe()
        {
            InitializeComponent();
            
            
        }
        static string connectionString = ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);
        private void dtHeader()
        {
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].HeaderText = "Banka Adı";
            dataGridView1.Columns[1].HeaderText = "Şube Adı";
            dataGridView1.Columns[2].HeaderText = "Hesap No";
            dataGridView1.Columns[3].HeaderText = "IBAN";
            dataGridView1.Columns[4].HeaderText = "Eklenme Tarihi";
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(baglanti.State==ConnectionState.Closed) 
                {
                    baglanti.Open();
                    SqlCommand kmt = new SqlCommand("select BankaAd,BankaSube,HesapNo,IBAN,EklenmeTarihi from Bankalar where BankaAd like @bad", baglanti);
                    kmt.Parameters.AddWithValue("@bad", textBox1.Text + "%");
                    SqlDataAdapter da = new SqlDataAdapter(kmt);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    
                    

                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }
    }
}
