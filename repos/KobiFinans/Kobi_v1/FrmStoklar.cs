using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kobi_v1
{
    public partial class FrmStoklar : Form
    {
        public FrmStoklar()
        {
            InitializeComponent();
        }
        public Form CagrilanForm { get; set; }


        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.IndianRed;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Transparent;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                string stokID = row.Cells["UrunId"].Value.ToString();
                string stokKod = row.Cells["UrunKodu"].Value.ToString();
                string stokTur = row.Cells["Barkod"].Value.ToString();
                string stokBarkod = row.Cells["Marka"].Value.ToString();
                string stokModel = row.Cells["Model"].Value.ToString();
                string stokAdi = row.Cells["UrunAdi"].Value.ToString();
                string stokKategori = row.Cells["KategoriID"].Value.ToString();
                string stokAlisFiyati = row.Cells["AlisFiyati"].Value.ToString();
                string stokSatisFiyati = row.Cells["SatisFiyati"].Value.ToString();
                string stokKdv = row.Cells["Kdv"].Value.ToString();
                string stokMiktar = row.Cells["StokMiktari"].Value.ToString();
                string stokAciklama = row.Cells["Aciklama"].Value.ToString();
                string stokResim = row.Cells["Resim"].Value.ToString();
                string stokDurum = row.Cells["Durum"].Value.ToString();
                string stokKayitTarihi = row.Cells["KayitTarihi"].Value.ToString();
                string stokBirim = row.Cells["Birim"].Value.ToString();

                if (CagrilanForm is FrmSatis)
                {
                    FrmSatis frmSatis = (FrmSatis)CagrilanForm;
                    frmSatis.StokBilgileriYukle(stokID, stokKod, stokTur, stokBarkod, stokModel,
                        stokAdi, stokKategori, stokAlisFiyati, stokSatisFiyati, stokKdv, stokMiktar, stokAciklama, stokResim, stokDurum, stokKayitTarihi, stokBirim);
                    

                }
            }
        }
         
    }
}
