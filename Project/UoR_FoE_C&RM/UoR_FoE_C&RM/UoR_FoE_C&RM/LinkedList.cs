using System.IO;
using TrackUrRequest;

public class LinkedList
{
    private Node head;
    private Node tail;

    public Node Head
    {
        get { return head; }
    }

    public void Add(Complaint data)
    {
        Node newNode = new Node(data);
        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            tail = newNode;
        }
    }

    public void Display(string userName)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Data.UserName == userName)
            {
                Console.WriteLine($"ID: {current.Data.ComplaintID} | Category: {current.Data.Category} |  Date: {current.Data.Date}");
                Console.WriteLine($"Description: {current.Data.Description}");
                Console.WriteLine($"Status: {current.Data.Status}\n");
            }
            current = current.Next;
        }
    }

    public List<Complaint> GetAllComplaints()
    {
        List<Complaint> complaintList = new List<Complaint>();
        Node current = head;

        while (current != null)
        {
            complaintList.Add(current.Data);
            current = current.Next;
        }

        return complaintList;
    }


    public void DisplayAll()
    {
        Node current = head;
        while (current != null)
        {
            Console.WriteLine($"ID: {current.Data.ComplaintID} | Category: {current.Data.Category} |  Date: {current.Data.Date}");
            Console.WriteLine($"Description: {current.Data.Description}");
            Console.WriteLine($"Priority: {current.Data.Priority} | Status: {current.Data.Status}\n");
            current = current.Next;
        }
    }

    public bool Edit(int complaintID, string userName, string newDescription)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Data.ComplaintID == complaintID && current.Data.UserName == userName)
            {
                current.Data.Description = newDescription;
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public bool PriorityChange(int complaintID, int NewPriority) 
    {
        Node current = head;
        int temp=0;
        while (current != null)
        {
            if (current.Data.ComplaintID == complaintID)
            {
                temp = current.Data.Priority;
                current.Data.Priority = NewPriority;
                return true;
            }
            current = current.Next;
        }
        
        return false;
    }

    public bool StatChange(int complaintID, string stats)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Data.ComplaintID == complaintID)
            {
                current.Data.Status = stats;
                return true;
            }
            current = current.Next;
        }

        return false;
    }

    public void SaveToCSV(string filePath)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Read))
        using (StreamWriter sw = new StreamWriter(fs))
        {
            sw.WriteLine("ComplaintID,UserName,Category,Description,Date,Priority,Status");
            Node current = head;
            while (current != null)
            {
                sw.WriteLine(current.Data.ToString());
                current = current.Next;
            }
        }
    }

    public void LoadFromCSV(string filePath)
    {
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

                    string[] data = line.Split(',');
                    if (data.Length == 7)
                    {
                        int id = int.Parse(data[0]);
                        string user = data[1];
                        string category = data[2];
                        string desc = data[3];
                        DateTime date = DateTime.Parse(data[4]);
                        int priority = int.Parse(data[5]);
                        string status = data[6];

                        Complaint complaint = new Complaint(id, user, category, desc);
                        complaint.Date = date;
                        complaint.Priority = priority;
                        complaint.Status = status;
                        Add(complaint);
                    }
                }
            }
        }
    }
}
