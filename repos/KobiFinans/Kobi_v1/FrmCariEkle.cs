using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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

        bool yeniKayitModu = true;


        string sorguEkle = @"INSERT INTO Cari (CariKod, CariAdi, CariTuru, Yetkili, Telefon, Eposta, Adres, Sehir, Ulke, 
                                                    VergiDairesi, VergiNo, DogumTarihi, EvlilikTarihi, KayitTarihi, Durum, Aciklama,Resim) 
                                                    VALUES 
                                                    (@carikod,@cariadi,@caritur,@yetkili,@telefon,@eposta,@Adres,@sehir,@ulke,
                                                    @vergiDairesi,@VergiNo,@dtarih,@evltarih,@kaytarih,@durum,@aciklama,@resim)";

        string sorguGuncelle = @"UPDATE Cari SET CariAdi=@cariadi, Yetkili=@yetkili, Telefon=@telefon, Eposta=@eposta,
                                Adres=@adres, Sehir=@sehir, Ulke=@ulke, VergiDairesi=@vergiDairesi, VergiNo=@vergiNo, DogumTarihi=@dtarih, 
                                EvlilikTarihi=@evltarih, KayitTarihi=@kaytarih, Durum=@durum, Aciklama=@aciklama,Resim=@resim  
                                WHERE CariID=@CariId";
        
        string sorguSil = "DELETE FROM Cari WHERE CariID=@CariId";
        string sorgucarituru = "SELECT AD  FROM CariTuru";
        
        
        private void YeniKayitislemleri()
        {
            btnEkle.Enabled = true;
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
            btnYeniKayit.Enabled = false;
            btnTurEkle.Enabled = true;
            btniptal.Enabled = true;
            chcDurum.Text = "Aktif";

        }
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
        private void btnDisable()
        {
            btnEkle.Enabled = false;
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
            btnYeniKayit.Enabled = true;
            btnTurEkle.Enabled = false;
            btniptal.Enabled = false;

        }
        private void btnEnable()
        {
            btnEkle.Enabled = true;
            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;
            btnYeniKayit.Enabled = false;
            btnTurEkle.Enabled = true;
            btniptal.Enabled = true;
        }
        private void TextleriTemizle()
        {
            txtID.Text = "";
            txtKod.Text = "";
            txtAd.Text = "";
            combTur.Text = "";
            txtYetkili.Text = "";
            txtTel.Text = "";
            txtEposta.Text = "";
            txtAdres.Text = "";
            txtSehir.Text = "";
            txtUlke.Text = "";
            txtVergiD.Text = "";
            txtVergiNo.Text = "";
            dateDogum.Format=DateTimePickerFormat.Custom;
            dateDogum.CustomFormat = " ";
            dateEvlilik.Format = DateTimePickerFormat.Custom;
            dateEvlilik.CustomFormat = " ";
            dateKayit.Value=DateTime.Now;
            chcDurum.Checked = false;
            txtAciklama.Text = "";
            pictureBox1.Image = null;
        }
        private void textEnable()
        {
            txtID.Enabled = false;
            txtKod.Enabled = false;
            txtAd.Enabled = true;
            combTur.Enabled = true;
            txtYetkili.Enabled = true;
            txtTel.Enabled = true;
            txtEposta.Enabled = true;
            txtAdres.Enabled = true;
            txtSehir.Enabled = true;
            txtUlke.Enabled = true;
            txtVergiD.Enabled = true;
            txtVergiNo.Enabled = true;
            dateKayit.Enabled = true;
            chcDurum.Enabled = true;
            checboxdTarih.Enabled = true;
            checboxeTarih.Enabled = true;
            
            txtAciklama.Enabled = true;
        }
        private void textDisable()
        {
            txtID.Enabled = false;
            txtKod.Enabled = false;
            txtAd.Enabled = false;
            combTur.Enabled = false;
            txtYetkili.Enabled = false;
            txtTel.Enabled = false;
            txtEposta.Enabled = false;
            txtAdres.Enabled = false;
            txtSehir.Enabled = false;
            txtUlke.Enabled = false;
            txtVergiD.Enabled = false;
            txtVergiNo.Enabled = false;
            dateDogum.Enabled = false;
            dateEvlilik.Enabled = false;
            dateKayit.Enabled = false;
            chcDurum.Enabled = false;
            checboxeTarih.Enabled = false;
            checboxdTarih.Enabled = false;
            txtAciklama.Enabled = false;
        }

        private void FrmCariEkle_Load(object sender, EventArgs e)
        {
            /*dateEvlilik.Format = DateTimePickerFormat.Custom;
            dateEvlilik.CustomFormat = " ";
            dateDogum.Format = DateTimePickerFormat.Custom;
            dateDogum.CustomFormat = " ";*/
            TextleriTemizle();
            textDisable();
            
            btnDisable();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;


        }

        private void btnYeniKayit_Click(object sender, EventArgs e)
        {
            YeniKayitislemleri();
            cariTurListele();
            textEnable();
            TextleriTemizle();
            yeniKayitModu = true;
        }

        private void btniptal_Click(object sender, EventArgs e)
        {
            btnDisable();
            textDisable();
            TextleriTemizle();
            checboxdTarih.Checked = false;
            checboxeTarih.Checked = false;
            chcDurum.Checked = false;
            chcDurum.Text = "";
        }

        private void combTur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!yeniKayitModu)
                return;

            if (combTur.SelectedIndex <= 0)
            {
                txtKod.Text = "";
                return;
            }

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
                txtKod.Text = prefix + prefixCount.ToString("D3");
                baglanti.Close();
            }
        }

        private void btnTurEkle_Click(object sender, EventArgs e)
        {
            FrmCariTurEkle frmCariTurEkle = new FrmCariTurEkle();
            frmCariTurEkle.ShowDialog();
            cariTurListele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            
            try
            {
               
                
                if (string.IsNullOrEmpty(txtAd.Text))
                {
                    MessageBox.Show("Lütfen Bos Alanları Doldurunuz", "Doldurulmamış Alan Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DateTime? dtarih = null;
                DateTime? evltarih = null;
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
                if(dateDogum.CustomFormat != " ")
                {
                    dtarih = dateDogum.Value;
                }
                
                if(dateEvlilik.CustomFormat != " ")
                {
                    evltarih = dateEvlilik.Value;
                }
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

                if (combTur.SelectedItem == null || combTur.SelectedItem.ToString() == "Tür Seçiniz")
                {
                    MessageBox.Show("Lütfen Cari Türü Seçiniz", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                    
                    if(dtarih != null)
                    {
                        kmtEkle.Parameters.AddWithValue("@dtarih", dtarih.Value);
                    }
                    else
                    {
                        kmtEkle.Parameters.AddWithValue("@dtarih", DBNull.Value);
                    }
                    if (evltarih != null)
                    {
                        kmtEkle.Parameters.AddWithValue("@evltarih", evltarih.Value);
                    }
                    else
                    {
                        kmtEkle.Parameters.AddWithValue("@evltarih", DBNull.Value);
                    }
                    //kmtEkle.Parameters.AddWithValue("@evltarih", Convert.ToDateTime(evltarih));
                    kmtEkle.Parameters.AddWithValue("@kaytarih", Convert.ToDateTime(kaytarih));
                    kmtEkle.Parameters.AddWithValue("@durum", Convert.ToInt32(durum));
                    kmtEkle.Parameters.AddWithValue("@aciklama", aciklama);
                    if (bayrak)
                    {
                        kmtEkle.Parameters.AddWithValue("@resim", resimYolu);
                    }
                    else
                    {
                        kmtEkle.Parameters.AddWithValue("@resim", varsayilanresimyolu);
                    }

                    int result = kmtEkle.ExecuteNonQuery();
                    if (result > 0)
                    {
                        // Başarılı ekleme işlemi
                        MessageBox.Show("Cari Kart Sisteme Eklendi","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        //temizle();
                    }
                    else
                    {
                        // Başarısız ekleme işlemi
                        MessageBox.Show("Cari Eklenemedi","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
                TextleriTemizle();
                btnDisable();
                textDisable();
                chcDurum.Text = "";
                bayrak = false;
            }
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Lütfen Güncellenecek Cari Seçiniz");
                return;
            }
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                SqlCommand kmtGuncelle = new SqlCommand(sorguGuncelle, baglanti);
                kmtGuncelle.Parameters.AddWithValue("@CariId", txtID.Text);
                kmtGuncelle.Parameters.AddWithValue("@cariadi", txtAd.Text);
                kmtGuncelle.Parameters.AddWithValue("@yetkili", txtYetkili.Text);
                kmtGuncelle.Parameters.AddWithValue("@telefon", txtTel.Text);
                kmtGuncelle.Parameters.AddWithValue("@eposta", txtEposta.Text);
                kmtGuncelle.Parameters.AddWithValue("@Adres", txtAdres.Text);
                kmtGuncelle.Parameters.AddWithValue("@sehir", txtSehir.Text);
                kmtGuncelle.Parameters.AddWithValue("@ulke", txtUlke.Text);
                kmtGuncelle.Parameters.AddWithValue("@vergiDairesi", txtVergiD.Text);
                kmtGuncelle.Parameters.AddWithValue("@VergiNo", txtVergiNo.Text);

                
                if(checboxeTarih.Checked)
                {
                    kmtGuncelle.Parameters.AddWithValue("@evltarih", Convert.ToDateTime(dateEvlilik.Value));
                    
                }
                else
                    kmtGuncelle.Parameters.AddWithValue("@evltarih", DBNull.Value);

                if (checboxdTarih.Checked)
                {
                    kmtGuncelle.Parameters.AddWithValue("@dtarih", Convert.ToDateTime(dateDogum.Value));
                    
                }
                else
                {
                    kmtGuncelle.Parameters.AddWithValue("@dtarih", DBNull.Value);
                }
                    
                kmtGuncelle.Parameters.AddWithValue("@kaytarih", Convert.ToDateTime(dateKayit.Value));

                kmtGuncelle.Parameters.AddWithValue("@durum", Convert.ToInt32(chcDurum.Checked));
                kmtGuncelle.Parameters.AddWithValue("@aciklama", txtAciklama.Text);
                if (bayrak)
                {
                    kmtGuncelle.Parameters.AddWithValue("@resim", resimYolu);
                }
                else
                {
                    kmtGuncelle.Parameters.AddWithValue("@resim", varsayilanresimyolu);
                }
                int result = kmtGuncelle.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Cari Güncellendi");
                }
                else
                {
                    MessageBox.Show("Güncelleme Başarısız");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
                TextleriTemizle();
                btnDisable();
                textDisable();
                yeniKayitModu = true;
                bayrak = false;
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Lütfen Silinecek Cari Seçiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    DialogResult sonuc = MessageBox.Show("Silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (sonuc == DialogResult.Yes)
                    {
                        if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                        SqlCommand kmtSil = new SqlCommand(sorguSil, baglanti);
                        kmtSil.Parameters.AddWithValue("@CariId", txtID.Text);
                        int result = kmtSil.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Cari Silindi", "Silme İşlemi Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Silme Başarısız", "Silme İşlemi Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                TextleriTemizle();
                btnDisable();
                textDisable();
                yeniKayitModu = true;
                chcDurum.Text = "";
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            yeniKayitModu = false;
            FrmCariListele frmCariListele = new FrmCariListele();
            frmCariListele.CagrilanForm = this;
            frmCariListele.ShowDialog();
            textEnable();
            combTur.Enabled = false;
            

        }

        public void CariBilgileriYukle( string cariID, string cariKod,string cariAdi, string cariTur, string yetkili, string telefon, string eposta, 
            string adres, string sehir,string ulke, string vergidairesi , string vergiNo, string dtarih, string etarih,string ktarih, string durum,string aciklama,string resim)
        {
            cariTurListele();
            txtID.Text = cariID;
            txtID.Enabled = false;
            txtKod.Enabled = false;
            txtKod.Text = cariKod;
            txtAd.Text = cariAdi;
            combTur.SelectedItem = cariTur;
            txtYetkili.Text = yetkili;
            txtTel.Text = telefon;
            txtEposta.Text = eposta;
            txtAdres.Text = adres;
            txtSehir.Text = sehir;
            txtUlke.Text = ulke;
            txtVergiD.Text = vergidairesi;
            txtVergiNo.Text = vergiNo;

            if(string.IsNullOrEmpty(dtarih)) //CarilisteleFormundan gelen doğum tarihi boş dolu kontrolü
            {
                checboxdTarih.Checked = false;
                dateDogum.Enabled = false;
                dateDogum.Format=DateTimePickerFormat.Custom;
                dateDogum.CustomFormat = " ";
                
            }
            else
            {
                checboxdTarih.Checked = true;
                dateDogum.Enabled = true;
                dateDogum.CustomFormat = "dd.MM.yyyy";
                dateDogum.Value = Convert.ToDateTime(dtarih);
                
            }

            if (string.IsNullOrEmpty(etarih)) //CarilisteleFormundan gelen evlilik tarihi boş dolu kontrolü
            {
                dateEvlilik.Enabled = false;
                checboxeTarih.Checked = false;
                dateEvlilik.Format = DateTimePickerFormat.Custom;
                dateEvlilik.CustomFormat = " ";
                
            }
            else
            {
                checboxeTarih.Checked = true;
                dateEvlilik.Enabled = true;
                dateEvlilik.CustomFormat = "dd.MM.yyyy";
                dateEvlilik.Value = Convert.ToDateTime(etarih);
                
            }
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
            if (string.IsNullOrEmpty(resim))
            {
                resim = varsayilanresimyolu;
            }
            else
            {
                pictureBox1.ImageLocation = Application.StartupPath + resim;
            }
            



            btnEkle.Enabled = false;
            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;
            btniptal.Enabled = true;


        }

        

        private void checboxdTarih_CheckedChanged(object sender, EventArgs e)
        {
            if (checboxdTarih.Checked)
            {
                dateDogum.Enabled = true;
                dateDogum.CustomFormat = "dd.MM.yyyy";
            }
            else
            {
                
                dateDogum.Enabled = false;
                dateDogum.CustomFormat = " ";

            }
        }

        private void checboxeTarih_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checboxeTarih.Checked)
            {
                dateEvlilik.Enabled = true;
                dateEvlilik.CustomFormat = "dd.MM.yyyy";
                

            }
            else
            {
                dateEvlilik.Enabled = false;
                dateEvlilik.CustomFormat = " ";

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

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }
        string resimYolu = "";
        string varsayilanresimyolu= @"\\images\\default.png";
        bool bayrak = false;
        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog resimAc = new OpenFileDialog();
            resimAc.Filter = "Resim Dosyaları|*.jpg;*.JPG;*.jpeg;*.png;*.bmp|Tüm Dosyalar|*.*";
            resimAc.Title = "Resim Seçiniz";
            if (resimAc.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = resimAc.FileName;
                string kaynak = resimAc.FileName;
                string hedef = Application.StartupPath + @"\\images\\";
                string yeniAd=Guid.NewGuid().ToString() + ".jpg";
                File.Copy(kaynak, hedef + yeniAd, true);
                resimYolu = @"\\images\\" + yeniAd;
                bayrak = true;
                
            }
        }
    }
}

