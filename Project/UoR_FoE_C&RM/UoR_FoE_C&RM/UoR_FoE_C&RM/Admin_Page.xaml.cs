﻿using System;
using System.Linq;
using System.Windows;
using TrackUrRequest;

namespace UoR_FoE_C_RM
{
    public partial class Admin_Page : Window
    {
        private LinkedList complaints;
        private string userName;

        public Admin_Page(string Name)
        {
            InitializeComponent();
            userName = Name;
            complaints = new LinkedList();
            LoadFromCSV();
            DisplayComplaints();
        }

        // Method to load complaints from CSV
        public void LoadFromCSV()
        {
            string filePath = "complaints.csv";
            complaints.LoadFromCSV(filePath);
        }

        // Display complaints in the DataGrid
        private void DisplayComplaints()
        {
            ComplaintsDataGrid.ItemsSource = complaints.GetAllComplaints();  // Bind complaints to the DataGrid
        }

        // Event handler for when a complaint is selected from the DataGrid
        private void ComplaintsDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ComplaintsDataGrid.SelectedItem != null)
            {
                var selectedComplaint = ComplaintsDataGrid.SelectedItem as Complaint;
                if (selectedComplaint != null)
                {
                    PriorityTextBox.Text = selectedComplaint.Priority.ToString();
                    StatusTextBox.Text = selectedComplaint.Status;
                }
            }
        }

        // Handle the Change Priority button click
        private void ChangePriorityButton_Click(object sender, RoutedEventArgs e)
        {
            if (ComplaintsDataGrid.SelectedItem != null)
            {
                var selectedComplaint = ComplaintsDataGrid.SelectedItem as Complaint;
                if (selectedComplaint != null)
                {
                    int newPriority;
                    if (int.TryParse(PriorityTextBox.Text, out newPriority))
                    {
                        selectedComplaint.Priority = newPriority;
                        DisplayComplaints(); // Refresh the DataGrid
                        SaveToCSV(); // Save changes
                        MessageBox.Show("Priority Updated");
                    }
                    else
                    {
                        MessageBox.Show("Invalid priority value.");
                    }
                }
            }
        }

        // Handle the Change Status button click
        private void ChangeStatusButton_Click(object sender, RoutedEventArgs e)
        {
            if (ComplaintsDataGrid.SelectedItem != null)
            {
                var selectedComplaint = ComplaintsDataGrid.SelectedItem as Complaint;
                if (selectedComplaint != null)
                {
                    string newStatus = StatusTextBox.Text;
                    selectedComplaint.Status = newStatus;
                    DisplayComplaints(); // Refresh the DataGrid
                    SaveToCSV(); // Save changes
                    MessageBox.Show("Status Updated");
                }
            }
        }

        // Handle sorting complaints by Complaint ID
        private void SortComplaintsByID_Click(object sender, RoutedEventArgs e)
        {
            var sortedComplaints = complaints.GetAllComplaints().OrderBy(c => c.ComplaintID).ToList();
            ComplaintsDataGrid.ItemsSource = sortedComplaints;  // Update the DataGrid with sorted complaints
        }

        // Handle sorting complaints by Priority
        private void SortComplaintsByPriority_Click(object sender, RoutedEventArgs e)
        {
            var sortedComplaints = complaints.GetAllComplaints().OrderBy(c => c.Priority).ToList();
            ComplaintsDataGrid.ItemsSource = sortedComplaints;  // Update the DataGrid with sorted complaints
        }

        // Save complaints back to CSV
        public void SaveToCSV()
        {
            string filePath = "complaints.csv";
            complaints.SaveToCSV(filePath);
        }
    }
}
