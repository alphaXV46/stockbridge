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

        private System.Collections.Generic.List<dynamic> AddSequentialNumbers(System.Collections.Generic.List<dynamic> items)
        {
            var result = new System.Collections.Generic.List<dynamic>();
            for (int i = 0; i < items.Count; i++)
            {
                var item = items[i];
                var expando = new System.Dynamic.ExpandoObject() as System.Collections.Generic.IDictionary<string, object>;
                var dict = (System.Collections.Generic.IDictionary<string, object>)item;
                foreach (var kvp in dict)
                {
                    expando[kvp.Key] = kvp.Value;
                }
                expando["No"] = i + 1;
                result.Add(expando);
            }
            return result;
        }

        private void LoadLogs()
        {
            try
            {
                var rawLogs = ProductRepository.GetStockLogs();
                var logs = AddSequentialNumbers(rawLogs);
                dgLogs.ItemsSource = logs;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat log transaksi: " + ex.Message);
            }
        }
    }
}