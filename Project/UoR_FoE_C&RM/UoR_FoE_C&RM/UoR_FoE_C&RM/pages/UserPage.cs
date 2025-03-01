using System;
using System.IO;

namespace TrackUrRequest
{
    public class UserPage
    {
        string userName = "";
        LinkedList complaints = new LinkedList(); // Using Custom LinkedList
        int complaintCounter = 1;

        public UserPage(string Name)
        {
            userName = Name;
            LoadFromCSV(); 
            complaintCounter = GetMaxComplaintID() + 1; 
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
            complaints.Display(userName);
        }

        public void EditComplaint()
        {
            Console.Write("\nEnter the Complaint ID to edit: ");
            int idToEdit = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the new description: ");
            string newDescription = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newDescription))
            {
                Console.WriteLine("Complaint description cannot be empty. Edit canceled.");
                return;
            }

            if (complaints.Edit(idToEdit, userName, newDescription))
            {
                Console.WriteLine("Complaint updated and saved to CSV.");
                SaveToCSV();
            }
            else
            {
                Console.WriteLine("Complaint not found or you are not authorized to edit this complaint.");
            }
        }

        public void SaveToCSV()
        {
            string filePath = "complaints.csv";
            complaints.SaveToCSV(filePath);
        }

        public void LoadFromCSV()
        {
            string filePath = "complaints.csv";
            complaints.LoadFromCSV(filePath);
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
    }
}
