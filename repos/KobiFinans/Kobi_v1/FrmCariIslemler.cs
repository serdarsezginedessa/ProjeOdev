using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kobi_v1
{
    public partial class FrmCariIslemler : Form
    {
        public FrmCariIslemler()
        {
            InitializeComponent();
        }
        public string cariad
        {
            get { return label13.Text; }
            set { label13.Text = value; }
        }
        public string adres

        {
            set { label12.Text = value; }
        }
        
        public string telefon
        {
            set { label9.Text = value; }
        }
        static string laptopConStr = "Data Source=DESKTOP-NFG00P8\\SQLEXPRESS;Initial Catalog=KobiFinans;Integrated Security=True";
        static string dukkanConStr = "Data Source=EDESSASERDAR\\SQLEXPRESS;Initial Catalog=KobiFinans;Integrated Security=True";
        SqlConnection baglanti = new SqlConnection(laptopConStr);
        public void SetCariInfolabel(string cariBilgi)
        {
            label13.Text = cariBilgi; // Seçilen cariyi label'a yaz

            // Cari ID'yi güncelle
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                string sorgu = "SELECT CariID FROM cari WHERE cariadi = @cadi";
                SqlCommand kmt = new SqlCommand(sorgu, baglanti);
                kmt.Parameters.Add("@cadi", SqlDbType.NVarChar, 100).Value = cariBilgi;

                SqlDataReader dr = kmt.ExecuteReader();
                if (dr.Read())
                {
                    cariID = Convert.ToInt32(dr["CariID"]);
                    MessageBox.Show("Yeni Seçilen Cari ID: " + cariID);
                }
                dr.Close();
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


        private void btnCariListe_Click(object sender, EventArgs e)
        {
            FrmCariListele frmCariListele = new FrmCariListele();
            frmCariListele.Owner = this;
            frmCariListele.ShowDialog();
            if (!string.IsNullOrEmpty(label13.Text))
            {
                SetCariInfolabel(label13.Text); // Yeni cari bilgilerini getir
            }
        }
        public void SetCariInfo(string cariBilgi)
        {
            label13.Text = cariBilgi; // Bilgiyi label'a yazıyoruz
        }


        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.SelectAll();
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.SelectAll();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        
        
        int cariID;
        void temizle()
        {
            textBox2.Clear();
            textBox3.Clear();
            foreach (RadioButton rb in groupBox1.Controls.OfType<RadioButton>())
            {
                rb.Checked = false;
            }
        }
        void kaydet()
        {
            try
            {
                if (cariID == 0)
                {
                    MessageBox.Show("Lütfen bir cari seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                baglanti.Open();
                string insertSorgu = "INSERT INTO CariHareketleri (Tarih, CariID, Aciklama, Tutar, HareketTipi) " +
                                     "VALUES (@tarih, @cid, @aciklama, @tutar, @tip)";
                SqlCommand cmd = new SqlCommand(insertSorgu, baglanti);

                cmd.Parameters.AddWithValue("@tarih", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@cid", cariID);  // Güncellenmiş cariID kullanılıyor
                cmd.Parameters.AddWithValue("@aciklama", textBox2.Text);
                cmd.Parameters.AddWithValue("@tutar", Convert.ToDecimal(textBox3.Text));

                foreach (RadioButton rb in groupBox1.Controls.OfType<RadioButton>())
                {
                    if (rb.Checked)
                    {
                        cmd.Parameters.AddWithValue("@tip", rb.Text);
                        break;
                    }
                }

                cmd.ExecuteNonQuery();
                MessageBox.Show("Kayıt Başarılı");
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
        void eskikaydet()
        {
            try
            {

                baglanti.Open();
                string insertSorgu = "Insert into CariHareketleri (Tarih,CariID, Aciklama, Tutar, HareketTipi) values (@tarih, @cid,@aciklama, @tutar, @tip)";
                SqlCommand cmd = new SqlCommand(insertSorgu, baglanti);

                cmd.Parameters.AddWithValue("@tarih", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@cid", cariID);
                cmd.Parameters.AddWithValue("@aciklama", textBox2.Text);
                cmd.Parameters.AddWithValue("@tutar", Convert.ToDecimal(textBox3.Text));
                foreach (RadioButton rb in groupBox1.Controls.OfType<RadioButton>())
                {
                    if (rb.Checked)
                    {
                        string value = rb.Text; // Seçili radiobutton'un metni
                        MessageBox.Show("Seçili değer: " + value);
                        cmd.Parameters.AddWithValue("@tip", value);
                        break;
                    }
                }
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kayıt Başarılı");

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
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            kaydet();
            temizle();
        }
        void eskiload()
        {
            MessageBox.Show("gelen cari adı: " + cariad);
            MessageBox.Show("Gelen Id: " + cariID);
            string sorgu = @"SELECT
                                c.CariID
                            FROM 
                                cari AS c
                            INNER JOIN 
                                carihareketleri AS ch
                            ON 
                                c.CariID = ch.CariID
                            WHERE 
                                c.cariadi = @cadi";
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                SqlCommand kmt = new SqlCommand(sorgu, baglanti);
                kmt.Parameters.Add("@cadi", SqlDbType.NVarChar, 100).Value = cariad;
                //kmt.Parameters.AddWithValue("@cadi", cariad);
                SqlDataReader dr = kmt.ExecuteReader();


                if (dr.Read())
                {
                    cariID = Convert.ToInt32(dr["CariID"].ToString());
                    MessageBox.Show("2 gelen id: " + cariID);
                }
                MessageBox.Show("gelen id Kontrol et: " + cariID);
                dr.Close();

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
        void load()
        {
            
            

            // Doğrudan `cari` tablosundan `CariID` alıyoruz
            string sorgu = @"SELECT c.CariID FROM cari AS c WHERE c.cariadi = @cadi";

            try
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();

                using (SqlCommand kmt = new SqlCommand(sorgu, baglanti))
                {
                    kmt.Parameters.Add("@cadi", SqlDbType.NVarChar, 100).Value = cariad;

                    using (SqlDataReader dr = kmt.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            cariID = dr.GetInt32(0); // Doğrudan `int` olarak alıyoruz.
                            MessageBox.Show("Gelen Cari ID: " + cariID);
                        }
                        else
                        {
                            MessageBox.Show("Bu isme sahip cari bulunamadı.");
                            cariID = 0; // Eğer kayıt yoksa sıfır olarak ayarla
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("SQL Hatası: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Genel Hata: " + ex.Message);
            }
            finally
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
            }
        }

        
        private void FrmCariIslemler_Load(object sender, EventArgs e)
        {
            load();
            

        }
    }
}
