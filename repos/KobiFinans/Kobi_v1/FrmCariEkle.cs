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
    public partial class FrmCariEkle : Form
    {
        public FrmCariEkle()
        {
            InitializeComponent();
            Listele();
            cariTurListele();
            btndisable();
            textDisable();

        }
        static string connectionString = ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);

        string sorguEkle = "INSERT INTO Cari (CariAdi, Telefon, Email, Adres, VergiNo, Borc, Alacak,CariTuru)  VALUES (@CariAdi, @Telefon, @Email, @Adres, @VergiNo, @Borc, @Alacak,@CariTuru)";
        string sorguGuncelle = "UPDATE Cari SET CariAdi=@CariAdi, Telefon=@Telefon, Email=@Email, Adres=@Adres, VergiNo=@VergiNo, Borc=@Borc, Alacak=@Alacak, CariTuru=@CariTuru WHERE CariID=@CariId";
        string sorguSil = "DELETE FROM Cari WHERE CariID=@CariId";
        string sorgucarituru = "SELECT AD  FROM CariTuru";
        string sorguListele = @"Select c.CariID,
                                    c.CariAdi,
		                            c.Telefon,
		                            c.Email,
		                            c.Adres,
		                            c.VergiNo,
		                            c.Borc,
		                            c.Alacak, 
		                            ct.Ad 
		                            From cari as c
		                            INNER JOIN
		                            CariTuru as ct
		                            ON
		                            c.cariTuru = ct.ID ";

        void cariTurListele()
        {
            try
            {
                SqlCommand kmt = new SqlCommand(sorgucarituru, baglanti);
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();

                SqlDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    comboBox1.Items.Add(oku["AD"].ToString());
                }
                oku.Close();
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
            SqlDataAdapter da = new SqlDataAdapter(sorguListele, baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Cari Adı";
            dataGridView1.Columns[2].HeaderText = "Telefon";
            dataGridView1.Columns[3].HeaderText = "E-Posta";
            dataGridView1.Columns[4].HeaderText = "Adres";
            dataGridView1.Columns[5].HeaderText = "Vergi No";
            dataGridView1.Columns[6].HeaderText = "Borç";
            dataGridView1.Columns[7].HeaderText = "Alacak";
            dataGridView1.Columns[8].HeaderText = "Cari Türü";


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
            comboBox1.SelectedIndex = -1;
            btndisable();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)// Geçerli bir Satır Seçilirse
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                txtCariAdi.Text = row.Cells["CariAdi"].Value.ToString();
                txtTelefon.Text = row.Cells["Telefon"].Value.ToString();
                txtEposta.Text = row.Cells["EMail"].Value.ToString();
                txtAdres.Text = row.Cells["Adres"].Value.ToString();
                txtVergiNo.Text = row.Cells["VergiNo"].Value.ToString();
                txtBorc.Text = row.Cells["Borc"].Value.ToString();
                txtAlacak.Text = row.Cells["Alacak"].Value.ToString();
                comboBox1.Text = row.Cells["Ad"].Value.ToString();

                btnenable();
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
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
                int cariTuru = 0;
                if (comboBox1.Text == "Müşteri")
                    cariTuru = 1;
                else if (comboBox1.Text == "Firma")
                    cariTuru = 2;
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
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
                kmt.Parameters.AddWithValue("@CariTuru", cariTuru);
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
                int cariTuru = 0;
                if (comboBox1.Text == "Müşteri")
                    cariTuru = 1;
                else if (comboBox1.Text == "Firma")
                    cariTuru = 2;
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
                kmt.Parameters.AddWithValue("@CariTuru", cariTuru);
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
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Silinecek Cariyi Seçiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DialogResult sonuc = MessageBox.Show("Cari Kaydı Silinsin mi?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (sonuc == DialogResult.Yes)
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
        void btnenable()
        {
            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;
            btnListele.Enabled = true;
            btnTemizle.Enabled = true;
        }
        void btndisable()
        {
            btnYeniKayit.Enabled = true;
            btnEkle.Enabled = false;
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
            btnListele.Enabled = false;
            btnTemizle.Enabled = false;
            btniptal.Enabled = false;
        }
        void btnGizle()
        {
            btnGuncelle.Visible = false;
            btnSil.Visible = false;
            btnListele.Visible = false;
            btnTemizle.Visible = false;
        }
        void btnGoster()
        {
            btnGuncelle.Visible = true;
            btnSil.Visible = true;
            btnListele.Visible = true;
            btnTemizle.Visible = true;
        }
        void textEnable()
        {
            txtCariAdi.Enabled = true;
            txtTelefon.Enabled = true;
            txtEposta.Enabled = true;
            txtAdres.Enabled = true;
            txtVergiNo.Enabled = true;
            txtBorc.Enabled = true;
            txtAlacak.Enabled = true;
            comboBox1.Enabled = true;
        }
        void textDisable()
        {
            txtCariAdi.Enabled = false;
            txtTelefon.Enabled = false;
            txtEposta.Enabled = false;
            txtAdres.Enabled = false;
            txtVergiNo.Enabled = false;
            txtBorc.Enabled = false;
            txtAlacak.Enabled = false;
            comboBox1.Enabled = false;
        }
        void textGizle()
        {
            txtCariAdi.Visible = false;
            txtTelefon.Visible = false;
            txtEposta.Visible = false;
            txtAdres.Visible = false;
            txtVergiNo.Visible = false;
            txtBorc.Visible = false;
            txtAlacak.Visible = false;
            comboBox1.Visible = false;
        }
        void textGoster()
        {
            txtCariAdi.Visible = true;
            txtTelefon.Visible = true;
            txtEposta.Visible = true;
            txtAdres.Visible = true;
            txtVergiNo.Visible = true;
            txtBorc.Visible = true;
            txtAlacak.Visible = true;
            comboBox1.Visible = true;
        }

        private void btnYeniKayit_Click(object sender, EventArgs e)
        {
            temizle();
            textEnable();
            btnYeniKayit.Enabled = false;
            btniptal.Enabled = true;
            btnEkle.Enabled = true;
            
        }

        private void btniptal_Click(object sender, EventArgs e)
        {
            temizle();
            textDisable();
            btndisable();
        }
    }
}

