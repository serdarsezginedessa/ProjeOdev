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

        string sorguEkle = "INSERT INTO Cari (CariAdi, Telefon, Email, Adres, VergiNo, Borc, Alacak,CariTuru)  VALUES (@CariAdi, @Telefon, @Email, @Adres, @VergiNo, @Borc, @Alacak,@CariTuru)";
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
            cariTurListele();
        }

        private void combTur_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
        }
    }
}

