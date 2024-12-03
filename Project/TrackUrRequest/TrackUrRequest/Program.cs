class TrackUrRequest
{
    // Hard-coded Usernames and Password Arrays
    string[] user_ids = { "AD001", "AD002", "AD003", "DE001", "DE002", "DE003", "EG225364", "EG225369", "EG225156" };
    string[] passw = { "dean_01", "ar_01", "warden_01", "Than_01", "Rami_01", "Path_03", "4635", "9635", "6515" };

    public void Print_login_page()
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
            admin_page();
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

    public static void Main(string[] args)
    {
        TrackUrRequest app = new TrackUrRequest(); 
        app.Print_login_page();
    }

    public void admin_page()
    {
        Console.Clear();
        Console.WriteLine("Admin Page!!!!!");
    }
}
