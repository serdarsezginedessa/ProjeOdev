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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kobi_v1
{
    public partial class FrmCariEkle : Form
    {
        public FrmCariEkle()
        {
            InitializeComponent();


        }
        static string connectionString = ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);

        string sorguEkle = @"INSERT INTO  [dbo].[Cari]
                                                           ([CariKod]
                                                           ,[CariAdi]
                                                           ,[CariTuru]
                                                           ,[Yetkili]
                                                           ,[Telefon]
                                                           ,[Eposta]
                                                           ,[Adres]
                                                           ,[Sehir]
                                                           ,[Ulke]
                                                           ,[VergiDairesi]
                                                           ,[VergiNo]
                                                           ,[DogumTarihi]
                                                           ,[EvlilikTarihi]
                                                           ,[KayitTarihi]
                                                           ,[Durum]
                                                           ,[Aciklama])  VALUES 
                                                            (@carikod,@cariad,@caritur,@yetkili,@telefon,@eposta,@adres,@sehir,@ulke,@vergidairesi,@vergino,@dtarih,@evltarih,@ktarih,@durum,@aciklama)
                                                            ";
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
		                            c.cariTuru = ct.ID";
        public string cariKodUretilmis;

        private void cariTurListele()
        {
            try
            {
                combTur.Items.Clear();
                combTur.Items.Add("Tür Seçiniz");
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand kmt = new SqlCommand(sorgucarituru, baglanti);
                    SqlDataReader dr = kmt.ExecuteReader();
                    while (dr.Read())
                    {
                        combTur.Items.Add(dr["AD"].ToString());
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                
                baglanti.Close();
                combTur.SelectedIndex = 0; // ilk değer 'Seçiniz' olacak
            }
        }


        private void btnTurEkle_Click(object sender, EventArgs e)
        {
            FrmCariTurEkle frmCariTurEkle = new FrmCariTurEkle();
            frmCariTurEkle.ShowDialog();
            cariTurListele();
        }

        private void FrmCariEkle_Load(object sender, EventArgs e)
        {
            chcDurum.Text = "Aktif";
            txtID.Enabled = false;
            txtKod.Enabled = false;
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
            //Form yüklendiğinde cari türlerini listele
            cariTurListele();

        }

        private void combTur_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtKod.Text = combTur.SelectedItem.ToString();

            /*if (combTur.SelectedIndex <= 0)
            {
                txtKod.Text = "";
                return;
            }

            string secilenTur = combTur.SelectedItem.ToString();
            string prefix = "";
            int prefixCount = 1;

            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                //prefix veritabanından çekiliyor.

                string sorguprefix = "select prefix from CariTuru where Ad=@tur";
                SqlCommand kmt = new SqlCommand(sorguprefix, baglanti);

                kmt.Parameters.AddWithValue("@tur", secilenTur);

                prefix = (string)kmt.ExecuteScalar();

                // Aynı prefix'le başlayan kaç cari var kontrol et

                string sorguprefixCount = "select count(*) from Cari where CariKod LIKE @prefix + '%'";
                SqlCommand kmt1 = new SqlCommand(sorguprefixCount, baglanti);
                kmt1.Parameters.AddWithValue("@prefix", prefix);

                prefixCount = (int)kmt1.ExecuteScalar() + 1;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                txtKod.Text = prefix + prefixCount.ToString("D3");
                baglanti.Close();
            }*/
        }

        private void chcDurum_CheckedChanged(object sender, EventArgs e)
        {
            if (chcDurum.Checked)
            {
                chcDurum.Text = "Aktif";
            }
            else
            {
                chcDurum.Text = "Pasif";
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (combTur.SelectedIndex <= 0)
                {
                    txtKod.Text = "";
                    return;
                }

                string secilenTur = combTur.SelectedItem.ToString();
                string prefix = "";
                int prefixCount = 1;

                try
                {
                    if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                    //prefix veritabanından çekiliyor.

                    string sorguprefix = "select prefix from CariTuru where Ad=@tur";
                    SqlCommand kmt = new SqlCommand(sorguprefix, baglanti);

                    kmt.Parameters.AddWithValue("@tur", secilenTur);

                    prefix = (string)kmt.ExecuteScalar();

                    // Aynı prefix'le başlayan kaç cari var kontrol et

                    string sorguprefixCount = "select count(*) from Cari where CariKod LIKE @prefix + '%'";
                    SqlCommand kmt1 = new SqlCommand(sorguprefixCount, baglanti);
                    kmt1.Parameters.AddWithValue("@prefix", prefix);

                    prefixCount = (int)kmt1.ExecuteScalar() + 1;


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
                finally
                {
                    string cariKodUretilmis = prefix + prefixCount.ToString("D3");
                    txtKod.Text = cariKodUretilmis;
                    baglanti.Close();
                }
                if (combTur.SelectedItem == null || combTur.SelectedItem.ToString() == "Tür Seçiniz")
                {
                    MessageBox.Show("Lütfen Cari Türü Seçiniz");
                    return;
                }

                string cariAdi= txtAd.Text;
                string cariTur=combTur.SelectedItem.ToString();
                string yetkili = txtYetkili.Text;
                string telefon = txtTel.Text;
                string eposta = txtEposta.Text;
                string adres = txtAdres.Text;
                string sehir = txtSehir.Text;
                string ulke = txtUlke.Text;
                string vergiDairesi = txtVergiD.Text;
                string vergiNo = txtVergiNo.Text;
                string dtarih=dateDogum.Value.ToString();
                string evltarih=dateEvlilik.Value.ToString();
                string kaytarih=dateKayit.Value.ToString();
                bool durum = chcDurum.Checked;
                string aciklama = txtAciklama.Text;

                //Otomatik cari kod üretecek
                string carikod=cariKodUretilmis;
                if(chcDurum.Checked)
                {
                    durum = true;
                }
                else
                {
                    durum = false;
                }

                if (string.IsNullOrEmpty(cariAdi))
                {
                    MessageBox.Show("Lütfen Bos Alanları Doldurunuz");
                    return;
                }
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();

                    // Seçilen türün id sini çağırıyoruz

                    string sorguTurID = "select Id from CariTuru where Ad=@tur";

                    SqlCommand kmtTurID = new SqlCommand(sorguTurID, baglanti);
                    kmtTurID.Parameters.AddWithValue("@tur", cariTur);
                    int cariTuruID = (int)kmtTurID.ExecuteScalar();

                    //Cari Ekleme
                    string sorguEkle = @"INSERT INTO Cari (CariKod, CariAdi, CariTuru, Yetkili, Telefon, Eposta, Adres, Sehir, Ulke, 
                                                    VergiDairesi, VergiNo, DogumTarihi, EvlilikTarihi, KayitTarihi, Durum, Aciklama) " +
                                                    "VALUES " +
                                                    "(@carikod,@cariadi,@caritur,@yetkili,@telefon,@eposta,@Adres,@sehir,@ulke," +
                                                    "@vergiDairesi,@VergiNo,@dtarih,@evltarih,@kaytarih,@durum,@aciklama)";

                    SqlCommand kmtEkle = new SqlCommand(sorguEkle, baglanti);
                    // Parametreleri ekle
                    kmtEkle.Parameters.AddWithValue("@caritur", cariTuruID);
                    kmtEkle.Parameters.AddWithValue("@carikod", carikod);
                    kmtEkle.Parameters.AddWithValue("@cariadi", cariAdi);
                    kmtEkle.Parameters.AddWithValue("@yetkili", yetkili);
                    kmtEkle.Parameters.AddWithValue("@telefon", telefon);
                    kmtEkle.Parameters.AddWithValue("@eposta", eposta);
                    kmtEkle.Parameters.AddWithValue("@Adres", adres);
                    kmtEkle.Parameters.AddWithValue("@sehir", sehir);
                    kmtEkle.Parameters.AddWithValue("@ulke", ulke);
                    kmtEkle.Parameters.AddWithValue("@vergiDairesi", vergiDairesi);
                    kmtEkle.Parameters.AddWithValue("@VergiNo", vergiNo);
                    kmtEkle.Parameters.AddWithValue("@dtarih", Convert.ToDateTime(dtarih));
                    kmtEkle.Parameters.AddWithValue("@evltarih", Convert.ToDateTime(evltarih));
                    kmtEkle.Parameters.AddWithValue("@kaytarih", Convert.ToDateTime(kaytarih));
                    kmtEkle.Parameters.AddWithValue("@durum", Convert.ToInt32(durum));
                    kmtEkle.Parameters.AddWithValue("@aciklama", aciklama);
                    
                    int result = kmtEkle.ExecuteNonQuery();
                    if (result > 0)
                    {
                        // Başarılı ekleme işlemi
                        MessageBox.Show("Cari Eklendi");
                        //temizle();
                    }
                    else
                    {
                        // Başarısız ekleme işlemi
                        MessageBox.Show("Cari Eklenemedi");
                    }
                    
                }

             }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex);
            }
            finally
            {
                baglanti.Close();
                //temizle();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtID.Text))
                {
                    MessageBox.Show("Lütfen Silinecek Cari Seçiniz");
                    return;
                }
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                SqlCommand kmt = new SqlCommand(sorguSil, baglanti);
                kmt.Parameters.AddWithValue("@CariId", txtID.Text);
                kmt.ExecuteNonQuery();
                MessageBox.Show("Cari Silindi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
                //temizle();
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            FrmCariListele frmCariListele = new FrmCariListele();
            frmCariListele.CagrilanForm = this;
            frmCariListele.ShowDialog();
        }
        public void CariBilgileriYukle( string cariKod,string cariAdi, string cariTuru, string yetkili, string telefon, string eposta, 
            string adres, string sehir,string ulke, string vergidairesi , string vergiNo, string dtarih, string etarih,string ktarih, string durum,string aciklama)
        {
            txtKod.Text = cariKod;
            txtAd.Text = cariAdi;
            combTur.SelectedItem = cariTuru;
            txtYetkili.Text = yetkili;
            txtTel.Text = telefon;
            txtEposta.Text = eposta;
            txtAdres.Text = adres;
            txtSehir.Text = sehir;
            txtUlke.Text = ulke;
            txtVergiD.Text = vergidairesi;
            txtVergiNo.Text = vergiNo;
            dateDogum.Value = Convert.ToDateTime(dtarih);
            dateEvlilik.Value = Convert.ToDateTime(etarih);
            dateKayit.Value = Convert.ToDateTime(ktarih);
            if (durum=="True")
            {
                chcDurum.Checked = true;
            }
            else
            {
                chcDurum.Checked = false;
            }
            txtAciklama.Text = aciklama;
            
            btnEkle.Enabled = false;
            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;
        }
    }
}

