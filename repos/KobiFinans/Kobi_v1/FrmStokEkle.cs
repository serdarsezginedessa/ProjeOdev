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
    public partial class FrmStokEkle : Form
    {
        public FrmStokEkle()
        {
            InitializeComponent();
        }
        private static string connectionString = ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglan = new SqlConnection(connectionString);


        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
        private void BtnLoad()
        {
            btnEkle.Enabled = true;
            btniptal.Enabled = false;
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
            btnKayit.Enabled = false;
            btnKapat.Enabled = true;
            btnUrunAra.Enabled = true;

            foreach (Control item in this.Controls)
            {
                if (item is Panel)
                {
                    foreach (Control item2 in item.Controls)
                    {
                        if (item2 is TextBox)
                        {
                            item2.Text = "";
                        }
                        else if (item2 is ComboBox)
                        {
                            ((ComboBox)item2).SelectedIndex = -1;
                        }
                        else if (item2 is CheckBox)
                        {
                            ((CheckBox)item2).Checked = false;
                        }
                    }
                }
            }
        }

        private void FrmStokEkle_Load(object sender, EventArgs e)
        {
            
            UrunKategoriYukle();
            BirimYukle();
            BtnLoad();
            txtUrunID.Enabled = false; // UrunID textbox'ını devre dışı bırak
        }
        public void StokBilgileriYukle(string urunno,string urunkodu,string barkod, string urunadi, string kategori,string marka,string model,string alisfiyati,
            string satisfiyati,string kdv,string miktar, string aciklama, string resim,string durum,string tarih,string birim)
        {
            txtUrunID.Text = urunno;
            txtUrunKod.Text = urunkodu;
            txtBarkod.Text = barkod;
            txtUrunAd.Text = urunadi;
            combxKategori.Text = kategori;
            txtMarka.Text = marka;
            txtModel.Text = model;
            txtAlisFiyati.Text = alisfiyati;
            txtSatisFiyati.Text = satisfiyati;
            combxKdv.Text = kdv;
            txtStokAdeti.Text = miktar;
            txtAciklama.Text = aciklama;
            pictureBox1.Text = resim;
            
            if (durum == "Aktif")
            {
                chcDurum.Checked = true;
            }
            else
            {
                chcDurum.Checked = false;
            }
            dateKayit.Text = tarih;
            combxBirim.Text = birim;

        }

        private void UrunEkle()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUrunKod.Text)|| string.IsNullOrWhiteSpace(txtUrunAd.Text) || string.IsNullOrWhiteSpace(txtSatisFiyati.Text) || string.IsNullOrWhiteSpace(combxKategori.Text) || string.IsNullOrWhiteSpace(combxKdv.Text))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                }
                else
                {
                    if (baglan.State == ConnectionState.Closed) baglan.Open();

                    SqlCommand cmd = new SqlCommand(@"Insert into Urunler ([UrunKodu]
                                            ,[Barkod] ,[Marka] ,[Model] ,[UrunAdi] 
                                            ,[KategoriID]  ,[AlisFiyat]  ,[SatisFiyat] 
                                            ,[Kdv] ,[StokMiktari]  ,[Aciklama] ,[Resim] 
                                            ,[Durum]  ,[KayitTarihi]  ,[Birim] )
                                             Values (@urunkodu,@barkod,@marka,@model,@urunadi,@kategori,@afiyat,@sfiyat,@kdv
                                            ,@stokmiktari,@aciklama,@resim,@durum,@ktarih,@birim)", baglan);

                    cmd.Parameters.AddWithValue("@urunkodu", txtUrunKod.Text);
                    cmd.Parameters.AddWithValue("@barkod", txtBarkod.Text);
                    cmd.Parameters.AddWithValue("@marka", txtMarka.Text);
                    cmd.Parameters.AddWithValue("@model", txtModel.Text);
                    cmd.Parameters.AddWithValue("@urunadi", txtUrunAd.Text);

                    cmd.Parameters.AddWithValue("@kategori", Convert.ToInt32(combxKategori.SelectedValue));
                    cmd.Parameters.AddWithValue("@afiyat", Convert.ToDecimal(txtAlisFiyati.Text));
                    cmd.Parameters.AddWithValue("@sfiyat", Convert.ToDecimal(txtSatisFiyati.Text));
                    cmd.Parameters.AddWithValue("@kdv", combxKdv.Text);
                    cmd.Parameters.AddWithValue("@stokmiktari", txtStokAdeti.Text);
                    cmd.Parameters.AddWithValue("@aciklama", txtAciklama.Text);
                    cmd.Parameters.AddWithValue("@resim", pictureBox1.Text);
                    if (chcDurum.Checked)
                        cmd.Parameters.AddWithValue("@durum", 1);
                    else
                        cmd.Parameters.AddWithValue("@durum", 0);
                    cmd.Parameters.AddWithValue("@ktarih", dateKayit.Value);
                    cmd.Parameters.AddWithValue("@birim", combxBirim.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Başarılı", "Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BtnLoad();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata" + ex.ToString());
            }
            finally { if(baglan.State==ConnectionState.Open) baglan.Close(); }
        }
        private void UrunGuncelle()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUrunKod.Text) || string.IsNullOrWhiteSpace(txtUrunAd.Text) || string.IsNullOrWhiteSpace(txtSatisFiyati.Text) || string.IsNullOrWhiteSpace(combxKategori.Text) || string.IsNullOrWhiteSpace(combxKdv.Text))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (baglan.State == ConnectionState.Closed) baglan.Open();
                    SqlCommand cmd = new SqlCommand(@"Update Urunler set [UrunKodu]=@urunkodu,[Barkod]=@barkod,[Marka]=@marka,[Model]=@model,[UrunAdi]=@urunadi,
                                            [KategoriID]=@kategori,[AlisFiyat]=@afiyat,[SatisFiyat]=@sfiyat,[Kdv]=@kdv,[StokMiktari]=@stokmiktari,
                                            [Aciklama]=@aciklama,[Resim]=@resim,[Durum]=@durum,[KayitTarihi]=@ktarih,[Birim]=@birim where UrunID=@urunid", baglan);
                    cmd.Parameters.AddWithValue("@urunid", txtUrunID.Text);
                    cmd.Parameters.AddWithValue("@urunkodu", txtUrunKod.Text);
                    cmd.Parameters.AddWithValue("@barkod", txtBarkod.Text);
                    cmd.Parameters.AddWithValue("@marka", txtMarka.Text);
                    cmd.Parameters.AddWithValue("@model", txtModel.Text);
                    cmd.Parameters.AddWithValue("@urunadi", txtUrunAd.Text);
                    cmd.Parameters.AddWithValue("@kategori", Convert.ToInt32(combxKategori.SelectedValue));
                    cmd.Parameters.AddWithValue("@afiyat", Convert.ToDecimal(txtAlisFiyati.Text));
                    cmd.Parameters.AddWithValue("@sfiyat", Convert.ToDecimal(txtSatisFiyati.Text));
                    cmd.Parameters.AddWithValue("@kdv", combxKdv.Text);
                    cmd.Parameters.AddWithValue("@stokmiktari", txtStokAdeti.Text);
                    cmd.Parameters.AddWithValue("@aciklama", txtAciklama.Text);
                    cmd.Parameters.AddWithValue("@resim", pictureBox1.Text);
                    if (chcDurum.Checked)
                        cmd.Parameters.AddWithValue("@durum", 1);
                    else
                        cmd.Parameters.AddWithValue("@durum", 0);
                    cmd.Parameters.AddWithValue("@ktarih", dateKayit.Value);
                    cmd.Parameters.AddWithValue("@birim", combxBirim.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Güncelleme Başarılı", "Güncelleme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BtnLoad();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata" + ex.ToString());
            }
            finally { if (baglan.State == ConnectionState.Open) baglan.Close(); }
        }
        private void UrunSil()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUrunID.Text))
                {
                    MessageBox.Show("Lütfen silmek istediğiniz ürünü seçin.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult result = MessageBox.Show("Silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    return; // Kullanıcı "Hayır" seçeneğini seçti, işlemi iptal et
                }
                if (baglan.State == ConnectionState.Closed) baglan.Open();
                SqlCommand cmd = new SqlCommand("Delete from Urunler where UrunID=@urunid", baglan);
                cmd.Parameters.AddWithValue("@urunid", txtUrunID.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Silme Başarılı", "Silme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BtnLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata" + ex.ToString());
            }
            finally { if (baglan.State == ConnectionState.Open) baglan.Close(); }

        }
        private void UrunKategoriYukle()
        {
            try
            {
                baglan.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT KategoriID,KategoriAdi FROM UrunKategori", baglan);
                DataTable dt = new DataTable();
                da.Fill(dt);

                combxKategori.DataSource = dt;
                combxKategori.DisplayMember = "KategoriAdi";
                combxKategori.ValueMember = "KategoriID";
                combxKategori.SelectedIndex = -1; // İlk başta hiçbir öğe seçili olmasın

            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yükleme sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (baglan.State == ConnectionState.Open)
                {
                    baglan.Close();
                }
            }
        }
        private void BirimYukle()
        {
            try
            {
                baglan.Open();
                SqlCommand cmd = new SqlCommand("SELECT BirimAdi FROM UrunBirimleri", baglan);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    combxBirim.Items.Add(dr["BirimAdi"]);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yükleme sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (baglan.State == ConnectionState.Open)
                {
                    baglan.Close();
                }
            }
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            UrunEkle();
            
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            BtnLoad();
            btnEkle.Enabled = false;            
            btniptal.Enabled = true;
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
            btnKayit.Enabled = true;
            btnKapat.Enabled = true;
            btnUrunAra.Enabled = false;
            

        }

        private void btniptal_Click(object sender, EventArgs e)
        {
            BtnLoad();
            btnUrunAra.Enabled = true;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            UrunSil();
            btnUrunAra.Enabled = true;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            UrunGuncelle();
            btnUrunAra.Enabled = true;
        }

        private void btnUrunAra_Click(object sender, EventArgs e)
        {
            FrmStoklar stoklar = new FrmStoklar();
            stoklar.CagrilanForm = this;
            stoklar.ShowDialog();

            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;
            btniptal.Enabled = true;
            btnUrunAra.Enabled = true;
        }

        private void btnKategoriEkle_Click(object sender, EventArgs e)
        {
            FrmStokKategori frmStokKategori = new FrmStokKategori();
            frmStokKategori.ShowDialog();
        }
    }
}
