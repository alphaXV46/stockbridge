using System;
using System.Windows;
using System.Windows.Controls;

namespace StockBridge_XAML
{
    public partial class UomPage : Page
    {
        private string _role;

        public UomPage(string role)
        {
            InitializeComponent();
            _role = role;
            
            // 1. Enforce RBAC rules on load
            ApplySecurityRules();
            
            // 2. Populate Grid
            LoadData();
        }

        private void ApplySecurityRules()
        {
            if (_role != "Admin")
            {
                // Disable creation panel and hide deletion bar for non-admins
                panelAdminAction.IsEnabled = false;
                panelAdminAction.Opacity = 0.5;
                panelDeleteAction.Visibility = Visibility.Collapsed;
            }
        }

        private void LoadData()
        {
            try
            {
                dgUnits.ItemsSource = UnitRepository.GetAllUnits();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengambil data satuan: " + ex.Message, "Kesalahan Database", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAddUnit_Click(object sender, RoutedEventArgs e)
        {
            // Security Guardrail
            if (_role != "Admin")
            {
                MessageBox.Show("Akses Ditolak! Hanya Administrator yang dapat menambah master satuan.", "Kesalahan Otorisasi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string code = txtUnitCode.Text.Trim();
            string name = txtUnitName.Text.Trim();

            // Validation 1: Blank checks
            if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Kode dan Nama satuan tidak boleh kosong!", "Validasi Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                // Validation 2: Duplicate check
                if (UnitRepository.UnitCodeExists(code))
                {
                    MessageBox.Show($"Satuan '{code}' sudah terdaftar!", "Duplikasi Data", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Add to DB
                UnitRepository.AddUnit(code, name);
                MessageBox.Show("Satuan berhasil ditambahkan!", "Sukses", MessageBoxButton.OK, MessageBoxImage.Information);
                
                // Clear and reload
                txtUnitCode.Clear();
                txtUnitName.Clear();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan data satuan: " + ex.Message, "Kesalahan", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnDeleteUnit_Click(object sender, RoutedEventArgs e)
        {
            // Security Guardrail
            if (_role != "Admin")
            {
                MessageBox.Show("Akses Ditolak! Hanya Administrator yang dapat menghapus master satuan.", "Kesalahan Otorisasi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var selected = (dynamic)dgUnits.SelectedItem;
            if (selected == null)
            {
                MessageBox.Show("Silakan pilih satuan dari tabel yang ingin dihapus.", "Pilih Data", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            string code = selected.unit_code;
            int id = selected.id;

            try
            {
                // Validation: Referential Integrity (Foreign Key Check in Inventory Products)
                if (UnitRepository.IsUnitReferenced(code))
                {
                    MessageBox.Show($"Satuan '{code}' tidak dapat dihapus karena sedang aktif digunakan oleh barang di inventaris!\n\nSilakan ubah data satuan barang tersebut terlebih dahulu sebelum menghapus satuan ini.", 
                                    "Pelanggaran Integritas Data", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var confirm = MessageBox.Show($"Apakah Anda yakin ingin menghapus satuan '{code}' ({selected.unit_name}) dari database secara permanen?", 
                                              "Konfirmasi Hapus Satuan", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (confirm == MessageBoxResult.Yes)
                {
                    UnitRepository.DeleteUnit(id);
                    MessageBox.Show("Satuan master berhasil dihapus!", "Sukses", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menghapus data satuan: " + ex.Message, "Kesalahan", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
