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
    public partial class FrmCariListele : Form
    {
        

        public FrmCariListele()
        {
            InitializeComponent();
            
        }
        public Form CagrilanForm { get; set; }


        static string connectionString = ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);

        string sorguInnerJoin = @"Select 
                                    c.CariID,
                                    c.CariKod,
                                    c.CariAdi,
                                    ct.Ad,
                                    c.Yetkili,
		                            c.Telefon,
		                            c.Eposta,
		                            c.Adres,
                                    c.Sehir,
                                    c.Ulke,
                                    c.VergiDairesi,
		                            c.VergiNo,
                                    c.DogumTarihi,
                                    c.EvlilikTarihi,
                                    c.KayitTarihi,
                                    c.Durum,
                                    c.Aciklama,
                                    c.Resim
		                            From cari as c
		                            INNER JOIN
		                            CariTuru as ct
		                            ON
		                            c.cariTuru = ct.ID";
        string sorguCariAd = @"SELECT 
                c.CariID,
                c.CariKod,
                c.CariAdi,
                ct.Ad,
                c.Yetkili,
		        c.Telefon,
		        c.Eposta,
		        c.Adres,
                c.Sehir,
                c.Ulke,
                c.VergiDairesi,
		        c.VergiNo,
                c.DogumTarihi,
                c.EvlilikTarihi,
                c.KayitTarihi,
                c.Durum,
                c.Aciklama
		        From cari as c
		        INNER JOIN
		        CariTuru as ct
		        ON
		        c.cariTuru = ct.ID
				where c.cariAdi LIKE @cariAd";
        string sorguCariKod = @"SELECT 
                c.CariID,
                c.CariKod,
                c.CariAdi,
                ct.Ad,
                c.Yetkili,
		        c.Telefon,
		        c.Eposta,
		        c.Adres,
                c.Sehir,
                c.Ulke,
                c.VergiDairesi,
		        c.VergiNo,
                c.DogumTarihi,
                c.EvlilikTarihi,
                c.KayitTarihi,
                c.Durum,
                c.Aciklama
		        From cari as c
		        INNER JOIN
		        CariTuru as ct
		        ON
		        c.cariTuru = ct.ID
				where c.cariKod LIKE @cariKod";
        string sorguCariTur = @"SELECT 
                c.CariID,
                c.CariKod,
                c.CariAdi,
                ct.Ad,
                c.Yetkili,
		        c.Telefon,
		        c.Eposta,
		        c.Adres,
                c.Sehir,
                c.Ulke,
                c.VergiDairesi,
		        c.VergiNo,
                c.DogumTarihi,
                c.EvlilikTarihi,
                c.KayitTarihi,
                c.Durum,
                c.Aciklama
		        From cari as c
		        INNER JOIN
		        CariTuru as ct
		        ON
		        c.cariTuru = ct.ID
				where ct.Ad LIKE @cariTurAd";
        string sorguCariYetkili = @"SELECT 
                c.CariID,
                c.CariKod,
                c.CariAdi,
                ct.Ad,
                c.Yetkili,
                c.Telefon,
                c.Eposta,
                c.Adres,
                c.Sehir,
                c.Ulke,
                c.VergiDairesi,
                c.VergiNo,
                c.DogumTarihi,
                c.EvlilikTarihi,
                c.KayitTarihi,
                c.Durum,
                c.Aciklama
                From cari as c
                INNER JOIN
                CariTuru as ct
                ON
                c.cariTuru = ct.ID
                Where 
                c.Yetkili LIKE @yetkili";
        string sorguTelefon = @"Select 
                                    c.CariID,
                                    c.CariKod,
                                    c.CariAdi,
                                    ct.Ad,
                                    c.Yetkili,
		                            c.Telefon,
		                            c.Eposta,
		                            c.Adres,
                                    c.Sehir,
                                    c.Ulke,
                                    c.VergiDairesi,
		                            c.VergiNo,
                                    c.DogumTarihi,
                                    c.EvlilikTarihi,
                                    c.KayitTarihi,
                                    c.Durum,
                                    c.Aciklama
		                            From cari as c
		                            INNER JOIN
		                            CariTuru as ct
		                            ON
		                            c.cariTuru = ct.ID
                                    where c.Telefon LIKE @telefon";
        string sorguSehir = @"Select 
                                    c.CariID,
                                    c.CariKod,
                                    c.CariAdi,
                                    ct.Ad,
                                    c.Yetkili,
                                    c.Telefon,
                                    c.Eposta,
                                    c.Adres,
                                    c.Sehir,
                                    c.Ulke,
                                    c.VergiDairesi,
                                    c.VergiNo,
                                    c.DogumTarihi,
                                    c.EvlilikTarihi,
                                    c.KayitTarihi,
                                    c.Durum,
                                    c.Aciklama
                                    From cari as c
                                    INNER JOIN
                                    CariTuru as ct
                                    ON
                                    c.cariTuru = ct.ID
                                    where c.Sehir LIKE @sehir";
        string sorguDtarihi = @"Select
                                    c.CariID,
                                    c.CariKod,
                                    c.CariAdi,
                                    ct.Ad,
                                    c.Yetkili,
                                    c.Telefon,
                                    c.Eposta,
                                    c.Adres,
                                    c.Sehir,
                                    c.Ulke,
                                    c.VergiDairesi,
                                    c.VergiNo,
                                    c.DogumTarihi,
                                    c.EvlilikTarihi,
                                    c.KayitTarihi,
                                    c.Durum,
                                    c.Aciklama
                                    From cari as c
                                    INNER JOIN
                                    CariTuru as ct
                                    ON
                                    c.cariTuru = ct.ID
                                    where c.DogumTarihi = @dtarih";
        string sorguEtarihi = @"Select
                                    c.CariID,
                                    c.CariKod,
                                    c.CariAdi,
                                    ct.Ad,
                                    c.Yetkili,
                                    c.Telefon,
                                    c.Eposta,
                                    c.Adres,
                                    c.Sehir,
                                    c.Ulke,
                                    c.VergiDairesi,
                                    c.VergiNo,
                                    c.DogumTarihi,
                                    c.EvlilikTarihi,
                                    c.KayitTarihi,
                                    c.Durum,
                                    c.Aciklama
                                    From cari as c
                                    INNER JOIN
                                    CariTuru as ct
                                    ON
                                    c.cariTuru = ct.ID
                                    where c.EvlilikTarihi = @etarih";
        string sorguKtarihi = @"Select
                                    c.CariID,
                                    c.CariKod,
                                    c.CariAdi,
                                    ct.Ad,
                                    c.Yetkili,
                                    c.Telefon,
                                    c.Eposta,
                                    c.Adres,
                                    c.Sehir,
                                    c.Ulke,
                                    c.VergiDairesi,
                                    c.VergiNo,
                                    c.DogumTarihi,
                                    c.EvlilikTarihi,
                                    c.KayitTarihi,
                                    c.Durum,
                                    c.Aciklama
                                    From cari as c
                                    INNER JOIN
                                    CariTuru as ct
                                    ON
                                    c.cariTuru = ct.ID
                                    
                                    where CAST (c.KayitTarihi AS DATE) = @ktarih";

        string sorguDurum = @"Select
                                    c.CariID,
                                    c.CariKod,
                                    c.CariAdi,
                                    ct.Ad,
                                    c.Yetkili,
                                    c.Telefon,
                                    c.Eposta,
                                    c.Adres,
                                    c.Sehir,
                                    c.Ulke,
                                    c.VergiDairesi,
                                    c.VergiNo,
                                    c.DogumTarihi,
                                    c.EvlilikTarihi,
                                    c.KayitTarihi,
                                    c.Durum,
                                    c.Aciklama
                                    From cari as c
                                    INNER JOIN
                                    CariTuru as ct
                                    ON
                                    c.cariTuru = ct.ID
                                    where c.Durum = @durum";




        private void dtHeader() // datagridview1 başlıkları ekleniyor..
        {
            if (dataGridView1.Columns.Count == 0)
            {
                
               
                dataGridView1.Columns.Add("c.CariID", "Cari No");
                dataGridView1.Columns.Add("c.CariKod", "Cari Kodu");
                dataGridView1.Columns.Add("c.CariAdi", "Cari Adı");
                dataGridView1.Columns.Add("ct.Ad", "Cari Turü");
                dataGridView1.Columns.Add("c.Yetkili", "Yetkili");
                dataGridView1.Columns.Add("c.Telefon", "Telefon");
                dataGridView1.Columns.Add("c.EPosta", "E-Posta");
                dataGridView1.Columns.Add("c.Adres", "Adres");
                dataGridView1.Columns.Add("c.Sehir", "Şehir");
                dataGridView1.Columns.Add("c.Ulke", "Ülke");
                dataGridView1.Columns.Add("c.VergiDairesi", "Vergi D.");
                dataGridView1.Columns.Add("c.VergiNo", "Vergi No");
                dataGridView1.Columns.Add("c.DogumTarihi", "Doğum T.");
                dataGridView1.Columns.Add("c.EvlilikTarihi", "Evlilik T.");
                dataGridView1.Columns.Add("c.KayitTarihi", "Kayıt T.");
                dataGridView1.Columns.Add("c.Durum", "Durum");
                dataGridView1.Columns.Add("c.Aciklama", "Açıklama");
                dataGridView1.Columns.Add("c.Resim","Resim");
            }
            
          
        }

        private void temizle()
        {
            txtCariAD.Clear();
            txtCariKOD.Clear();
            txtCariTUR.Clear();
            txtYetkili.Clear();
            txtTelefon.Clear();
            txtSehir.Clear();
            dateDtarih.Value = DateTime.Now;
            dateEtarih.Value = DateTime.Now;
            datektarih.Value = DateTime.Now;
            comboBox1.Text = "";
            txtCariKOD.Focus();
            listele();


        }
        private void listele()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                
                {
                    SqlCommand kmt = new SqlCommand(sorguInnerJoin, baglanti);
                    SqlDataAdapter da = new SqlDataAdapter(kmt);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //dataGridView1.DataSource = dt;
                    dataGridView1.Rows.Clear(); // Mevcut satırları temizle Manuel Eklediğim Başlıklar Bozulmuyor..
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
        }



        private void FrmCariListele_Load(object sender, EventArgs e)
        {
            dtHeader();
            listele();
            
        }
        private void btnSifirla_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // DataGridView'de çift tıklama olayı

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                string cariID = row.Cells["c.CariID"].Value.ToString();
                string cariKod = row.Cells["c.CariKod"].Value.ToString();
                string cariAdi = row.Cells["c.CariAdi"].Value.ToString();
                string cariTur = row.Cells["ct.Ad"].Value.ToString();
                string yetkili = row.Cells["c.Yetkili"].Value.ToString();
                string telefon = row.Cells["c.Telefon"].Value.ToString();
                string ePosta = row.Cells["c.EPosta"].Value.ToString();
                string adres = row.Cells["c.Adres"].Value.ToString();
                string sehir = row.Cells["c.Sehir"].Value.ToString();
                string ulke = row.Cells["c.Ulke"].Value.ToString();
                string vergiDairesi = row.Cells["c.VergiDairesi"].Value.ToString();
                string vergiNo = row.Cells["c.VergiNo"].Value.ToString();

                object dogumTarihiOBJ = row.Cells["c.DogumTarihi"].Value;
                string dogumTarihi = (dogumTarihiOBJ==DBNull.Value)?"" :Convert.ToDateTime(dogumTarihiOBJ).ToString();


                object evlilikTarihiOBJ = row.Cells["c.EvlilikTarihi"].Value;
                string evlilikTarihi = (evlilikTarihiOBJ == DBNull.Value) ? "" : Convert.ToDateTime(evlilikTarihiOBJ).ToString();



                string kayitTarihi = row.Cells["c.KayitTarihi"].Value.ToString();
                string durum = row.Cells["c.Durum"].Value.ToString();
                string aciklama = row.Cells["c.Aciklama"].Value.ToString();
                string resim = row.Cells["c.Resim"].Value.ToString();

                //Hangi Formdan Geldiysek veriyi o forma gönderiyoruz.

                if (CagrilanForm is FrmCariEkle)
                {
                    var hedefForm= CagrilanForm as FrmCariEkle;
                    hedefForm.CariBilgileriYukle(cariID,cariKod,cariAdi, cariTur, yetkili, telefon, ePosta, adres, sehir, ulke, vergiDairesi, vergiNo, dogumTarihi, evlilikTarihi, kayitTarihi, durum, aciklama,resim);

                }
                //Diğer Formlardanda datagrid deki veriler çekilecekse  else if eklenecek ve hedef form verilecek
                else if(CagrilanForm is FrmSatis)
                {
                    var hedefForm = CagrilanForm as FrmSatis;
                    hedefForm.CariBilgileriYukle(cariID, cariKod, cariAdi, cariTur, yetkili, telefon, ePosta,resim);
                }
                else
                {
                    return;
                }
                this.Close();
            }
        }



        private void txtCariTUR_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(baglanti.State == ConnectionState.Closed) baglanti.Open();
                if(!string.IsNullOrEmpty(txtCariTUR.Text))
                {
                    SqlCommand kmtCariTur = new SqlCommand(sorguCariTur, baglanti);
                    kmtCariTur.Parameters.AddWithValue("@cariTurAd", txtCariTUR.Text+"%");
                    SqlDataAdapter da = new SqlDataAdapter(kmtCariTur);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.Rows.Clear(); // Mevcut satırları temizleyin Manuel Eklediğim Başlıklar Bozulmuyor..
                    foreach (DataRow row in dt.Rows)
                    {
                        dataGridView1.Rows.Add(row.ItemArray); // Satırlar ekleniyor..
                    }
                    baglanti.Close();
                }
                else
                {
                    SqlCommand kmtCariTur = new SqlCommand(sorguInnerJoin, baglanti);
                    SqlDataAdapter da = new SqlDataAdapter(kmtCariTur);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.Rows.Clear(); // Mevcut satırları temizleyin Manuel Eklediğim Başlıklar Bozulmuyor..
                    foreach (DataRow row in dt.Rows)
                    {
                        dataGridView1.Rows.Add(row.ItemArray); // Satırlar ekleniyor..
                    }
                    baglanti.Close();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString());
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void txtCariKOD_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                if (!string.IsNullOrEmpty(txtCariKOD.Text))
                {
                    SqlCommand kmtCariTur = new SqlCommand(sorguCariKod, baglanti);
                    kmtCariTur.Parameters.AddWithValue("@cariKod", txtCariKOD.Text + "%");
                    SqlDataAdapter da = new SqlDataAdapter(kmtCariTur);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.Rows.Clear(); // Mevcut satırları temizleyin Manuel Eklediğim Başlıklar Bozulmuyor..
                    foreach (DataRow row in dt.Rows)
                    {
                        dataGridView1.Rows.Add(row.ItemArray); // Satırlar ekleniyor..
                    }
                    baglanti.Close();
                }
                else
                {
                    SqlCommand kmtCariTur = new SqlCommand(sorguInnerJoin, baglanti);
                    SqlDataAdapter da = new SqlDataAdapter(kmtCariTur);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.Rows.Clear(); // Mevcut satırları temizleyin Manuel Eklediğim Başlıklar Bozulmuyor..
                    foreach (DataRow row in dt.Rows)
                    {
                        dataGridView1.Rows.Add(row.ItemArray); // Satırlar ekleniyor..
                    }
                    baglanti.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString());
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void txtCariAD_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                if (!string.IsNullOrEmpty(txtCariAD.Text))
                {
                    SqlCommand kmtCariTur = new SqlCommand(sorguCariAd, baglanti);
                    kmtCariTur.Parameters.AddWithValue("@cariAd", txtCariAD.Text + "%");
                    SqlDataAdapter da = new SqlDataAdapter(kmtCariTur);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.Rows.Clear(); // Mevcut satırları temizleyin Manuel Eklediğim Başlıklar Bozulmuyor..
                    foreach (DataRow row in dt.Rows)
                    {
                        dataGridView1.Rows.Add(row.ItemArray); // Satırlar ekleniyor..
                    }
                    baglanti.Close();
                }
                else
                {
                    SqlCommand kmtCariTur = new SqlCommand(sorguInnerJoin, baglanti);
                    SqlDataAdapter da = new SqlDataAdapter(kmtCariTur);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.Rows.Clear(); // Mevcut satırları temizleyin Manuel Eklediğim Başlıklar Bozulmuyor..
                    foreach (DataRow row in dt.Rows)
                    {
                        dataGridView1.Rows.Add(row.ItemArray); // Satırlar ekleniyor..
                    }
                    baglanti.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString());
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void txtYetkili_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                if (!string.IsNullOrEmpty(txtYetkili.Text))
                {
                    SqlCommand kmtCariTur = new SqlCommand(sorguCariYetkili, baglanti);
                    kmtCariTur.Parameters.AddWithValue("@yetkili", txtYetkili.Text + "%");
                    SqlDataAdapter da = new SqlDataAdapter(kmtCariTur);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.Rows.Clear(); // Mevcut satırları temizle Manuel Eklediğim Başlıklar Bozulmuyor..
                    foreach (DataRow row in dt.Rows)
                    {
                        dataGridView1.Rows.Add(row.ItemArray); // Satırlar ekleniyor..
                    }
                    baglanti.Close();
                }
                else
                {
                    SqlCommand kmtCariTur = new SqlCommand(sorguInnerJoin, baglanti);
                    SqlDataAdapter da = new SqlDataAdapter(kmtCariTur);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.Rows.Clear(); // Mevcut satırları temizle Manuel Eklediğim Başlıklar Bozulmuyor..
                    foreach (DataRow row in dt.Rows)
                    {
                        dataGridView1.Rows.Add(row.ItemArray); // Satırlar ekleniyor..
                    }
                    baglanti.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString());
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void txtTelefon_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                if (!string.IsNullOrEmpty(txtTelefon.Text))
                {
                    SqlCommand kmtCariTur = new SqlCommand(sorguTelefon, baglanti);
                    kmtCariTur.Parameters.AddWithValue("@telefon", txtTelefon.Text + "%");
                    SqlDataAdapter da = new SqlDataAdapter(kmtCariTur);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.Rows.Clear(); // Mevcut satırları temizle Manuel Eklediğim Başlıklar Bozulmuyor..
                    foreach (DataRow row in dt.Rows)
                    {
                        dataGridView1.Rows.Add(row.ItemArray); // Satırlar ekleniyor..
                    }
                    baglanti.Close();
                }
                else
                {
                    SqlCommand kmtCariTur = new SqlCommand(sorguInnerJoin, baglanti);
                    SqlDataAdapter da = new SqlDataAdapter(kmtCariTur);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.Rows.Clear(); // Mevcut satırları temizle Manuel Eklediğim Başlıklar Bozulmuyor..
                    foreach (DataRow row in dt.Rows)
                    {
                        dataGridView1.Rows.Add(row.ItemArray); // Satırlar ekleniyor..
                    }
                    baglanti.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString());
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void txtSehir_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                if (!string.IsNullOrEmpty(txtSehir.Text))
                {
                    SqlCommand kmtCariTur = new SqlCommand(sorguSehir, baglanti);
                    kmtCariTur.Parameters.AddWithValue("@sehir", txtSehir.Text + "%");
                    SqlDataAdapter da = new SqlDataAdapter(kmtCariTur);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.Rows.Clear(); // Mevcut satırları temizle Manuel Eklediğim Başlıklar Bozulmuyor..
                    foreach (DataRow row in dt.Rows)
                    {
                        dataGridView1.Rows.Add(row.ItemArray); // Satırlar ekleniyor..
                    }
                    baglanti.Close();
                }
                else
                {
                    SqlCommand kmtCariTur = new SqlCommand(sorguInnerJoin, baglanti);
                    SqlDataAdapter da = new SqlDataAdapter(kmtCariTur);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.Rows.Clear(); // Mevcut satırları temizle Manuel Eklediğim Başlıklar Bozulmuyor..
                    foreach (DataRow row in dt.Rows)
                    {
                        dataGridView1.Rows.Add(row.ItemArray); // Satırlar ekleniyor..
                    }
                    baglanti.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString());
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void dateDtarih_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                if (dateDtarih.Value != null)
                {
                    
                    SqlCommand kmtCariTur = new SqlCommand(sorguDtarihi, baglanti);

                    
                    

                    kmtCariTur.Parameters.AddWithValue("@dtarih", Convert.ToDateTime(dateDtarih.Text));
                    
                    SqlDataAdapter da = new SqlDataAdapter(kmtCariTur);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.Rows.Clear(); // Mevcut satırları temizle Manuel Eklediğim Başlıklar Bozulmuyor..
                    foreach (DataRow row in dt.Rows)
                    {
                        dataGridView1.Rows.Add(row.ItemArray); // Satırlar ekleniyor..
                    }
                    baglanti.Close();
                }
                else
                {
                    dateDtarih.CustomFormat = "yyyy-MM-dd";
                    SqlCommand kmtCariTur = new SqlCommand(sorguInnerJoin, baglanti);
                    
                    SqlDataAdapter da = new SqlDataAdapter(kmtCariTur);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.Rows.Clear(); // Mevcut satırları temizle Manuel Eklediğim Başlıklar Bozulmuyor..
                    foreach (DataRow row in dt.Rows)
                    {
                        dataGridView1.Rows.Add(row.ItemArray); // Satırlar ekleniyor..
                    }
                    baglanti.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString());
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void dateEtarih_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                if (dateEtarih.Value != null)
                {

                    SqlCommand kmtCariTur = new SqlCommand(sorguEtarihi, baglanti);

                    kmtCariTur.Parameters.AddWithValue("@etarih", Convert.ToDateTime(dateEtarih.Text));
                    
                    SqlDataAdapter da = new SqlDataAdapter(kmtCariTur);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.Rows.Clear(); // Mevcut satırları temizle Manuel Eklediğim Başlıklar Bozulmuyor..
                    foreach (DataRow row in dt.Rows)
                    {
                        dataGridView1.Rows.Add(row.ItemArray); // Satırlar ekleniyor..
                    }
                    baglanti.Close();
                }
                else
                {
                    dateDtarih.CustomFormat = "yyyy-MM-dd";
                    SqlCommand kmtCariTur = new SqlCommand(sorguInnerJoin, baglanti);

                    SqlDataAdapter da = new SqlDataAdapter(kmtCariTur);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.Rows.Clear(); // Mevcut satırları temizle Manuel Eklediğim Başlıklar Bozulmuyor..
                    foreach (DataRow row in dt.Rows)
                    {
                        dataGridView1.Rows.Add(row.ItemArray); // Satırlar ekleniyor..
                    }
                    baglanti.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString());
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void datektarih_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                if (datektarih.Value != null)
                {

                    SqlCommand kmtCariTur = new SqlCommand(sorguKtarihi, baglanti);

                    /*
                    DateTime Sorgu Hatasını bulmak icin ekledim
                    MessageBox.Show(datektarih.Text); 
                    MessageBox.Show(datektarih.Value.ToString());
                    */

                    kmtCariTur.Parameters.AddWithValue("@ktarih", Convert.ToDateTime(datektarih.Text));

                    

                    SqlDataAdapter da = new SqlDataAdapter(kmtCariTur);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.Rows.Clear(); // Mevcut satırları temizle Manuel Eklediğim Başlıklar Bozulmuyor..
                    foreach (DataRow row in dt.Rows)
                    {
                        dataGridView1.Rows.Add(row.ItemArray); // Satırlar ekleniyor..
                    }
                    baglanti.Close();
                }
                else
                {
                    
                    SqlCommand kmtCariTur = new SqlCommand(sorguInnerJoin, baglanti);

                    SqlDataAdapter da = new SqlDataAdapter(kmtCariTur);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.Rows.Clear(); // Mevcut satırları temizle Manuel Eklediğim Başlıklar Bozulmuyor..
                    foreach (DataRow row in dt.Rows)
                    {
                        dataGridView1.Rows.Add(row.ItemArray); // Satırlar ekleniyor..
                    }
                    baglanti.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString());
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmCariEkle frmCariEkle = new FrmCariEkle();
            frmCariEkle.ShowDialog();
            listele();
        }

        private void cariEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCariEkle frmCariEkle = new FrmCariEkle();
            frmCariEkle.ShowDialog();
            listele();
        }

        private void cariBilgileriDüzeltToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCariEkle frmCariEkle = new FrmCariEkle();
            frmCariEkle.ShowDialog();
            listele();
        }

        private void cariSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCariEkle frmCariEkle = new FrmCariEkle();
            frmCariEkle.ShowDialog();
            listele();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}
