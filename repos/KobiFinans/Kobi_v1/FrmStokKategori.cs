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
    public partial class FrmStokKategori : Form
    {
        public FrmStokKategori()
        {
            InitializeComponent();
        }
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);

        private void FrmStokKategori_Load(object sender, EventArgs e)
        {
            BtnLoad();
            Listele();
            
        }
        private void BtnLoad()
        {
            btnYeni.Enabled = true;
            btniptal.Enabled = false;
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
            btnEkle.Enabled = false;
        }
        private void Listele()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                SqlCommand komut = new SqlCommand("select KategoriID [Kategori No], KategoriAdi [Kategori Adı], Aciklama [Açıklama] , CASE  WHEN Durum = 1 THEN 'Aktif'  ELSE 'Pasif'  END AS Durum from UrunKategori", baglanti);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];

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
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int satirIndex = e.RowIndex;
            if (satirIndex >= 0)
            {
                DataGridViewRow satir = dataGridView1.Rows[satirIndex];
                txtstKategoriNo.Text = satir.Cells["Kategori No"].Value.ToString();
                txtStkategoriAd.Text = satir.Cells["Kategori Adı"].Value.ToString();
                txtStKategoriAciklama.Text = satir.Cells["Açıklama"].Value.ToString();
                comboBoxDurum.Text = satir.Cells["Durum"].Value.ToString();
            }
        }
    }
}
