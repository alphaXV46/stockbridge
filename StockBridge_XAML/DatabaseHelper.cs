using System;
using System.Data.SqlClient;
using Dapper;

namespace StockBridge_XAML
{
    public static class DatabaseHelper
    {
        public static string ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=StockBridgeDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public static void InitializeDatabase()
        {
            const string masterConnString = "Server=(localdb)\\MSSQLLocalDB;Database=master;Trusted_Connection=True;TrustServerCertificate=True;";

            try
            {
                // 1. Check if database exists, if not create it
                using (var masterDb = new SqlConnection(masterConnString))
                {
                    masterDb.Open();
                    var dbId = masterDb.ExecuteScalar<int?>("SELECT database_id FROM sys.databases WHERE name = 'StockBridgeDB'");
                    if (dbId == null)
                    {
                        masterDb.Execute("CREATE DATABASE StockBridgeDB");
                    }
                }

                // 2. Check and create tables if they don't exist
                using (var db = new SqlConnection(ConnectionString))
                {
                    db.Open();

                    var tableExists = db.ExecuteScalar<int?>("SELECT 1 FROM sys.tables WHERE name = 'users'");
                    if (tableExists == null)
                    {
                        db.Execute(@"
                            CREATE TABLE users (
                                id INT IDENTITY(1,1) PRIMARY KEY, 
                                username NVARCHAR(100) UNIQUE, 
                                password NVARCHAR(100), 
                                role NVARCHAR(50)
                            );
                        ");

                        db.Execute(@"INSERT INTO users (username, password, role) VALUES 
                            ('admin', @adminPass, 'Admin'), 
                            ('manager', @managerPass, 'Manager'), 
                            ('staff', @staffPass, 'Staff')",
                            new {
                                adminPass = HashPassword("admin123"),
                                managerPass = HashPassword("manager123"),
                                staffPass = HashPassword("staff123")
                            });

                        db.Execute(@"
                            CREATE TABLE categories (
                                id INT IDENTITY(1,1) PRIMARY KEY, 
                                category_name NVARCHAR(100)
                            );
                            INSERT INTO categories (category_name) VALUES 
                            ('Elektronik'), 
                            ('IT Asset'), 
                            ('ATK');

                            CREATE TABLE products (
                                id NVARCHAR(100) PRIMARY KEY, 
                                product_name NVARCHAR(255), 
                                category_id INT, 
                                base_stock INT DEFAULT 0, 
                                unit_name NVARCHAR(50), 
                                pack_name NVARCHAR(50), 
                                conversion_rate INT DEFAULT 1, 
                                price DECIMAL(18,2), 
                                description NVARCHAR(MAX),
                                created_at DATETIME DEFAULT GETDATE()
                            );
                            
                            CREATE TABLE stock_logs (
                                log_id INT IDENTITY(1,1) PRIMARY KEY, 
                                product_id NVARCHAR(100), 
                                type NVARCHAR(50), 
                                quantity INT, 
                                total_affected INT, 
                                created_at DATETIME DEFAULT GETDATE()
                            );
                            
                            CREATE TABLE requests (
                                id INT IDENTITY(1,1) PRIMARY KEY, 
                                product_name NVARCHAR(255), 
                                qty_requested INT, 
                                status NVARCHAR(50) DEFAULT 'Pending'
                            );
                        ");
                    }

                    // Check and create units table if it does not exist
                    var unitsTableExists = db.ExecuteScalar<int?>("SELECT 1 FROM sys.tables WHERE name = 'units'");
                    if (unitsTableExists == null)
                    {
                        db.Execute(@"
                            CREATE TABLE units (
                                id INT IDENTITY(1,1) PRIMARY KEY, 
                                unit_code NVARCHAR(50) UNIQUE NOT NULL, 
                                unit_name NVARCHAR(100) NOT NULL
                            );
                            INSERT INTO units (unit_code, unit_name) VALUES 
                            ('Pcs', 'Pieces'), 
                            ('Dus', 'Dus/Box'), 
                            ('Kg', 'Kilogram'), 
                            ('Meter', 'Meter'), 
                            ('Rim', 'Rim');
                        ");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Database initialization failed: " + ex.Message, "Database Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }

        public static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password)) return string.Empty;
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                var sb = new System.Text.StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    sb.Append(bytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}