using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common.CommandTrees.ExpressionBuilder;
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
      
        static string connectionString = ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);

        private void FrmCariHareketleri_Load(object sender, EventArgs e)
        {
            dtHeader();
            BugunRapor  ();
            BankalariYukle();
            HareketTipleriniYukle();
            
        }

        private void dtHeader()
        {
            if (dataGridView1.Columns.Count == 0)
            {

                dataGridView1.Columns.Add("ch.HareketID","İşlem No");
                dataGridView1.Columns.Add("c.CariAdi", "Cari Adı");
                dataGridView1.Columns.Add("k.KasaAdi", "Kasa Adı");
                dataGridView1.Columns.Add("b.BankaAD","Banka Adı");
                dataGridView1.Columns.Add("o.OdemeAD","Ödeme Türü");
                dataGridView1.Columns.Add("ch.Tarih","Tarih");
                dataGridView1.Columns.Add("ch.Aciklama","Açıklama");
                dataGridView1.Columns.Add("ch.Tutar","Tutar");
                dataGridView1.Columns.Add("ch.HareketTipi","Hareket Tipi");
                dataGridView1.Columns.Add("ch.TahsilatID","Tahsilat No");
                dataGridView1.Columns.Add("ch.GiderID","Gider No");
                
            }
        }
        private void BankalariYukle()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand kmt = new SqlCommand(@"SELECT BankaAd FROM Bankalar", baglanti);
                    SqlDataReader dr = kmt.ExecuteReader();
                    while (dr.Read())
                    {
                        comboBanka.Items.Add(dr["BankaAd"].ToString());
                    }
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

        private void HareketTipleriniYukle()
        {
            try
            {
                comboHareketTipi.Items.Add("Borç");
                comboHareketTipi.Items.Add("Alacak");
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

        private void HesaplaGelirGider()
        {
            decimal toplamGelir = 0;
            decimal toplamGider = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue; // Yeni satırı atla

                string hareketTipi = row.Cells["ch.HareketTipi"].Value?.ToString();
                decimal tutar;

                if (decimal.TryParse(row.Cells["ch.Tutar"].Value?.ToString(), out tutar))
                {
                    if (hareketTipi == "Alacak")
                        toplamGelir += tutar;
                    else if (hareketTipi == "Borç")
                        toplamGider += tutar;
                }
            }

            txtGelirTop.Text = toplamGelir.ToString("N2");
            txtGiderTop.Text = toplamGider.ToString("N2");
            txtGenelTop.Text = (toplamGelir - toplamGider).ToString("N2");
        }

        private void BugunRapor()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                string sorgu = @"SELECT
                                ch.HareketID, c.CariAdi, k.KasaAdi, b.BankaAd, o.OdemeAD,
                                ch.Tarih,
                                ch.Aciklama,
                                ch.Tutar,
                                ch.HareketTipi,
	                            ch.TahsilatID,
                                ch.GiderID
                            FROM  carihareketleri AS ch
                            LEFT JOIN cari AS c
                            ON ch.CariID = c.CariID
                            LEFT JOIN Kasalar AS k
                            ON ch.KasaID = k.KasaID
                            LEFT JOIN Bankalar AS b
                            ON ch.BankaID = b.BankaID
                            LEFT JOIN OdemeTuru AS o
                            ON ch.OdemeID = o.OdemeID
                            LEFT JOIN gider AS g
                            ON ch.GiderID = g.GiderID

                            WHERE ch.Tarih >= @tarih AND ch.Tarih < DATEADD(DAY, 1, @tarih)";

                SqlCommand kmt = new SqlCommand(sorgu, baglanti);
                kmt.Parameters.AddWithValue("@tarih", Date1.Value.Date);
                SqlDataAdapter da = new SqlDataAdapter(kmt);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    dataGridView1.Rows.Add(row.ItemArray);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
            HesaplaGelirGider();
        }

        private void TumRapor()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                string sorgu = @"SELECT
                                ch.HareketID, c.CariAdi, k.KasaAdi, b.BankaAd, o.OdemeAD,
                                ch.Tarih,
                                ch.Aciklama,
                                ch.Tutar,
                                ch.HareketTipi,
                                ch.TahsilatID,
                                ch.GiderID
                            FROM  carihareketleri AS ch
                            LEFT JOIN cari AS c
                            ON ch.CariID = c.CariID
                            LEFT JOIN Kasalar AS k
                            ON ch.KasaID = k.KasaID
                            LEFT JOIN Bankalar AS b
                            ON ch.BankaID = b.BankaID
                            LEFT JOIN OdemeTuru AS o
                            ON ch.OdemeID = o.OdemeID
                            LEFT JOIN gider AS g
                            ON ch.GiderID = g.GiderID";

                SqlCommand kmt = new SqlCommand(sorgu, baglanti);
                SqlDataAdapter da = new SqlDataAdapter(kmt);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    dataGridView1.Rows.Add(row.ItemArray);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
            HesaplaGelirGider();
        }
        private void IkiTarihArasiRapor()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                string sorgu = @"SELECT
                                ch.HareketID, c.CariAdi, k.KasaAdi, b.BankaAd, o.OdemeAD,
                                ch.Tarih,
                                ch.Aciklama,
                                ch.Tutar,
                                ch.HareketTipi,
                                ch.TahsilatID,
                                ch.GiderID
                            FROM  carihareketleri AS ch
                            LEFT JOIN cari AS c
                            ON ch.CariID = c.CariID
                            LEFT JOIN Kasalar AS k
                            ON ch.KasaID = k.KasaID
                            LEFT JOIN Bankalar AS b
                            ON ch.BankaID = b.BankaID
                            LEFT JOIN OdemeTuru AS o
                            ON ch.OdemeID = o.OdemeID
                            LEFT JOIN gider AS g
                            ON ch.GiderID = g.GiderID
                            WHERE ch.Tarih >= @tarih1 AND ch.Tarih < DATEADD(DAY, 1, @tarih2)";
                SqlCommand kmt = new SqlCommand(sorgu, baglanti);
                kmt.Parameters.AddWithValue("@tarih1", Date1.Value.Date);
                kmt.Parameters.AddWithValue("@tarih2", Date2.Value.Date);
                SqlDataAdapter da = new SqlDataAdapter(kmt);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    dataGridView1.Rows.Add(row.ItemArray);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
            HesaplaGelirGider();
        }









        private void comboHareketTipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                string sorgu = @"SELECT
                                ch.HareketID, c.CariAdi, k.KasaAdi, b.BankaAd, o.OdemeAD,
                                ch.Tarih,
                                ch.Aciklama,
                                ch.Tutar,
                                ch.HareketTipi,
                                ch.TahsilatID,
                                ch.GiderID
                            FROM  carihareketleri AS ch
                            LEFT JOIN cari AS c
                            ON ch.CariID = c.CariID
                            LEFT JOIN Kasalar AS k
                            ON ch.KasaID = k.KasaID
                            LEFT JOIN Bankalar AS b
                            ON ch.BankaID = b.BankaID
                            LEFT JOIN OdemeTuru AS o
                            ON ch.OdemeID = o.OdemeID
                            LEFT JOIN gider AS g
                            ON ch.GiderID = g.GiderID";
                
               
                sorgu += " WHERE ch.HareketTipi = '" + comboHareketTipi.Text + "'";
                
                SqlCommand kmt = new SqlCommand(sorgu, baglanti);
                SqlDataAdapter da = new SqlDataAdapter(kmt);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    dataGridView1.Rows.Add(row.ItemArray);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
            HesaplaGelirGider();
        }

        private void comboBanka_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                string sorgu = @"SELECT
                                ch.HareketID, c.CariAdi, k.KasaAdi, b.BankaAd, o.OdemeAD,
                                ch.Tarih,
                                ch.Aciklama,
                                ch.Tutar,
                                ch.HareketTipi,
                                ch.TahsilatID,
                                ch.GiderID
                            FROM  carihareketleri AS ch
                            LEFT JOIN cari AS c
                            ON ch.CariID = c.CariID
                            LEFT JOIN Kasalar AS k
                            ON ch.KasaID = k.KasaID
                            LEFT JOIN Bankalar AS b
                            ON ch.BankaID = b.BankaID
                            LEFT JOIN OdemeTuru AS o
                            ON ch.OdemeID = o.OdemeID
                            LEFT JOIN gider AS g
                            ON ch.GiderID = g.GiderID";
                
                    string bankaID = "Select BankaID From Bankalar Where BankaAd = '" + comboBanka.Text + "'";
                    SqlDataReader dr = new SqlCommand(bankaID, baglanti).ExecuteReader();
                    while (dr.Read())
                    {
                        sorgu += " WHERE ch.BankaID = '" + dr["BankaID"].ToString() + "'";
                    }
                    dr.Close();
                    // sorgu += " WHERE ch.BankaID = '" + comboBanka.SelectedItem.ToString() + "'";
                
                SqlCommand kmt = new SqlCommand(sorgu, baglanti);
                SqlDataAdapter da = new SqlDataAdapter(kmt);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    dataGridView1.Rows.Add(row.ItemArray);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
            HesaplaGelirGider();
        }

        private void btnSifirla_Click(object sender, EventArgs e)
        {
            txtCariAD.Clear();
            txtislemNo.Clear();            
            comboBanka.SelectedIndex = -1;
            comboHareketTipi.SelectedIndex = -1;
            checkBoxTumKayitlar.Checked = false;
            Date1.Value = DateTime.Now;
            Date2.Value = DateTime.Now;
            BugunRapor();
        }

        private void checkBoxTumKayitlar_CheckedChanged(object sender, EventArgs e)
        {
           if(checkBoxTumKayitlar.Checked == true)
            {
                TumRapor();
            }
            else
            {
                BugunRapor();
            }
        }

        private void txtislemNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                string sorgu = @"SELECT
                                ch.HareketID, c.CariAdi, k.KasaAdi, b.BankaAd, o.OdemeAD,
                                ch.Tarih,
                                ch.Aciklama,
                                ch.Tutar,
                                ch.HareketTipi,
                                ch.TahsilatID,
                                ch.GiderID
                            FROM  carihareketleri AS ch
                            LEFT JOIN cari AS c
                            ON ch.CariID = c.CariID
                            LEFT JOIN Kasalar AS k
                            ON ch.KasaID = k.KasaID
                            LEFT JOIN Bankalar AS b
                            ON ch.BankaID = b.BankaID
                            LEFT JOIN OdemeTuru AS o
                            ON ch.OdemeID = o.OdemeID
                            LEFT JOIN gider AS g
                            ON ch.GiderID = g.GiderID
                            WHERE ch.HareketID LIKE @islemNo";
                
                
                SqlCommand kmt = new SqlCommand(sorgu, baglanti);
                kmt.Parameters.AddWithValue("@islemNo", '%' + txtislemNo.Text + '%');
                SqlDataAdapter da = new SqlDataAdapter(kmt);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    dataGridView1.Rows.Add(row.ItemArray);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
            HesaplaGelirGider();
        }

        private void txtCariAD_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                string sorgu = @"SELECT
                                ch.HareketID, c.CariAdi, k.KasaAdi, b.BankaAd, o.OdemeAD,
                                ch.Tarih,
                                ch.Aciklama,
                                ch.Tutar,
                                ch.HareketTipi,
                                ch.TahsilatID,
                                ch.GiderID
                            FROM  carihareketleri AS ch
                            LEFT JOIN cari AS c
                            ON ch.CariID = c.CariID
                            LEFT JOIN Kasalar AS k
                            ON ch.KasaID = k.KasaID
                            LEFT JOIN Bankalar AS b
                            ON ch.BankaID = b.BankaID
                            LEFT JOIN OdemeTuru AS o
                            ON ch.OdemeID = o.OdemeID
                            LEFT JOIN gider AS g
                            ON ch.GiderID = g.GiderID
                            WHERE c.CariAdi LIKE @cariadi";

                SqlCommand kmt = new SqlCommand(sorgu, baglanti);
                kmt.Parameters.AddWithValue("@cariadi", '%' + txtCariAD.Text + '%');
                SqlDataAdapter da = new SqlDataAdapter(kmt);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    dataGridView1.Rows.Add(row.ItemArray);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
            HesaplaGelirGider();
        }

        private void Date1_ValueChanged(object sender, EventArgs e)
        {
            IkiTarihArasiRapor();
        }

        private void Date2_ValueChanged(object sender, EventArgs e)
        {
            IkiTarihArasiRapor();
        }

        private void FrmCariHareketleri_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
