using System;
using System.Collections.Generic;
using System.IO;

namespace TrackUrRequest
{
    public class Tracker
    {
        private Dictionary<string, string> credentials = new Dictionary<string, string>();
        private string csvFilePath = "users.csv";

        public Tracker()
        {
            LoadCredentialsFromCsv();
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
