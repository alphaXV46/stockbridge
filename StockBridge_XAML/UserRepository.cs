using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace StockBridge_XAML
{
    public static class UserRepository
    {
        public static dynamic Authenticate(string username, string password)
        {
            using (var db = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                string hashedPassword = DatabaseHelper.HashPassword(password);
                return db.QueryFirstOrDefault("SELECT * FROM users WHERE username = @u AND password = @p", new { u = username, p = hashedPassword });
            }
        }

        public static List<dynamic> GetAllUsers()
        {
            using (var db = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                return db.Query("SELECT id, username, role FROM users").ToList();
            }
        }

        public static void InsertUser(string username, string password, string role)
        {
            using (var db = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                string hashedPassword = DatabaseHelper.HashPassword(password);
                db.Execute("INSERT INTO users (username, password, role) VALUES (@u, @p, @r)", new { u = username, p = hashedPassword, r = role });
            }
        }
    }
}
