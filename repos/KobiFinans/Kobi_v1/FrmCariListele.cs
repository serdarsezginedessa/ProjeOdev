using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common.CommandTrees.ExpressionBuilder;
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
        public Form CagrilanForm { get; set; }


        static string connectionString = ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);

        string sorguInnerJoin = @"Select 
                                    c.CariID,
                                    c.CariKod,
                                    c.CariAdi,
                                    ct.Ad AS CariTuru,
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
                                    c.Aciklama,
                                    c.Resim
		                            From cari as c
		                            INNER JOIN
		                            CariTuru as ct
		                            ON
		                            c.cariTuru = ct.ID";
        string sorguCariAd = @"SELECT 
                c.CariID,
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
                c.Aciklama,
                c.resim
		        From cari as c
		        INNER JOIN
		        CariTuru as ct
		        ON
		        c.cariTuru = ct.ID
				where c.cariAdi LIKE @cariAd";
        string sorguCariKod = @"SELECT 
                c.CariID,
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
                c.Aciklama,
                c.Resim
		        From cari as c
		        INNER JOIN
		        CariTuru as ct
		        ON
		        c.cariTuru = ct.ID
				where c.cariKod LIKE @cariKod";
        string sorguCariTur = @"SELECT 
                c.CariID,
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
                c.Aciklama,
                c.Resim
		        From cari as c
		        INNER JOIN
		        CariTuru as ct
		        ON
		        c.cariTuru = ct.ID
				where ct.Ad LIKE @cariTurAd";
        string sorguCariYetkili = @"SELECT 
                c.CariID,
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
                c.Aciklama,
                c.Resim
                From cari as c
                INNER JOIN
                CariTuru as ct
                ON
                c.cariTuru = ct.ID
                Where 
                c.Yetkili LIKE @yetkili";
        string sorguTelefon = @"Select 
                                    c.CariID,
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
                                    c.Aciklama,
                                    c.Resim
		                            From cari as c
		                            INNER JOIN
		                            CariTuru as ct
		                            ON
		                            c.cariTuru = ct.ID
                                    where c.Telefon LIKE @telefon";
        string sorguSehir = @"Select 
                                    c.CariID,
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
                                    c.Aciklama,
                                    c.Resim
                                    From cari as c
                                    INNER JOIN
                                    CariTuru as ct
                                    ON
                                    c.cariTuru = ct.ID
                                    where c.Sehir LIKE @sehir";
        string sorguDtarihi = @"Select
                                    c.CariID,
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
                                    c.Aciklama,
                                    c.Resim
                                    From cari as c
                                    INNER JOIN
                                    CariTuru as ct
                                    ON
                                    c.cariTuru = ct.ID
                                    where c.DogumTarihi = @dtarih";
        string sorguEtarihi = @"Select
                                    c.CariID,
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
                                    c.Aciklama,
                                    c.Resim
                                    From cari as c
                                    INNER JOIN
                                    CariTuru as ct
                                    ON
                                    c.cariTuru = ct.ID
                                    where c.EvlilikTarihi = @etarih";
        string sorguKtarihi = @"Select
                                    c.CariID,
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
                                    c.Aciklama,
                                    c.Resim
                                    From cari as c
                                    INNER JOIN
                                    CariTuru as ct
                                    ON
                                    c.cariTuru = ct.ID
                                    
                                    where CAST (c.KayitTarihi AS DATE) = @ktarih";

        string sorguDurum = @"Select
                                    c.CariID,
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
                                    c.cariTuru = ct.ID
                                    where c.Durum = @durum";




        private void dtHeaderEski() // datagridview1 başlıkları ekleniyor..
        {
            if (dataGridView1.Columns.Count == 0)
            {
                
               
                dataGridView1.Columns.Add("c.CariID", "Cari No");
                dataGridView1.Columns.Add("c.CariKod", "Cari Kodu");
                dataGridView1.Columns.Add("c.CariAdi", "Cari Adı");
                dataGridView1.Columns.Add("ct.Ad", "Cari Turü");
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
                dataGridView1.Columns.Add("c.Resim","Resim");
            }
            
          
        }
        private void dtHeader()
        {
            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("CariID", "Cari No");
                dataGridView1.Columns.Add("CariKod", "Cari Kodu");
                dataGridView1.Columns.Add("CariAdi", "Cari Adı");
                dataGridView1.Columns.Add("CariTuru", "Cari Türü");
                dataGridView1.Columns.Add("Yetkili", "Yetkili");
                dataGridView1.Columns.Add("Telefon", "Telefon");
                dataGridView1.Columns.Add("Eposta", "E-Posta");
                dataGridView1.Columns.Add("Adres", "Adres");
                dataGridView1.Columns.Add("Sehir", "Şehir");
                dataGridView1.Columns.Add("Ulke", "Ülke");
                dataGridView1.Columns.Add("VergiDairesi", "Vergi D.");
                dataGridView1.Columns.Add("VergiNo", "Vergi No");
                dataGridView1.Columns.Add("DogumTarihi", "Doğum T.");
                dataGridView1.Columns.Add("EvlilikTarihi", "Evlilik T.");
                dataGridView1.Columns.Add("KayitTarihi", "Kayıt T.");
                dataGridView1.Columns.Add("Durum", "Durum");
                dataGridView1.Columns.Add("Aciklama", "Açıklama");
                dataGridView1.Columns.Add("Resim", "Resim");
            }
        }


        private void temizle()
        {
            txtCariAD.Clear();
            txtCariKOD.Clear();
            txtCariTUR.Clear();
            txtYetkili.Clear();
            txtTelefon.Clear();
            txtSehir.Clear();
            dateDtarih.Value = DateTime.Now;
            dateEtarih.Value = DateTime.Now;
            datektarih.Value = DateTime.Now;
            comboBox1.Text = "";
            txtCariKOD.Focus();
            checkBoxDogum.Checked = false;
            checkBoxEvlilik.Checked = false;
            chkTarihFiltre.Checked = false;

            listele();


        }
        private void listele()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                {
                    SqlCommand kmt = new SqlCommand(sorguInnerJoin, baglanti);
                    SqlDataAdapter da = new SqlDataAdapter(kmt);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //dataGridView1.DataSource = dt;
                    dataGridView1.Rows.Clear(); // Mevcut satırları temizle Manuel Eklediğim Başlıklar Bozulmuyor..
                    foreach (DataRow row in dt.Rows)
                    {
                        object[] values = new object[dt.Columns.Count];

                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            if (row[i] == DBNull.Value)
                            {
                                values[i] = ""; // Boş değerler için boş string
                            }
                            else if (row[i] is DateTime tarih)
                            {
                                values[i] = tarih.ToString("yyyy-MM-dd"); // Tarihi biçimli stringe çevir
                            }
                            else if (row[i] is bool durum)
                            {
                                values[i] = durum ? "Aktif" : "Pasif"; // Durum kolonu için okunabilir değer
                            }
                            else
                            {
                                values[i] = row[i];
                            }
                        }

                        dataGridView1.Rows.Add(values); // Satırı DataGridView'e ekle
                    }



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void Filtrele()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();

                List<string> filtreler = new List<string>();
                SqlCommand cmd = new SqlCommand();
                string sorgu = @"SELECT c.CariID, c.CariKod, c.CariAdi, ct.Ad as CariTuru, 
                    c.Yetkili, c.Telefon, c.Eposta, c.Adres, c.Sehir, c.Ulke, 
                    c.VergiDairesi, c.VergiNo, c.DogumTarihi, c.EvlilikTarihi, 
                    c.KayitTarihi, c.Durum, c.Aciklama, c.Resim 
                    FROM Cari c 
                    INNER JOIN CariTuru ct ON c.CariTuru = ct.ID 
                    WHERE 1=1";

                // Metin filtreleri
                if (!string.IsNullOrWhiteSpace(txtCariKOD.Text))
                {
                    filtreler.Add("c.CariKod LIKE @CariKod");
                    cmd.Parameters.AddWithValue("@CariKod", "%" + txtCariKOD.Text + "%");
                }

                if (!string.IsNullOrWhiteSpace(txtCariAD.Text))
                {
                    filtreler.Add("c.CariAdi LIKE @CariAdi");
                    cmd.Parameters.AddWithValue("@CariAdi", "%" + txtCariAD.Text + "%");
                }

                if (!string.IsNullOrWhiteSpace(txtSehir.Text))
                {
                    filtreler.Add("c.Sehir LIKE @Sehir");
                    cmd.Parameters.AddWithValue("@Sehir", "%" + txtSehir.Text + "%");
                }

                if (!string.IsNullOrWhiteSpace(txtYetkili.Text))
                {
                    filtreler.Add("c.Yetkili LIKE @Yetkili");
                    cmd.Parameters.AddWithValue("@Yetkili", "%" + txtYetkili.Text + "%");
                }

                if (!string.IsNullOrWhiteSpace(txtTelefon.Text))
                {
                    filtreler.Add("c.Telefon LIKE @Telefon");
                    cmd.Parameters.AddWithValue("@Telefon", "%" + txtTelefon.Text + "%");
                }

                // ComboBox filtreleri
                if (comboBox1.SelectedIndex > -1)
                {
                    filtreler.Add("c.Durum = @Durum");
                    cmd.Parameters.AddWithValue("@Durum", comboBox1.SelectedItem.ToString() == "Aktif");
                }

                if (!string.IsNullOrEmpty(txtCariTUR.Text))
                {
                    filtreler.Add("ct.Ad LIKE @CariTuru");
                    cmd.Parameters.AddWithValue("@CariTuru","%"+ txtCariTUR.Text+"%");
                }

                // Tarih filtreleme (CheckBox kontrolleri)
                if (chkTarihFiltre.Checked)
                {
                    DateTime baslangic = datektarih.Value.Date;
                    DateTime bitis = dateEtarih.Value.Date;

                    List<string> tarihFiltreleri = new List<string>();
                    tarihFiltreleri.Add("c.KayitTarihi BETWEEN @Baslangic AND @Bitis");
                    if (checkBoxDogum.Checked)
                        tarihFiltreleri.Add("c.DogumTarihi BETWEEN @Baslangic AND @Bitis");

                    else if (checkBoxEvlilik.Checked)
                        tarihFiltreleri.Add("c.EvlilikTarihi BETWEEN @Baslangic AND @Bitis");

                    if (tarihFiltreleri.Count > 0)
                    {
                        filtreler.Add("(" + string.Join(" OR ", tarihFiltreleri) + ")");
                        cmd.Parameters.AddWithValue("@Baslangic", baslangic);
                        cmd.Parameters.AddWithValue("@Bitis", bitis);
                    }
                }

                // Tüm filtreleri sorguya ekle
                if (filtreler.Count > 0)
                {
                    sorgu += " AND " + string.Join(" AND ", filtreler);
                }

                cmd.CommandText = sorgu;
                cmd.Connection = baglanti;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.Rows.Clear(); // Mevcut satırları temizle Manuel Eklediğim Başlıklar Bozulmuyor..
                foreach (DataRow row in dt.Rows)
                {
                    object[] values = new object[dt.Columns.Count];

                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (row[i] == DBNull.Value)
                        {
                            values[i] = ""; // Boş değerler için boş string
                        }
                        else if (row[i] is DateTime tarih)
                        {
                            values[i] = tarih.ToString("yyyy-MM-dd"); // Tarihi biçimli stringe çevir
                        }
                        else if (row[i] is bool durum)
                        {
                            values[i] = durum ? "Aktif" : "Pasif"; // Durum kolonu için okunabilir değer
                        }
                        else
                        {
                            values[i] = row[i];
                        }
                    }

                    dataGridView1.Rows.Add(values); // Satırı DataGridView'e ekle
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Filtreleme Hatası: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }







        private void FrmCariListele_Load(object sender, EventArgs e)
        {
            dtHeader();
            listele();
            /*foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }*/

        }
        private void btnSifirla_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)//tıklanan satırdaki verileri alıp  gelen forma gönderiyoruz.
        {
            try
            {

                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    string cariID = row.Cells["CariID"].Value.ToString();
                    string cariKod = row.Cells["CariKod"].Value.ToString();
                    string cariAdi = row.Cells["CariAdi"].Value.ToString();
                    string cariTur = row.Cells["CariTuru"].Value.ToString();
                    string yetkili = row.Cells["Yetkili"].Value.ToString();
                    string telefon = row.Cells["Telefon"].Value.ToString();
                    string ePosta = row.Cells["EPosta"].Value.ToString();
                    string adres = row.Cells["Adres"].Value.ToString();
                    string sehir = row.Cells["Sehir"].Value.ToString();
                    string ulke = row.Cells["Ulke"].Value.ToString();
                    string vergiDairesi = row.Cells["VergiDairesi"].Value.ToString();
                    string vergiNo = row.Cells["VergiNo"].Value.ToString();

                    string dogumTarihi = row.Cells["DogumTarihi"].Value.ToString();
                    //string dogumTarihi = (dogumTarihiOBJ == DBNull.Value) ? "" : Convert.ToDateTime(dogumTarihiOBJ).ToString();


                    string evlilikTarihi = row.Cells["EvlilikTarihi"].Value.ToString();
                    //string evlilikTarihi = (evlilikTarihiOBJ == DBNull.Value) ? "" : Convert.ToDateTime(evlilikTarihiOBJ).ToString();



                    string kayitTarihi = row.Cells["KayitTarihi"].Value.ToString();
                    string durum = row.Cells["Durum"].Value.ToString();
                    string aciklama = row.Cells["Aciklama"].Value.ToString();
                    string resim = row.Cells["Resim"].Value?.ToString() ?? "";
                    //string deger = dataGridView1.CurrentRow.Cells["KolonAdi"].Value?.ToString() ?? "Varsayılan Değer";

                    //Hangi Formdan Geldiysek veriyi o forma gönderiyoruz.


                    if (CagrilanForm is FrmCariEkle)
                    {
                        var hedefForm = CagrilanForm as FrmCariEkle;
                        hedefForm.CariBilgileriYukle(cariID, cariKod, cariAdi, cariTur, yetkili, telefon, ePosta, adres, sehir, ulke, vergiDairesi, vergiNo, dogumTarihi, evlilikTarihi, kayitTarihi, durum, aciklama, resim);

                    }
                    //Diğer Formlardanda datagrid deki veriler çekilecekse  else if eklenecek ve hedef form verilecek
                    else if (CagrilanForm is FrmSatis)
                    {
                        var hedefForm = CagrilanForm as FrmSatis;
                        hedefForm.CariBilgileriYukle(cariID, cariKod, cariAdi, cariTur, yetkili, telefon, ePosta, resim);
                    }
                    else if (CagrilanForm is FrmTahsilat)
                    {
                        var hedefForm = CagrilanForm as FrmTahsilat;
                        hedefForm.CariBilgileriYukle(cariID, cariKod, cariAdi);
                    }
                    else if (CagrilanForm is FrmGiderler)
                    {
                        var hedefForm = CagrilanForm as FrmGiderler;
                        hedefForm.CariBilgileriYukle(cariID, cariKod, cariAdi);
                    }
                    else
                    {
                        return;

                    }
                    this.Close();
                }
                else
                {
                    
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString());
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)//Carinin resmini gösteriyorum
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                string resim =  row.Cells["Resim"].Value?.ToString() ?? "";
                pictureBox1.ImageLocation = Application.StartupPath + resim;
            }
            
        }



        private void txtCariTUR_TextChanged(object sender, EventArgs e) => Filtrele();
        /*{
           try
            {
                if(baglanti.State == ConnectionState.Closed) baglanti.Open();
                if(!string.IsNullOrEmpty(txtCariTUR.Text))
                {
                    SqlCommand kmtCariTur = new SqlCommand(sorguCariTur, baglanti);
                    kmtCariTur.Parameters.AddWithValue("@cariTurAd", txtCariTUR.Text+"%");
                    SqlDataAdapter da = new SqlDataAdapter(kmtCariTur);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    
                    dataGridView1.Rows.Clear(); // Mevcut satırları temizleyin Manuel Eklediğim Başlıklar Bozulmuyor..
                    
                    foreach (DataRow row in dt.Rows)
                    {
                        dataGridView1.Rows.Add(row.ItemArray); // Satırlar ekleniyor..
                    }
                    baglanti.Close();
                }
                else
                {
                    listele();
                    *//*SqlCommand kmtCariTur = new SqlCommand(sorguInnerJoin, baglanti);
                    SqlDataAdapter da = new SqlDataAdapter(kmtCariTur);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.Rows.Clear(); // Mevcut satırları temizleyin Manuel Eklediğim Başlıklar Bozulmuyor..
                    foreach (DataRow row in dt.Rows)
                    {
                        dataGridView1.Rows.Add(row.ItemArray); // Satırlar ekleniyor..
                    }
                    baglanti.Close();}*/

        private void txtCariKOD_TextChanged(object sender, EventArgs e) => Filtrele();
        /*{
*//*            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                if (!string.IsNullOrEmpty(txtCariKOD.Text))
                {
                    SqlCommand kmtCariTur = new SqlCommand(sorguCariKod, baglanti);
                    kmtCariTur.Parameters.AddWithValue("@cariKod", txtCariKOD.Text + "%");
                    SqlDataAdapter da = new SqlDataAdapter(kmtCariTur);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.Rows.Clear(); // Mevcut satırları temizleyin Manuel Eklediğim Başlıklar Bozulmuyor..
                    foreach (DataRow row in dt.Rows)
                    {
                        dataGridView1.Rows.Add(row.ItemArray); // Satırlar ekleniyor..
                    }
                    baglanti.Close();
                }
                else
                {
                    SqlCommand kmtCariTur = new SqlCommand(sorguInnerJoin, baglanti);
                    SqlDataAdapter da = new SqlDataAdapter(kmtCariTur);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.Rows.Clear(); // Mevcut satırları temizleyin Manuel Eklediğim Başlıklar Bozulmuyor..
                    foreach (DataRow row in dt.Rows)
                    {
                        dataGridView1.Rows.Add(row.ItemArray); // Satırlar ekleniyor..
                    }
                    baglanti.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString());
            }
            finally
            {
                baglanti.Close();
            }
*//*        }*/

        private void txtCariAD_TextChanged(object sender, EventArgs e)=> Filtrele();
        /* {
 *//*            try
             {
                 if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                 if (!string.IsNullOrEmpty(txtCariAD.Text))
                 {
                     SqlCommand kmtCariTur = new SqlCommand(sorguCariAd, baglanti);
                     kmtCariTur.Parameters.AddWithValue("@cariAd", txtCariAD.Text + "%");
                     SqlDataAdapter da = new SqlDataAdapter(kmtCariTur);
                     DataTable dt = new DataTable();
                     da.Fill(dt);

                     dataGridView1.Rows.Clear(); // Mevcut satırları temizleyin Manuel Eklediğim Başlıklar Bozulmuyor..
                     foreach (DataRow row in dt.Rows)
                     {
                         dataGridView1.Rows.Add(row.ItemArray); // Satırlar ekleniyor..
                     }
                     baglanti.Close();
                 }
                 else
                 {
                     SqlCommand kmtCariTur = new SqlCommand(sorguInnerJoin, baglanti);
                     SqlDataAdapter da = new SqlDataAdapter(kmtCariTur);
                     DataTable dt = new DataTable();
                     da.Fill(dt);

                     dataGridView1.Rows.Clear(); // Mevcut satırları temizleyin Manuel Eklediğim Başlıklar Bozulmuyor..
                     foreach (DataRow row in dt.Rows)
                     {
                         dataGridView1.Rows.Add(row.ItemArray); // Satırlar ekleniyor..
                     }
                     baglanti.Close();
                 }

             }
             catch (Exception ex)
             {
                 MessageBox.Show("Hata: " + ex.ToString());
             }
             finally
             {
                 baglanti.Close();
             }
 *//*        }*/

        private void txtYetkili_TextChanged(object sender, EventArgs e) => Filtrele();
        /*{
*//*            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                if (!string.IsNullOrEmpty(txtYetkili.Text))
                {
                    SqlCommand kmtCariTur = new SqlCommand(sorguCariYetkili, baglanti);
                    kmtCariTur.Parameters.AddWithValue("@yetkili", txtYetkili.Text + "%");
                    SqlDataAdapter da = new SqlDataAdapter(kmtCariTur);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.Rows.Clear(); // Mevcut satırları temizle Manuel Eklediğim Başlıklar Bozulmuyor..
                    foreach (DataRow row in dt.Rows)
                    {
                        dataGridView1.Rows.Add(row.ItemArray); // Satırlar ekleniyor..
                    }
                    baglanti.Close();
                }
                else
                {
                    SqlCommand kmtCariTur = new SqlCommand(sorguInnerJoin, baglanti);
                    SqlDataAdapter da = new SqlDataAdapter(kmtCariTur);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.Rows.Clear(); // Mevcut satırları temizle Manuel Eklediğim Başlıklar Bozulmuyor..
                    foreach (DataRow row in dt.Rows)
                    {
                        dataGridView1.Rows.Add(row.ItemArray); // Satırlar ekleniyor..
                    }
                    baglanti.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString());
            }
            finally
            {
                baglanti.Close();
            }
*//*        }*/

        private void txtTelefon_TextChanged(object sender, EventArgs e) => Filtrele();
        /*{
*//*            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                if (!string.IsNullOrEmpty(txtTelefon.Text))
                {
                    SqlCommand kmtCariTur = new SqlCommand(sorguTelefon, baglanti);
                    kmtCariTur.Parameters.AddWithValue("@telefon", txtTelefon.Text + "%");
                    SqlDataAdapter da = new SqlDataAdapter(kmtCariTur);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.Rows.Clear(); // Mevcut satırları temizle Manuel Eklediğim Başlıklar Bozulmuyor..
                    foreach (DataRow row in dt.Rows)
                    {
                        dataGridView1.Rows.Add(row.ItemArray); // Satırlar ekleniyor..
                    }
                    baglanti.Close();
                }
                else
                {
                    SqlCommand kmtCariTur = new SqlCommand(sorguInnerJoin, baglanti);
                    SqlDataAdapter da = new SqlDataAdapter(kmtCariTur);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.Rows.Clear(); // Mevcut satırları temizle Manuel Eklediğim Başlıklar Bozulmuyor..
                    foreach (DataRow row in dt.Rows)
                    {
                        dataGridView1.Rows.Add(row.ItemArray); // Satırlar ekleniyor..
                    }
                    baglanti.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString());
            }
            finally
            {
                baglanti.Close();
            }
*//*        }*/

        private void txtSehir_TextChanged(object sender, EventArgs e) => Filtrele();
        /*{
*//*            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                if (!string.IsNullOrEmpty(txtSehir.Text))
                {
                    SqlCommand kmtCariTur = new SqlCommand(sorguSehir, baglanti);
                    kmtCariTur.Parameters.AddWithValue("@sehir", txtSehir.Text + "%");
                    SqlDataAdapter da = new SqlDataAdapter(kmtCariTur);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.Rows.Clear(); // Mevcut satırları temizle Manuel Eklediğim Başlıklar Bozulmuyor..
                    foreach (DataRow row in dt.Rows)
                    {
                        object[] values = new object[dt.Columns.Count];

                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            if (row[i] == DBNull.Value)
                            {
                                values[i] = ""; // Boş değerler için boş string
                            }
                            else if (row[i] is DateTime tarih)
                            {
                                values[i] = tarih.ToString("yyyy-MM-dd"); // Tarihi biçimli stringe çevir
                            }
                            else if (row[i] is bool durum)
                            {
                                values[i] = durum ? "Aktif" : "Pasif"; // Durum kolonu için okunabilir değer
                            }
                            else
                            {
                                values[i] = row[i];
                            }
                        }

                        dataGridView1.Rows.Add(values); // Satırı DataGridView'e ekle
                    }
                    
                }
                else
                {
                    SqlCommand kmtCariTur = new SqlCommand(sorguInnerJoin, baglanti);
                    SqlDataAdapter da = new SqlDataAdapter(kmtCariTur);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.Rows.Clear(); // Mevcut satırları temizle Manuel Eklediğim Başlıklar Bozulmuyor..
                    foreach (DataRow row in dt.Rows)
                    {
                        dataGridView1.Rows.Add(row.ItemArray); // Satırlar ekleniyor..
                    }
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString());
            }
            finally
            {
                baglanti.Close();
            }
*//*        }*/
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) => Filtrele();
        /*        {
        *//*            try
                    {
                        if(baglanti.State == ConnectionState.Closed) baglanti.Open();
                        if (comboBox1.SelectedItem != null)
                        {
                            string durum1 = comboBox1.SelectedItem.ToString();
                            SqlCommand kmtDurum = new SqlCommand(sorguDurum, baglanti);
                            if(durum1 == "Aktif")
                            {
                                durum1 = "True";
                            }
                            else
                            {
                                durum1 = "False";
                            }
                            kmtDurum.Parameters.AddWithValue("@durum", durum1);
                            SqlDataAdapter da = new SqlDataAdapter(kmtDurum);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.Rows.Clear(); // Mevcut satırları temizle Manuel Eklediğim Başlıklar Bozulmuyor..
                            foreach (DataRow row in dt.Rows)
                            {
                                object[] values = new object[dt.Columns.Count];

                                for (int i = 0; i < dt.Columns.Count; i++)
                                {
                                    if (row[i] == DBNull.Value)
                                    {
                                        values[i] = ""; // Boş değerler için boş string
                                    }
                                    else if (row[i] is DateTime tarih)
                                    {
                                        values[i] = tarih.ToString("yyyy-MM-dd"); // Tarihi biçimli stringe çevir
                                    }
                                    else if (row[i] is bool durum)
                                    {
                                        values[i] = durum ? "Aktif" : "Pasif"; // Durum kolonu için okunabilir değer
                                    }
                                    else
                                    {
                                        values[i] = row[i];
                                    }
                                }

                                dataGridView1.Rows.Add(values); // Satırı DataGridView'e ekle
                            }

                        }
                        else
                        {
                            listele();
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.ToString());
                    }
                    finally
                    {
                        baglanti.Close();
                    }
        *//*        }*/
        private void dateDtarih_ValueChanged(object sender, EventArgs e) => Filtrele();
        /*        {
        *//*            try
                    {

                        if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                        if (dateDtarih.Value != null)
                        {

                            SqlCommand kmtCariTur = new SqlCommand(sorguDtarihi, baglanti);




                            kmtCariTur.Parameters.AddWithValue("@dtarih", Convert.ToDateTime(dateDtarih.Text));

                            SqlDataAdapter da = new SqlDataAdapter(kmtCariTur);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.Rows.Clear(); // Mevcut satırları temizle Manuel Eklediğim Başlıklar Bozulmuyor..
                            foreach (DataRow row in dt.Rows)
                            {
                                dataGridView1.Rows.Add(row.ItemArray); // Satırlar ekleniyor..
                            }
                            baglanti.Close();
                        }
                        else
                        {
                            dateDtarih.CustomFormat = "yyyy-MM-dd";
                            SqlCommand kmtCariTur = new SqlCommand(sorguInnerJoin, baglanti);

                            SqlDataAdapter da = new SqlDataAdapter(kmtCariTur);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.Rows.Clear(); // Mevcut satırları temizle Manuel Eklediğim Başlıklar Bozulmuyor..
                            foreach (DataRow row in dt.Rows)
                            {
                                dataGridView1.Rows.Add(row.ItemArray); // Satırlar ekleniyor..
                            }
                            baglanti.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.ToString());
                    }
                    finally
                    {
                        baglanti.Close();
                    }
        *//*        }*/

        private void dateEtarih_ValueChanged(object sender, EventArgs e) => Filtrele();
        /*        {
        *//*            try
                    {

                        if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                        if (dateEtarih.Value != null)
                        {

                            SqlCommand kmtCariTur = new SqlCommand(sorguEtarihi, baglanti);

                            kmtCariTur.Parameters.AddWithValue("@etarih", Convert.ToDateTime(dateEtarih.Text));

                            SqlDataAdapter da = new SqlDataAdapter(kmtCariTur);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.Rows.Clear(); // Mevcut satırları temizle Manuel Eklediğim Başlıklar Bozulmuyor..
                            foreach (DataRow row in dt.Rows)
                            {
                                dataGridView1.Rows.Add(row.ItemArray); // Satırlar ekleniyor..
                            }
                            baglanti.Close();
                        }
                        else
                        {
                            dateDtarih.CustomFormat = "yyyy-MM-dd";
                            SqlCommand kmtCariTur = new SqlCommand(sorguInnerJoin, baglanti);

                            SqlDataAdapter da = new SqlDataAdapter(kmtCariTur);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.Rows.Clear(); // Mevcut satırları temizle Manuel Eklediğim Başlıklar Bozulmuyor..
                            foreach (DataRow row in dt.Rows)
                            {
                                dataGridView1.Rows.Add(row.ItemArray); // Satırlar ekleniyor..
                            }
                            baglanti.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.ToString());
                    }
                    finally
                    {
                        baglanti.Close();
                    }
        *//*        }*/

        private void datektarih_ValueChanged(object sender, EventArgs e) => Filtrele();
        /*        {
                    try
                    {

                        if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                        if (datektarih.Value != null)
                        {

                            SqlCommand kmtCariTur = new SqlCommand(sorguKtarihi, baglanti);

                            *//*
                            DateTime Sorgu Hatasını bulmak icin ekledim
                            MessageBox.Show(datektarih.Text); 
                            MessageBox.Show(datektarih.Value.ToString());
                            

                            kmtCariTur.Parameters.AddWithValue("@ktarih", Convert.ToDateTime(datektarih.Text));



                            SqlDataAdapter da = new SqlDataAdapter(kmtCariTur);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.Rows.Clear(); // Mevcut satırları temizle Manuel Eklediğim Başlıklar Bozulmuyor..
                            foreach (DataRow row in dt.Rows)
                            {
                                dataGridView1.Rows.Add(row.ItemArray); // Satırlar ekleniyor..
                            }
                            baglanti.Close();
                        }
                        else
                        {

                            SqlCommand kmtCariTur = new SqlCommand(sorguInnerJoin, baglanti);

                            SqlDataAdapter da = new SqlDataAdapter(kmtCariTur);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.Rows.Clear(); // Mevcut satırları temizle Manuel Eklediğim Başlıklar Bozulmuyor..
                            foreach (DataRow row in dt.Rows)
                            {
                                dataGridView1.Rows.Add(row.ItemArray); // Satırlar ekleniyor..
                            }
                            baglanti.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.ToString());
                    }
                    finally
                    {
                        baglanti.Close();
                    }
              }
        */

        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmCariEkle frmCariEkle = new FrmCariEkle();
            frmCariEkle.ShowDialog();
            listele();
        }

        private void cariEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCariEkle frmCariEkle = new FrmCariEkle();
            frmCariEkle.ShowDialog();
            listele();
        }

        private void cariBilgileriDüzeltToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCariEkle frmCariEkle = new FrmCariEkle();
            frmCariEkle.ShowDialog();
            listele();
        }

        private void cariSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCariEkle frmCariEkle = new FrmCariEkle();
            frmCariEkle.ShowDialog();
            listele();
        }

        private void chkTarihFiltre_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTarihFiltre.Checked)
            {
                Filtrele();
            }
            else
            {
                checkBoxEvlilik.Checked = false;
                checkBoxDogum.Checked = false;
                listele();

            }
        }

        private void checkBoxEvlilik_CheckedChanged(object sender, EventArgs e) => Filtrele();

        private void checkBoxDogum_CheckedChanged(object sender, EventArgs e) => Filtrele();

        private void FrmCariListele_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }

}
