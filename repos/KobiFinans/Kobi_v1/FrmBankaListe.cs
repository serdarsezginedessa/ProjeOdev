using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kobi_v1
{
    public partial class FrmBankaListe : Form
    {
        public FrmBankaListe()
        {
            InitializeComponent();
            

        }
        static string connectionString = ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);       
        SqlCommand kmt;
        SqlDataAdapter da;
        DataTable dt;

        private void FrmBankaListe_Load(object sender, EventArgs e)
        {
            dtHeader();
            btnBaslangic();
            getir();
            textTemizle();
            txtID.Enabled = false; // ID alanını devre dışı bırakıyoruz.
        }

        private void dtHeader()
        {
            if (dataGridView1.Columns.Count == 0)

              {
                dataGridView1.Columns.Add("ID", "ID");
                dataGridView1.Columns.Add("BankaAd", "Banka Adı");
                dataGridView1.Columns.Add("BankaSube", "Şube Adı");
                dataGridView1.Columns.Add("HesapNo", "Hesap No");
                dataGridView1.Columns.Add("IBAN", "IBAN");
                dataGridView1.Columns.Add("EklenmeTarihi", "Eklenme Tarihi");
            }


        }
        private void getir()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    
                        //dataGridView1.Rows.Clear();
                   
                        SqlCommand kmt = new SqlCommand("select * From Bankalar", baglanti);

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
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }
        private void textTemizle()
        {
            txtID.Clear();
            txtBankaAdi.Clear();
            txtSubeAdi.Clear();
            txtHesapNo.Clear();
            txtIban.Clear();
            dateTimePicker1.Value = DateTime.Now;
        }

        private void btnBaslangic()
        {
            btnEkle.Enabled = true;
            btnGüncelle.Enabled = false;
            btnSil.Enabled = false;

        }
        private void btnGunSilAktif()
        {
            btnEkle.Enabled = false;
            btnGüncelle.Enabled = true;
            btnSil.Enabled = true;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                string bankaAd = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                string subeAd = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                string hesapNo = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                string iban = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                

            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {

            try
            {
                if ((string.IsNullOrEmpty(txtBankaAdi.Text)) || (string.IsNullOrEmpty(txtSubeAdi.Text)) || (string.IsNullOrEmpty(txtHesapNo.Text)))
                {
                    MessageBox.Show("Lütfen Gerekli Bilgileri Doldurun..");
                }
                else
                {
                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                        kmt = new SqlCommand("Insert Into Bankalar(BankaAd, BankaSube, HesapNo, Iban, EklenmeTarihi) Values(@BankaAd, @SubeAd, @HesapNo, @Iban, @EklenmeTarihi)", baglanti);
                        kmt.Parameters.AddWithValue("@BankaAd", txtBankaAdi.Text);
                        kmt.Parameters.AddWithValue("@SubeAd", txtSubeAdi.Text);
                        kmt.Parameters.AddWithValue("@HesapNo", txtHesapNo.Text);
                        kmt.Parameters.AddWithValue("@Iban", txtIban.Text);
                        kmt.Parameters.AddWithValue("@EklenmeTarihi", dateTimePicker1.Value);
                        kmt.ExecuteNonQuery();
                        MessageBox.Show("Kayıt Eklendi");

                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            finally
            {
                baglanti.Close();
                getir();
                textTemizle();
            }
        }
    
                
        

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    kmt = new SqlCommand("Update Bankalar Set BankaAd=@BankaAd, BankaSube=@SubeAd, HesapNo=@HesapNo, Iban=@Iban, EklenmeTarihi=@EklenmeTarihi Where ID=@Id", baglanti);
                    kmt.Parameters.AddWithValue("@Id", txtID.Text);
                    kmt.Parameters.AddWithValue("@BankaAd", txtBankaAdi.Text);
                    kmt.Parameters.AddWithValue("@SubeAd", txtSubeAdi.Text);
                    kmt.Parameters.AddWithValue("@HesapNo", txtHesapNo.Text);
                    kmt.Parameters.AddWithValue("@Iban", txtIban.Text);
                    kmt.Parameters.AddWithValue("@EklenmeTarihi", dateTimePicker1.Value);
                    kmt.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Güncellendi");
                    
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            finally
            {
                baglanti.Close();
                getir();
                textTemizle();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    if (MessageBox.Show("Silmek istediğinize emin misiniz?", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        baglanti.Open();
                    }
                    else
                    {
                        return;
                    }
                    
                    kmt = new SqlCommand("Delete From Bankalar Where ID=@Id", baglanti);
                    kmt.Parameters.AddWithValue("@Id", txtID.Text);
                    kmt.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Silindi");

                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            finally
            {
                baglanti.Close();
                getir();
                textTemizle();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex==-1 || e.ColumnIndex==-1)
            {
                textTemizle();
                btnBaslangic();
            }
            else
            {
                string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string bankaAd = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                string subeAd = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                string hesapNo = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                string iban = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                string eklenmeTarihi = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txtID.Text = id;
                txtBankaAdi.Text = bankaAd;
                txtSubeAdi.Text = subeAd;
                txtHesapNo.Text = hesapNo;
                txtIban.Text = iban;
                dateTimePicker1.Value = Convert.ToDateTime(eklenmeTarihi);
                btnGunSilAktif();
            }
        }
    }
}
