using System;
using System.Collections.Generic;
using System.IO;

namespace TrackUrRequest
{
    public class UserPage
    {
        string userName = "";
        List<Complaint> complaints = new List<Complaint>();
        int complaintCounter = 1;

        public UserPage(string Name)
        {
            userName = Name;
            LoadFromCSV(); 
            complaintCounter = complaints.Count + 1; 
        }

        public void WelcomeTXT()
        {
            Console.WriteLine($"Hello {userName}");
        }

        public void App()
        {
            WelcomeTXT();
            Console.WriteLine("Welcome to the User Page!!!");

            int choice = 0;
            do
            {
                Console.WriteLine("\n1. Add New Complaint");
                Console.WriteLine("2. View Complaints");
                Console.WriteLine("3. Edit Complaint");
                Console.WriteLine("4. Logout");
                Console.Write("Select an option: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddComplaint();
                        break;
                    case 2:
                        ViewComplaints();
                        break;
                    case 3:
                        EditComplaint();
                        break;
                    case 4:
                        SaveToCSV();
                        Console.WriteLine("Logging out...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            } while (choice != 4);
        }

        public void AddComplaint()
        {
            Console.WriteLine("\nSelect Category:");
            Console.WriteLine("1. Hostel");
            Console.WriteLine("2. Academic");
            Console.WriteLine("3. Sport");
            Console.WriteLine("4. Other");
            Console.Write("Enter your choice: ");
            int catChoice = Convert.ToInt32(Console.ReadLine());

            string category = catChoice switch
            {
                1 => "Hostel",
                2 => "Academic",
                3 => "Sport",
                4 => "Other",
                _ => "Other"
            };

            Console.Write("\nEnter your complaint: ");
            string description = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(description))
            {
                Console.WriteLine("Complaint description cannot be empty. Try again.");
                return;
            }

            Complaint newComplaint = new Complaint(complaintCounter++, userName, category, description);
            complaints.Add(newComplaint);
            Console.WriteLine("Complaint added successfully!");

            SaveToCSV();
        }

        public void ViewComplaints()
        {
            Console.WriteLine("\nYour Complaints:");
            var userComplaints = complaints.FindAll(c => c.UserName == userName);

            if (userComplaints.Count == 0)
            {
                Console.WriteLine("No complaints found.");
            }
            else
            {
                foreach (Complaint complaint in userComplaints)
                {
                    Console.WriteLine($"ID: {complaint.ComplaintID} | Category: {complaint.Category} | Description: {complaint.Description} | Date: {complaint.Date}");
                }
            }
        }

        public void EditComplaint()
        {
            Console.Write("\nEnter the Complaint ID to edit: ");
            int idToEdit = Convert.ToInt32(Console.ReadLine());

            // Check if the complaint exists and belongs to the logged-in user
            Complaint complaintToEdit = complaints.Find(c => c.ComplaintID == idToEdit && c.UserName == userName);

            if (complaintToEdit != null)
            {
                Console.WriteLine($"Current Description: {complaintToEdit.Description}");
                Console.Write("Enter the new description: ");
                string newDescription = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(newDescription))
                {
                    Console.WriteLine("Complaint description cannot be empty. Edit canceled.");
                    return;
                }

                complaintToEdit.Description = newDescription;
                SaveToCSV(); 

                Console.WriteLine("Complaint updated and saved to CSV.");
            }
            else
            {
                Console.WriteLine("Complaint not found or you are not authorized to edit this complaint.");
            }
        }

        public void SaveToCSV()
        {
            string filePath = "complaints.csv";

            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Read))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine("ComplaintID,UserName,Category,Description,Date");
                foreach (var complaint in complaints)
                {
                    sw.WriteLine(complaint.ToString());
                }
            }
        }

        public void LoadFromCSV()
        {
            string filePath = "complaints.csv";
            if (File.Exists(filePath))
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (StreamReader sr = new StreamReader(fs))
                {
                    string line;
                    int lineNumber = 0;

                    while ((line = sr.ReadLine()) != null)
                    {
                        lineNumber++;
                        if (lineNumber == 1) continue; // Skip Header

                        if (string.IsNullOrWhiteSpace(line))
                        {
                            continue;
                        }

                        string[] data = line.Split(',');

                        if (data.Length != 5)
                        {
                            Console.WriteLine($"Invalid data at line {lineNumber}: {line}");
                            continue;
                        }

                        try
                        {
                            int id = int.Parse(data[0]);
                            string user = data[1];
                            string category = data[2];
                            string desc = data[3];
                            DateTime date = DateTime.Parse(data[4]);

                            complaints.Add(new Complaint(id, user, category, desc));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error parsing line {lineNumber}: {line}");
                            Console.WriteLine($"Exception: {ex.Message}");
                        }
                    }
                }
                Console.WriteLine("Complaints loaded from CSV file.");
            }
        }
    }
}
