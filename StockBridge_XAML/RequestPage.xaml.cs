using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Dapper;

namespace StockBridge_XAML
{
    public partial class RequestPage : Page
    {
        private string _role;

        public RequestPage(string role)
        {
            InitializeComponent();
            _role = role;
            LoadRequests();

            // Sembunyikan panel aksi jika user bukan Manager/Admin
            if (_role == "Staff")
            {
                panelManagerAction.Visibility = Visibility.Collapsed;
                // Staff tetap bisa lihat tombol New Request untuk minta stok
                btnNewRequest.Visibility = Visibility.Visible;
            }
        }

        private void LoadRequests()
        {
            try
            {
                using (var db = new SqlConnection(DatabaseHelper.ConnectionString))
                {
                    var data = db.Query("SELECT * FROM requests ORDER BY id DESC").ToList();
                    dgRequests.ItemsSource = data;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message);
            }
        }

        private void BtnApprove_Click(object sender, RoutedEventArgs e)
        {
            var selected = (dynamic)dgRequests.SelectedItem;
            if (selected == null)
            {
                MessageBox.Show("Silakan pilih permintaan yang ingin disetujui.", "Pilih Data", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (selected.status != "Pending")
            {
                MessageBox.Show("Hanya permintaan berstatus 'Pending' yang bisa diproses.", "Peringatan", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var confirm = MessageBox.Show($"Setujui permintaan {selected.product_name} sebanyak {selected.qty_requested} unit?",
                                         "Konfirmasi Approval", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (confirm == MessageBoxResult.Yes)
            {
                using (var db = new SqlConnection(DatabaseHelper.ConnectionString))
                {
                    db.Open();
                    using (var trans = db.BeginTransaction())
                    {
                        try
                        {
                            db.Execute("UPDATE requests SET status = 'Approved' WHERE id = @id", new { id = selected.id });
                            db.Execute("UPDATE products SET base_stock = base_stock - @qty WHERE product_name = @name",
                                        new { qty = selected.qty_requested, name = selected.product_name });
                            trans.Commit();
                            MessageBox.Show("Permintaan berhasil disetujui!", "Sukses", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            MessageBox.Show("Gagal memproses stok: " + ex.Message);
                        }
                    }
                }
                LoadRequests();
            }
        }

        private void BtnReject_Click(object sender, RoutedEventArgs e)
        {
            var selected = (dynamic)dgRequests.SelectedItem;
            if (selected == null) return;

            var confirm = MessageBox.Show("Tolak permintaan stok ini?", "Konfirmasi", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (confirm == MessageBoxResult.Yes)
            {
                using (var db = new SqlConnection(DatabaseHelper.ConnectionString))
                {
                    db.Execute("UPDATE requests SET status = 'Rejected' WHERE id = @id", new { id = selected.id });
                }
                LoadRequests();
            }
        }

        private void BtnNewRequest_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Navigasi ke Form Request baru...");
            // Di sini kamu bisa arahkan ke NavigationService.Navigate(new NewRequestPage());
        }
    }
}