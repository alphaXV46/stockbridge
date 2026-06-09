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
                using (var db = new SqlConnection(DatabaseHelper.ConnectionString))
                {
                    db.Open();
                    // Mengambil data user untuk ditampilkan di tabel
                    var userList = db.Query("SELECT id, username, role FROM users").ToList();
                    dgUsers.ItemsSource = userList;
                }
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

                using (var db = new SqlConnection(DatabaseHelper.ConnectionString))
                {
                    db.Open();
                    string hashedPassword = DatabaseHelper.HashPassword(txtNewPass.Text);
                    const string sql = "INSERT INTO users (username, password, role) VALUES (@u, @p, @r)";
                    db.Execute(sql, new
                    {
                        u = txtNewUser.Text.Trim(),
                        p = hashedPassword,
                        r = selectedRole
                    });
                }

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