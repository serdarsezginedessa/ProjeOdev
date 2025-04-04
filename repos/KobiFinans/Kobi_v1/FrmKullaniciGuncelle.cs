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
    public partial class FrmKullaniciGuncelle : Form
    {
        public FrmKullaniciGuncelle()
        {
            InitializeComponent();
        }
        static string connectionString = ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);
        public string kad
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public string sifre
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }

        public string rol
        {
            get { return comboBox1.Text; }
            set { comboBox1.Text = value; }
        }
        public string buttonText
        {
            get { return btnGuncelle.Text; }
            set { btnGuncelle.Text = value; }
        }
        public object buttonImage
        {
            get { return btnGuncelle.Image; }
            set { btnGuncelle.Image = (Image)value; }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {if (baglanti.State == ConnectionState.Closed) baglanti.Open();
            string updateSorgu = "Update Kullanici set KullaniciAdi=@kad, Sifre=@Sifre, Rol=@Rol where KullaniciAdi=@kad";
            SqlCommand kmt = new SqlCommand(updateSorgu, baglanti);
            kmt.Parameters.AddWithValue("@kad", textBox1.Text);
            kmt.Parameters.AddWithValue("@Sifre", textBox2.Text);
            kmt.Parameters.AddWithValue("@Rol", comboBox1.Text);
            kmt.ExecuteNonQuery();
            MessageBox.Show("Güncelleme Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }
    }
}
