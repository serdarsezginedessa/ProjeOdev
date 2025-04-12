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
    public partial class FrmCariListele : Form
    {
        public FrmCariListele()
        {
            InitializeComponent();
        }
        

        static string connectionString = ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);
        string sorguListele = "Select * From Cari";
        string sorgu = "Select cariID From Cari where cariAdi=@cad";
        string sorguCari_Tur = @"Select 
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

        private void dtHeader()
        {
            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Clear();
                dataGridView1.AutoGenerateColumns = false; // Otomatik sütun oluşturmayı kapat
                                                           //dataGridView1.Columns.Add("ID", "Cari No");
                dataGridView1.Columns.Add("c.CariKod", "Cari Kodu");
                dataGridView1.Columns.Add("c.CariAdi", "Cari Adı");
                dataGridView1.Columns.Add("ct.Ad", -----------------------------------------------------------------------------------------**************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************---+--------------------------------------------------------------------------------------------------------------------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------+++++*-++*"Cari Turü");
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
                dataGridView1.DataSource = dt;
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
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // Geçerli bir hücre seçili mi?
                {
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }

        }
    }

}
