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
    public partial class FrmCariHareketleri : Form
    {
        public FrmCariHareketleri()
        {
            InitializeComponent();
        }
        public string cariad
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }
        public string adres

        {
            set { label2.Text = value; }
        }
        public string borc
        {
            set { label6.Text = value; }
        }
        public string alacak
        {
            set { label7.Text = value; }
        }
        public string telefon
        {
            set { label9.Text = value; }
        }
        static string laptopConStr = "Data Source=DESKTOP-NFG00P8\\SQLEXPRESS;Initial Catalog=KobiFinans;Integrated Security=True";
        static string dukkanConStr = "Data Source=EDESSASERDAR\\SQLEXPRESS;Initial Catalog=KobiFinans;Integrated Security=True";
        SqlConnection baglanti = new SqlConnection(laptopConStr);

        private void FrmCariHareketleri_Load(object sender, EventArgs e)
        {
            
        }
        void listele()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                string sorgu = @"SELECT
                                ch.Tarih,
	                            ch.HareketID,
	                            ch.Aciklama,	
	                            c.Borc,
	                            c.Alacak,    
                                ch.HareketTipi,
                                ch.Tutar
                            FROM 
                                cari AS c
                            INNER JOIN 
                                carihareketleri AS ch
                            ON 
                                c.CariID = ch.CariID
                            WHERE 
                                c.cariadi = @cariad";// -- Burada @ID, filtreleme için kullandığınız parametreyi temsil eder;
                //string sorguhareket = "Select * From CariHareketleri";
                SqlCommand kmt = new SqlCommand(sorgu, baglanti);
                kmt.Parameters.AddWithValue("@cariad", label1.Text);
                SqlDataAdapter da = new SqlDataAdapter(kmt);
                //DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                ds.Clear();
                //dt.Clear();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].HeaderText = "Tarih";
                dataGridView1.Columns[1].HeaderText = "Belge No";
                dataGridView1.Columns[2].HeaderText = "Açıklama";
                dataGridView1.Columns[3].HeaderText = "Borç";
                dataGridView1.Columns[4].HeaderText = "Alacak";
                dataGridView1.Columns[5].HeaderText = "Bakiye";
                dataGridView1.Columns[6].HeaderText = "İşlem Türü";


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
            FrmCariIslemler frmCariislemler = new FrmCariIslemler();
            frmCariislemler.cariad = label1.Text;
            frmCariislemler.adres = label2.Text;
            frmCariislemler.telefon = label9.Text;
            frmCariislemler.ShowDialog();
            listele();
        }

        private void FrmCariHareketleri_Load_1(object sender, EventArgs e)
        {
            listele();
        }
    }
}
