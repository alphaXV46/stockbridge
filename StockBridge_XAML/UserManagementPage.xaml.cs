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

        private System.Collections.Generic.List<dynamic> AddSequentialNumbers(System.Collections.Generic.List<dynamic> items)
        {
            var result = new System.Collections.Generic.List<dynamic>();
            for (int i = 0; i < items.Count; i++)
            {
                var item = items[i];
                var expando = new System.Dynamic.ExpandoObject() as System.Collections.Generic.IDictionary<string, object>;
                var dict = (System.Collections.Generic.IDictionary<string, object>)item;
                foreach (var kvp in dict)
                {
                    expando[kvp.Key] = kvp.Value;
                }
                expando["No"] = i + 1;
                result.Add(expando);
            }
            return result;
        }

        private void LoadUsers()
        {
            try
            {
                var rawList = UserRepository.GetAllUsers();
                var userList = AddSequentialNumbers(rawList);
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