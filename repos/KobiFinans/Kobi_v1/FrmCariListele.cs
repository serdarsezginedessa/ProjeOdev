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
        string sorguListele = "Select * From Cari";
        string sorgu = "Select cariID From Cari where cariAdi=@cad";
        string sorguCari_Tur = @"Select 
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
		                            c.cariTuru = ct.ID";

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
            }
            
          
        }
        private void listele()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                SqlCommand kmt = new SqlCommand(sorguCari_Tur, baglanti);
                SqlDataAdapter da = new SqlDataAdapter(kmt);
                DataTable dt = new DataTable();
                da.Fill(dt);
                //dataGridView1.DataSource = dt;
                dataGridView1.Rows.Clear(); // Mevcut satırları temizleyin Manuel Eklediğim Başlıklar Bozulmuyor..
                foreach (DataRow row in dt.Rows)
                {
                    dataGridView1.Rows.Add(row.ItemArray); // Satırlar ekleniyor..
                }
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }


        private void FrmCariListele_Load(object sender, EventArgs e)
        {
            dtHeader();
            listele();
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
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

                //Hangi Formdan Geldiysek veriyi o forma gönderiyoruz.

                if(CagrilanForm is FrmCariEkle)
                {
                    var hedefForm= CagrilanForm as FrmCariEkle;
                    hedefForm.CariBilgileriYukle(cariID,cariKod,cariAdi, cariTur, yetkili, telefon, ePosta, adres, sehir, ulke, vergiDairesi, vergiNo, dogumTarihi, evlilikTarihi, kayitTarihi, durum, aciklama);

                }
                else
                {

                }
                this.Close();
            }
        }
    }

}
