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
    public partial class FrmBanka : Form
    {
        public FrmBanka()
        {
            InitializeComponent();
        }

        private void btnBankaAra_Click(object sender, EventArgs e)
        {
            FrmBankaListe frmBankaListe = new FrmBankaListe();
            frmBankaListe.Show();
        }
    }
}
