using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackUrRequest
{
    internal class Tracker
    {
        // Hard-coded Usernames and Password Arrays
        string[] user_ids = { "AD001", "AD002", "AD003", "DE001", "DE002", "DE003", "EG225364", "EG225369", "EG225156" };
        string[] passw = { "dean_01", "ar_01", "warden_01", "Than_01", "Rami_01", "Path_03", "4635", "9635", "6515" };

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
                else if (detec_page(inp_user_id) == 3) { users_page(); }
            }
            else
            {
                Console.WriteLine("Invalid Login.");
            }
        }

        public bool check_login(string username, string password)
        {
            for (int i = 0; i < user_ids.Length; i++)
            {
                if (username == user_ids[i])
                {
                    if (password == passw[i])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public int detec_page(string username)
        {
            int page = 0;
            string prefx01 = "AD";
            string prefx02 = "DE";
            string prefx03 = "EG";
            if (username.Contains(prefx01))
            {
                page = 1;
            }
            else if (username.Contains(prefx02))
            {
                page = 2;
            }
            else if (username.Contains(prefx03))
            {
                page = 3;
            }
            return page;
        }

        public void admin_page()
        {
            Console.Clear();
            Console.WriteLine("Admin Page!!!!!");
        }
        public void dev_page()
        {
            Console.Clear();
            Console.WriteLine("Developers Page!!!");
        }
        public void users_page()
        {
            Console.Clear();
            Console.WriteLine("Undergraduates Page!!!");
        }
    }
}
