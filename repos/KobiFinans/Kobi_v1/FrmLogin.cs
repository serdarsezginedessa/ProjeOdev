﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Kobi_v1
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        static string connectionString=ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);
        string rol;

        private void btnGiris_Click(object sender, EventArgs e)
        {
            if(baglanti.State == ConnectionState.Closed)baglanti.Open();
            string sorgu ="Select Rol from Kullanici where KullaniciAdi=@KullaniciAdi and Sifre=@Sifre";
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@KullaniciAdi",txtKullaniciAdi.Text);
            komut.Parameters.AddWithValue("@Sifre",txtSifre.Text);
            
            var result = komut.ExecuteScalar();
            if(result != null)
            {
                rol = result.ToString();
                if (rol == "Admin")
                MessageBox.Show("Yönetici Olarak Oturum Açtınız","Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (rol == "Kullanici")
                    MessageBox.Show("Kullanıcı Olarak Oturum Açtınız", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                FrmAnaMenu anaMenu = new FrmAnaMenu(rol);
                anaMenu.ShowDialog();
                this.Close();

}
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Yanlış", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_iptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
