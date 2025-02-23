using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackUrRequest.pages
{
    internal class Admin_Page
    {
        string userName = "";
        LinkedList complaints = new LinkedList();

        public Admin_Page(string Name)
        {
            userName = Name;
            LoadFromCSV();
        }

        public void App()
        {
            WelcomeTXT();
            Console.WriteLine("Welcome to the User Page!!!");

            int choice = 0;
            do
            {
                
                Console.WriteLine("1. View Complaints");
                Console.WriteLine("2. Change Priority");
                Console.WriteLine("3. Change Status");
                Console.WriteLine("4. Save and Logout");
                Console.Write("Select an option: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    
                    case 1:
                        ViewComplaints();
                        break;
                    case 2:
                        ChangePriority();
                        break;
                    case 3:
                        ChangeStat();
                        break;
                    case 4:
                        SaveToCSV();
                        Console.WriteLine("Saving and Logging out...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            } while (choice != 4);
        }

        public void WelcomeTXT()
        {
            Console.WriteLine($"Hello {userName}");
        }
        public void LoadFromCSV()
        {
            string filePath = "complaints.csv";
            complaints.LoadFromCSV(filePath);
        }

        public void ViewComplaints()
        {
            Console.WriteLine("\nYour Complaints:");
            complaints.DisplayAll();
        }

        public void ChangePriority() 
        {
            Console.Write("\nEnter the Complaint ID to edit: ");
            int idToEdit = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the new Priority: ");
            int newPriority = Convert.ToInt32(Console.ReadLine());

            if (string.IsNullOrWhiteSpace(newPriority.ToString()))
            {
                Console.WriteLine("Priority Value cannot be empty. Edit canceled.");
                return;
            }
            if (complaints.PriorityChange(idToEdit, newPriority))
            {
                Console.WriteLine("Priority Updated.");
                SaveToCSV();
            }
            else
            {
                Console.WriteLine("Complaint not found or you are not authorized to edit this complaint.");
            }
        }

        public void ChangeStat()
        {
            Console.Write("\nEnter the Complaint ID: ");
            int idToEdit = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the Status Update: ");
            string StatUp = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(StatUp))
            {
                Console.WriteLine("Priority Value cannot be empty. Edit canceled.");
                return;
            }
            if (complaints.StatChange(idToEdit, StatUp))
            {
                Console.WriteLine("Status Updated.");
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

    }
}
