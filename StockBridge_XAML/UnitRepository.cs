using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

namespace StockBridge_XAML
{
    public static class UnitRepository
    {
        // 1. Get all units ordered by name
        public static IEnumerable<dynamic> GetAllUnits()
        {
            using (var db = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                return db.Query("SELECT * FROM units ORDER BY unit_code ASC");
            }
        }

        // 2. Add a new unit
        public static void AddUnit(string code, string name)
        {
            using (var db = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                db.Execute("INSERT INTO units (unit_code, unit_name) VALUES (@code, @name)", new { code, name });
            }
        }

        // 3. Delete a unit
        public static void DeleteUnit(int id)
        {
            using (var db = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                db.Execute("DELETE FROM units WHERE id = @id", new { id });
            }
        }

        // 4. Check if unit code already exists (Duplication Check)
        public static bool UnitCodeExists(string code)
        {
            using (var db = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                return db.ExecuteScalar<int>("SELECT COUNT(1) FROM units WHERE unit_code = @code", new { code }) > 0;
            }
        }

        // 5. Check if unit is referenced by products (Referential Integrity)
        public static bool IsUnitReferenced(string code)
        {
            using (var db = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                const string query = "SELECT COUNT(1) FROM products WHERE unit_name = @code OR pack_name = @code";
                return db.ExecuteScalar<int>(query, new { code }) > 0;
            }
        }
    }
}
