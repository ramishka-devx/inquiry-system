using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackUrRequest.pages
{
    internal class Developer_Page
    {
        private LinkedList students;

        public Developer_Page()
        {
            students = new LinkedList();
        }

        private class Student
        {
            public string ID { get; set; }
            public string Name { get; set; }

            public Student(string id, string name)
            {
                ID = id;
                Name = name;
            }

            public override string ToString()
            {
                return $"{ID} - {Name}";
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

            public void AddLast(Student student)
            {
                Node newNode = new Node(student);
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

            public void Remove(Student student)
            {
                if (Head == null) return;

                if (Head.Data.ID == student.ID)
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
                while (current.Next != null && current.Next.Data.ID != student.ID)
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
                    Console.WriteLine("No students available.");
                    return;
                }

                while (current != null)
                {
                    Console.WriteLine(current.Data);
                    current = current.Next;
                }
            }

            public class Node
            {
                public Student Data { get; set; }
                public Node? Next { get; set; }

                public Node(Student data)
                {
                    Data = data;
                    Next = null;
                }
            }
        }

        public void AddStudent(string id, string name)
        {
            var student = new Student(id, name);
            students.AddLast(student);
            Console.WriteLine($"Student {name} with ID {id} added successfully.");
        }

        public void RemoveStudent(string id)
        {
            var studentNode = students.Search(id);
            if (studentNode != null)
            {
                students.Remove(studentNode.Data);
                Console.WriteLine($"Student with ID {id} removed successfully.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        public void DisplayStudents()
        {
            students.Display();
        }

        public void Start_dev()
        {
            var studentManager = new Developer_Page();

            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Remove Student");
                Console.WriteLine("3. Display Students");
                Console.WriteLine("4. Exit");

                Console.Write("Choose an option: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter student ID: ");
                        string id = Console.ReadLine();
                        Console.Write("Enter student name: ");
                        string name = Console.ReadLine();
                        studentManager.AddStudent(id, name);
                        break;

                    case 2:
                        Console.Write("Enter student ID to remove: ");
                        string removeId = Console.ReadLine();
                        studentManager.RemoveStudent(removeId);
                        break;

                    case 3:
                        studentManager.DisplayStudents();
                        break;

                    case 4:
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
