using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace TrackUrRequest.pages
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

            public override string ToString()
            {
                return $"{ID} - {Password}";
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


            lstUsers.Items.Add(user.ToString());
        }


        private void btnRemoveUser_Click(object sender, RoutedEventArgs e)
        {

            if (lstUsers.SelectedItem == null)
            {
                MessageBox.Show("Please select a user to remove.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string selectedUserText = lstUsers.SelectedItem.ToString();
            var selectedUserId = selectedUserText.Split('-')[0].Trim();

            var userNode = SearchUser(selectedUserId);
            if (userNode != null)
            {
                users.Remove(userNode);
                MessageBox.Show($"User with ID {selectedUserId} removed successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                SaveUsersToCsv();
                ClearInputs();


                lstUsers.Items.Clear();
                foreach (var user in users)
                {
                    lstUsers.Items.Add(user.ToString());
                }
            }
            else
            {
                MessageBox.Show("User not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        private void btnDisplayUsers_Click(object sender, RoutedEventArgs e)
        {
            lstUsers.Items.Clear();
            foreach (var user in users)
            {
                lstUsers.Items.Add(user.ToString());
            }
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
        }


        private LinkedListNode<User> SearchUser(string id)
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
            Application.Current.Shutdown();
        }


        private void lstUsers_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (lstUsers.SelectedItem != null)
            {
                var selectedUser = lstUsers.SelectedItem.ToString();

            }
        }
    }
}
