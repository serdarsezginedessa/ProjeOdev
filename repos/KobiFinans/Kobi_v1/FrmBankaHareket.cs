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
    public partial class FrmBankaHareket : Form
    {
        public FrmBankaHareket()
        {
            InitializeComponent();
        }
        static string connectionString = ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);
        private void FrmBankaHareket_Load(object sender, EventArgs e)
        {
            dtHeader();
            BugunRapor();
            odemeTuruYukle();
            BankalariYukle();
        }

        private void dtHeader()
        {
            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("kh.HareketID", "İşlem No");
                dataGridView1.Columns.Add("c.CariAdi", "Cari");
                dataGridView1.Columns.Add("b.BankaAd", "Banka");
                dataGridView1.Columns.Add("kh.Tarih", "Tarih");
                dataGridView1.Columns.Add("kh.HareketTipi", "Gelir");
                dataGridView1.Columns.Add("kh.Kaynak", "Kaynak");
                dataGridView1.Columns.Add("kh.Aciklama", "Açıklama");
                dataGridView1.Columns.Add("kh.Tutar", "Tutar");


            }

        }

        private void getir()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand kmt = new SqlCommand(@"Select bh.ID, c.Cariadi, b.BankaAd, bh.Tarih, bh.HareketTipi, 
                                                    bh.Kaynak, bh.Aciklama, 
                                                    bh.Tutar
                                                    From 
                                                    Bankalar b
                                                    Inner Join
                                                    BankaHareketleri bh
                                                    On
                                                    b.BankaID=bh.BankaID
                                                    Inner Join Cari c
                                                    On
                                                    c.CariID=bh.CariID          
                                                                ", baglanti);
                    SqlDataAdapter da = new SqlDataAdapter(kmt);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.Rows.Clear(); // Mevcut satırları temizleyin Manuel Eklediğim Başlıklar Bozulmuyor..
                    foreach (DataRow row in dt.Rows)
                    {
                        object[] values = new object[dt.Columns.Count];

                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            if (row[i] == DBNull.Value)
                            {
                                values[i] = ""; // Boş değerler için boş string
                            }
                            else if (row[i] is DateTime tarih)
                            {
                                values[i] = tarih.ToString("yyyy-MM-dd"); // Tarihi biçimli stringe çevir
                            }
                            else if (row[i] is bool durum)
                            {
                                values[i] = durum ? "Aktif" : "Pasif"; // Durum kolonu için okunabilir değer
                            }
                            else
                            {
                                values[i] = row[i];
                            }
                        }

                        dataGridView1.Rows.Add(values); // Satırı DataGridView'e ekle
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

        private void odemeTuruYukle()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand kmt = new SqlCommand(@"SELECT OdemeAD FROM OdemeTuru WHERE OdemeAD <> 'Nakit'", baglanti);
                    SqlDataReader dr = kmt.ExecuteReader();
                    while (dr.Read())
                    {
                        comboOdemeTuru.Items.Add(dr["OdemeAd"].ToString());
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

        private void HesaplaGelirGider()
        {
            decimal toplamGelir = 0;
            decimal toplamGider = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue; // Yeni satırı atla

                string hareketTipi = row.Cells["kh.HareketTipi"].Value?.ToString();
                decimal tutar;

                if (decimal.TryParse(row.Cells["kh.Tutar"].Value?.ToString(), out tutar))
                {
                    if (hareketTipi == "Gelir" || hareketTipi == "Tahsilat")
                        toplamGelir += tutar;
                    else if (hareketTipi == "Gider")
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
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand kmt = new SqlCommand(@"Select bh.ID, c.Cariadi, b.BankaAd, bh.Tarih, bh.HareketTipi, 
                                                    bh.Kaynak, bh.Aciklama, 
                                                    bh.Tutar
                                                    From 
                                                    Bankalar b
                                                    Inner Join
                                                    BankaHareketleri bh
                                                    On
                                                    b.BankaID=bh.BankaID
                                                    Inner Join Cari c
                                                    On
                                                    c.CariID=bh.CariID

                                                    WHERE bh.Tarih >= @tarih AND bh.Tarih < DATEADD(DAY, 1, @tarih)", baglanti);

                    kmt.Parameters.AddWithValue("@tarih", DateTime.Now.Date);
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
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
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
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand kmt = new SqlCommand(@"Select bh.ID, c.Cariadi, b.BankaAd, bh.Tarih, bh.HareketTipi, 
                                                    bh.Kaynak, bh.Aciklama, 
                                                    bh.Tutar
                                                    From 
                                                    Bankalar b
                                                    Inner Join
                                                    BankaHareketleri bh
                                                    On
                                                    b.BankaID=bh.BankaID
                                                    Inner Join Cari c
                                                    On
                                                    c.CariID=bh.CariID
                                                    WHERE bh.Tarih >= @tarih1 AND bh.Tarih < DATEADD(DAY, 1, @tarih2)", baglanti);
                    kmt.Parameters.AddWithValue("@Tarih1", Date1.Value.Date);
                    kmt.Parameters.AddWithValue("@Tarih2", Date2.Value.Date);
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
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
            HesaplaGelirGider();
        }

        private void checkBoxTumKayitlar_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTumKayitlar.Checked)
            {
                getir();

            }
            else
            {
                BugunRapor();
            }
            HesaplaGelirGider();
        }

        private void txtislemNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand kmt = new SqlCommand(@"Select bh.ID, c.Cariadi, b.BankaAd, bh.Tarih, bh.HareketTipi, 
                                                    bh.Kaynak, bh.Aciklama, 
                                                    bh.Tutar
                                                    From 
                                                    Bankalar b
                                                    Inner Join
                                                    BankaHareketleri bh
                                                    On
                                                    b.BankaID=bh.BankaID
                                                    Inner Join Cari c
                                                    On
                                                    c.CariID=bh.CariID
                                                    WHERE bh.ID LIKE @islemNo", baglanti);
                    kmt.Parameters.AddWithValue("@islemNo", "%" + txtislemNo.Text + "%");
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
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
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
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand kmt = new SqlCommand(@"Select bh.ID, c.Cariadi, b.BankaAd, bh.Tarih, bh.HareketTipi, 
                                                    bh.Kaynak, bh.Aciklama, 
                                                    bh.Tutar
                                                    From 
                                                    Bankalar b
                                                    Inner Join
                                                    BankaHareketleri bh
                                                    On
                                                    b.BankaID=bh.BankaID
                                                    Inner Join Cari c
                                                    On
                                                    c.CariID=bh.CariID
                                                    WHERE c.Cariadi LIKE @cariadi", baglanti);
                    kmt.Parameters.AddWithValue("@cariadi", "%" + txtCariAD.Text + "%");
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
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
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
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand kmt = new SqlCommand(@"Select bh.ID, c.Cariadi, b.BankaAd, bh.Tarih, bh.HareketTipi, 
                                                    bh.Kaynak, bh.Aciklama, 
                                                    bh.Tutar
                                                    From 
                                                    Bankalar b
                                                    Inner Join
                                                    BankaHareketleri bh
                                                    On
                                                    b.BankaID=bh.BankaID
                                                    Inner Join Cari c
                                                    On
                                                    c.CariID=bh.CariID
                                                    WHERE b.BankaAd =@bankaadi", baglanti);
                    kmt.Parameters.AddWithValue("@bankaadi", comboBanka.Text);
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
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
            HesaplaGelirGider();
        }

        private void comboOdemeTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand kmt = new SqlCommand(@"Select bh.ID, c.Cariadi, b.BankaAd, bh.Tarih, bh.HareketTipi, 
                                                    bh.Kaynak, bh.Aciklama, 
                                                    bh.Tutar
                                                    From 
                                                    Bankalar b
                                                    Inner Join
                                                    BankaHareketleri bh
                                                    On
                                                    b.BankaID=bh.BankaID
                                                    Inner Join Cari c
                                                    On
                                                    c.CariID=bh.CariID
                                                    WHERE bh.Kaynak = @odemeturu", baglanti);
                    kmt.Parameters.AddWithValue("@odemeturu", comboOdemeTuru.Text);

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
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
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
            comboOdemeTuru.SelectedIndex = -1;
            checkBoxTumKayitlar.Checked = false;
            Date1.Value = DateTime.Now;
            Date2.Value = DateTime.Now;
            HesaplaGelirGider();

        }

        private void Date1_ValueChanged(object sender, EventArgs e)
        {
            IkiTarihArasiRapor();
            HesaplaGelirGider();
        }

        private void Date2_ValueChanged(object sender, EventArgs e)
        {
            IkiTarihArasiRapor();
            HesaplaGelirGider();
        }

        private void FrmBankaHareket_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
