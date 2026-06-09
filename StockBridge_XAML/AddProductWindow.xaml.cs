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
        }

        // PERBAIKAN: Sinkronisasi algoritma pencarian IP Wi-Fi asli
        private string GetRealLocalIP()
        {
            try
            {
                foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (ni.OperationalStatus == OperationalStatus.Up && ni.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                    {
                        var props = ni.GetIPProperties();
                        if (props.GatewayAddresses.Any())
                        {
                            foreach (var ip in props.UnicastAddresses)
                            {
                                if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                                {
                                    return ip.Address.ToString();
                                }
                            }
                        }
                    }
                }
            }
            catch { }
            return "localhost";
        }

        private void LoadCategories()
        {
            try
            {
                using (var db = new SqlConnection(DatabaseHelper.ConnectionString))
                {
                    var categories = db.Query("SELECT * FROM categories").ToList();
                    cbCategory.ItemsSource = categories;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat kategori: " + ex.Message);
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text)) { MessageBox.Show("ID Barang wajib diisi!"); return; }
            if (cbCategory.SelectedValue == null) { MessageBox.Show("Pilih Kategori terlebih dahulu!"); return; }

            try
            {
                using (var db = new SqlConnection(DatabaseHelper.ConnectionString))
                {
                    const string sql = @"INSERT INTO products (id, product_name, category_id, base_stock, unit_name, pack_name, conversion_rate, price, description) 
                                   VALUES (@id, @name, @cat, @stock, @unit, @pack, @conv, @price, @desc)";

                    db.Execute(sql, new
                    {
                        id = txtId.Text,
                        name = txtName.Text,
                        cat = cbCategory.SelectedValue,
                        stock = int.Parse(txtStock.Text),
                        unit = cbUnitName.Text,
                        pack = cbPackName.Text,
                        conv = int.Parse(txtConvRate.Text),
                        price = double.Parse(txtPrice.Text),
                        desc = txtDescription.Text
                    });
                }

                string ip = GetRealLocalIP();
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