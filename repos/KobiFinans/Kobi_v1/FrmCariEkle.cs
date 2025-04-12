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


        private void Listele()
        {
           

        }


        void temizle()
        {

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
           if(combTur.SelectedIndex<=0)
            {
                txtKod.Text = "";
                return;
            }

            string secilenTur=combTur.SelectedItem.ToString();
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
            }
            
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
                if(combTur.SelectedItem == null || combTur.SelectedItem.ToString() == "Tür Seçiniz")
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
                string carikod=txtKod.Text;
                if(chcDurum.Checked)
                {
                    durum = true;
                }
                else
                {
                    durum = false;
                }

                if (string.IsNullOrEmpty(cariAdi)|| string.IsNullOrEmpty(carikod) || string.IsNullOrEmpty(cariTur))
                {
                    MessageBox.Show("Lütfen Bos Alanları Doldurunuz");
                    return;
                }
                if(baglanti.State == ConnectionState.Closed)
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

                    SqlCommand kmt = new SqlCommand(sorguEkle, baglanti);
                    // Parametreleri ekle
                    kmt.Parameters.AddWithValue("@caritur", cariTuruID);
                    kmt.Parameters.AddWithValue("@carikod", carikod);
                    kmt.Parameters.AddWithValue("@cariadi", cariAdi);
                    kmt.Parameters.AddWithValue("@yetkili", yetkili);
                    kmt.Parameters.AddWithValue("@telefon", telefon);
                    kmt.Parameters.AddWithValue("@eposta", eposta);
                    kmt.Parameters.AddWithValue("@Adres", adres);
                    kmt.Parameters.AddWithValue("@sehir", sehir);
                    kmt.Parameters.AddWithValue("@ulke", ulke);
                    kmt.Parameters.AddWithValue("@vergiDairesi", vergiDairesi);
                    kmt.Parameters.AddWithValue("@VergiNo", vergiNo);
                    kmt.Parameters.AddWithValue("@dtarih", Convert.ToDateTime(dtarih));
                    kmt.Parameters.AddWithValue("@evltarih", Convert.ToDateTime(evltarih));
                    kmt.Parameters.AddWithValue("@kaytarih", Convert.ToDateTime(kaytarih));
                    kmt.Parameters.AddWithValue("@durum", Convert.ToInt32(durum));
                    kmt.Parameters.AddWithValue("@aciklama", aciklama);
                    
                    int result = kmt.ExecuteNonQuery();
                    if (result > 0)
                    {
                        // Başarılı ekleme işlemi
                        MessageBox.Show("Cari Eklendi");
                        temizle();
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
                temizle();
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            FrmCariListele frmCariListele = new FrmCariListele();
            frmCariListele.ShowDialog();
        }
    }
}

