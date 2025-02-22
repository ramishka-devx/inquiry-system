using TrackUrRequest;

public class LinkedList
{
    private Node head;
    private Node tail;

    public Node Head
    {
        get { return head; }
    }

    // Add Complaint
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

    // Display Complaints
    public void Display(string userName)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Data.UserName == userName)
            {
                Console.WriteLine($"ID: {current.Data.ComplaintID} | Category: {current.Data.Category} | Description: {current.Data.Description} | Date: {current.Data.Date}");
            }
            current = current.Next;
        }
    }

    // Edit Complaint
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

    // Save to CSV
    public void SaveToCSV(string filePath)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Read))
        using (StreamWriter sw = new StreamWriter(fs))
        {
            sw.WriteLine("ComplaintID,UserName,Category,Description,Date");
            Node current = head;
            while (current != null)
            {
                sw.WriteLine(current.Data.ToString());
                current = current.Next;
            }
        }
    }

    // Load from CSV
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
                    if (data.Length == 5)
                    {
                        int id = int.Parse(data[0]);
                        string user = data[1];
                        string category = data[2];
                        string desc = data[3];
                        DateTime date = DateTime.Parse(data[4]);

                        Complaint complaint = new Complaint(id, user, category, desc);
                        Add(complaint);
                    }
                }
            }
        }
    }
}
