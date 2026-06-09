using System;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;
using Dapper;

namespace StockBridge_XAML
{
    public partial class InventoryPage : Page
    {
        private readonly string _userRole;
        private List<dynamic> _fullProductList; // Untuk menyimpan data asli agar pencarian cepat

        public InventoryPage(string role)
        {
            InitializeComponent();
            _userRole = role;
            LoadData();

            // Sesuai role, Manager hanya bisa lihat stok (view only)
            if (_userRole == "Manager")
            {
                btnAddProduct.Visibility = Visibility.Collapsed;
                btnUpdateStock.Visibility = Visibility.Collapsed; // Biasanya Manager tidak input stok harian
            }
        }

        public void LoadData()
        {
            try
            {
                using (var db = new SqlConnection(DatabaseHelper.ConnectionString))
                {
                    _fullProductList = db.Query("SELECT * FROM products ORDER BY created_at DESC").ToList();
                    dgProducts.ItemsSource = _fullProductList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message);
            }
        }

        // Fitur Pencarian Real-time
        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_fullProductList == null) return;

            string keyword = txtSearch.Text.ToLower();
            Placeholder.Visibility = string.IsNullOrEmpty(keyword) ? Visibility.Visible : Visibility.Collapsed;

            var filtered = _fullProductList.Where(p =>
                p.product_name.ToString().ToLower().Contains(keyword) ||
                p.id.ToString().ToLower().Contains(keyword)
            ).ToList();

            dgProducts.ItemsSource = filtered;
        }

        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow win = new AddProductWindow { Owner = Window.GetWindow(this) };
            if (win.ShowDialog() is true) LoadData();
        }

        private void BtnUpdateStock_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = dgProducts.SelectedItem;
            if (selectedProduct == null)
            {
                MessageBox.Show("Mohon pilih item dari tabel untuk melakukan penyesuaian stok.");
                return;
            }

            UpdateStockWindow win = new UpdateStockWindow(selectedProduct) { Owner = Window.GetWindow(this) };
            if (win.ShowDialog() is true) LoadData();
        }

        private void BtnPrintQR_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = (dynamic)dgProducts.SelectedItem;
            if (selectedProduct == null)
            {
                MessageBox.Show("Pilih item terlebih dahulu untuk mencetak label QR.");
                return;
            }

            PrintQRWindow win = new PrintQRWindow(selectedProduct.id, selectedProduct.product_name) { Owner = Window.GetWindow(this) };
            win.ShowDialog();
        }
    }
}