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
    public partial class FrmKasa : Form
    {
        public FrmKasa()
        {
            InitializeComponent();
        }
        static string connectionString = ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);


        private void load()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                SqlCommand kmt = new SqlCommand(@"SELECT id 'Kasa No', KasaAdi as 'Kasa Adı',Aciklama 'Açıklama',
                                                                            Durum, Tarih  FROM Kasa", baglanti);
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

        private void txtTemizle()
        {
            txtID.Clear();
            txtKasaAdi.Clear();
            txtAciklama.Clear();
            checkBox1.Checked = true;
            dateTimePicker1.Value = DateTime.Now;
        }

        private void btnBaslangic()
        {
            btnEkle.Enabled = true;
            btnGüncelle.Enabled = false;
            btnSil.Enabled = false;
        }


        private void FrmKasa_Load(object sender, EventArgs e)
        {
            btnBaslangic();
            load();
            checkBox1_CheckedChanged(sender, e);
            txtID.Enabled = false; // ID alanını devre dışı bırakıyoruz.
            txtKasaAdi.Focus();
            txtTemizle();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                checkBox1.Text = "Pasif";
            }
            else
            {
                checkBox1.Text = "Aktif";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
            {
                txtTemizle();
                btnBaslangic();
            }
            else
            {
                txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtKasaAdi.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtAciklama.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                checkBox1.Checked = (bool)dataGridView1.Rows[e.RowIndex].Cells[3].Value;
                dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                btnEkle.Enabled = false;
                btnGüncelle.Enabled = true;
                btnSil.Enabled = true;
                txtKasaAdi.Focus();
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtKasaAdi.Text))
                {
                    MessageBox.Show("Lütfen Kasa Adını Giriniz");
                    return;
                }
                else
                {
                    if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                    SqlCommand kmt = new SqlCommand(@"INSERT INTO Kasa (KasaAdi, Aciklama, Durum, Tarih) 
                                                        VALUES (@KasaAdi, @Aciklama, @Durum, @Tarih)", baglanti);
                    kmt.Parameters.AddWithValue("@KasaAdi", txtKasaAdi.Text);
                    kmt.Parameters.AddWithValue("@Aciklama", txtAciklama.Text);
                    kmt.Parameters.AddWithValue("@Durum", checkBox1.Checked);
                    kmt.Parameters.AddWithValue("@Tarih", dateTimePicker1.Value);
                    kmt.ExecuteNonQuery();
                    MessageBox.Show("Kasa Eklendi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
                load();
                txtTemizle();
                btnBaslangic();
            }

        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                {
                    SqlCommand kmt = new SqlCommand(@"UPDATE Kasa SET KasaAdi=@KasaAdi, Aciklama=@Aciklama, Durum=@Durum, Tarih=@Tarih WHERE id=@id", baglanti);
                    kmt.Parameters.AddWithValue("@KasaAdi", txtKasaAdi.Text);
                    kmt.Parameters.AddWithValue("@Aciklama", txtAciklama.Text);
                    kmt.Parameters.AddWithValue("@Durum", checkBox1.Checked);
                    kmt.Parameters.AddWithValue("@Tarih", dateTimePicker1.Value);
                    kmt.Parameters.AddWithValue("@id", txtID.Text);
                    kmt.ExecuteNonQuery();
                    MessageBox.Show("Kasa Güncellendi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
                load();
                txtTemizle();
                btnBaslangic();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                {
                    if(string.IsNullOrEmpty(txtID.Text))
                    {
                        MessageBox.Show("Lütfen Silinecek Kasa Seçiniz");
                        return;
                    }
                    else
                    {
                        if (MessageBox.Show("Silmek istediğinize emin misiniz?", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            // Silme işlemi
                            SqlCommand kmt = new SqlCommand(@"DELETE FROM Kasa WHERE id=@id", baglanti);
                            kmt.Parameters.AddWithValue("@id", txtID.Text);
                            kmt.ExecuteNonQuery();
                            MessageBox.Show("Kasa Silindi");
                        }
                        else
                        {
                            return;
                        }
                        
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
                load();
                txtTemizle();
                btnBaslangic();
            }
        }
    }
}
