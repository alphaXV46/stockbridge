using System.Windows;
using System.Windows.Media.Imaging;
using System.IO;
using System.Drawing.Imaging;
using ZXing;
using ZXing.Common;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Controls;
using System.Linq;

namespace StockBridge_XAML
{
    public partial class PrintQRWindow : Window
    {
        public PrintQRWindow(string idBarang, string namaBarang)
        {
            InitializeComponent();
            lblProductName.Text = namaBarang;
            lblProductId.Text = "ID/Barcode: " + idBarang;

            // Best Practice: QR Code dan Barcode pada label barang hanya memuat ID Barang saja (tidak memuat URL jaringan)
            // agar label yang dicetak bersifat permanen dan tidak rusak saat IP jaringan atau URL Ngrok berubah.
            imgQRCode.Source = GenerateImage(idBarang, BarcodeFormat.QR_CODE, 200, 200);
            imgBarcode.Source = GenerateImage(idBarang, BarcodeFormat.CODE_128, 250, 80);
        }


        private BitmapImage GenerateImage(string content, BarcodeFormat format, int width, int height)
        {
            var writer = new BarcodeWriter
            {
                Format = format,
                Options = new EncodingOptions { Height = height, Width = width, Margin = 1 }
            };

            var bmp = writer.Write(content);
            using (MemoryStream ms = new MemoryStream())
            {
                bmp.Save(ms, ImageFormat.Png);
                ms.Position = 0;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = ms;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                return bitmapImage;
            }
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(this, "Cetak Label Barang");
            }
        }
    }
}