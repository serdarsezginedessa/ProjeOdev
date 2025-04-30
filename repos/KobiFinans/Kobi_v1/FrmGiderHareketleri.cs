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
    public partial class FrmGiderHareketleri : Form
    {
        public FrmGiderHareketleri()
        {
            InitializeComponent();
            //TumKayitlar();
        }
        private static string connectionString = ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);

        private void FrmGiderHareketleri_Load(object sender, EventArgs e)
        {
            comboGiderTuru.SelectedIndexChanged += comboGiderTuru_SelectedIndexChanged;
            comboBoxNakit.SelectedIndexChanged += comboBoxNakit_SelectedIndexChanged;

            
            KasalariGetir();
            GiderTuruGetir();
            BugunListele();
            
           
            
            
        }

        private void GiderTuruGetir()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                SqlDataAdapter da = new SqlDataAdapter("SELECT ID, Ad FROM GiderTipi", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // "Tümü" seçeneğini en üstte ekle
                DataRow tumu = dt.NewRow();
                tumu["ID"] = 0;              // 0 genelde "hepsi" için kullanılır
                tumu["Ad"] = "Tümü";
                dt.Rows.InsertAt(tumu, 0);   // İlk sıraya ekle

                comboGiderTuru.DataSource = dt;
                comboGiderTuru.DisplayMember = "Ad";
                comboGiderTuru.ValueMember = "ID";
                comboGiderTuru.Text = "";

                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gider Türü Yüklenirken Hata Oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void KasalariGetir()
        {
            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                baglanti.Open();
                SqlDataAdapter da = new SqlDataAdapter("Select KasaID, KasaAdi From Kasalar", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DataRow tumu = dt.NewRow();
                tumu["KasaID"] = 0;              // 0 genelde "hepsi" için kullanılır
                tumu["KasaAdi"] = "Tümü";
                dt.Rows.InsertAt(tumu, 0);

                comboBoxNakit.DataSource = dt;
                comboBoxNakit.DisplayMember = "KasaAdi";
                comboBoxNakit.ValueMember = "KasaID";
                comboBoxNakit.Text = "";
                baglanti.Close();
            }
        }
        private void KasaGetir()
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("select KasaAdi From Kasalar",baglanti);
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                comboBoxNakit.Items.Add(dataReader["KasaAdi"]);
            }
            dataReader.Close();
            baglanti.Close() ;
        }// ikinci yöntem yedek dursun

        private void TumKayitlar()
        {
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(@"select g.Tarih 'Tarih', g.GiderID as'Gider No',c.CariKod 'Cari Kod',ct.Ad 'Cari Türü'
                                            ,c.CariAdi 'Ad Soyad', k.KasaAdi 'Kasa'
                                            ,g.Aciklama 'Açıklama', g.Tutar, gt.Ad 'Gider Adı' from Gider g
                                              Left Join GiderTipi gt
                                              On g.Tipi= gt.ID
                                              Left Join Kasalar k
                                              On g.KasaID=k.KasaID
                                              Left Join Cari c
                                              On g.CariID=c.CariID
                                              Left Join CariTuru ct
                                              On c.CariTuru=ct.ID", baglanti);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }
        private void IkiTarihArasiListele()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();


                SqlCommand cmdTarihler = new SqlCommand(@"select g.Tarih, g.GiderID as'Gider No',c.CariKod 'Cari Kod',ct.Ad 'Cari Türü'
                                            ,c.CariAdi 'Ad Soyad', k.KasaAdi 'Kasa'
                                            ,g.Aciklama 'Açıklama', g.Tutar, gt.Ad 'Gider Adı' from Gider g
                                              Left Join GiderTipi gt
                                              On g.Tipi= gt.ID
                                              Left Join Kasalar k
                                              On g.KasaID=k.KasaID
                                              Left Join Cari c
                                              On g.CariID=c.CariID
                                              Left Join CariTuru ct
                                              On c.CariTuru=ct.ID

                                                where g.Tarih>=@tarih1 AND g.Tarih < DATEADD(DAY,1,@tarih2)", baglanti);
                cmdTarihler.Parameters.AddWithValue("@tarih1", SqlDbType.DateTime).Value = Date1.Value.Date;
                cmdTarihler.Parameters.AddWithValue("@tarih2", SqlDbType.DateTime).Value = Date2.Value.Date;

                SqlDataAdapter da = new SqlDataAdapter(cmdTarihler);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Giderler Listelenirken Bir Hata Oluştu.. "+ex, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void BugunListele()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();


                SqlCommand cmdBugun = new SqlCommand(@"select g.Tarih 'Tarih', g.GiderID as'Gider No',c.CariKod 'Cari Kod',ct.Ad 'Cari Türü'
                                            ,c.CariAdi 'Ad Soyad', k.KasaAdi 'Kasa'
                                            ,g.Aciklama 'Açıklama', g.Tutar, gt.Ad 'Gider Adı' from Gider g
                                              Left Join GiderTipi gt
                                              On g.Tipi= gt.ID
                                              Left Join Kasalar k
                                              On g.KasaID=k.KasaID
                                              Left Join Cari c
                                              On g.CariID=c.CariID
                                              Left Join CariTuru ct
                                              On c.CariTuru=ct.ID 
                                              WHERE g.Tarih >= @tarih AND g.Tarih < DATEADD(DAY, 1, @tarih) ", baglanti);
                cmdBugun.Parameters.AddWithValue("@tarih", Date1.Value.Date);
                SqlDataAdapter da = new SqlDataAdapter(cmdBugun);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Giderler Listelenirken Bir Hata Oluştu.. " + ex.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglanti.Close();
            }
        }
        private void GiderNoListele()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();


                SqlCommand cmdBugun = new SqlCommand(@"select g.Tarih 'Tarih', g.GiderID as'Gider No',c.CariKod 'Cari Kod',ct.Ad 'Cari Türü'
                                            ,c.CariAdi 'Ad Soyad', k.KasaAdi 'Kasa'
                                            ,g.Aciklama 'Açıklama', g.Tutar, gt.Ad 'Gider Adı' from Gider g
                                              Left Join GiderTipi gt
                                              On g.Tipi= gt.ID
                                              Left Join Kasalar k
                                              On g.KasaID=k.KasaID
                                              Left Join Cari c
                                              On g.CariID=c.CariID
                                              Left Join CariTuru ct
                                              On c.CariTuru=ct.ID 
                                              WHERE g.GiderID LIKE @giderno ", baglanti);
                cmdBugun.Parameters.AddWithValue("@giderno", '%'+txtGiderNo.Text+'%');

                SqlDataAdapter da = new SqlDataAdapter(cmdBugun);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Giderler Listelenirken Bir Hata Oluştu.. " + ex.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void GiderTurListele()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                int giderID;
                SqlCommand cmd;
                if (comboGiderTuru.SelectedValue.ToString() != "0")

                {
                    if (comboGiderTuru.SelectedItem is DataRowView drv)
                    {
                        giderID = Convert.ToInt32(drv["ID"]);
                        // Filtrele
                        cmd = new SqlCommand(@"SELECT g.Tarih 'Tarih', g.GiderID as 'Gider No', c.CariKod 'Cari Kod', ct.Ad 'Cari Türü',
                                          c.CariAdi 'Ad Soyad', k.KasaAdi 'Kasa', g.Aciklama 'Açıklama',
                                          g.Tutar, gt.Ad 'Gider Adı'
                                   FROM Gider g
                                   LEFT JOIN GiderTipi gt ON g.Tipi = gt.ID
                                   LEFT JOIN Kasalar k ON g.KasaID = k.KasaID
                                   LEFT JOIN Cari c ON g.CariID = c.CariID
                                   LEFT JOIN CariTuru ct ON c.CariTuru = ct.ID
                                   WHERE gt.ID = @giderturu", baglanti);
                        cmd.Parameters.AddWithValue("@giderturu", giderID);

                    }
                    else
                    {
                        MessageBox.Show("Lütfen geçerli bir gider türü seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                }
                else
                {



                    cmd = new SqlCommand(@"SELECT g.Tarih 'Tarih', g.GiderID as 'Gider No', c.CariKod 'Cari Kod', ct.Ad 'Cari Türü',
                                                  c.CariAdi 'Ad Soyad', k.KasaAdi 'Kasa', g.Aciklama 'Açıklama',
                                                  g.Tutar, gt.Ad 'Gider Adı'
                                           FROM Gider g
                                           LEFT JOIN GiderTipi gt ON g.Tipi = gt.ID
                                           LEFT JOIN Kasalar k ON g.KasaID = k.KasaID
                                           LEFT JOIN Cari c ON g.CariID = c.CariID
                                           LEFT JOIN CariTuru ct ON c.CariTuru = ct.ID", baglanti);


                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Giderler Listelenirken Bir Hata Oluştu:\n" + ex.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (baglanti.State == ConnectionState.Open) baglanti.Close();
            }
        }

        private void KasaListele2()
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT g.Tarih 'Tarih', g.GiderID as 'Gider No', c.CariKod 'Cari Kod', ct.Ad 'Cari Türü',
                                          c.CariAdi 'Ad Soyad', k.KasaAdi 'Kasa', g.Aciklama 'Açıklama',
                                          g.Tutar, gt.Ad 'Gider Adı'
                                   FROM Gider g
                                   LEFT JOIN GiderTipi gt ON g.Tipi = gt.ID
                                   LEFT JOIN Kasalar k ON g.KasaID = k.KasaID
                                   LEFT JOIN Cari c ON g.CariID = c.CariID
                                   LEFT JOIN CariTuru ct ON c.CariTuru = ct.ID
                                   WHERE k.KasaAdi = @kasaAdi", baglanti);
            cmd.Parameters.AddWithValue("@kasaAdi",comboBoxNakit.SelectedItem.ToString());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
            baglanti.Close();
        }//ikinci yöntem yedek dursun
        
        private void KasaListele()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                int kasaID;
                SqlCommand cmd;
                if (comboBoxNakit.SelectedValue.ToString() != "0")

                {
                    if (comboBoxNakit.SelectedItem is DataRowView drv)
                    {
                        kasaID = Convert.ToInt32(drv["KasaID"]);
                        // Filtrele
                        cmd = new SqlCommand(@"SELECT g.Tarih 'Tarih', g.GiderID as 'Gider No', c.CariKod 'Cari Kod', ct.Ad 'Cari Türü',
                                          c.CariAdi 'Ad Soyad', k.KasaAdi 'Kasa', g.Aciklama 'Açıklama',
                                          g.Tutar, gt.Ad 'Gider Adı'
                                   FROM Gider g
                                   LEFT JOIN GiderTipi gt ON g.Tipi = gt.ID
                                   LEFT JOIN Kasalar k ON g.KasaID = k.KasaID
                                   LEFT JOIN Cari c ON g.CariID = c.CariID
                                   LEFT JOIN CariTuru ct ON c.CariTuru = ct.ID
                                   WHERE k.KasaID = @kasaID", baglanti);

                        cmd.Parameters.AddWithValue("@kasaID", kasaID);

                    }
                    else
                    {
                        MessageBox.Show("Lütfen geçerli bir gider türü seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    
                }
                else
                {



                    cmd = new SqlCommand(@"SELECT g.Tarih 'Tarih', g.GiderID as 'Gider No', c.CariKod 'Cari Kod', ct.Ad 'Cari Türü',
                                                  c.CariAdi 'Ad Soyad', k.KasaAdi 'Kasa', g.Aciklama 'Açıklama',
                                                  g.Tutar, gt.Ad 'Gider Adı'
                                           FROM Gider g
                                           LEFT JOIN GiderTipi gt ON g.Tipi = gt.ID
                                           LEFT JOIN Kasalar k ON g.KasaID = k.KasaID
                                           LEFT JOIN Cari c ON g.CariID = c.CariID
                                           LEFT JOIN CariTuru ct ON c.CariTuru = ct.ID", baglanti);


                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Giderler Listelenirken Bir Hata Oluştu:\n" + ex.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (baglanti.State == ConnectionState.Open) baglanti.Close();
            }
        }

        private void CariTurListele()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();


                SqlCommand cmdBugun = new SqlCommand(@"select g.Tarih 'Tarih', g.GiderID as'Gider No',c.CariKod 'Cari Kod',ct.Ad 'Cari Türü'
                                            ,c.CariAdi 'Ad Soyad', k.KasaAdi 'Kasa'
                                            ,g.Aciklama 'Açıklama', g.Tutar, gt.Ad 'Gider Adı' from Gider g
                                              Left Join GiderTipi gt
                                              On g.Tipi= gt.ID
                                              Left Join Kasalar k
                                              On g.KasaID=k.KasaID
                                              Left Join Cari c
                                              On g.CariID=c.CariID
                                              Left Join CariTuru ct
                                              On c.CariTuru=ct.ID 
                                              WHERE c.CariKod LIKE @caritur ", baglanti);
                cmdBugun.Parameters.AddWithValue("@caritur", '%' + txtCariTur.Text + '%');

                SqlDataAdapter da = new SqlDataAdapter(cmdBugun);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Giderler Listelenirken Bir Hata Oluştu.. " + ex.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglanti.Close();
            }
        }
        private void CariKodListele()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();


                SqlCommand cmdBugun = new SqlCommand(@"select g.Tarih 'Tarih', g.GiderID as'Gider No',c.CariKod 'Cari Kod',ct.Ad 'Cari Türü'
                                            ,c.CariAdi 'Ad Soyad', k.KasaAdi 'Kasa'
                                            ,g.Aciklama 'Açıklama', g.Tutar, gt.Ad 'Gider Adı' from Gider g
                                              Left Join GiderTipi gt
                                              On g.Tipi= gt.ID
                                              Left Join Kasalar k
                                              On g.KasaID=k.KasaID
                                              Left Join Cari c
                                              On g.CariID=c.CariID
                                              Left Join CariTuru ct
                                              On c.CariTuru=ct.ID 
                                              WHERE c.CariKod LIKE @carikod ", baglanti);
                cmdBugun.Parameters.AddWithValue("@carikod", '%' + txtCariKOD.Text + '%');

                SqlDataAdapter da = new SqlDataAdapter(cmdBugun);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Giderler Listelenirken Bir Hata Oluştu.. " + ex.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglanti.Close();
            }
        }
        private void AdsoyadListele()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();


                SqlCommand cmdBugun = new SqlCommand(@"select g.Tarih 'Tarih', g.GiderID as'Gider No',c.CariKod 'Cari Kod',ct.Ad 'Cari Türü'
                                            ,c.CariAdi 'Ad Soyad', k.KasaAdi 'Kasa'
                                            ,g.Aciklama 'Açıklama', g.Tutar, gt.Ad 'Gider Adı' from Gider g
                                              Left Join GiderTipi gt
                                              On g.Tipi= gt.ID
                                              Left Join Kasalar k
                                              On g.KasaID=k.KasaID
                                              Left Join Cari c
                                              On g.CariID=c.CariID
                                              Left Join CariTuru ct
                                              On c.CariTuru=ct.ID 
                                              WHERE c.CariAdi LIKE @cariad ", baglanti);
                cmdBugun.Parameters.AddWithValue("@cariad", '%' + txtCariAD.Text + '%');

                SqlDataAdapter da = new SqlDataAdapter(cmdBugun);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Giderler Listelenirken Bir Hata Oluştu.. " + ex.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglanti.Close();
            }
        }
        

    
        


        private void Date1_ValueChanged(object sender, EventArgs e)
        {
            IkiTarihArasiListele();
        }

        private void Date2_ValueChanged(object sender, EventArgs e)
        {
            IkiTarihArasiListele();
        }

        private void comboBoxNakit_SelectedIndexChanged(object sender, EventArgs e)
        {
            KasaListele();
        }

        private void comboGiderTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboGiderTuru.SelectedIndex != -1)
            {
                GiderTurListele();
            }
        }

        private void checkBoxTumKayitlar_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxTumKayitlar.Checked)
            {
                TumKayitlar();
            }
            else
            {
                BugunListele();
            }
        }

        private void btnSifirla_Click(object sender, EventArgs e)
        {
            txtCariAD.Clear();
            txtCariKOD.Clear();
            txtCariTur.Clear();
            txtGiderNo.Clear();
            comboGiderTuru.SelectedIndex = 0;
            comboBoxNakit.SelectedIndex = 0;
            checkBoxTumKayitlar.Checked = false;
            Date1.Value = DateTime.Now;
            Date2.Value = DateTime.Now;
            BugunListele();
        }


        private void txtGiderNo_TextChanged(object sender, EventArgs e)
        {
            GiderNoListele();
        }

        private void txtCariKOD_TextChanged(object sender, EventArgs e)
        {
            CariKodListele();
        }

        private void txtCariTur_TextChanged(object sender, EventArgs e)
        {
            CariTurListele();
        }

        private void txtCariAD_TextChanged(object sender, EventArgs e)
        {
            AdsoyadListele();
        }
    }
}
