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
    public partial class FrmCariEkle : Form
    {
        public FrmCariEkle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-NFG00P8\\SQLEXPRESS;Initial Catalog=KobiFinans;Integrated Security=True");
        string sorguEkle = "INSERT INTO Cari (CariAdi, Telefon, Email, Adres, VergiNo, Borc, Alacak)  VALUES (@CariAdi, @Telefon, @Email, @Adres, @VergiNo, @Borc, @Alacak)";
    }
}
