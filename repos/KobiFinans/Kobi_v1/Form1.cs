using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Kobi_v1
{
    public partial class Form1 : Form

    {
        private ClockManager clockManager;
        public Form1()
        {
            InitializeComponent();
            clockManager = new ClockManager(lblTime);
            
            
        }

        static string connectionString = ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
            
        }

        private void cariListeleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCariListele frmCariListele = new FrmCariListele();
            frmCariListele.ShowDialog();
        }

        private void cariHareketlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCariHareketleri frmCariHareketleri = new FrmCariHareketleri();
            frmCariHareketleri.ShowDialog();
        }

        private void cariOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCariEkle frmCariEkle = new FrmCariEkle();
            frmCariEkle.ShowDialog();
        }

        private void kasaListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKasa frmKasa = new FrmKasa();
            frmKasa.ShowDialog();
        }

        private void kasaHareketleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKasaHareketleri frmKasaHareketleri = new FrmKasaHareketleri();
            frmKasaHareketleri.ShowDialog();
        }



        private void bankaHareketleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBankaHareket frmBankaHareket = new FrmBankaHareket();
            frmBankaHareket.ShowDialog();
        }

        private void bankalarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBankaListe frmBankaListe = new FrmBankaListe();
            frmBankaListe.ShowDialog();
        }
    }
}
