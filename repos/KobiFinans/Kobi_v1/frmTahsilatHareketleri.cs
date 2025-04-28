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
        public partial class frmTahsilatHareketleri : Form
        {
            
            public frmTahsilatHareketleri()
            {
                InitializeComponent();
                
            }
            public int TahsilatIdGonder {  get; set; }

            private static string connectionString = ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
            SqlConnection baglanti = new SqlConnection(connectionString);

            //************************Sql Sorgular**************************************************
            string sqlTumKayitlar = @"SELECT * FROM TAHSİLATLAR";




            //************************METHOTLAR******************************************************

            private void TumKayitlariListele()
            {
                try
                {
                    if (baglanti.State == ConnectionState.Closed) baglanti.Open();


                    SqlDataAdapter da = new SqlDataAdapter(sqlTumKayitlar, baglanti);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;

                    baglanti.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tahsilatlar Listelenirken Bir Hata Oluştu.. " + ex.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    baglanti.Close();
                }
            }

            private void frmTahsilatHareketleri_Load(object sender, EventArgs e)
            {
                TumKayitlariListele();
            }

            private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex >= 0)
                {

                DataGridViewRow satir = dataGridView1.Rows[e.RowIndex];
                string tahsilatID = satir.Cells["TahsilatID"].Value.ToString();
                string faturaNo = satir.Cells["FaturaNo"].Value.ToString();
                string cariId = satir.Cells["CariId"].Value.ToString();
                string tutar = satir.Cells["Tutar"].Value.ToString();
                string tarih = satir.Cells["Tarih"].Value.ToString();
                string odemeTuru = satir.Cells["OdemeTuruID"].Value.ToString();
                string kasaID = satir.Cells["KasaID"].Value.ToString();
                string BankaID = satir.Cells["BankaID"].Value.ToString();
                string aciklama = satir.Cells["Aciklama"].Value.ToString();

                TahsilatIdGonder=Convert.ToInt32(tahsilatID);
                this.DialogResult = DialogResult.OK;
                this.Close();
                
                }
                
            }
        }
}
