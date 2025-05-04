using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kobi_v1
{
    public partial class FrmKasaHareketleri : Form
    {
        public FrmKasaHareketleri()
        {
            InitializeComponent();
            KasalariYukle();
            HareketTipleriYukle();

        }
        private void FrmKasaHareketleri_Load(object sender, EventArgs e)
        {
            dtHeader();
            BugunRapor();
            gelirToplam();
            giderToplam();
            toplamBakiye();
        }
        static string connectionString = ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);

        private void dtHeader()
        {
            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("kh.HareketID", "İşlem No");
                dataGridView1.Columns.Add("c.CariAdi", "Cari");
                dataGridView1.Columns.Add("k.kasaadi", "Kasa");
                dataGridView1.Columns.Add("kh.Tarih", "Tarih");
                dataGridView1.Columns.Add("kh.HareketTipi", "Gelir/Gider");
                dataGridView1.Columns.Add("kh.Aciklama", "Açıklama");
                dataGridView1.Columns.Add("kh.Tutar", "Tutar");
            }

        }

        private void TumRapor()
        {
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();
            string sorgu = @"Select kh.HareketID, c.CariAdi, k.kasaadi,kh.Tarih, 
                                                            kh.HareketTipi,kh.Aciklama,kh.Tutar
                                                            from KasaHareketleri kh
                                                            INNER JOIN
                                                            Kasalar k
                                                            ON
                                                            kh.KasaID=k.KasaID
                                                            INNER JOIN
                                                            Cari c
                                                            ON
                                                            kh.CariID=c.CariID";
            SqlCommand cmd = new SqlCommand(sorgu, baglanti);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                dataGridView1.Rows.Add(row.ItemArray);
            }
        }
        private void BugunRapor()
        {
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();
            string sorgu = @"Select kh.HareketID, c.CariAdi, k.kasaadi,kh.Tarih, 
                                                            kh.HareketTipi,kh.Aciklama,kh.Tutar
                                                            from KasaHareketleri kh
                                                            INNER JOIN
                                                            Kasalar k
                                                            ON
                                                            kh.KasaID=k.KasaID
                                                            INNER JOIN
                                                            Cari c
                                                            ON
                                                            kh.CariID=c.CariID
                                WHERE kh.Tarih >= @tarih AND kh.Tarih < DATEADD(DAY, 1, @tarih)";
            SqlCommand cmd = new SqlCommand(sorgu, baglanti);
            cmd.Parameters.AddWithValue("@tarih", Date1.Value.Date);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                dataGridView1.Rows.Add(row.ItemArray);
            }

        }

        private void gelirToplam()
        {
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();
            string sorgu = "Select Sum(Tutar) From KasaHareketleri where HareketTipi='Gelir' OR HareketTipi='Tahsilat'";
            SqlCommand kmt = new SqlCommand(sorgu, baglanti);
            txtGelirTop.Text = kmt.ExecuteScalar().ToString();
            baglanti.Close();
        }
        private void giderToplam()
        {
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();
            string sorgu = "Select Sum(Tutar) From KasaHareketleri where HareketTipi='Gider'";
            SqlCommand kmt = new SqlCommand(sorgu, baglanti);
            txtGiderTop.Text = kmt.ExecuteScalar().ToString();
            baglanti.Close();
        }
        private void toplamBakiye()
        {
            if ((string.IsNullOrEmpty(txtGelirTop.Text) || (string.IsNullOrEmpty(txtGiderTop.Text))))
            {
                txtGenelTop.Text = "0";
            }
            else
            {
                txtGenelTop.Text = (Convert.ToDecimal(txtGelirTop.Text) - Convert.ToDecimal(txtGiderTop.Text)).ToString();

            }

        }

        private void KasalariYukle()
        {
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();
            SqlCommand kmt = new SqlCommand("Select * from Kasalar", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(kmt);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBoxKasa.DataSource = dt;
            comboBoxKasa.DisplayMember = "KasaAdi";
            comboBoxKasa.ValueMember = "KasaID";
            comboBoxKasa.SelectedIndex = -1;
            baglanti.Close();
        }
        private void HareketTipleriYukle()
        {
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();
            SqlCommand kmt = new SqlCommand("Select HareketTipi from KasaHareketleri", baglanti);
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                comboGiderTuru.Items.Add(dr["HareketTipi"].ToString());
            }


            comboGiderTuru.SelectedIndex = -1;
            baglanti.Close();
        }
        private void IkiTarihArasiRapor()
        {
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();
            string sorgu = @"Select kh.HareketID, c.CariAdi, k.kasaadi,kh.Tarih, 
                                                            kh.HareketTipi,kh.Aciklama,kh.Tutar
                                                            from KasaHareketleri kh
                                                            INNER JOIN
                                                            Kasalar k
                                                            ON
                                                            kh.KasaID=k.KasaID
                                                            INNER JOIN
                                                            Cari c
                                                            ON
                                                            kh.CariID=c.CariID
                                WHERE kh.Tarih >= @tarih1 AND kh.Tarih < DATEADD(DAY, 1, @tarih2)";
            SqlCommand cmd = new SqlCommand(sorgu, baglanti);
            cmd.Parameters.AddWithValue("@tarih1", Date1.Value);
            cmd.Parameters.AddWithValue("@tarih2", Date2.Value);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                dataGridView1.Rows.Add(row.ItemArray);
            }
        }


        private void txtCariAD_TextChanged(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();
            SqlCommand kmt = new SqlCommand(@"Select kh.HareketID, c.CariAdi, k.kasaadi,kh.Tarih, 
                                                            kh.HareketTipi,kh.Aciklama,kh.Tutar
                                                            from KasaHareketleri kh
                                                            INNER JOIN
                                                            Kasalar k
                                                            ON
                                                            kh.KasaID=k.KasaID
                                                            INNER JOIN
                                                            Cari c
                                                            ON
                                                            kh.CariID=c.CariID
                                                            where c.CariAdi like @cariadi", baglanti);
            kmt.Parameters.AddWithValue("@cariadi", '%' + txtCariAD.Text + "%");
            SqlDataAdapter da = new SqlDataAdapter(kmt);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                dataGridView1.Rows.Add(row.ItemArray);
            }
            baglanti.Close();
        }

        private void txtislemNo_TextChanged(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();
            SqlCommand kmt = new SqlCommand(@"Select kh.HareketID, c.CariAdi, k.kasaadi,kh.Tarih, 
                                                            kh.HareketTipi,kh.Aciklama,kh.Tutar
                                                            from KasaHareketleri kh
                                                            INNER JOIN
                                                            Kasalar k
                                                            ON
                                                            kh.KasaID=k.KasaID
                                                            INNER JOIN
                                                            Cari c
                                                            ON
                                                            kh.CariID=c.CariID
                                                            where kh.HareketID like @islemno", baglanti);
            kmt.Parameters.AddWithValue("@islemno", '%' + txtislemNo.Text + "%");
            SqlDataAdapter da = new SqlDataAdapter(kmt);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                dataGridView1.Rows.Add(row.ItemArray);
            }
            baglanti.Close();
        }

        private void comboBoxKasa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();
            int kasaID;
            SqlCommand cmd;
            if (comboBoxKasa.SelectedValue != null && comboBoxKasa.SelectedValue.ToString() != "0")

            {
                if (comboBoxKasa.SelectedItem is DataRowView drv)
                {
                    kasaID = Convert.ToInt32(drv["KasaID"]);
                    // Filtrele
                    cmd = new SqlCommand(@"Select kh.HareketID, c.CariAdi, k.kasaadi,kh.Tarih, 
                                                            kh.HareketTipi,kh.Aciklama,kh.Tutar
                                                            from KasaHareketleri kh
                                                            INNER JOIN
                                                            Kasalar k
                                                            ON
                                                            kh.KasaID=k.KasaID
                                                            INNER JOIN
                                                            Cari c
                                                            ON
                                                            kh.CariID=c.CariID
                                                            WHERE k.KasaID = @kasaID", baglanti);

                    cmd.Parameters.AddWithValue("@kasaID", kasaID);

                }
                else
                {                     // Seçili öğe bir DataRowView değilse, varsayılan sorguyu kullan
                    cmd = new SqlCommand(@"Select kh.HareketID, c.CariAdi, k.kasaadi,kh.Tarih, 
                                                            kh.HareketTipi,kh.Aciklama,kh.Tutar
                                                            from KasaHareketleri kh
                                                            INNER JOIN
                                                            Kasalar k
                                                            ON
                                                            kh.KasaID=k.KasaID
                                                            INNER JOIN
                                                            Cari c
                                                            ON
                                                            kh.CariID=c.CariID", baglanti);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.Rows.Clear();
                dtHeader();
                foreach (DataRow row in dt.Rows)
                {
                    dataGridView1.Rows.Add(row.ItemArray);
                }
                baglanti.Close();
            }
        }

        private void comboGiderTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();

            SqlCommand cmd;

            cmd = new SqlCommand(@"Select kh.HareketID, c.CariAdi, k.kasaadi,kh.Tarih, 
                                                            kh.HareketTipi,kh.Aciklama,kh.Tutar
                                                            from KasaHareketleri kh
                                                            INNER JOIN
                                                            Kasalar k
                                                            ON
                                                            kh.KasaID=k.KasaID
                                                            INNER JOIN
                                                            Cari c
                                                            ON
                                                            kh.CariID=c.CariID
                                                            WHERE kh.HareketTipi = @hareket", baglanti);

            cmd.Parameters.AddWithValue("@hareket", comboGiderTuru.Text);


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.Rows.Clear();
            dtHeader();
            foreach (DataRow row in dt.Rows)
            {
                dataGridView1.Rows.Add(row.ItemArray);
            }

            baglanti.Close();

        }

        private void checkBoxTumKayitlar_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTumKayitlar.Checked)
            {
                TumRapor();
                comboBoxKasa.SelectedIndex = -1;
                comboGiderTuru.SelectedIndex = -1;
                txtislemNo.Clear();
                txtCariAD.Clear();
            }
            else
            {
                BugunRapor();
                comboBoxKasa.SelectedIndex = -1;
                comboGiderTuru.SelectedIndex = -1;
                txtislemNo.Clear();
                txtCariAD.Clear();
            }
        }

        private void btnSifirla_Click(object sender, EventArgs e)
        {
            TumRapor();
            comboBoxKasa.SelectedIndex = -1;
            comboGiderTuru.SelectedIndex = -1;
            txtislemNo.Clear();
            txtCariAD.Clear();
            checkBoxTumKayitlar.Checked = false;
            Date1.Value = DateTime.Now;
            Date2.Value = DateTime.Now;

        }

        private void Date1_ValueChanged(object sender, EventArgs e)
        {
            IkiTarihArasiRapor();
        }

        private void Date2_ValueChanged(object sender, EventArgs e)
        {
            IkiTarihArasiRapor();
        }
    }
}
