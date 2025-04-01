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
    public partial class FrmKullanicilar : Form
    {
        public FrmKullanicilar()
        {
            InitializeComponent();
        }
        static string laptopConStr = "Data Source=DESKTOP-NFG00P8\\SQLEXPRESS;Initial Catalog=KobiFinans;Integrated Security=True";
        static string dukkanConStr = "Data Source=EDESSASERDAR\\SQLEXPRESS;Initial Catalog=KobiFinans;Integrated Security=True";
        SqlConnection baglanti = new SqlConnection(laptopConStr);
        public int kullaniciID
        { 
            get { return Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value); }
            set { kullaniciID = value; }
        }

        private void KullaniciListele()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                string sorgu = "Select * From Kullanici";
                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[1].HeaderText = "Kullanıcı Adı";
                dataGridView1.Columns[2].HeaderText = "Şifre";
                dataGridView1.Columns[3].HeaderText = "Rol";
                //dataGridView1.DefaultCellStyle.BackColor = Color.Coral;
                //dataGridView1.DefaultCellStyle.ForeColor = Color.WhiteSmoke; 
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

        private void FrmKullanicilar_Load(object sender, EventArgs e)
        {
            KullaniciListele();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmKullaniciEkle frmKullaniciEkle = new FrmKullaniciEkle();
            frmKullaniciEkle.ShowDialog();
            KullaniciListele();

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            string sorgu = "Delete From Kullanici where KullaniciID=@Id";
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                SqlCommand kmta= new SqlCommand("Select rol from kullanici", baglanti);
                var rol=kmta.ExecuteScalar().ToString();
                if (dataGridView1.CurrentRow.Cells[3].Value.ToString() == "Admin")
                {
                    MessageBox.Show("Admin Kullanıcısını Silemezsiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    var result = MessageBox.Show(dataGridView1.CurrentRow.Cells[1].Value.ToString() + " Kullanıcısını Silmek İstediğinize Emin Misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        SqlCommand kmt = new SqlCommand(sorgu, baglanti);
                        kmt.Parameters.AddWithValue("@Id", dataGridView1.CurrentRow.Cells[0].Value);
                        kmt.ExecuteNonQuery();
                        MessageBox.Show("Silme İşlemi Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        KullaniciListele();
                    }
                    else
                    {
                        return;
                    }
                }
                baglanti.Close();
                
                

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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null){
                string kad = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                string sifre = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                string rol = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                FrmKullaniciGuncelle frmKullaniciGuncelle = new FrmKullaniciGuncelle();
                frmKullaniciGuncelle.kad = kad;
                frmKullaniciGuncelle.sifre = sifre;
                frmKullaniciGuncelle.rol = rol;
                frmKullaniciGuncelle.buttonImage= Properties.Resources.editUser;
                frmKullaniciGuncelle.Text = "Kullanıcı Güncelle";
                frmKullaniciGuncelle.ShowDialog();
                KullaniciListele();




            }
            
            


        }
    }
}
