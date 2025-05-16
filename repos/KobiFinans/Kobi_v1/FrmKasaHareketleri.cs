using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;


using System.IO;
using IContainer = QuestPDF.Infrastructure.IContainer;



namespace Kobi_v1
{
    public partial class FrmKasaHareketleri : Form
    {
        private KasaHareketleriRepository _repository;
        public FrmKasaHareketleri()
        {
            InitializeComponent();
            _repository = new KasaHareketleriRepository(ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString);
            KasalariYukle();
            HareketTipleriYukle();

        }

        PrintDocument printDocument = new PrintDocument();
        PrintPreviewDialog previewDialog = new PrintPreviewDialog();
        private int seciliSatir = 0;

        private void PrintDataGridView()
        {
            seciliSatir = 0;
            printDocument.PrintPage += PrintDocument_PrintPage;

            printDocument.EndPrint += (s, args) =>
            {
                MessageBox.Show("Yazdırma işlemi tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };


            // Yazıcı seçimi için dialog
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print(); // Direkt yazdır
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font fontBaslik = new Font("Arial", 12, FontStyle.Bold);
            Font font = new Font("Arial", 8);
            float lineHeight = font.GetHeight(e.Graphics) + 15;
            float x = 20;
            float y = 70;

            // Başlık
            string baslik = "Kasa Hareketleri";
            SizeF baslikSize = e.Graphics.MeasureString(baslik, fontBaslik);
            float centerX = (e.MarginBounds.Width - baslikSize.Width) / 2 + e.MarginBounds.Left;
            e.Graphics.DrawString(baslik, fontBaslik, Brushes.Red, centerX, 20);

            e.Graphics.DrawString("Tarih: " + DateTime.Now.ToString("dd/MM/yyyy"), font, Brushes.Black, 20, 50);

            e.Graphics.DrawLine(Pens.Black, 20, 65, 800, 65); // Çizgi
            // Sütun başlıkları
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                e.Graphics.DrawString(dataGridView1.Columns[i].HeaderText, fontBaslik, Brushes.Green, x, y);
                x += dataGridView1.Columns[i].Width / 2;
            }

            y += lineHeight;
            x = 50;

            // Satırlar
            while (seciliSatir < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[seciliSatir];
                if (row.IsNewRow) break;

                x = 20;
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {

                    if (i == 1)
                    {
                        // Cari adı formatlama uzunluk sınırı ayarlandı
                        string text = row.Cells[i].Value?.ToString() ?? "";
                        if (text.Length > 20)
                        {
                            text = text.Substring(0, 20) + "...";
                        }
                        e.Graphics.DrawString(text, font, Brushes.Black, x, y);
                        x += dataGridView1.Columns[i].Width / 2;
                        continue;
                    }

                    // Tarih formatlama saat bölümü kırpıldı
                    if (i == 3)
                    {
                        DateTime tarih = Convert.ToDateTime(row.Cells[i].Value);
                        string formattedDate = tarih.ToString("dd/MM/yyyy");
                        e.Graphics.DrawString(formattedDate, font, Brushes.Black, x, y);
                        x += dataGridView1.Columns[i].Width / 2;

                    }
                    else
                    {
                        string text = row.Cells[i].Value?.ToString() ?? "";
                        e.Graphics.DrawString(text, font, Brushes.Black, x, y);
                        e.Graphics.DrawLine(Pens.LightGray, x, y + 15, 800, y + 15);// Satır arası çizgi
                        x += dataGridView1.Columns[i].Width / 2;

                    }

                }

                y += lineHeight;
                seciliSatir++;

                // Sayfa dolduysa, diğer sayfa için tekrar çağırılacak
                if (y + lineHeight > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            // Tüm satırlar bitti
            e.HasMorePages = false;
        }

        private void ExportToExcel(DataGridView dgv)
        {
            using (SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Excel Dosyası|*.xlsx",
                Title = "Excel Dosyası Kaydet",
                FileName = "KasaHareketleri.xlsx"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Excel.Application excelApp = new Excel.Application();
                    Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                    Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];
                    worksheet.Name = "KasaHareketleri";

                    // Sütun başlıkları
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1] = dgv.Columns[i].HeaderText.ToUpper();
                    }

                    // Veriler
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgv.Columns.Count; j++)
                        {
                            worksheet.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j].Value?.ToString();
                        }
                    }

                    try
                    {
                        workbook.SaveAs(sfd.FileName);
                        workbook.Close();
                        excelApp.Quit();
                        MessageBox.Show("Excel dosyası başarıyla kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Dosya kaydedilirken hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        // COM objelerini serbest bırakmak için
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                    }
                }
            }
        }

        private void ExportToPdf(DataGridView dgv)
        {
            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("Tabloda kayıt bulunamadı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF Dosyası|*.pdf";
                saveFileDialog.Title = "PDF Kaydet";
                saveFileDialog.FileName = "KasaHareketleri.pdf";

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return; // Kaydetme iptal edildi

                string filePath = saveFileDialog.FileName;

                var columnCount = dgv.Columns.Count;

                var document = Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Margin(20);
                        page.Size(PageSizes.A4);
                        page.PageColor(Colors.White);
                        page.DefaultTextStyle(x => x.FontSize(12));

                        page.Header()
                            .Text("Kasa Hareketleri Raporu")
                            .SemiBold().FontSize(16).FontColor(Colors.Blue.Medium);

                        page.Content()
                            .Table(table =>
                            {
                                // Burada ColumnsDefinition sadece 1 kere çağrılır
                                table.ColumnsDefinition(columns =>
                                {
                                    for (int i = 0; i < columnCount; i++)
                                        columns.RelativeColumn();
                                });

                                // Başlık hücreleri
                                table.Header(header =>
                                {
                                    for (int i = 0; i < columnCount; i++)
                                    {
                                        header.Cell().Background(Colors.Grey.Lighten2).Padding(5)
                                              .Text(dgv.Columns[i].HeaderText)
                                              .SemiBold();
                                    }
                                });

                                // Satır verileri
                                foreach (DataGridViewRow row in dgv.Rows)
                                {
                                    if (row.IsNewRow) continue;

                                    for (int i = 0; i < columnCount; i++)
                                    {
                                        string cellText = row.Cells[i].Value?.ToString() ?? "";
                                        table.Cell().Padding(5).Text(cellText);
                                    }
                                }
                            });

                        page.Footer()
                                .AlignCenter()
                                .Text("Kasa Hareketleri Raporu");
                    });
                });

                // PDF'yi diske kaydet
                document.GeneratePdf(filePath);

                MessageBox.Show($"PDF başarıyla kaydedildi:\n{filePath}", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void FrmKasaHareketleri_Load(object sender, EventArgs e)
        {
            dtHeader();
            BugunRapor();

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
            baglanti.Close();
            HesaplaGelirGider();
        }
        private void BugunRapor()
        {
            /*  if (baglanti.State == ConnectionState.Closed) baglanti.Open();
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
              da.Fill(dt);*/

            var dt = _repository.GetBugunRapor(Date1.Value.Date);

            dataGridView1.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                dataGridView1.Rows.Add(row.ItemArray);
            }
            HesaplaGelirGider();

        }

        /*        private void gelirToplam()
                {
                    if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                    string sorgu = "Select Sum(Tutar) From KasaHareketleri where HareketTipi='Gelir' OR HareketTipi='Tahsilat'";
                    SqlCommand kmt = new SqlCommand(sorgu, baglanti);
                    txtGelirTop.Text = kmt.ExecuteScalar().ToString();
                    baglanti.Close();
                }

                private void gelirToplam1()
                {
                    if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                    string sorgu = @"SELECT SUM(Tutar) 
                                    FROM KasaHareketleri 
                                    WHERE (HareketTipi = 'Gelir' OR HareketTipi = 'Tahsilat') 
                                    AND CAST(Tarih AS DATE) BETWEEN @tarih1 AND @tarih2";
                    SqlCommand kmt = new SqlCommand(sorgu, baglanti);
                    kmt.Parameters.AddWithValue("@tarih1", Date1.Value.Date);
                    kmt.Parameters.AddWithValue("@tarih2", Date2.Value.Date);
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

                private void giderToplam2()
                {
                    if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                    string sorgu = @"SELECT SUM(Tutar) 
                                        FROM KasaHareketleri 
                                        WHERE HareketTipi = 'Gider' 
                                        AND CAST(Tarih AS DATE) BETWEEN @tarih1 AND @tarih2";

                    SqlCommand kmt = new SqlCommand(sorgu, baglanti);
                    kmt.Parameters.AddWithValue("@tarih1", Date1.Value.Date);
                    kmt.Parameters.AddWithValue("@tarih2", Date2.Value.Date);
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

                }*/

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
            var hareketTipleri = new List<string>
            {
                "Gelir",
                "Gider",
                "Tahsilat"
            };
            comboGiderTuru.DataSource = null; // Önce mevcut veri kaynağını temizle
            comboGiderTuru.DataSource = hareketTipleri;


            comboGiderTuru.SelectedIndex = -1;

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
                                WHERE kh.Tarih >= @tarih1 AND kh.Tarih <= DATEADD(SECOND, -1, DATEADD(DAY, 1, @tarih2))
";
            SqlCommand cmd = new SqlCommand(sorgu, baglanti);
            cmd.Parameters.AddWithValue("@tarih1", Date1.Value.Date);
            cmd.Parameters.AddWithValue("@tarih2", Date2.Value.Date);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                dataGridView1.Rows.Add(row.ItemArray);
            }
            if (baglanti.State == ConnectionState.Open) baglanti.Close();
            HesaplaGelirGider();
        }



        private void HesaplaGelirGider()
        {
            decimal toplamGelir = 0;
            decimal toplamGider = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue; // Yeni satırı atla

                string hareketTipi = row.Cells["kh.HareketTipi"].Value?.ToString();
                decimal tutar;

                if (decimal.TryParse(row.Cells["kh.Tutar"].Value?.ToString(), out tutar))
                {
                    if (hareketTipi == "Gelir" || hareketTipi == "Tahsilat")
                        toplamGelir += tutar;
                    else if (hareketTipi == "Gider")
                        toplamGider += tutar;
                }
            }

            txtGelirTop.Text = toplamGelir.ToString("N2");
            txtGiderTop.Text = toplamGider.ToString("N2");
            txtGenelTop.Text = (toplamGelir - toplamGider).ToString("N2");
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
            HesaplaGelirGider();
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
            HesaplaGelirGider();
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
                HesaplaGelirGider();

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
            HesaplaGelirGider();

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
                HesaplaGelirGider();
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
            HesaplaGelirGider();

        }

        private void Date1_ValueChanged(object sender, EventArgs e)
        {
            IkiTarihArasiRapor();
            HesaplaGelirGider();
        }

        private void Date2_ValueChanged(object sender, EventArgs e)
        {
            IkiTarihArasiRapor();
            HesaplaGelirGider();
        }

        private void FrmKasaHareketleri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void BtnYazdir_Click(object sender, EventArgs e)
        {

            PrintDataGridView();
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel(dataGridView1);
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            ExportToPdf(dataGridView1);
        }
    }
}
