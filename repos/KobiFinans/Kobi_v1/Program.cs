using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kobi_v1
{
    internal static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]

        static void Main()
        {
            QuestPDF.Settings.License = LicenseType.Community;
            string connectionString = ConfigurationManager.ConnectionStrings["KobiFinans"].ConnectionString;
            SqlConnection baglanti = new SqlConnection(connectionString);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (baglanti.State == System.Data.ConnectionState.Closed) baglanti.Open();
            SqlCommand cmd = new SqlCommand("Select KullaniciID from Kullanici", baglanti);
            object count = cmd.ExecuteScalar();
            if(count!=null)//Kayıtlı Kullanıcı varsa
            {
                Application.Run(new FrmLogin());
            }
            else //Kayıtlı Kullanıcı yoksa
            {
                Application.Run(new FrmKullaniciEkle());
            }
            baglanti.Close();

        }
    }
}
