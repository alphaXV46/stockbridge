using System;
using System.Windows;
using System.Windows.Input;
using System.Net;
using System.Threading.Tasks;
using System.Text;
using System.Data.SqlClient;
using Dapper;

namespace StockBridge_XAML
{
    public partial class DashboardWindow : Window
    {
        private string _role;
        private HttpListener _listener;

        public DashboardWindow(string role)
        {
            InitializeComponent();
            _role = role;
            lblWelcome.Text = $"Welcome, {_role}";
            ApplyAccessControl();

            if (_role != "Manager") { StartMobileServer(); }
        }

        private void ApplyAccessControl()
        {
            if (_role != "Admin") 
            { 
                if (btnMenuUsers != null) btnMenuUsers.Visibility = Visibility.Collapsed; 
                if (btnMenuUom != null) btnMenuUom.Visibility = Visibility.Collapsed; 
            }
            if (_role == "Staff") { if (btnMenuLogs != null) btnMenuLogs.Visibility = Visibility.Collapsed; }
            if (_role == "Manager") { if (btnConnectMobile != null) btnConnectMobile.Visibility = Visibility.Collapsed; }
        }

        private void StartMobileServer()
        {
            try
            {
                _listener = new HttpListener();
                _listener.Prefixes.Add("http://*:8080/");
                _listener.Start();
                ProductRepository.LogSystemEvent("Server Start");

                Task.Run(() =>
                {
                    while (_listener.IsListening)
                    {
                        try
                        {
                            var context = _listener.GetContext();
                            var request = context.Request;
                            var response = context.Response;

                            string idBarang = request.QueryString["id"];

                            if (!string.IsNullOrEmpty(idBarang))
                            {
                                byte[] okBuffer = Encoding.UTF8.GetBytes("OK");
                                response.OutputStream.Write(okBuffer, 0, okBuffer.Length);
                                response.OutputStream.Close();

                                Application.Current.Dispatcher.BeginInvoke(new Action(() => OpenUpdateFromMobile(idBarang)));
                            }
                            else
                            {
                                // PERBAIKAN: Menambahkan sistem "Anti-Spam" di script scanner
                                string htmlWebScanner = @"
                                <!DOCTYPE html>
                                <html lang='id'>
                                <head>
                                    <meta charset='UTF-8'>
                                    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                                    <title>Scanner Gudang</title>
                                    <script src='https://unpkg.com/html5-qrcode'></script>
                                </head>
                                <body style='text-align:center; font-family:sans-serif; background:#ECF0F1; padding:20px;'>
                                    <h2 style='color:#2C3E50;'>📱 Arahkan ke Barcode / QR Barang Saja</h2>
                                    <div id='reader' style='width:100%; max-width:400px; margin:0 auto; background:white; padding:10px; border-radius:10px;'></div>
                                    <p id='status' style='margin-top:20px; font-weight:bold; color:#27AE60;'></p>

                                    <script>
                                        let isProcessing = false; // Sistem Anti-Spam

                                        function onScanSuccess(decodedText) {
                                            if(isProcessing) return; // Kalau lagi proses, abaikan scan baru
                                            
                                            isProcessing = true; // Kunci sistem
                                            document.getElementById('status').innerText = 'Mengirim ID: ' + decodedText;
                                            
                                            fetch('/?id=' + decodedText)
                                                .then(response => {
                                                    document.getElementById('status').innerText = '✔️ Cek Layar Laptop!';
                                                    // Buka kunci setelah 3 detik
                                                    setTimeout(() => { isProcessing = false; document.getElementById('status').innerText = 'Siap Scan Lagi'; }, 3000);
                                                })
                                                .catch(err => {
                                                    alert('Gagal koneksi ke laptop');
                                                    isProcessing = false;
                                                });
                                        }

                                        let scanner = new Html5QrcodeScanner('reader', { fps: 10, qrbox: 250 });
                                        scanner.render(onScanSuccess);
                                    </script>
                                </body>
                                </html>";

                                byte[] buffer = Encoding.UTF8.GetBytes(htmlWebScanner);
                                response.ContentType = "text/html; charset=utf-8";
                                response.ContentLength64 = buffer.Length;
                                response.OutputStream.Write(buffer, 0, buffer.Length);
                                response.OutputStream.Close();
                            }
                        }
                        catch { }
                    }
                });
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Aplikasi mendeteksi bahwa hak akses Administrator belum aktif.\n\n" +
                    "Harap jalankan Visual Studio (atau file .exe program) dengan cara:\n" +
                    "Klik Kanan -> 'Run as Administrator'\n\n" +
                    "Ini diperlukan agar fitur Sinkronisasi HP (QR/Barcode Scanner) dapat berjalan.",
                    "Hak Akses Administrator Diperlukan",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                );
            }
        }

        // ... (Fungsi OpenUpdateFromMobile dan lainnya tetap sama seperti sebelumnya) ...
        private void OpenUpdateFromMobile(string id)
        {
            var product = ProductRepository.GetProductById(id);
            if (product != null)
            {
                UpdateStockWindow win = new UpdateStockWindow(product);
                win.Owner = this;
                win.ShowDialog();
                if (MainFrame.Content is InventoryPage page) { page.LoadData(); }
            }
            else
            {
                MessageBox.Show("Barang tidak ditemukan di database: " + id, "Peringatan", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnConnectMobile_Click(object sender, RoutedEventArgs e) { new ConnectMobileWindow { Owner = this }.ShowDialog(); }
        private void MenuUsers_Click(object sender, RoutedEventArgs e) { DefaultContent.Visibility = Visibility.Collapsed; MainFrame.Navigate(new UserManagementPage()); }
        private void MenuInventory_Click(object sender, RoutedEventArgs e) { DefaultContent.Visibility = Visibility.Collapsed; MainFrame.Navigate(new InventoryPage(_role)); }
        private void MenuRequest_Click(object sender, RoutedEventArgs e) { DefaultContent.Visibility = Visibility.Collapsed; MainFrame.Navigate(new RequestPage(_role)); }
        private void MenuLogs_Click(object sender, RoutedEventArgs e) { DefaultContent.Visibility = Visibility.Collapsed; MainFrame.Navigate(new LogsPage()); }
        private void MenuUom_Click(object sender, RoutedEventArgs e) { DefaultContent.Visibility = Visibility.Collapsed; MainFrame.Navigate(new UomPage(_role)); }
        private void BtnLogout_Click(object sender, RoutedEventArgs e) 
        { 
            if (_listener != null) 
            {
                try
                {
                    _listener.Stop();
                    ProductRepository.LogSystemEvent("Server Stop");
                }
                catch { }
            } 
            new MainWindow().Show(); 
            this.Close(); 
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void BtnToggleFullscreen_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = this.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Header_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && this.WindowState != WindowState.Maximized)
            {
                this.DragMove();
            }
        }
    }
}