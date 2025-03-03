using System;
using System.Windows;
using System.Windows.Controls;
using TrackUrRequest;

namespace UoR_FoE_C_RM
{
    public partial class User_Page : Window
    {
        private string userName;
        private LinkedList complaints = new LinkedList();
        private int complaintCounter = 1;

        public User_Page(string Name)
        {
            InitializeComponent();
            userName = Name;
            LoadFromCSV();
            complaintCounter = GetMaxComplaintID() + 1;
            UpdateComplaintListView();
        }

        private void AddComplaint_Click(object sender, RoutedEventArgs e)
        {
            if (CategoryComboBox.SelectedItem == null || string.IsNullOrWhiteSpace(ComplaintTextBox.Text))
            {
                MessageBox.Show("Please select a category and enter a valid complaint.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string category = ((ComboBoxItem)CategoryComboBox.SelectedItem).Content.ToString();
            string description = ComplaintTextBox.Text;

            Complaint newComplaint = new Complaint(complaintCounter++, userName, category, description);
            complaints.Add(newComplaint);
            SaveToCSV();
            UpdateComplaintListView();

            MessageBox.Show("Complaint added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            ComplaintTextBox.Clear();
        }

        private void EditComplaint_Click(object sender, RoutedEventArgs e)
        {
            if (ComplaintsListView.SelectedItem is Complaint selectedComplaint)
            {
                string newDescription = ComplaintTextBox.Text.Trim();
                if (string.IsNullOrWhiteSpace(newDescription))
                {
                    MessageBox.Show("Complaint description cannot be empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (complaints.Edit(selectedComplaint.ComplaintID, userName, newDescription))
                {
                    SaveToCSV();
                    UpdateComplaintListView();
                    MessageBox.Show("Complaint updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Failed to update complaint. You might not have permission to edit it.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a complaint to edit.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            SaveToCSV();
            MessageBox.Show("Logging out...", "Logout", MessageBoxButton.OK, MessageBoxImage.Information);
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void LoadFromCSV()
        {
            string filePath = "complaints.csv";
            complaints.LoadFromCSV(filePath);
        }

        private void SaveToCSV()
        {
            string filePath = "complaints.csv";
            complaints.SaveToCSV(filePath);
        }

        private int GetMaxComplaintID()
        {
            int maxID = 0;
            Node current = complaints.Head;
            while (current != null)
            {
                if (current.Data.ComplaintID > maxID)
                {
                    maxID = current.Data.ComplaintID;
                }
                current = current.Next;
            }
            return maxID;
        }

        private void UpdateComplaintListView()
        {
            ComplaintsListView.Items.Clear();
            Node current = complaints.Head;
            while (current != null)
            {
                if (current.Data.UserName == userName)
                {
                    ComplaintsListView.Items.Add(current.Data);
                }
                current = current.Next;
            }
        }
    }
}
