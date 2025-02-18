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
    public partial class FrmCariEkle : Form
    {
        public FrmCariEkle()
        {
            InitializeComponent();
            Listele();
        }
        static string laptopConStr = "Data Source=DESKTOP-NFG00P8\\SQLEXPRESS;Initial Catalog=KobiFinans;Integrated Security=True";
        static string dukkanConStr = "Data Source=EDESSASERDAR\\SQLEXPRESS;Initial Catalog=KobiFinans;Integrated Security=True";
        SqlConnection baglanti = new SqlConnection(dukkanConStr);
        string sorguEkle = "INSERT INTO Cari (CariAdi, Telefon, Email, Adres, VergiNo, Borc, Alacak)  VALUES (@CariAdi, @Telefon, @Email, @Adres, @VergiNo, @Borc, @Alacak)";
        string sorguGuncelle = "UPDATE Cari SET CariAdi=@CariAdi, Telefon=@Telefon, Email=@Email, Adres=@Adres, VergiNo=@VergiNo, Borc=@Borc, Alacak=@Alacak WHERE CariID=@CariId";
        string sorguSil = "DELETE FROM Cari WHERE CariID=@CariId";

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(txtCariAdi.Text))
                {
                    MessageBox.Show("Cari Adı Boş Bırakılamaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                    return;
                }
                if(!decimal.TryParse(txtBorc.Text, out _)||!decimal.TryParse(txtAlacak.Text,out _))
                {
                    MessageBox.Show("Borç ve Alacak Alanına Sayısal Değer Giriniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                SqlCommand kmt = new SqlCommand(sorguEkle, baglanti);
                kmt.Parameters.AddWithValue("@CariAdi", txtCariAdi.Text);
                kmt.Parameters.AddWithValue("@Telefon", txtTelefon.Text);
                kmt.Parameters.AddWithValue("@Email", txtEposta.Text);
                kmt.Parameters.AddWithValue("@Adres", txtAdres.Text);
                kmt.Parameters.AddWithValue("@VergiNo", txtVergiNo.Text);
                kmt.Parameters.AddWithValue("@Borc", Convert.ToDecimal(txtBorc.Text));
                kmt.Parameters.AddWithValue("@Alacak", Convert.ToDecimal(txtAlacak.Text));
                kmt.ExecuteNonQuery();
                MessageBox.Show("Cari Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglanti.Close();
            }
        }
        private void Listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Cari", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();

        }
        void temizle()
        {
            txtCariAdi.Clear();
            txtTelefon.Clear();
            txtEposta.Clear();
            txtAdres.Clear();
            txtVergiNo.Clear();
            txtBorc.Clear();
            txtAlacak.Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >=0)// Geçerli bir Satır Seçilirse
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txtCariAdi.Text = row.Cells["CariAdi"].Value.ToString();
                txtTelefon.Text = row.Cells["Telefon"].Value.ToString();
                txtEposta.Text = row.Cells["Email"].Value.ToString();
                txtAdres.Text = row.Cells["Adres"].Value.ToString();
                txtVergiNo.Text = row.Cells["VergiNo"].Value.ToString();
                txtBorc.Text = row.Cells["Borc"].Value.ToString();
                txtAlacak.Text = row.Cells["Alacak"].Value.ToString();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCariAdi.Text))
                {
                    MessageBox.Show("Cari Adı Boş Bırakılamaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!decimal.TryParse(txtBorc.Text, out _) || !decimal.TryParse(txtAlacak.Text, out _))
                {
                    MessageBox.Show("Borç ve Alacak Alanına Sayısal Değer Giriniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                SqlCommand kmt = new SqlCommand(sorguGuncelle, baglanti);
                kmt.Parameters.AddWithValue("@CariAdi", txtCariAdi.Text);
                kmt.Parameters.AddWithValue("@Telefon", txtTelefon.Text);
                kmt.Parameters.AddWithValue("@Email", txtEposta.Text);
                kmt.Parameters.AddWithValue("@Adres", txtAdres.Text);
                kmt.Parameters.AddWithValue("@VergiNo", txtVergiNo.Text);
                kmt.Parameters.AddWithValue("@Borc", Convert.ToDecimal(txtBorc.Text));
                kmt.Parameters.AddWithValue("@Alacak", Convert.ToDecimal(txtAlacak.Text));
                kmt.Parameters.AddWithValue("@CariId", dataGridView1.CurrentRow.Cells["CariID"].Value);
                kmt.ExecuteNonQuery();
                MessageBox.Show("Cari Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if(dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Silinecek Cariyi Seçiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DialogResult sonuc = MessageBox.Show("Cari Kaydı Silinsin mi?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if(sonuc == DialogResult.Yes) 
                {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();                                  
                    SqlCommand kmt = new SqlCommand(sorguSil, baglanti);
                    kmt.Parameters.AddWithValue("@CariId", dataGridView1.CurrentRow.Cells["CariID"].Value);                    
                    kmt.ExecuteNonQuery();

                    MessageBox.Show("Cari Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Listele();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }
    }
    
}

