using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kobi_v1
{
    public partial class FrmSatisHareketleri : Form
    {
        public FrmSatisHareketleri()
        {
            InitializeComponent();
        }
        private static string connectionString=ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);

        private void Listele()
        {
            string sqlListele = @"Select ";
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();

            }
            catch { }
        }

    }
}
