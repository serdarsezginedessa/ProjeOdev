﻿using System;
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
    public partial class FrmGelirGiderTipEkle : Form
    {
        public FrmGelirGiderTipEkle()
        {
            InitializeComponent();
        }
        static string connectionString = ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                SqlCommand kmt = new SqlCommand("INSERT INTO GelirGiderTipi (Ad) VALUES (@ad)", baglanti);
                kmt.Parameters.AddWithValue("@ad", txtAd.Text);
                kmt.ExecuteNonQuery();
                MessageBox.Show("Gelir Gider  Türü Eklendi");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
                this.Hide();
            }
        }

        private void btniptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
