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
                var data = RequestRepository.GetAllRequests();
                dgRequests.ItemsSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message);
            }
        }

        private void BtnApprove_Click(object sender, RoutedEventArgs e)
        {
            if (_role != "Manager" && _role != "Admin")
            {
                MessageBox.Show("Akses Ditolak! Anda tidak memiliki izin untuk menyetujui permintaan.", "Kesalahan Otorisasi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

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
                try
                {
                    RequestRepository.ApproveRequest((int)selected.id, (int)selected.qty_requested, (string)selected.product_name);
                    MessageBox.Show("Permintaan berhasil disetujui!", "Sukses", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memproses stok: " + ex.Message);
                }
                LoadRequests();
            }
        }

        private void BtnReject_Click(object sender, RoutedEventArgs e)
        {
            if (_role != "Manager" && _role != "Admin")
            {
                MessageBox.Show("Akses Ditolak! Anda tidak memiliki izin untuk menolak permintaan.", "Kesalahan Otorisasi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var selected = (dynamic)dgRequests.SelectedItem;
            if (selected == null) return;

            var confirm = MessageBox.Show("Tolak permintaan stok ini?", "Konfirmasi", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (confirm == MessageBoxResult.Yes)
            {
                RequestRepository.RejectRequest((int)selected.id);
                LoadRequests();
            }
        }

        private void BtnNewRequest_Click(object sender, RoutedEventArgs e)
        {
            NewRequestWindow win = new NewRequestWindow { Owner = Window.GetWindow(this) };
            if (win.ShowDialog() == true)
            {
                LoadRequests();
            }
        }
    }
}