using System;
using System.Windows;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Data.SqlClient;
using Dapper;
using ZXing;
using ZXing.Common;

namespace StockBridge_XAML
{
    public partial class AddProductWindow : Window
    {
        public AddProductWindow()
        {
            InitializeComponent();
            LoadCategories();
            LoadUnits();

            // Register event handlers for live preview
            cbUnitName.SelectionChanged += (s, ev) => UpdateConversionPreview();
            cbPackName.SelectionChanged += (s, ev) => UpdateConversionPreview();
            txtConvRate.TextChanged += (s, ev) => UpdateConversionPreview();

            // Initialize preview
            UpdateConversionPreview();
        }

        private void UpdateConversionPreview()
        {
            if (lblConversionPreview == null) return;

            string unitName = cbUnitName.SelectedItem as string;
            string packName = cbPackName.SelectedItem as string;
            string rateText = txtConvRate.Text?.Trim();

            if (string.IsNullOrEmpty(unitName)) unitName = "[Satuan]";
            if (string.IsNullOrEmpty(packName)) packName = "[Kemasan]";
            if (string.IsNullOrEmpty(rateText)) rateText = "1";

            lblConversionPreview.Text = $"Hasil Konversi: 1 {packName} = {rateText} {unitName}";
        }

        private void LoadCategories()
        {
            try
            {
                var categories = ProductRepository.GetCategories();
                cbCategory.ItemsSource = categories;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat kategori: " + ex.Message);
            }
        }

        private void LoadUnits()
        {
            try
            {
                var units = UnitRepository.GetAllUnits();
                // Select only the string codes to bind as a raw string list
                var unitCodes = units.Select(u => (string)u.unit_code).ToList();

                cbUnitName.ItemsSource = unitCodes;
                cbPackName.ItemsSource = unitCodes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat satuan: " + ex.Message);
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text)) { MessageBox.Show("ID Barang wajib diisi!", "Validasi Gagal", MessageBoxButton.OK, MessageBoxImage.Warning); return; }
            if (string.IsNullOrWhiteSpace(txtName.Text)) { MessageBox.Show("Nama Produk wajib diisi!", "Validasi Gagal", MessageBoxButton.OK, MessageBoxImage.Warning); return; }
            if (cbCategory.SelectedValue == null) { MessageBox.Show("Pilih Kategori terlebih dahulu!", "Validasi Gagal", MessageBoxButton.OK, MessageBoxImage.Warning); return; }
            if (cbUnitName.SelectedItem == null) { MessageBox.Show("Pilih Satuan Eceran (Unit) terlebih dahulu!", "Validasi Gagal", MessageBoxButton.OK, MessageBoxImage.Warning); return; }
            if (cbPackName.SelectedItem == null) { MessageBox.Show("Pilih Satuan Kemasan (Pack) terlebih dahulu!", "Validasi Gagal", MessageBoxButton.OK, MessageBoxImage.Warning); return; }

            if (!int.TryParse(txtStock.Text, out int stockVal) || stockVal < 0)
            {
                MessageBox.Show("Masukkan jumlah stok awal yang valid (angka bulat non-negatif).", "Validasi Gagal", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(txtConvRate.Text, out int convVal) || convVal <= 0)
            {
                MessageBox.Show("Masukkan rate konversi yang valid (angka bulat positif).", "Validasi Gagal", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!double.TryParse(txtPrice.Text, out double priceVal) || priceVal < 0)
            {
                MessageBox.Show("Masukkan harga beli yang valid (angka non-negatif).", "Validasi Gagal", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                ProductRepository.InsertProduct(
                    txtId.Text.Trim(),
                    txtName.Text.Trim(),
                    (int)cbCategory.SelectedValue,
                    stockVal,
                    cbUnitName.SelectedItem as string,
                    cbPackName.SelectedItem as string,
                    convVal,
                    priceVal,
                    txtDescription.Text
                );

                string ip = NetworkHelper.GetRealLocalIP();
                string qrLink = $"http://{ip}:8080/?id={txtId.Text}";

                GenerateFile(qrLink, txtId.Text, "QRCodes", BarcodeFormat.QR_CODE);
                GenerateFile(txtId.Text, txtId.Text, "Barcodes", BarcodeFormat.CODE_128);

                MessageBox.Show("Berhasil! Data barang telah tersimpan.", "Sukses", MessageBoxButton.OK, MessageBoxImage.Information);
                this.DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Simpan: " + ex.Message);
            }
        }

        private void GenerateFile(string content, string id, string folder, BarcodeFormat format)
        {
            try
            {
                var writer = new BarcodeWriter
                {
                    Format = format,
                    Options = new EncodingOptions { Height = 200, Width = 300, Margin = 10 }
                };

                var bmp = writer.Write(content);
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, folder);

                if (!Directory.Exists(path)) Directory.CreateDirectory(path);

                string fileName = id.Replace("/", "_").Replace("\\", "_") + ".png";
                bmp.Save(Path.Combine(path, fileName), ImageFormat.Png);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal Generate Gambar: " + ex.Message);
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e) => this.Close();
    }
}