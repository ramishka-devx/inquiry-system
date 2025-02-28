using System;
using System.Collections.Generic;
using System.IO;

namespace TrackUrRequest.pages
{
    internal class Developer_Page
    {   

        private LinkedList users;

        public Developer_Page()
        {
            users = new LinkedList();
        }


        private class User
        {
            public string ID { get; set; }
            public string Password { get; set; }

            public User(string id, string password)
            {
                ID = id;
                Password = password;
            }

            public override string ToString()
            {
                return $"{ID} - {Password}";
            }
        }


        private class LinkedList
        {
            public Node? Head { get; set; }
            public Node? Tail { get; set; }
            public int Count { get; set; }

            public LinkedList()
            {
                Head = null;
                Tail = null;
                Count = 0;
            }

            public void AddLast(User user)
            {
                Node newNode = new Node(user);
                if (Tail == null)
                {
                    Head = newNode;
                    Tail = newNode;
                }
                else
                {
                    Tail.Next = newNode;
                    Tail = newNode;
                }
                Count++;
            }

            public void Remove(User user)
            {
                if (Head == null) return;


                if (Head.Data.ID == user.ID)
                {
                    Head = Head.Next;
                    if (Head == null)
                    {
                        Tail = null;
                    }
                    Count--;
                    return;
                }

                Node current = Head;
                while (current.Next != null && current.Next.Data.ID != user.ID)
                {
                    current = current.Next;
                }

                if (current.Next != null)
                {
                    current.Next = current.Next.Next;
                    if (current.Next == null)
                    {
                        Tail = current;
                    }
                    Count--;
                }
            }

            public Node Search(string id)
            {
                Node current = Head;
                while (current != null)
                {
                    if (current.Data.ID == id)
                    {
                        return current;
                    }
                    current = current.Next;
                }
                return null;
            }

            public void Display()
            {
                Node? current = Head;
                if (current == null)
                {
                    Console.WriteLine("No users available.");
                    return;
                }

                while (current != null)
                {
                    Console.WriteLine(current.Data);
                    current = current.Next;
                }
            }



            public void SaveToCsv(string filePath)
            {
                using (var writer = new StreamWriter(filePath))
                {
                    Node current = Head;
                    while (current != null)
                    {

                        string csvLine = $"{current.Data.ID},{current.Data.Password}";
                        writer.WriteLine(csvLine);
                        current = current.Next;
                    }
                }
            }

            public void LoadFromCsv(string filePath)
            {
                if (!File.Exists(filePath)) return;


                Head = null;
                Tail = null;
                Count = 0;

                using (var reader = new StreamReader(filePath))
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {

                        var parts = line.Split(',');
                        if (parts.Length == 2)
                        {
                            var user = new User(parts[0], parts[1]);
                            AddLast(user);
                        }
                    }
                }
            }

            public class Node
            {
                public User Data { get; set; }
                public Node? Next { get; set; }

                public Node(User data)
                {
                    Data = data;
                    Next = null;
                }
            }
        }


        public void AddUser(string id, string password)
        {
            var user = new User(id, password);
            users.AddLast(user);
            Console.WriteLine($"User with ID {id} added successfully.");
        }


        public void RemoveUser(string id)
        {
            var userNode = users.Search(id);
            if (userNode != null)
            {
                users.Remove(userNode.Data);
                Console.WriteLine($"User with ID {id} removed successfully.");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }


        public void DisplayUsers()
        {
            users.Display();
        }


        public void Start_dev()
        {

            var userManager = new Developer_Page();


            string filePath = "users.csv";


            userManager.users.LoadFromCsv(filePath);

            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add User");
                Console.WriteLine("2. Remove User");
                Console.WriteLine("3. Display Users");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                int choice;
                bool validInput = int.TryParse(Console.ReadLine(), out choice);
                if (!validInput)
                {
                    Console.WriteLine("Invalid input. Please enter a number 1-4.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter user ID: ");
                        string? id = Console.ReadLine();

                        Console.Write("Enter user password: ");
                        string? password = Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(id) && !string.IsNullOrWhiteSpace(password))
                        {
                            userManager.AddUser(id, password);
                            userManager.users.SaveToCsv(filePath);
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID or password.");
                        }
                        break;

                    case 2:
                        Console.Write("Enter user ID to remove: ");
                        string? removeId = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(removeId))
                        {
                            userManager.RemoveUser(removeId);
                            userManager.users.SaveToCsv(filePath);
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;

                    case 3:
                        userManager.DisplayUsers();
                        break;

                    case 4:

                        userManager.users.SaveToCsv(filePath);
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
