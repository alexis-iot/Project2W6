using System;
using System.Collections.Generic;
using System.Data;
using IoTProjectWeek6.Model;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace IoTProjectWeek6.Data
{
    public class DbService
    {
        private static MySqlConnection OpenConnection()
        {
            var connString = Startup.Configuration.GetConnectionString("DefaultDatabase");
            var conn = new MySqlConnection(connString);
            conn.Open();

            return conn;
        }

        public static void InsertLoginRequest(LoginRequest item)
        {
            MySqlConnection conn = null;

            conn = OpenConnection();
            var query =
                "INSERT INTO LoginRequest (username, password, request_date, ip_address) VALUES (@Username, @Password, @RequestDate, @IpAddress)";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.Add("@Username", item.Username);
            cmd.Parameters.Add("@Password", item.Password);
            cmd.Parameters.Add("@RequestDate", item.RequestDate);
            cmd.Parameters.Add("@IpAddress", item.IpAddress);
            cmd.ExecuteNonQuery();

            if (conn != null && conn.State == ConnectionState.Open)
                conn.Close();
        }

        public static LoginRequest[] GetLatestEntries()
        {
            var items = new List<LoginRequest>();
            MySqlConnection conn = null;

            conn = OpenConnection();
            var query = "SELECT * FROM LoginRequest ORDER BY id DESC LIMIT 10";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var item = new LoginRequest
                {
                    Id = (int) reader[0],
                    Username = (string) reader[1],
                    Password = (string) reader[2],
                    RequestDate = (DateTime) reader[3],
                    IpAddress = (string) reader[4]
                };

                items.Add(item);
            }

            reader.Close();
            if (conn != null && conn.State == ConnectionState.Open)
                conn.Close();

            return items.ToArray();
        }
    }
}