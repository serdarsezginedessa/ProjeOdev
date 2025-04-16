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
    public partial class FrmSatis : Form
    {
        public FrmSatis()
        {
            InitializeComponent();
        }
        private static string connectionString = ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);

        private void musteriAdi()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                SqlCommand komut = new SqlCommand("select CariID, CariAdi from Cari where CariAdi = 'Serdar Sezgin' ", baglanti);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                LblMusteri.Text = ds.Tables[0].Rows[0]["CariAdi"].ToString();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata: " + hata.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }
        private void FrmSatis_Load(object sender, EventArgs e)
        {
            musteriAdi();
        }
    }
}
