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
                var logs = ProductRepository.GetStockLogs();
                dgLogs.ItemsSource = logs;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat log transaksi: " + ex.Message);
            }
        }
    }
}