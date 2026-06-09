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
        private System.Collections.Generic.List<dynamic> _allLogs;

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
                _allLogs = AddSequentialNumbers(rawLogs);
                ApplyFilterAndSearch();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat log transaksi: " + ex.Message);
            }
        }

        private void ApplyFilterAndSearch()
        {
            if (_allLogs == null) return;

            string searchText = txtSearchLogs.Text.Trim().ToLower();
            string selectedType = (cmbLogFilter.SelectedItem as ComboBoxItem)?.Content?.ToString();

            var filtered = _allLogs.Where(log =>
            {
                var dict = (System.Collections.Generic.IDictionary<string, object>)log;

                // Filter by Type
                if (selectedType == "Stock In (Masuk)")
                {
                    if (dict["type"]?.ToString() != "Masuk") return false;
                }
                else if (selectedType == "Stock Out (Keluar)")
                {
                    if (dict["type"]?.ToString() != "Keluar") return false;
                }

                // Filter by Search Text (matches product_id or type)
                if (!string.IsNullOrEmpty(searchText))
                {
                    string productId = dict.ContainsKey("product_id") ? dict["product_id"]?.ToString()?.ToLower() : "";
                    string type = dict.ContainsKey("type") ? dict["type"]?.ToString()?.ToLower() : "";

                    return productId.Contains(searchText) || type.Contains(searchText);
                }

                return true;
            }).ToList();

            // Re-apply sequential numbers based on filtered result
            var rawDataList = filtered.Select(x => {
                var dict = (System.Collections.Generic.IDictionary<string, object>)x;
                dict.Remove("No");
                return x;
            }).ToList();

            dgLogs.ItemsSource = AddSequentialNumbers(rawDataList);
        }

        private void TxtSearchLogs_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilterAndSearch();
        }

        private void CmbLogFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilterAndSearch();
        }

        private void BtnExportCSV_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var logs = dgLogs.ItemsSource as System.Collections.Generic.List<dynamic>;
                if (logs == null || logs.Count == 0)
                {
                    MessageBox.Show("Tidak ada data log transaksi untuk diekspor.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog
                {
                    Filter = "CSV files (*.csv)|*.csv",
                    FileName = $"StockBridge_Logs_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    var csvBuilder = new System.Text.StringBuilder();
                    // Header
                    csvBuilder.AppendLine("No,Waktu,SKU / Product ID,Tipe Aksi,Quantity,Stok Akhir");

                    foreach (var log in logs)
                    {
                        var dict = (System.Collections.Generic.IDictionary<string, object>)log;

                        string no = dict.ContainsKey("No") ? dict["No"]?.ToString() : "";
                        string time = dict.ContainsKey("created_at") && dict["created_at"] is DateTime dt
                            ? dt.ToString("yyyy-MM-dd HH:mm:ss")
                            : (dict.ContainsKey("created_at") ? dict["created_at"]?.ToString() : "");
                        string productId = dict.ContainsKey("product_id") ? dict["product_id"]?.ToString() : "";
                        string type = dict.ContainsKey("type") ? dict["type"]?.ToString() : "";
                        string qty = dict.ContainsKey("quantity") ? dict["quantity"]?.ToString() : "";
                        string finalBalance = dict.ContainsKey("total_affected") ? dict["total_affected"]?.ToString() : "";

                        // Sanitasi karakter koma untuk format CSV
                        no = EscapeCSV(no);
                        time = EscapeCSV(time);
                        productId = EscapeCSV(productId);
                        type = EscapeCSV(type);
                        qty = EscapeCSV(qty);
                        finalBalance = EscapeCSV(finalBalance);

                        csvBuilder.AppendLine($"{no},{time},{productId},{type},{qty},{finalBalance}");
                    }

                    System.IO.File.WriteAllText(saveFileDialog.FileName, csvBuilder.ToString(), System.Text.Encoding.UTF8);
                    MessageBox.Show("Laporan log transaksi berhasil diekspor ke file CSV!", "Ekspor Sukses", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengekspor data: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private string EscapeCSV(string value)
        {
            if (string.IsNullOrEmpty(value)) return "";
            if (value.Contains(",") || value.Contains("\"") || value.Contains("\n") || value.Contains("\r"))
            {
                return "\"" + value.Replace("\"", "\"\"") + "\"";
            }
            return value;
        }
    }
}