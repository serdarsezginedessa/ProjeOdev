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

        private void KategoriEkle()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into UrunKategori(KategoriAdi,Aciklama,Durum) values(@p1,@p2,@p3)", baglanti);
                komut.Parameters.AddWithValue("@p1", txtStkategoriAd.Text);
                komut.Parameters.AddWithValue("@p2", txtStKategoriAciklama.Text);
                if (comboBoxDurum.Text == "Aktif")
                {
                    komut.Parameters.AddWithValue("@p3", 1);
                }
                else
                {
                    komut.Parameters.AddWithValue("@p3", 0);
                }
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kategori Eklendi");
                Listele();
                BtnLoad();
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
        private void KategoriGuncelle()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                SqlCommand komut = new SqlCommand("update UrunKategori set KategoriAdi=@p1,Aciklama=@p2,Durum=@p3 where KategoriID=@p4", baglanti);
                komut.Parameters.AddWithValue("@p1", txtStkategoriAd.Text);
                komut.Parameters.AddWithValue("@p2", txtStKategoriAciklama.Text);
                if (comboBoxDurum.Text == "Aktif")
                {
                    komut.Parameters.AddWithValue("@p3", 1);
                }
                else
                {
                    komut.Parameters.AddWithValue("@p3", 0);
                }
                komut.Parameters.AddWithValue("@p4", txtstKategoriNo.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kategori Güncellendi");
                Listele();
                BtnLoad();
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
        private void KategoriSil()
        {
            try
            {
                if (MessageBox.Show("Silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from UrunKategori where KategoriID=@p1", baglanti);
                komut.Parameters.AddWithValue("@p1", txtstKategoriNo.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kategori Silindi");
                Listele();
                BtnLoad();
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
        private void BtnLoad()
        {
            btnYeni.Enabled = true;
            btniptal.Enabled = false;
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
            btnEkle.Enabled = false;
            btnKapat.Enabled = true;
            txtstKategoriNo.Text = "";
            txtStkategoriAd.Text = "";
            txtStKategoriAciklama.Text = "";
            comboBoxDurum.Text = "";
            txtstKategoriNo.Enabled = false;
            txtStkategoriAd.Enabled = false;
            txtStKategoriAciklama.Enabled = false;
            dataGridView1.Enabled = true;

            comboBoxDurum.Enabled = false;
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
            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;
            btnEkle.Enabled = false;
            btnYeni.Enabled = false;
            btniptal.Enabled = true;
            
            txtStkategoriAd.Enabled = true;
            txtStKategoriAciklama.Enabled = true;
            comboBoxDurum.Enabled = true;
            
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            BtnLoad();
            btnEkle.Enabled = true;
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
            btnYeni.Enabled = false;
            btniptal.Enabled = true;
            txtstKategoriNo.Enabled = false;
            txtStkategoriAd.Enabled = true;
            txtStKategoriAciklama.Enabled = true;
            comboBoxDurum.Enabled = true;
            dataGridView1.Enabled = false;
        }

        private void btniptal_Click(object sender, EventArgs e)
        {
            BtnLoad();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            KategoriEkle();
            dataGridView1.Enabled = true;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            KategoriGuncelle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            KategoriSil();
        }
    }
}
