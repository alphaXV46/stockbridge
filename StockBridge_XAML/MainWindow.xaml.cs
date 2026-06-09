using System;
using System.Windows;
using System.Windows.Input;
using System.Data.SqlClient;
using Dapper;

namespace StockBridge_XAML
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitSystem();
        }

        private void InitSystem()
        {
            try
            {
                DatabaseHelper.InitializeDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"System Error: {ex.Message}", "Init Failure", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPass.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Authentication Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var userFound = UserRepository.Authenticate(username, password);

                if (userFound != null)
                {
                    string role = userFound.role;
                    DashboardWindow dashboard = new DashboardWindow(role);
                    dashboard.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid credentials. Please try again.", "Access Denied", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database connection failed: {ex.Message}", "Technical Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && this.WindowState != WindowState.Maximized)
            {
                this.DragMove();
            }
        }
    }
}