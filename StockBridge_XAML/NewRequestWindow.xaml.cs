using System;
using System.Windows;

namespace StockBridge_XAML
{
    public partial class NewRequestWindow : Window
    {
        public NewRequestWindow()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                cbProducts.ItemsSource = ProductRepository.GetAllProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat produk: " + ex.Message);
            }
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (cbProducts.SelectedValue == null)
            {
                MessageBox.Show("Pilih Produk terlebih dahulu!", "Validasi Gagal", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(txtQuantity.Text, out int qty) || qty <= 0)
            {
                MessageBox.Show("Masukkan jumlah quantity permintaan yang valid (angka bulat positif).", "Validasi Gagal", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                string productName = cbProducts.SelectedValue.ToString();
                RequestRepository.InsertRequest(productName, qty);

                MessageBox.Show("Berhasil mengirimkan permintaan restock!", "Sukses", MessageBoxButton.OK, MessageBoxImage.Information);
                this.DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengirimkan permintaan: " + ex.Message, "Error Database");
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
