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
    public partial class frmTahsilatHareketleri : Form
    {

        public frmTahsilatHareketleri()
        {
            InitializeComponent();

        }
        public string TahsilatIdGonder { get; set; }
        public string FaturaNoGonder { get; set; }
        public string CariIdGonder { get; set; }
        public string CariKodGonder { get; set; }
        public string CariAdGonder { get; set; }
        public string TutarGonder { get; set; }
        public string TarihGonder { get; set; }
        public string OdemeTuruGoner { get; set; }
        public string KasaIdGonder { get; set; }
        public string BankaIdGonder { get; set; }
        public string AciklamaGonder { get; set; }

        private static string connectionString = ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);

        private void frmTahsilatHareketleri_Load(object sender, EventArgs e)
        {
            BugunListele();
        }
        //************************Sql Sorgular**************************************************
        string sqlTumKayitlar = @"Select t.TahsilatID as[Tahsilat No],t.FaturaNo as[Fatura No],c.Carikod as[Cari Kod],c.CariAdi as[Ad Soyad]
                                ,t.Tutar, t.Tarih, ot.OdemeAD as[Ödeme Türü], k.KasaAdi as [Kasa], b.BankaAd as [Banka]
                                ,t.Aciklama as [Açıklama]
                                From Tahsilatlar t
                                LEFT Join Cari c
                                On t.CariID=c.CariID
                                LEFT Join OdemeTuru ot
                                On t.OdemeTuruID=ot.OdemeID
                                LEFT Join Kasalar k
                                On t.KasaID=k.KasaID
                                LEFT Join Bankalar b
                                ON t.BankaID=b.BankaID";
        string sqlFaturano = @"
                                Select t.TahsilatID as[Tahsilat No],t.FaturaNo as[Fatura No],c.Carikod as[Cari Kod], c.CariAdi as[Ad Soyad]
                                ,t.Tutar, t.Tarih, ot.OdemeAD as[Ödeme Türü], k.KasaAdi as [Kasa], b.BankaAd as [Banka]
                                ,t.Aciklama as [Açıklama]
                                From Tahsilatlar t
                                LEFT Join Cari c
                                On t.CariID=c.CariID
                                LEFT Join OdemeTuru ot
                                On t.OdemeTuruID=ot.OdemeID
                                LEFT Join Kasalar k
                                On t.KasaID=k.KasaID
                                LEFT Join Bankalar b
                                ON t.BankaID=b.BankaID

                                where t.FaturaNo LIKE @faturaNO";
        string sqlBugun = @"Select t.TahsilatID as[Tahsilat No],t.FaturaNo as[Fatura No], c.Carikod as[Cari Kod],c.CariAdi as[Ad Soyad]
                                ,t.Tutar, t.Tarih, ot.OdemeAD as[Ödeme Türü], k.KasaAdi as [Kasa], b.BankaAd as [Banka]
                                ,t.Aciklama as [Açıklama]
                                From Tahsilatlar t
                                LEFT Join Cari c
                                On t.CariID=c.CariID
                                LEFT Join OdemeTuru ot
                                On t.OdemeTuruID=ot.OdemeID
                                LEFT Join Kasalar k
                                On t.KasaID=k.KasaID
                                LEFT Join Bankalar b
                                ON t.BankaID=b.BankaID

                                WHERE t.Tarih >= @tarih AND t.Tarih < DATEADD(DAY, 1, @tarih)";

        string sqlTahsilatno = @"Select t.TahsilatID as[Tahsilat No],t.FaturaNo as[Fatura No],c.Carikod as[Cari Kod], c.CariAdi as[Ad Soyad]
                                ,t.Tutar, t.Tarih, ot.OdemeAD as[Ödeme Türü], k.KasaAdi as [Kasa], b.BankaAd as [Banka]
                                ,t.Aciklama as [Açıklama]
                                From Tahsilatlar t
                                LEFT Join Cari c
                                On t.CariID=c.CariID
                                LEFT Join OdemeTuru ot
                                On t.OdemeTuruID=ot.OdemeID
                                LEFT Join Kasalar k
                                On t.KasaID=k.KasaID
                                LEFT Join Bankalar b
                                ON t.BankaID=b.BankaID

                                Where t.TahsilatID LIKE @tahsilatNo";

        string sqlAdaSoyad = @"Select t.TahsilatID as[Tahsilat No],t.FaturaNo as[Fatura No],c.Carikod as[Cari Kod], c.CariAdi as[Ad Soyad]
                            ,t.Tutar, t.Tarih, ot.OdemeAD as[Ödeme Türü], k.KasaAdi as [Kasa], b.BankaAd as [Banka]
                            ,t.Aciklama as [Açıklama]
                            From Tahsilatlar t
                            LEFT Join Cari c
                            On t.CariID=c.CariID
                            LEFT Join OdemeTuru ot
                            On t.OdemeTuruID=ot.OdemeID
                            LEFT Join Kasalar k
                            On t.KasaID=k.KasaID
                            LEFT Join Bankalar b
                            ON t.BankaID=b.BankaID

                            Where c.CariAdi LIKE @adSoyad";
        string sqlOdemeTuru = @"Select t.TahsilatID as[Tahsilat No],t.FaturaNo as[Fatura No],c.Carikod as[Cari Kod], c.CariAdi as[Ad Soyad]
                                ,t.Tutar, t.Tarih, ot.OdemeAD as[Ödeme Türü], k.KasaAdi as [Kasa], b.BankaAd as [Banka]
                                ,t.Aciklama as [Açıklama]
                                From Tahsilatlar t
                                LEFT Join Cari c
                                On t.CariID=c.CariID
                                LEFT Join OdemeTuru ot
                                On t.OdemeTuruID=ot.OdemeID
                                LEFT Join Kasalar k
                                On t.KasaID=k.KasaID
                                LEFT Join Bankalar b
                                ON t.BankaID=b.BankaID

                                Where ot.OdemeAD LIKE @odemeTuru";
        string sqlIkiTarihArasi = @"Select t.TahsilatID as[Tahsilat No],t.FaturaNo as[Fatura No],c.Carikod as[Cari Kod], c.CariAdi as[Ad Soyad]
                                ,t.Tutar, t.Tarih, ot.OdemeAD as[Ödeme Türü], k.KasaAdi as [Kasa], b.BankaAd as [Banka]
                                ,t.Aciklama as [Açıklama]
                                From Tahsilatlar t
                                LEFT Join Cari c
                                On t.CariID=c.CariID
                                LEFT Join OdemeTuru ot
                                On t.OdemeTuruID=ot.OdemeID
                                LEFT Join Kasalar k
                                On t.KasaID=k.KasaID
                                LEFT Join Bankalar b
                                ON t.BankaID=b.BankaID

                                Where t.Tarih>=@tarih1 AND t.tarih < DATEADD(DAY,1,@tarih2)";

        string sqlCariKod = @"Select t.TahsilatID as[Tahsilat No],t.FaturaNo as[Fatura No],c.Carikod as[Cari Kod], c.CariAdi as[Ad Soyad]
                                ,t.Tutar, t.Tarih, ot.OdemeAD as[Ödeme Türü], k.KasaAdi as [Kasa], b.BankaAd as [Banka]
                                ,t.Aciklama as [Açıklama]
                                From Tahsilatlar t
                                LEFT Join Cari c
                                On t.CariID=c.CariID
                                LEFT Join OdemeTuru ot
                                On t.OdemeTuruID=ot.OdemeID
                                LEFT Join Kasalar k
                                On t.KasaID=k.KasaID
                                LEFT Join Bankalar b
                                ON t.BankaID=b.BankaID
Where c.CariKod LIKE @cariKod";

        //************************METHOTLAR******************************************************

        private void TumKayitlariListele()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();


                SqlDataAdapter da = new SqlDataAdapter(sqlTumKayitlar, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tahsilatlar Listelenirken Bir Hata Oluştu.. " + ex.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglanti.Close();
            }
        }
        private void FaturaNoListele()
        {
            string arananNo = txtFaturaNo.Text.Trim();
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                
                SqlCommand kmt = new SqlCommand(sqlFaturano, baglanti);
                DataTable dt = new DataTable();
                kmt.Parameters.AddWithValue("@faturaNo", '%'+txtFaturaNo.Text+'%');

                SqlDataAdapter da = new SqlDataAdapter(kmt);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
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

        private void BugunListele()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();


                SqlCommand cmdBugun = new SqlCommand(sqlBugun, baglanti);
                cmdBugun.Parameters.AddWithValue("@tarih", Date1.Value.Date);
                SqlDataAdapter da = new SqlDataAdapter(cmdBugun);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tahsilatlar Listelenirken Bir Hata Oluştu.. " + ex.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void TahsilatNoListele()
        {
            try
            {
                
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
               
                SqlCommand cmdTahsilatNo = new SqlCommand(sqlTahsilatno, baglanti);
                cmdTahsilatNo.Parameters.AddWithValue("@tahsilatNo",'%'+ txtTahsilatNo.Text+'%');
                SqlDataAdapter da = new SqlDataAdapter(cmdTahsilatNo);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tahsilatlar Listelenirken Bir Hata Oluştu.. " + ex.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void IkiTarihArasiListele()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();


                SqlCommand cmdTarihler = new SqlCommand(sqlIkiTarihArasi, baglanti);
                cmdTarihler.Parameters.AddWithValue("@tarih1", SqlDbType.DateTime).Value=Date1.Value.Date;
                cmdTarihler.Parameters.AddWithValue("@tarih2", SqlDbType.DateTime).Value = Date2.Value.Date;

                SqlDataAdapter da = new SqlDataAdapter(cmdTarihler);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tahsilatlar Listelenirken Bir Hata Oluştu.. " + ex.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void AdSoyadListele()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();


                SqlCommand cmdAdsoyad = new SqlCommand(sqlAdaSoyad, baglanti);
                cmdAdsoyad.Parameters.AddWithValue("@adSoyad", '%'+txtCariAD.Text+'%');
                SqlDataAdapter da = new SqlDataAdapter(cmdAdsoyad);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tahsilatlar Listelenirken Bir Hata Oluştu.. " + ex.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


                SqlCommand cmdCarikod = new SqlCommand(sqlCariKod, baglanti);
                cmdCarikod.Parameters.AddWithValue("@carikod", '%' + txtCariKOD.Text + '%');
                SqlDataAdapter da = new SqlDataAdapter(cmdCarikod);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tahsilatlar Listelenirken Bir Hata Oluştu.. " + ex.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglanti.Close();
            }
        }
        

        

 

        private void TahsilatBilgileriniGonder(DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.Rows[e.RowIndex];
            string tahsilatID = satir.Cells["Tahsilat No"].Value.ToString();
            string faturaNo = satir.Cells["Fatura No"].Value.ToString();
            if(baglanti.State == ConnectionState.Closed)
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("select CariID From Cari where CariKod = @cariKod",baglanti);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@cariKod", satir.Cells["Cari Kod"].Value.ToString());
            SqlDataReader dr = cmd.ExecuteReader();
            
            string cariID=null;
            if(dr.Read())
            {
                cariID = dr["CariID"].ToString();
            }
            dr.Close();

            string cariKod = satir.Cells["Cari Kod"].Value.ToString();
            string cariAd = satir.Cells["Ad Soyad"].Value.ToString();
            string tutar = satir.Cells["Tutar"].Value.ToString();
            string tarih = satir.Cells["Tarih"].Value.ToString();
            string odemeTuru = satir.Cells["Ödeme Türü"].Value.ToString();
            string kasaID = satir.Cells["Kasa"].Value.ToString();
            string bankaID = satir.Cells["Banka"].Value.ToString();
            string aciklama = satir.Cells["Açıklama"].Value.ToString();

            TahsilatIdGonder = tahsilatID;
            FaturaNoGonder = faturaNo;
            CariIdGonder = cariID;
            CariKodGonder = cariKod;
            CariAdGonder=cariAd;
            TutarGonder = tutar;
            TarihGonder = tarih;
            OdemeTuruGoner = odemeTuru;
            KasaIdGonder = kasaID;
            BankaIdGonder = bankaID;
            AciklamaGonder = aciklama;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                TahsilatBilgileriniGonder(e);

                this.DialogResult = DialogResult.OK;
                this.Close();

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
        private void txtFaturaNo_TextChanged(object sender, EventArgs e)
        {
            
            FaturaNoListele();
        }

        private void txtCariAD_TextChanged(object sender, EventArgs e)
        {
            
            AdSoyadListele();
        }

        private void txtCariKOD_TextChanged(object sender, EventArgs e)
        {
            
            CariKodListele();
        }

        private void txtTahsilatNo_TextChanged(object sender, EventArgs e)
        {
            
            TahsilatNoListele();
        }

        private void btnSifirla_Click(object sender, EventArgs e)
        {
            txtCariAD.Clear();
            txtCariKOD.Clear() ;
            txtTahsilatNo.Clear() ;
            txtFaturaNo.Clear() ;
            Date1.Value= DateTime.Now;
            Date2.Value = DateTime.Now;
            BugunListele();
            
        }
    }
}
