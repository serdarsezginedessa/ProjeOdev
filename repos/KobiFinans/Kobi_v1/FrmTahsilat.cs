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
    public partial class FrmTahsilat : Form
    {
        public FrmTahsilat()
        {
            InitializeComponent();
        }
        public int SatisID { get; set; }
        public int CariID { get; set; }
        public int KasaID { get; set; }
        public int BankaID { get; set; }

        public string OdemeYontemi { get; set; }

        public decimal ToplamTutar { get; set; }
        public string MusteriAdi { get; set; }


        string sqlKasaHareket = @"INSERT INTO KasaHareketleri
                                        (KasaID, CariID, Tarih, Tutar, Aciklama, HareketTipi)
                                         VALUES
                                        (@kasaID, @cariID, @tarih, @tutar, @aciklama, 'Tahsilat')";

        string sqlBankaHareket = @"INSERT INTO BankaHareketler
                                        (BankaID, CariID, Tarih, Tutar, Aciklama, HareketTipi, Kaynak)
                                        VALUES
                                        (@bankaID, @cariID, @tarih, @tutar, @aciklama, 'Banka Tahsilat', 'Satış Ekranı')";


      /*  if (odemeYontemi == "Kasa")
{
    SqlCommand cmd = new SqlCommand("INSERT INTO KasaHareketleri (KasaID, CariID, Tarih, Tutar, Aciklama, HareketTipi) VALUES (@kasaID, @cariID, @tarih, @tutar, @aciklama, 'Tahsilat')", baglanti);
        cmd.Parameters.AddWithValue("@kasaID", kasaID);
    cmd.Parameters.AddWithValue("@cariID", cariID);
    cmd.Parameters.AddWithValue("@tarih", DateTime.Now);
    cmd.Parameters.AddWithValue("@tutar", tutar);
    cmd.Parameters.AddWithValue("@aciklama", "Satış ödemesi");
    cmd.ExecuteNonQuery();
}
else if (odemeYontemi == "Banka")
{
    SqlCommand cmd = new SqlCommand("INSERT INTO BankaHareketler (BankaID, CariID, Tarih, Tutar, Aciklama, HareketTipi, Kaynak) VALUES (@bankaID, @cariID, @tarih, @tutar, @aciklama, 'Banka Tahsilat', 'Satış Ekranı')", baglanti);
    cmd.Parameters.AddWithValue("@bankaID", bankaID);
    cmd.Parameters.AddWithValue("@cariID", cariID);
    cmd.Parameters.AddWithValue("@tarih", DateTime.Now);
    cmd.Parameters.AddWithValue("@tutar", tutar);
    cmd.Parameters.AddWithValue("@aciklama", "Satış ödemesi");
    cmd.ExecuteNonQuery();
}
      */

private void FrmTahsilat_Load(object sender, EventArgs e)
        {
            labelMusteri.Text = MusteriAdi;
            labelOdemeTutar.Text = ToplamTutar.ToString("C2"); // örnek: ₺1.000,00

            comboOdemeTuru.Items.AddRange(new string[] { "Nakit", "Kredi Kartı", "Havale", "Çek" });
            comboOdemeTuru.SelectedIndex = 0;

            dateTarih.Value = DateTime.Now;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtTutar.Text, out decimal odemeTutari))
            {
                string odemeTuru = comboOdemeTuru.SelectedItem.ToString();
                DateTime tarih = dateTarih.Value;
                string aciklama = txtAciklama.Text;

                // Burada veritabanına kayıt yapılacak - şimdilik mesajla görelim
                MessageBox.Show($"Tahsilat kaydedildi:\n\n" +
                                $"Satış ID: {SatisID}\n" +
                                $"Tutar: {odemeTutari:C2}\n" +
                                $"Tür: {odemeTuru}\n" +
                                $"Tarih: {tarih.ToShortDateString()}\n" +
                                $"Açıklama: {aciklama}");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir tutar giriniz.");
            }
        }
    }
}
