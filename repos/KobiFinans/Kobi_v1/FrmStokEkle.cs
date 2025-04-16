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
    public partial class FrmStokEkle : Form
    {
        public FrmStokEkle()
        {
            InitializeComponent();
        }
        
        
        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
        private void BtnLoad()
        {
            btnEkle.Enabled = true;
            btniptal.Enabled = false;
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
            btnKayit.Enabled = false;
            btnKapat.Enabled = true;
        }

        private void FrmStokEkle_Load(object sender, EventArgs e)
        {
            BtnLoad();
        }
    }
}
