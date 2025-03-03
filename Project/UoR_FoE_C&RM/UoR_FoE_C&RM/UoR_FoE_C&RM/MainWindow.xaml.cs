using System;
using System.Windows;
using TrackUrRequest;
using TrackUrRequest.pages;

namespace UoR_FoE_C_RM
{
    public partial class MainWindow : Window
    {
        // Create an instance of the Tracker class
        private Tracker tracker;

        public MainWindow()
        {
            InitializeComponent();
            tracker = new Tracker(); // Initialize Tracker
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text; // Get the username from the input field
            string password = PasswordBox.Password; // Get the password from the input field

            // Check login credentials using Tracker
            if (tracker.check_login(username, password))
            {
                // If the user is an admin, go to the Admin page
                if (tracker.detec_page(username) == 1)
                {
                    // Open Admin Page (you can create a new window or page for the admin)
                    Admin_Page adminPage = new Admin_Page("Admin");
                    adminPage.Show();
                    this.Close(); // Close the current window (login window)
                }
                else if (tracker.detec_page(username) == 2)
                {

                    Developer_PageWindow devPage = new Developer_PageWindow("Developer");
                    devPage.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Access denied. Only Admins can log in.");
                }
            }
            else
            {
                MessageBox.Show("Invalid login credentials.");
            }
        }
    }
}
