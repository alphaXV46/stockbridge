using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Dapper;

namespace StockBridge_XAML
{
    public partial class LogsPage : Page
    {
        public LogsPage()
        {
            InitializeComponent();
            LoadLogs();
        }

        private void LoadLogs()
        {
            try
            {
                using (var db = new SqlConnection(DatabaseHelper.ConnectionString))
                {
                    var logs = db.Query("SELECT * FROM stock_logs ORDER BY created_at DESC").ToList();
                    dgLogs.ItemsSource = logs;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat log transaksi: " + ex.Message);
            }
        }
    }
}