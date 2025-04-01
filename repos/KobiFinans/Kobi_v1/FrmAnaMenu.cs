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
    public partial class FrmAnaMenu : Form
    {
        private readonly string kullaniciRol;
        public FrmAnaMenu(string rol)
        {
            InitializeComponent();
            kullaniciRol = rol;
            YetkiKontrol();

        }
        private void YetkiKontrol() 
        {
            if(kullaniciRol !="Admin")
                btnKullaniciYonetimi.Enabled= false;
        }

        private void btnKasaHareketleri_Click(object sender, EventArgs e)
        {
            FrmKasaHareketleri frmKasaHareketleri = new FrmKasaHareketleri();
            frmKasaHareketleri.ShowDialog();
        }

        private void btnKullaniciYonetimi_Click(object sender, EventArgs e)
        {
            FrmKullanicilar frmKullanicilar = new FrmKullanicilar();
            frmKullanicilar.ShowDialog();
            
        }

        private void btnCariListe_Click(object sender, EventArgs e)
        {
            FrmCariListele frmCariListele = new FrmCariListele();
            frmCariListele.ShowDialog();

        }

        private void BtnAyarlar_Click(object sender, EventArgs e)
        {
            FrmAyarlar frmAyarlar = new FrmAyarlar();
            frmAyarlar.ShowDialog();
        }
    }
}
