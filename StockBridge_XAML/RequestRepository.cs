using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace StockBridge_XAML
{
    public static class RequestRepository
    {
        public static List<dynamic> GetAllRequests()
        {
            using (var db = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                return db.Query("SELECT * FROM requests ORDER BY id DESC").ToList();
            }
        }

        public static void ApproveRequest(int requestId, int qty, string productName)
        {
            using (var db = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                db.Open();
                var currentStock = db.QueryFirstOrDefault<int?>("SELECT base_stock FROM products WHERE product_name = @name", new { name = productName });
                if (currentStock == null)
                {
                    throw new Exception("Barang tidak ditemukan!");
                }

                if (currentStock < qty)
                {
                    throw new InvalidOperationException($"Stok tidak mencukupi! Sisa stok: {currentStock}, yang diminta: {qty}");
                }

                using (var trans = db.BeginTransaction())
                {
                    try
                    {
                        db.Execute("UPDATE requests SET status = 'Approved' WHERE id = @id", 
                                   new { id = requestId }, 
                                   transaction: trans);
                        db.Execute("UPDATE products SET base_stock = base_stock - @qty WHERE product_name = @name",
                                   new { qty = qty, name = productName }, 
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

        public static void RejectRequest(int requestId)
        {
            using (var db = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                db.Execute("UPDATE requests SET status = 'Rejected' WHERE id = @id", new { id = requestId });
            }
        }

        public static void InsertRequest(string productName, int qty)
        {
            using (var db = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                db.Execute("INSERT INTO requests (product_name, qty_requested, status) VALUES (@name, @qty, 'Pending')", new { name = productName, qty = qty });
            }
        }
    }
}
