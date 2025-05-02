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
    public partial class FrmCariTur : Form
    {
        public FrmCariTur()
        {
            InitializeComponent();
        }
        static string connectionString = ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);



        private void FrmCariTur_Load(object sender, EventArgs e)
        {
            load();
            btnFormLoad();
            txtAd.Focus();
            txtstKategoriNo.ReadOnly = true;
            txtstKategoriNo.Enabled = false;
            txtKod.Enabled = false;
            txtKod.ReadOnly = true;

        }

        private void sil()
        {
            if (string.IsNullOrEmpty(txtAd.Text.Trim()))
            {
                MessageBox.Show("Lütfen Cari Türü Adını Giriniz");
                txtAd.Focus();
                return;
            }
            
            DialogResult result = MessageBox.Show("Seçili Cari Türü Silmek İstediğinize Emin Misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                return;
            }

            try
            {
                SqlCommand kmt = new SqlCommand("DELETE FROM CariTuru WHERE ID = @id", baglanti);

                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                kmt.Parameters.AddWithValue("@id", Convert.ToInt32(txtstKategoriNo.Text));
                kmt.ExecuteNonQuery();
                load();
                MessageBox.Show("Cari Türü Silindi");
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
        private void guncelle()
        {
            if (string.IsNullOrEmpty(txtAd.Text.Trim()))
            {
                MessageBox.Show("Lütfen Cari Türü Adını Giriniz");
                txtAd.Focus();
                
            }
            string tur = txtAd.Text.Trim();
            if (string.IsNullOrEmpty(tur)) return;

            string prefix = tur.Length >= 3 ? tur.Substring(0, 3).ToUpper() : tur.ToUpper();//ilk 3 harfi al ve buyuk harf yap

            //prefix veritabanında varmı kontrol ediliyor.
            try
            {
                SqlCommand kmt = new SqlCommand("UPDATE CariTuru SET Ad=@ad , Prefix = @tur WHERE ID = @id", baglanti);
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                kmt.Parameters.AddWithValue("@id", Convert.ToInt32(txtstKategoriNo.Text));
                kmt.Parameters.AddWithValue("@ad", txtAd.Text);
                kmt.Parameters.AddWithValue("@tur", prefix);


                kmt.ExecuteNonQuery();
                MessageBox.Show("Cari Türü  Başarıyla Güncellendi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
                load();

            }


        }
        private void load()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                SqlCommand kmt = new SqlCommand("SELECT ID as 'No', Ad as 'Ad', Prefix as 'Kod' FROM CariTuru", baglanti);
                SqlDataAdapter da = new SqlDataAdapter(kmt);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
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
        private void ekle()
        {
            if (string.IsNullOrEmpty(txtAd.Text.Trim()))
            {
                MessageBox.Show("Lütfen Cari Türü Adını Giriniz");
                txtAd.Focus();
                return;
            }
            string tur = txtAd.Text.Trim();
            if (string.IsNullOrEmpty(tur)) return;

            string prefix = tur.Length >= 3 ? tur.Substring(0, 3).ToUpper() : tur.ToUpper();//ilk 3 harfi al ve buyuk harf yap

            //prefix veritabanında varmı kontrol ediliyor.



            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                string sorguprefix = "select count(*) from CariTuru where Ad='" + prefix + "'";
                SqlCommand kmt1 = new SqlCommand(sorguprefix, baglanti);
                kmt1.Parameters.AddWithValue("@prefix", prefix);

                int prefixCount = (int)kmt1.ExecuteScalar();
                if (prefixCount > 0)
                {
                    prefix += prefixCount.ToString();
                }

                SqlCommand kmt = new SqlCommand("INSERT INTO CariTuru (Ad,Prefix) VALUES (@ad,@prefix)", baglanti);
                kmt.Parameters.AddWithValue("@ad", tur);
                kmt.Parameters.AddWithValue("@prefix", prefix);

                kmt.ExecuteNonQuery();
                MessageBox.Show("Cari Türü  Başarıyla Eklendi");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
                load();

            }
        }
        private void textClear()
        {
            txtstKategoriNo.Clear();
            txtAd.Clear();
            txtKod.Clear();
        }
        private void btnYeniDurum()
        {
            btnYeni.Enabled = false;
            btniptal.Enabled = true;
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
            btnEkle.Enabled = true;

        }
        private void btnFormLoad()
        {
            btnYeni.Enabled = true;
            btniptal.Enabled = false;
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
            btnEkle.Enabled = false;

        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            ekle();
            btnFormLoad();
            dataGridView1.Enabled = true;
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand kmt = new SqlCommand("DELETE FROM CariTuru WHERE Ad = @ad", baglanti);
            kmt.Parameters.AddWithValue("@ad", dataGridView1.CurrentRow.Cells[0].Value.ToString());
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                kmt.ExecuteNonQuery();
                load();
                MessageBox.Show("Cari Türü Silindi");

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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int satirIndex = e.RowIndex;
            if (satirIndex >= 0)
            {
                btnGuncelle.Enabled = true;
                btniptal.Enabled = true;
                btnSil.Enabled = true;
                btnYeni.Enabled = false;
                DataGridViewRow satir = dataGridView1.Rows[satirIndex];
                txtstKategoriNo.Text = satir.Cells["No"].Value.ToString();
                txtAd.Text = satir.Cells["Ad"].Value.ToString();
                txtKod.Text = satir.Cells["Kod"].Value.ToString();
                txtstKategoriNo.ReadOnly = true;
                txtKod.ReadOnly = true;
            }
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = false;
            textClear();
            btnYeniDurum();

        }

        private void btniptal_Click(object sender, EventArgs e)
        {
            btnFormLoad();
            dataGridView1.Enabled = true;
            textClear();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            guncelle();
            btnFormLoad();
            textClear();
            load();
        }

        private void btnSil_Click_1(object sender, EventArgs e)
        {
            sil();
            btnFormLoad();
            textClear();
            load();
        }
    }
}
