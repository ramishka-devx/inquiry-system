using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace UoR_FoE_C_RM
{
    public partial class Developer_PageWindow : Window
    {
        private LinkedList<User> users;
        private string userRole;

        public Developer_PageWindow(string role = null)
        {
            InitializeComponent();
            userRole = role;
            SetWindowTitle();
            users = new LinkedList<User>();
            LoadUsersFromCsv();
        }

        private void SetWindowTitle()
        {
            this.Title = string.IsNullOrEmpty(userRole) ? "User Management System" : $"{userRole} - User Management System";
        }

        private class User
        {
            public string ID { get; set; }
            public string Password { get; set; }

            public User(string id, string password)
            {
                ID = id ?? throw new ArgumentNullException(nameof(id));
                Password = password ?? throw new ArgumentNullException(nameof(password));
            }
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            string id = txtUserID.Text;
            string password = txtPassword.Password;

            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("User ID and Password cannot be empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var user = new User(id, password);
            users.AddLast(user);
            MessageBox.Show($"User with ID {id} added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            SaveUsersToCsv();
            ClearInputs();
            DisplayUsers();
        }

        private void btnRemoveUser_Click(object sender, RoutedEventArgs e)
        {
            if (dgUsers.SelectedItem == null)
            {
                MessageBox.Show("Please select a user to remove.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var selectedUser = dgUsers.SelectedItem as User;
            if (selectedUser != null)
            {
                users.Remove(FindUserNodeById(selectedUser.ID));
                MessageBox.Show($"User with ID {selectedUser.ID} removed successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                SaveUsersToCsv();
                DisplayUsers();
            }
        }

        private void btnDisplayUsers_Click(object sender, RoutedEventArgs e)
        {
            var sortedUsers = new List<User>(users);
            sortedUsers.Sort((user1, user2) => string.Compare(user1.ID, user2.ID));

            // Bind the sorted users to the DataGrid
            dgUsers.ItemsSource = sortedUsers;

        }

        private void DisplayUsers()
        {
            dgUsers.ItemsSource = null;
            dgUsers.ItemsSource = users;
        }

        private void SaveUsersToCsv()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "users.csv");
            using (var writer = new StreamWriter(filePath))
            {
                foreach (var user in users)
                {
                    writer.WriteLine($"{user.ID},{user.Password}");
                }
            }
        }

        private void LoadUsersFromCsv()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "users.csv");
            if (File.Exists(filePath))
            {
                using (var reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split(',');
                        if (parts.Length == 2)
                        {
                            var user = new User(parts[0], parts[1]);
                            users.AddLast(user);
                        }
                    }
                }
            }
            DisplayUsers();
        }

        private LinkedListNode<User> FindUserNodeById(string id)
        {
            var currentNode = users.First;
            while (currentNode != null)
            {
                if (currentNode.Value.ID == id)
                {
                    return currentNode;
                }
                currentNode = currentNode.Next;
            }
            return null;
        }

        private void ClearInputs()
        {
            txtUserID.Clear();
            txtPassword.Clear();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void dgUsers_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Handle selection changes if necessary
        }
        
    }
}
