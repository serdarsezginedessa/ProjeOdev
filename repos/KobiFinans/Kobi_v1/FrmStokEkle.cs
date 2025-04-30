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
        }

        private void FrmStokEkle_Load(object sender, EventArgs e)
        {
            
            UrunKategoriYukle();
            BirimYukle();
        }

        private void ekle()
        {
            try
            {
                if(baglan.State==ConnectionState.Closed)baglan.Open();

                SqlCommand cmd = new SqlCommand(@"Insert into Urunler ([UrunKodu]
                                            ,[Barkod] ,[Marka] ,[Model] ,[UrunAdi] 
                                            ,[KategoriID]  ,[AlisFiyat]  ,[SatisFiyat] 
                                            ,[Kdv] ,[StokMiktari]  ,[Aciklama] ,[Resim] 
                                            ,[Durum]  ,[KayitTarihi]  ,[Birim] )
                                             Values (@urunkodu,@barkod,@marka,@model,@urunadi,@kategori,@afiyat,@sfiyat,@kdv
                                            ,@stokmiktari,@aciklama,@resim,@durum,@ktarih,@birim)", baglan);

                cmd.Parameters.AddWithValue("@urunkodu",txtUrunKod.Text);
                cmd.Parameters.AddWithValue("@barkod", txtBarkod.Text);
                cmd.Parameters.AddWithValue("@marka", txtMarka.Text);
                cmd.Parameters.AddWithValue("@model", txtModel.Text);
                cmd.Parameters.AddWithValue("@urunadi", txtUrunAd.Text);

                cmd.Parameters.AddWithValue("@kategori",Convert.ToInt32(combxKategori.SelectedValue));
                cmd.Parameters.AddWithValue("@afiyat",Convert.ToDecimal(txtAlisFiyati.Text));
                cmd.Parameters.AddWithValue("@sfiyat", Convert.ToDecimal(txtSatisFiyati.Text));
                cmd.Parameters.AddWithValue("@kdv", combxKdv.Text);
                cmd.Parameters.AddWithValue("@stokmiktari", txtStokAdeti.Text);
                cmd.Parameters.AddWithValue("@aciklama", txtAciklama.Text);
                cmd.Parameters.AddWithValue("@resim", pictureBox1.Text);
                if(chcDurum.Checked )
                    cmd.Parameters.AddWithValue("@durum", 1);
                else
                    cmd.Parameters.AddWithValue("@durum", 0);
                cmd.Parameters.AddWithValue("@ktarih", dateKayit.Value);
                cmd.Parameters.AddWithValue("@birim", combxBirim.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Kayıt Başarılı", "Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata" + ex.ToString());
            }
            finally { if(baglan.State==ConnectionState.Open) baglan.Close(); }
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
            ekle();
        }
    }
}
