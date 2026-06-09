using System;
using System.Windows;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Media.Imaging;
using System.IO;
using System.Drawing.Imaging;
using ZXing;
using ZXing.Common;
using System.Linq;

namespace StockBridge_XAML
{
    public partial class ConnectMobileWindow : Window
    {
        public ConnectMobileWindow()
        {
            InitializeComponent();
            GenerateConnectionQR();
        }

        private void GenerateConnectionQR(string customUrl = null)
        {
            try
            {
                string url = customUrl;
                if (string.IsNullOrEmpty(url))
                {
                    string localIP = NetworkHelper.GetRealLocalIP();
                    url = $"http://{localIP}:8080/";
                }

                if (!url.EndsWith("/"))
                {
                    url += "/";
                }

                // Pastikan di XAML kamu ada TextBlock dengan nama lblIPAddress
                if (lblIPAddress != null)
                    lblIPAddress.Text = $"Server Aktif: {url}";

                var writer = new BarcodeWriter
                {
                    Format = BarcodeFormat.QR_CODE,
                    Options = new EncodingOptions { Height = 200, Width = 200, Margin = 1 }
                };

                var bmp = writer.Write(url);

                using (MemoryStream ms = new MemoryStream())
                {
                    bmp.Save(ms, ImageFormat.Png);
                    ms.Position = 0;
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = ms;
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.EndInit();

                    // Pastikan di XAML kamu ada Image dengan nama imgQRCode
                    if (imgQRCode != null)
                        imgQRCode.Source = bitmapImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal membuat QR: " + ex.Message);
            }
        }

        private void BtnGenerateCustom_Click(object sender, RoutedEventArgs e)
        {
            string url = txtCustomURL.Text.Trim();
            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Silakan masukkan URL Ngrok HTTPS terlebih dahulu.", "Peringatan", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            GenerateConnectionQR(url);
        }

        // --- FIX: FUNGSI UNTUK MENUTUP JENDELA ---
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}