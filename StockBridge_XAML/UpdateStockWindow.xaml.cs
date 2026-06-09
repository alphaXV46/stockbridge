using System;
using System.Data.SqlClient;
using System.Windows;
using Dapper;

namespace StockBridge_XAML
{
    public partial class UpdateStockWindow : Window
    {
        private dynamic _product;

        public UpdateStockWindow(dynamic product)
        {
            InitializeComponent();
            _product = product;

            // Setup Tampilan
            lblProductName.Text = _product.product_name.ToString().ToUpper();
            itemUnit.Content = $"Unit ({_product.unit_name})";
            itemPack.Content = $"Pack ({_product.pack_name}) @{_product.conversion_rate}";
        }

        private void BtnProcess_Click(object sender, RoutedEventArgs e)
        {
            // Validasi Input
            if (!int.TryParse(txtQuantity.Text, out int qtyInput) || qtyInput <= 0)
            {
                MessageBox.Show("Masukkan jumlah quantity yang valid (angka positif).", "Input Salah");
                return;
            }

            try
            {
                // Ambil tipe transaksi secara aman
                string fullTypeText = cbTransactionType.Text;
                string type = fullTypeText.Contains("Masuk") ? "Masuk" : "Keluar";

                // Logika Konversi Satuan
                int multiplier = (cbUnitType.SelectedIndex == 1) ? (int)_product.conversion_rate : 1;
                int totalAffected = qtyInput * multiplier;

                using (var db = new SqlConnection(DatabaseHelper.ConnectionString))
                {
                    db.Open();
                    using (var trans = db.BeginTransaction())
                    {
                        // Operasi Matematika SQL
                        string op = (type == "Masuk") ? "+" : "-";
                        db.Execute($"UPDATE products SET base_stock = base_stock {op} @diff WHERE id = @id",
                                   new { diff = totalAffected, id = _product.id },
                                   transaction: trans);

                        // Catat Riwayat (Log)
                        db.Execute(@"INSERT INTO stock_logs (product_id, type, quantity, total_affected, created_at) 
                                     VALUES (@pid, @type, @qty, @total, GETDATE())",
                                     new { pid = _product.id, type = type, qty = qtyInput, total = totalAffected },
                                     transaction: trans);

                        trans.Commit();
                    }
                }

                MessageBox.Show($"Berhasil memperbarui stok {totalAffected} unit!", "Berhasil", MessageBoxButton.OK, MessageBoxImage.Information);
                this.DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memperbarui stok: " + ex.Message, "Error Database");
            }
        }
    }
}