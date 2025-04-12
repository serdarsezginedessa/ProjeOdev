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
    public partial class FrmCariListele : Form
    {
        public FrmCariListele()
        {
            InitializeComponent();
        }
        

        static string connectionString = ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);
        string sorguListele = "Select * From Cari";
        string sorgu = "Select cariID From Cari where cariAdi=@cad";
        string sorguCari_Tur = @"Select c.CariID,
                                    c.CariAdi,
		                            c.Telefon,
		                            c.Email,
		                            c.Adres,
		                            c.VergiNo,
		                            c.Borc,
		                            c.Alacak, 
		                            ct.Ad 
		                            From cari as c
		                            INNER JOIN
		                            CariTuru as ct
		                            ON
		                            c.cariTuru = ct.ID";

        private void dtHeader()
        {
            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("ID", "Cari No");
                dataGridView1.Columns.Add("Cari Adı", "Cari Adı");
                dataGridView1.Columns.Add("Telefon", "Telefon");
                dataGridView1.Columns.Add("E-Posta", "E-Posta");
                dataGridView1.Columns.Add("Adres", "Adres");
                dataGridView1.Columns.Add("Vergi No", "Vergi No");
                dataGridView1.Columns.Add("Borç", "Borç");
                dataGridView1.Columns.Add("Alacak", "Alacak");
                dataGridView1.Columns.Add("Cari Türü", "Cari Türü");
            }
        }

        private void FrmCariListele_Load(object sender, EventArgs e)
        {
            
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }











        /*private void btnBorcAlacak_Click(object sender, EventArgs e)
        {
            FrmCariHareketleri frmCariHareketleri = new FrmCariHareketleri();
            frmCariHareketleri.cariad = ad.ToString();
            frmCariHareketleri.adres = adres.ToString();
            frmCariHareketleri.alacak = alacak.ToString();
            frmCariHareketleri.borc = borc.ToString();
            frmCariHareketleri.telefon = tel.ToString();
            frmCariHareketleri.ShowDialog();
            
        }*/


        /*  private void CariCariturListele()
  {
      try
      {
          label6.Visible = false;
          if (baglanti.State == ConnectionState.Closed) baglanti.Open();

          SqlDataAdapter da = new SqlDataAdapter(sorguCari_Tur, baglanti);
          DataTable dt = new DataTable();
          dt.Clear();
          da.Fill(dt);
          dataGridView1.DataSource = dt;

          dataGridView1.Columns[0].HeaderText = "ID";
          dataGridView1.Columns[1].HeaderText = "Cari Adı";
          dataGridView1.Columns[2].HeaderText = "Telefon";
          dataGridView1.Columns[3].HeaderText = "E-Posta";
          dataGridView1.Columns[4].HeaderText = "Adres";
          dataGridView1.Columns[5].HeaderText = "Vergi No";
          dataGridView1.Columns[6].HeaderText = "Borç";
          dataGridView1.Columns[7].HeaderText = "Alacak";
          dataGridView1.Columns[8].HeaderText = "Cari Türü";
      }
      catch (Exception ex)
      {
          MessageBox.Show(ex.Message);
      }
      finally
      {
          baglanti.Close();
      }
  }*/


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // Geçerli bir hücre seçili mi?
                {
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }

        }
    }

}
