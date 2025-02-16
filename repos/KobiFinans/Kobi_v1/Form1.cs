using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Kobi_v1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=EDESSASERDAR\\SQLEXPRESS;Initial Catalog=Kobi;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
