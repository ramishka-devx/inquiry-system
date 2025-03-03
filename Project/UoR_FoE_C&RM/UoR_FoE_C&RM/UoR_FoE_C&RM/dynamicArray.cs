using System;
using System.Collections.Generic;

namespace DynamicArray
{
    public class DynamicArray
    {
        private string[] data;
        private int capacity;
        private int count;

        public DynamicArray()
        {
            capacity = 4; // Fixed initial capacity
            data = new string[capacity];
            count = 0;
        }

        public void Add(string value)
        {
            if (count == capacity)
            {
                Expand();
            }
            data[count] = value;
            count++;
        }

        public void Expand()
        {
            if (capacity == 0) capacity = 4;
            else capacity *= 2;

            string[] newData = new string[capacity];
            Array.Copy(data, newData, count);
            data = newData;
        }

        public void Print()
        {
            for (int i = 0; i < count; i++) // Fixed printing logic
            {
                Console.WriteLine($"Array element {i}={data[i]}");
            }
            Console.WriteLine();
        }

        public int Count()
        {
            return count;
        }

        public string Get(int index)
        {
            if (index >= 0 && index < count)
            {
                return data[index];
            }
            return null;
        }

        public void BubbleSort()
        {
            for (int i = 0; i < count - 1; i++)
            {
                for (int j = 0; j < count - 1 - i; j++)
                {
                    if (string.Compare(data[j], data[j + 1]) > 0)
                    {
                        // Swap elements if they are in the wrong order
                        string temp = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = temp;
                    }
                }
            }
        }
    }

    class DeveloperPage
    {
        public void LoadUsersFromCsv()
        {
            string filePath = "users.csv"; // Update with the path to your CSV file
            var adUsers = new DynamicArray();
            var deUsers = new DynamicArray();
            var egUsers = new DynamicArray();
            var otherUsers = new DynamicArray();

            if (System.IO.File.Exists(filePath))
            {
                using (var reader = new System.IO.StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split(',');
                        if (parts.Length == 2)
                        {
                            string userID = parts[0].Trim();
                            string userPassword = parts[1].Trim();

                            // Group users by their ID prefix and add to respective dynamic array
                            if (userID.StartsWith("AD"))
                            {
                                adUsers.Add(userID + " - " + userPassword);
                            }
                            else if (userID.StartsWith("DE"))
                            {
                                deUsers.Add(userID + " - " + userPassword);
                            }
                            else if (userID.StartsWith("EG"))
                            {
                                egUsers.Add(userID + " - " + userPassword);
                            }
                            else
                            {
                                otherUsers.Add(userID + " - " + userPassword);
                            }
                        }
                    }
                }
            }

            // Sort each dynamic array using bubble sort
            adUsers.BubbleSort();
            deUsers.BubbleSort();
            egUsers.BubbleSort();
            otherUsers.BubbleSort();

            // Combine sorted arrays and display results
            Console.WriteLine("Users with IDs starting with AD:");
            adUsers.Print();

            Console.WriteLine("Users with IDs starting with DE:");
            deUsers.Print();

            Console.WriteLine("Users with IDs starting with EG:");
            egUsers.Print();

            Console.WriteLine("Users with other IDs:");
            otherUsers.Print();
        }
    }


}
