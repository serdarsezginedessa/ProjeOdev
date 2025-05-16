using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kobi_v1
{
    public partial class FrmSatisHareketleri : Form
    {
        
        public FrmSatisHareketleri()
        {
            InitializeComponent();

            ListeleBugun();
            
        }
        public Form CagrilanForm { get; set; }
        private static string connectionString=ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);

        private void ListeleBugun()
        {
            string sqlListele = @"SELECT Convert(DATE, si.SatisTarihi) as [Fatura Tarihi]					
																		
				,si.satisID as [Satış No],si.FaturaNo as [Fatura No]
                ,c.CariKod [Cari Kod]
				,c.cariAdi [Ad Soyad]
                ,si.Durum
							                                            

                From SatisIslemleri as si
                                                                        
                LEFT Join Cari as c
                On si.CariID=c.CariID
                LEFT Join SatisFaturaNo as f            
                On si.FaturaNo=f.FaturaID

			Where CONVERT(DATE,(si.SatisTarihi)) between CONVERT(DATE,@tarih1) and CONVERT(DATE,@tarih2)                                                                    
			Group By si.SatisID,si.SatisTarihi, si.FaturaNo, c.CariKod,c.CariAdi,si.durum
																	
            Order BY si.FaturaNo DESC ";
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                SqlDataAdapter da = new SqlDataAdapter(sqlListele, baglanti);
                da.SelectCommand.Parameters.AddWithValue("@tarih1", DateTime.Now.Date);
                da.SelectCommand.Parameters.AddWithValue("@tarih2", DateTime.Now.Date);
                DataTable dt = new DataTable();
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
        private void ListeleCariKod()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                string sqlListele = @"SELECT Convert(DATE, si.SatisTarihi) as [Fatura Tarihi]					
																		
				                        ,si.satisID as [Satış No],si.FaturaNo as [Fatura No]
                                        ,c.CariKod [Cari Kod]
				                        ,c.cariAdi [Ad Soyad]
                                        ,si.Durum
							                                            

                                        From SatisIslemleri as si
                                                                        
                                        LEFT Join Cari as c
                                        On si.CariID=c.CariID
                                        LEFT Join SatisFaturaNo as f            
                                        On si.FaturaNo=f.FaturaID

										Where c.CariKod like @cariKod
                                        Group By si.SatisID,si.SatisTarihi, si.FaturaNo, c.CariKod,c.CariAdi, si.Durum
                                        Order BY si.FaturaNo DESC  ";

                SqlCommand kmt = new SqlCommand(sqlListele, baglanti);
                DataTable dt = new DataTable();
                kmt.Parameters.AddWithValue("@cariKod", "%" + txtCariKOD.Text + "%");
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
        private void ListeleCariAd()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                string sqlListele = @"SELECT Convert(DATE, si.SatisTarihi) as [Fatura Tarihi]					
																		
				                        ,si.satisID as [Satış No],si.FaturaNo as [Fatura No]
                                        ,c.CariKod [Cari Kod]
				                        ,c.cariAdi [Ad Soyad]
                                        ,si.Durum
							                                            

                                        From SatisIslemleri as si
                                                                        
                                        LEFT Join Cari as c
                                        On si.CariID=c.CariID
                                        LEFT Join SatisFaturaNo as f            
                                        On si.FaturaNo=f.FaturaID

									    Where c.CariAdi like @cariAdi
                                        Group By si.satisID,si.SatisTarihi, si.FaturaNo, c.CariKod,c.CariAdi,si.Durum
                                        Order BY si.FaturaNo DESC ";

                SqlCommand kmt = new SqlCommand(sqlListele, baglanti);
                DataTable dt = new DataTable();
                kmt.Parameters.AddWithValue("@cariAdi", "%" + txtCariAD.Text + "%");
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
        private void ListeleFaturaNo()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                string sqlListele = @"SELECT Convert(DATE, si.SatisTarihi) as [Fatura Tarihi]					
																		
				                        ,si.satisID as [Satış No],si.FaturaNo as [Fatura No]
                                        ,c.CariKod [Cari Kod]
				                        ,c.cariAdi [Ad Soyad]
                                        ,si.Durum
							           
                                        From SatisIslemleri as si
                                                                        
                                        LEFT Join Cari as c
                                        On si.CariID=c.CariID
                                        LEFT Join SatisFaturaNo as f            
                                        On si.FaturaNo=f.FaturaID

							            Where si.FaturaNo like @faturaNo
                                        Group By si.satisID, si.SatisTarihi, si.FaturaNo, c.CariKod, c.CariAdi, si.Durum
                                        Order BY si.FaturaNo DESC  ";
                SqlCommand kmt = new SqlCommand(sqlListele, baglanti);
                DataTable dt = new DataTable();
                kmt.Parameters.AddWithValue("@faturaNo", "%" + txtFaturaNo.Text + "%");
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
        private void ListeleFaturaTarihhAraligi()
        {
            try
            {

                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                string sqlListele = @"SELECT Convert(DATE, si.SatisTarihi) as [Fatura Tarihi]					
																		
				                        ,si.satisID as [Satış No],si.FaturaNo as [Fatura No]
                                        ,c.CariKod [Cari Kod]
				                        ,c.cariAdi [Ad Soyad]
                                        ,si.Durum

                                        From SatisIslemleri as si
                                                                        
                                        LEFT Join Cari as c
                                        On si.CariID=c.CariID
                                        LEFT Join SatisFaturaNo as f            
                                        On si.FaturaNo=f.FaturaID

										Where si.SatisTarihi between @tarih1 and @tarih2
                                        Group By si.SatisID,si.SatisTarihi, si.FaturaNo, c.CariKod,c.CariAdi,si.Durum
                                        Order BY si.FaturaNo DESC  ";

                SqlCommand kmt = new SqlCommand(sqlListele, baglanti);
                DataTable dt = new DataTable();
                kmt.Parameters.AddWithValue("@tarih1", Date1.Value.Date);
                kmt.Parameters.AddWithValue("@tarih2", Date2.Value.Date);
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
        private void ListeleTumKayitlar()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                string sqlListele = @"SELECT Convert(DATE, si.SatisTarihi) as [Fatura Tarihi]					
																		
				                        ,si.satisID as [Satış No],si.FaturaNo as [Fatura No]
                                        ,c.CariKod [Cari Kod]
				                        ,c.cariAdi [Ad Soyad]
                                        ,si.Durum
							                                
                                        From SatisIslemleri as si
                                                                        
                                        LEFT Join Cari as c
                                        On si.CariID=c.CariID
                                        LEFT Join SatisFaturaNo as f            
                                        On si.FaturaNo=f.FaturaID

                                        Group By si.satisID,si.SatisTarihi, si.FaturaNo, c.CariKod,c.CariAdi,si.Durum
                                        Order BY si.FaturaNo DESC  ";
                SqlCommand kmt = new SqlCommand(sqlListele, baglanti);
                DataTable dt = new DataTable();
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
        

        private void txtCariKOD_TextChanged(object sender, EventArgs e)
        {
            ListeleCariKod();
        }

        private void txtCariAD_TextChanged(object sender, EventArgs e)
        {
            ListeleCariAd();
        }

        private void txtFaturaNo_TextChanged(object sender, EventArgs e)
        {
            ListeleFaturaNo();
        }

        private void btnTarihFiltrele_Click(object sender, EventArgs e)
        {

            if (checkBoxTarihFiltresi.Checked == true)
            {
                ListeleFaturaTarihhAraligi();
            }
            else
            {
                ListeleTumKayitlar();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow satir = dataGridView1.Rows[e.RowIndex];
                string satisId = satir.Cells["Satış No"].Value.ToString();
                string faturaTarihi = satir.Cells["Fatura Tarihi"].Value.ToString();
                string faturaNo = satir.Cells["Fatura No"].Value.ToString();
                string cariKod = satir.Cells["Cari Kod"].Value.ToString();
                string cariAd = satir.Cells["Ad Soyad"].Value.ToString();
                /*string kdvMatrahi = satir.Cells["Kdv Matrahı"].Value.ToString();
                string kdvTutari = satir.Cells["Kdv Tutarı"].Value.ToString();
                string tutar = satir.Cells["Tutar"].Value.ToString();
                string genelToplam = satir.Cells["Genel Toplam"].Value.ToString();
                string tahsilat = satir.Cells["Tahsilat"].Value.ToString();*/
                

                if (CagrilanForm is FrmSatis)
                {
                    var hedefForm =  CagrilanForm as FrmSatis;
                    hedefForm.SatisBigileriYukle(satir,satisId,faturaTarihi, faturaNo, cariKod, cariAd/*,kdvMatrahi,kdvTutari,tutar,genelToplam,tahsilat*/);

                    this.Close();
                }
                else
                {
                    return;
                }

            }
            
        }

        private void checkBoxTarihFiltresi_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxTarihFiltresi.Checked != true)
            {
                ListeleTumKayitlar();
            }
            else
            {
                ListeleFaturaTarihhAraligi();
            }

        }

        private void btnSifirla_Click(object sender, EventArgs e)
        {
            txtCariAD.Clear();
            txtCariKOD.Clear();
            txtFaturaNo.Clear();
            Date1.Value = DateTime.Now;
            Date2.Value = DateTime.Now;
            checkBoxTarihFiltresi.Checked = true;
            ListeleBugun();
        }

        private void FrmSatisHareketleri_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
