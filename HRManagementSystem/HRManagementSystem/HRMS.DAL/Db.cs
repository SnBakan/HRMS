using System;
using HRMS.Domain;
using MySqlConnector;

namespace HRMS.DAL.Database
{
    public static class Db
    {
        // 1) Her çağrıda yeni connection üretir (en sağlıklısı)
        public static MySqlConnection CreateConnection()
            => new MySqlConnection(ConnectionStrings.Main);

        // 2) Açık connection isteyenler için kısa yol
        public static MySqlConnection OpenConnection()
        {
            var conn = CreateConnection();
            conn.Open();
            return conn;
        }

        // 3) “DB ayakta mı?” testi (SELECT 1)
        public static bool Ping(out string message)
        {
            try
            {
                var conn = OpenConnection();
                var cmd = new MySqlCommand("SELECT 1;", conn);
                var result = cmd.ExecuteScalar();

                var ok = result?.ToString() == "1";
                message = ok ? "OK: DB bağlantısı kuruldu (SELECT 1)." : "HATA: SELECT 1 dönmedi.";
                return ok;
            }
            catch (Exception ex)
            {
                message = "HATA: " + ex.Message;
                return false;
            }
        }

    }
}

