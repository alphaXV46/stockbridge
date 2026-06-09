using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Dapper;

namespace StockBridge_XAML
{
    public partial class UserManagementPage : Page
    {
        public UserManagementPage()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                var userList = UserRepository.GetAllUsers();
                dgUsers.ItemsSource = userList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message);
            }
        }

        private void BtnSaveUser_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewUser.Text) || string.IsNullOrWhiteSpace(txtNewPass.Text))
            {
                MessageBox.Show("Full Username and Password are required!", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                // Ambil role saja (buang keterangan di dalam kurung)
                string selectedRole = cbNewRole.Text.Split(' ')[0];

                UserRepository.InsertUser(txtNewUser.Text.Trim(), txtNewPass.Text, selectedRole);

                MessageBox.Show("New team member added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Reset form
                txtNewUser.Clear();
                txtNewPass.Clear();
                cbNewRole.SelectedIndex = 0;

                LoadUsers(); // Refresh tabel
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save user: " + ex.Message, "Database Error");
            }
        }
    }
}