using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace StockBridge_XAML
{
    public static class ProductRepository
    {
        public static List<dynamic> GetAllProducts()
        {
            using (var db = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                return db.Query("SELECT * FROM products ORDER BY created_at DESC").ToList();
            }
        }

        public static dynamic GetProductById(string id)
        {
            using (var db = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                return db.QueryFirstOrDefault("SELECT * FROM products WHERE id = @id", new { id = id });
            }
        }

        public static void InsertProduct(string id, string name, int categoryId, int baseStock, string unitName, string packName, int conversionRate, double price, string description)
        {
            using (var db = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                const string sql = @"INSERT INTO products (id, product_name, category_id, base_stock, unit_name, pack_name, conversion_rate, price, description) 
                               VALUES (@id, @name, @cat, @stock, @unit, @pack, @conv, @price, @desc)";
                db.Execute(sql, new 
                { 
                    id = id, 
                    name = name, 
                    cat = categoryId, 
                    stock = baseStock, 
                    unit = unitName, 
                    pack = packName, 
                    conv = conversionRate, 
                    price = price, 
                    desc = description 
                });
            }
        }

        public static void AdjustStock(string productId, string type, int qtyInput, int totalAffected)
        {
            using (var db = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                db.Open();
                using (var trans = db.BeginTransaction())
                {
                    try
                    {
                        string op = (type == "Masuk") ? "+" : "-";
                        db.Execute($"UPDATE products SET base_stock = base_stock {op} @diff WHERE id = @id",
                                   new { diff = totalAffected, id = productId },
                                   transaction: trans);

                        db.Execute(@"INSERT INTO stock_logs (product_id, type, quantity, total_affected, created_at) 
                                     VALUES (@pid, @type, @qty, @total, GETDATE())",
                                     new { pid = productId, type = type, qty = qtyInput, total = totalAffected },
                                     transaction: trans);

                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        public static List<dynamic> GetCategories()
        {
            using (var db = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                return db.Query("SELECT * FROM categories").ToList();
            }
        }

        public static List<dynamic> GetStockLogs()
        {
            using (var db = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                return db.Query("SELECT * FROM stock_logs ORDER BY created_at DESC").ToList();
            }
        }
    }
}
