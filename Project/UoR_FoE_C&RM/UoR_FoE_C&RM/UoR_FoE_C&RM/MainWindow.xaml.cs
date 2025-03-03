using System;
using System.Windows;
using TrackUrRequest;
using TrackUrRequest.pages;

namespace UoR_FoE_C_RM
{
    public partial class MainWindow : Window
    {
        private Tracker tracker;

        public MainWindow()
        {
            InitializeComponent();
            tracker = new Tracker();
        }

        private void LoginButton_Enter(object sender, RoutedEventArgs e)
        {
            LoginButton_Click(sender, e);
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            if (tracker.check_login(username, password))
            {
                if (tracker.detec_page(username) == 1)
                {
                    Admin_Page adminPage = new Admin_Page("Admin");
                    adminPage.Show();
                    this.Close();
                }
                else if (tracker.detec_page(username) == 2)
                {

                    Developer_PageWindow devPage = new Developer_PageWindow("Developer");
                    devPage.Show();
                    this.Close();
                }
                else if (tracker.detec_page(username) == 3)
                {
                    User_Page userPage = new User_Page(username);
                    userPage.Show();
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
