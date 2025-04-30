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
        private readonly ClockManager clockManager;
        public Form1()
        {
            InitializeComponent();
            clockManager = new ClockManager(lblTime);
            
            
        }

        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);

        private void Form1_Load(object sender, EventArgs e)
        {
            llblKullanici.Text = FrmLogin.kullaniciAdi;
            lblRol.Text=FrmLogin.rolOku;
            userCountGet();
            GelirGiderGet();
            KasaOzetGrafik();



        }

        public void userCountGet()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                SqlCommand cmd = new SqlCommand("select count (SUBSTRING(CariKod,1,3)) as 'Müşteri Sayısı' from cari where SUBSTRING(CariKod,1,3) LIKE 'MÜŞ%' ", baglanti);

                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                label2.Text = "Müşteri Sayısı: "+dt.Rows[0][0].ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (baglanti.State == ConnectionState.Open) baglanti.Close();
            }
        }
        public void GelirGiderGet()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                SqlCommand cmd = new SqlCommand(@"
            SELECT 
                SUM(CASE WHEN HareketTipi IN ('Tahsilat', 'Giriş') THEN Tutar ELSE 0 END) AS ToplamGelir,
                SUM(CASE WHEN HareketTipi IN ('Tediye', 'Çıkış', 'Gider') THEN Tutar ELSE 0 END) AS ToplamGider
            FROM KasaHareketleri", baglanti);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    decimal toplamGelir = dr["ToplamGelir"] != DBNull.Value ? Convert.ToDecimal(dr["ToplamGelir"]) : 0;
                    decimal toplamGider = dr["ToplamGider"] != DBNull.Value ? Convert.ToDecimal(dr["ToplamGider"]) : 0;
                    decimal bakiye = toplamGelir - toplamGider;

                    lblToplamGelir.Text = "Toplam Gelir: "+toplamGelir.ToString("C2");   // ₺ formatlı
                    lblToplamGider.Text = "Toplam Gider: "+toplamGider.ToString("C2");
                    lblKasaBakiyesi.Text = "Toplam Bakiye: "+bakiye.ToString("C2");

                    // Renkli görsel destek
                    lblKasaBakiyesi.ForeColor = bakiye >= 0 ? Color.Green : Color.Red;
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kasa özeti alınamadı: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void KasaOzetGrafik()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                SqlCommand cmd = new SqlCommand(@"
            SELECT 
                SUM(CASE WHEN HareketTipi IN ('Tahsilat', 'Giriş') THEN Tutar ELSE 0 END) AS ToplamGelir,
                SUM(CASE WHEN HareketTipi IN ('Tediye', 'Çıkış', 'Gider') THEN Tutar ELSE 0 END) AS ToplamGider
            FROM KasaHareketleri", baglanti);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    decimal gelir = dr["ToplamGelir"] != DBNull.Value ? Convert.ToDecimal(dr["ToplamGelir"]) : 0;
                    decimal gider = dr["ToplamGider"] != DBNull.Value ? Convert.ToDecimal(dr["ToplamGider"]) : 0;

                    chartKasaOzet.Series.Clear();
                    chartKasaOzet.Series.Add("Kasa");
                    chartKasaOzet.Series["Kasa"].Points.AddXY("Gelir", gelir);
                    chartKasaOzet.Series["Kasa"].Points.AddXY("Gider", gider);
                }

                dr.Close();
            }
            catch { }
            finally { baglanti.Close(); }
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
            frmCariEkle.Owner = this; // this = ana form
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

        private void stoklarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmStoklar frmStoklar = new FrmStoklar();
            frmStoklar.ShowDialog();
        }

        private void stokTanımlamalarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmStokEkle frmStokEkle = new FrmStokEkle();
            frmStokEkle.ShowDialog();
        }

        private void stokKategorileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmStokKategori frmStokKategori = new FrmStokKategori();
            frmStokKategori.ShowDialog();
        }

        private void satışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSatis frmSatis = new FrmSatis();
            frmSatis.ShowDialog();
        }

        private void satışlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSatisHareketleri frmSat =new FrmSatisHareketleri();
            frmSat.ShowDialog();
        }

        private void tahsilatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTahsilat frm = new FrmTahsilat();
            frm.Owner = this; // this = ana form
            frm.ShowDialog();


        }

        private void giderToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmGiderler frmGider = new FrmGiderler();
            frmGider.Owner = this; // this = ana form
            frmGider.ShowDialog();
        }

        private void giderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGiderHareketleri frmGiderHareketleri = new FrmGiderHareketleri();
            frmGiderHareketleri.ShowDialog();
        }

        private void tahsilaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTahsilatHareketleri frmTahsilatHareketleri = new frmTahsilatHareketleri();
            frmTahsilatHareketleri.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }
    }
}
