using System;
using System.Collections.Generic;
using System.IO;
using TrackUrRequest.pages;

namespace TrackUrRequest
{
    internal class Tracker
    {

        private Dictionary<string, string> credentials = new Dictionary<string, string>();


        private string csvFilePath = "users.csv";

        public Tracker()
        {

            LoadCredentialsFromCsv();
        }

        public void Login_page()
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("                Welcome!                     ");
            Console.WriteLine("                                             ");
            Console.WriteLine("          University of Ruhuna               ");
            Console.WriteLine("         Faculty of Engineering              ");
            Console.WriteLine(" Request and Complain Tracking System        ");
            Console.WriteLine("                                             ");
            Console.Write("User ID: ");
            string inp_user_id = Console.ReadLine();
            Console.Write("Password: ");
            string inp_passw = Console.ReadLine();
            Console.WriteLine("---------------------------------------------");

            if (check_login(inp_user_id, inp_passw))
            {
                if (detec_page(inp_user_id) == 1) { admin_page(); }
                else if (detec_page(inp_user_id) == 2) { dev_page(); }
                else if (detec_page(inp_user_id) == 3) { users_page(inp_user_id); }
                else
                {
                    Console.WriteLine("Invalid user role detected.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Login.");
            }
        }


        public bool check_login(string username, string password)
        {

            return credentials.ContainsKey(username) && credentials[username] == password;
        }


        public int detec_page(string username)
        {
            if (username.StartsWith("AD")) return 1;
            if (username.StartsWith("DE")) return 2;
            if (username.StartsWith("EG")) return 3;
            return 0;
        }

        public void admin_page()
        {
            Console.Clear();
            Admin_Page a = new Admin_Page("Admin");
            a.App();
        }

        public void dev_page()
        {
            Console.Clear();
            Developer_Page dev = new Developer_Page();
            dev.Start_dev();
        }

        public void users_page(string Name)
        {
            Console.Clear();
            UserPage u = new UserPage(Name);
            u.App();
        }


        private void LoadCredentialsFromCsv()
        {
            if (!File.Exists(csvFilePath))
            {

                Console.WriteLine($"[Warning] CSV file not found: {csvFilePath}");
                return;
            }

            try
            {
                using (var reader = new StreamReader(csvFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {

                        var parts = line.Split(',');
                        if (parts.Length == 2)
                        {
                            string userId = parts[0].Trim();
                            string password = parts[1].Trim();


                            if (!credentials.ContainsKey(userId))
                            {
                                credentials[userId] = password;
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading credentials: " + ex.Message);
            }
        }
    }
}
//Changed28/2/25