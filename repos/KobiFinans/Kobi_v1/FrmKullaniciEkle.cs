using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kobi_v1
{
    public partial class FrmKullaniciEkle : Form
    {
        public FrmKullaniciEkle()
        {
            InitializeComponent();
           
        }
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
            get { return btnEkle.Text; }
            set { btnEkle.Text = value; }
        }
        public object buttonImage
        {
            get { return btnEkle.Image; }
            set { btnEkle.Image = (Image)value; }
        }
        
        static string laptopConStr = "Data Source=DESKTOP-NFG00P8\\SQLEXPRESS;Initial Catalog=KobiFinans;Integrated Security=True";
        static string dukkanConStr = "Data Source=EDESSASERDAR\\SQLEXPRESS;Initial Catalog=KobiFinans;Integrated Security=True";
        SqlConnection baglanti = new SqlConnection(laptopConStr);
        

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        void ekle()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                string sorgu = "insert into Kullanici (KullaniciAdi, Sifre, Rol) values (@user,@pass,@rol)";
                SqlCommand kmt = new SqlCommand(sorgu, baglanti);
                kmt.Parameters.AddWithValue("@user", textBox1.Text);
                kmt.Parameters.AddWithValue("@pass", textBox2.Text);
                kmt.Parameters.AddWithValue("@rol", comboBox1.Text);
                kmt.ExecuteNonQuery();
                MessageBox.Show("Kullanıcı Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
                textBox2.Clear();
                comboBox1.Text = "";
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
        public void guncelle()
        {
            try
            {
                FrmKullanicilar frmKullanicilar = new FrmKullanicilar();
                int id = frmKullanicilar.kullaniciID;
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                string sorgu = "update Kullanici set KullaniciAdi=@user, Sifre=@pass, Rol=@rol where KullaniciID=@Id";
                SqlCommand kmt = new SqlCommand(sorgu, baglanti);
                kmt.Parameters.AddWithValue("@user", textBox1.Text);
                kmt.Parameters.AddWithValue("@pass", textBox2.Text);
                kmt.Parameters.AddWithValue("@rol", comboBox1.Text);

                kmt.Parameters.AddWithValue("@Id", Convert.ToInt32(id));
                kmt.ExecuteNonQuery();
                MessageBox.Show("Kullanıcı Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
                textBox2.Clear();
                comboBox1.Text = "";
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
        private void btnEkle_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}
