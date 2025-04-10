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
            if (dataGridView1.Columns.Count == 0)

              {
                dataGridView1.Columns.Add("BankaAd", "Banka Adı");
                dataGridView1.Columns.Add("BankaSube", "Şube Adı");
                dataGridView1.Columns.Add("HesapNo", "Hesap No");
                dataGridView1.Columns.Add("IBAN", "IBAN");
                dataGridView1.Columns.Add("EklenmeTarihi", "Eklenme Tarihi");
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(baglanti.State==ConnectionState.Closed) 
                {
                    baglanti.Open();
                    if (textBox1.Text=="")
                    {
                        dataGridView1.Rows.Clear();
                    }
                    else
                    {
                        SqlCommand kmt = new SqlCommand("select BankaAd,BankaSube,HesapNo,IBAN,EklenmeTarihi from Bankalar where BankaAd like @bad", baglanti);
                        kmt.Parameters.AddWithValue("@bad", textBox1.Text + "%");
                        SqlDataAdapter da = new SqlDataAdapter(kmt);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dataGridView1.Rows.Clear(); // Mevcut satırları temizleyin Manuel Eklediğim Başlıklar Bozulmuyor..
                        foreach (DataRow row in dt.Rows)
                        {
                            dataGridView1.Rows.Add(row.ItemArray); // Satırlar ekleniyor..
                        }
                    }
                    
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

        private void FrmBankaListe_Load(object sender, EventArgs e)
        {
            dtHeader();
        }
    }
}
