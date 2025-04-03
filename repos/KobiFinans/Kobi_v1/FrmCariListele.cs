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
        public int id
        {
            get { return Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value); }
            
        }
        
        public  string ad
        {
            get { return label6.Text; }

        }
        public string tel
        {
            get { return dataGridView1.CurrentRow.Cells[2].Value.ToString(); }
        }
        public string eposta
        {
            get { return dataGridView1.CurrentRow.Cells[3].Value.ToString(); }
        }
        public string adres
        {
            get { return dataGridView1.CurrentRow.Cells[4].Value.ToString(); }
        }
        public string vergiNo
        {
            get { return dataGridView1.CurrentRow.Cells[5].Value.ToString(); }
        }
        public decimal borc
        {
            get { return Convert.ToDecimal(dataGridView1.CurrentRow.Cells[6].Value); }
        }
        public decimal alacak
        {
            get { return Convert.ToDecimal(dataGridView1.CurrentRow.Cells[7].Value); }
        }

        static string connectionString = ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);
        private void FrmCariListele_Load(object sender, EventArgs e)
        {
            try
            {
                string sorguListele = "Select * From Cari";
                string sorgucariadi = "Select cariID From Cari where cariAdi=@cad";

                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                
                SqlDataAdapter da = new SqlDataAdapter(sorguListele, baglanti);
                DataTable dt = new DataTable();
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
                


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void btnBorcAlacak_Click(object sender, EventArgs e)
        {
            FrmCariHareketleri frmCariHareketleri = new FrmCariHareketleri();
            frmCariHareketleri.cariad = ad.ToString();
            frmCariHareketleri.adres = adres.ToString();
            frmCariHareketleri.alacak = alacak.ToString();
            frmCariHareketleri.borc = borc.ToString();
            frmCariHareketleri.telefon = tel.ToString();
            frmCariHareketleri.ShowDialog();
            
        }

        private void btnCariAdd_Click(object sender, EventArgs e)
        {
            FrmCariEkle frmCariEkle = new FrmCariEkle();
            frmCariEkle.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label6.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0) // Geçerli bir hücre seçili mi?
            {
                // Seçilen hücredeki veriyi al
                string selectedData = dataGridView1.Rows[e.RowIndex].Cells["cariadi"].Value.ToString(); // Sütun adını belirt

                // Ana formda ilgili metoda bilgiyi gönder
                ((FrmCariIslemler)this.Owner).SetCariInfo(selectedData);

                // Formu kapat
                this.Close();
            }
        }
    }
    
}
