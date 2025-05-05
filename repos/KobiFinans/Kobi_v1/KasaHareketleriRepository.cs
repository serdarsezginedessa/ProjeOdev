using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kobi_v1
{
    public class KasaHareketleriRepository
    {
        private readonly SqlConnection _connection;

        public KasaHareketleriRepository(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        private void EnsureConnectionOpen()
        {
            if (_connection.State == ConnectionState.Closed)
                _connection.Open();
        }

        public DataTable GetTumRapor()
        {
            EnsureConnectionOpen();
            string sorgu = @"SELECT kh.HareketID, c.CariAdi, k.kasaadi, kh.Tarih, 
                                    kh.HareketTipi, kh.Aciklama, kh.Tutar
                             FROM KasaHareketleri kh
                             INNER JOIN Kasalar k ON kh.KasaID = k.KasaID
                             INNER JOIN Cari c ON kh.CariID = c.CariID";
            return ExecuteQuery(sorgu);
        }

        public DataTable GetBugunRapor(DateTime tarih)
        {
            EnsureConnectionOpen();
            string sorgu = @"SELECT kh.HareketID, c.CariAdi, k.kasaadi, kh.Tarih, 
                                    kh.HareketTipi, kh.Aciklama, kh.Tutar
                             FROM KasaHareketleri kh
                             INNER JOIN Kasalar k ON kh.KasaID = k.KasaID
                             INNER JOIN Cari c ON kh.CariID = c.CariID
                             WHERE kh.Tarih >= @tarih AND kh.Tarih < DATEADD(DAY, 1, @tarih)";
            SqlCommand cmd = new SqlCommand(sorgu, _connection);
            cmd.Parameters.AddWithValue("@tarih", tarih.Date);
            return ExecuteQuery(cmd);
        }

        public DataTable GetIkiTarihArasiRapor(DateTime tarih1, DateTime tarih2)
        {
            EnsureConnectionOpen();
            string sorgu = @"SELECT kh.HareketID, c.CariAdi, k.kasaadi, kh.Tarih, 
                                    kh.HareketTipi, kh.Aciklama, kh.Tutar
                             FROM KasaHareketleri kh
                             INNER JOIN Kasalar k ON kh.KasaID = k.KasaID
                             INNER JOIN Cari c ON kh.CariID = c.CariID
                             WHERE kh.Tarih >= @tarih1 AND kh.Tarih <= DATEADD(SECOND, -1, DATEADD(DAY, 1, @tarih2))";
            SqlCommand cmd = new SqlCommand(sorgu, _connection);
            cmd.Parameters.AddWithValue("@tarih1", tarih1.Date);
            cmd.Parameters.AddWithValue("@tarih2", tarih2.Date);
            return ExecuteQuery(cmd);
        }

        public DataTable GetByCariAdi(string cariAdi)
        {
            EnsureConnectionOpen();
            string sorgu = @"SELECT kh.HareketID, c.CariAdi, k.kasaadi, kh.Tarih, 
                                    kh.HareketTipi, kh.Aciklama, kh.Tutar
                             FROM KasaHareketleri kh
                             INNER JOIN Kasalar k ON kh.KasaID = k.KasaID
                             INNER JOIN Cari c ON kh.CariID = c.CariID
                             WHERE c.CariAdi LIKE @cariadi";
            SqlCommand cmd = new SqlCommand(sorgu, _connection);
            cmd.Parameters.AddWithValue("@cariadi", "%" + cariAdi + "%");
            return ExecuteQuery(cmd);
        }

        public DataTable GetByHareketID(string hareketID)
        {
            EnsureConnectionOpen();
            string sorgu = @"SELECT kh.HareketID, c.CariAdi, k.kasaadi, kh.Tarih, 
                                    kh.HareketTipi, kh.Aciklama, kh.Tutar
                             FROM KasaHareketleri kh
                             INNER JOIN Kasalar k ON kh.KasaID = k.KasaID
                             INNER JOIN Cari c ON kh.CariID = c.CariID
                             WHERE kh.HareketID LIKE @hareketID";
            SqlCommand cmd = new SqlCommand(sorgu, _connection);
            cmd.Parameters.AddWithValue("@hareketID", "%" + hareketID + "%");
            return ExecuteQuery(cmd);
        }

        public DataTable GetByKasaID(int kasaID)
        {
            EnsureConnectionOpen();
            string sorgu = @"SELECT kh.HareketID, c.CariAdi, k.kasaadi, kh.Tarih, 
                                    kh.HareketTipi, kh.Aciklama, kh.Tutar
                             FROM KasaHareketleri kh
                             INNER JOIN Kasalar k ON kh.KasaID = k.KasaID
                             INNER JOIN Cari c ON kh.CariID = c.CariID
                             WHERE k.KasaID = @kasaID";
            SqlCommand cmd = new SqlCommand(sorgu, _connection);
            cmd.Parameters.AddWithValue("@kasaID", kasaID);
            return ExecuteQuery(cmd);
        }

        public DataTable GetByHareketTipi(string hareketTipi)
        {
            EnsureConnectionOpen();
            string sorgu = @"SELECT kh.HareketID, c.CariAdi, k.kasaadi, kh.Tarih, 
                                    kh.HareketTipi, kh.Aciklama, kh.Tutar
                             FROM KasaHareketleri kh
                             INNER JOIN Kasalar k ON kh.KasaID = k.KasaID
                             INNER JOIN Cari c ON kh.CariID = c.CariID
                             WHERE kh.HareketTipi = @hareketTipi";
            SqlCommand cmd = new SqlCommand(sorgu, _connection);
            cmd.Parameters.AddWithValue("@hareketTipi", hareketTipi);
            return ExecuteQuery(cmd);
        }

        private DataTable ExecuteQuery(string sorgu)
        {
            SqlCommand cmd = new SqlCommand(sorgu, _connection);
            return ExecuteQuery(cmd);
        }

        private DataTable ExecuteQuery(SqlCommand cmd)
        {
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}