using TrackUrRequest;

internal class Bubble
{
    public LinkedList Sort(LinkedList complaints,int choice)
    {
        if (choice == 1) 
        {
            bool swapped;
            do
            {
                swapped = false;
                Node current = complaints.Head;
                while (current != null && current.Next != null)
                {
                    if (current.Data.Priority > current.Next.Data.Priority)
                    {
                        Complaint temp = current.Data;
                        current.Data = current.Next.Data;
                        current.Next.Data = temp;
                        swapped = true;
                    }
                    current = current.Next;
                }
            } while (swapped);
            
        }
        else if (choice == 2) 
        {
            bool swapped;
            do
            {
                swapped = false;
                Node current = complaints.Head;
                while (current != null && current.Next != null)
                {
                    if (current.Data.ComplaintID > current.Next.Data.ComplaintID)
                    {
                        Complaint temp = current.Data;
                        current.Data = current.Next.Data;
                        current.Next.Data = temp;
                        swapped = true;
                    }
                    current = current.Next;
                }
            } while (swapped);
            
        }
        return complaints;

    }
}
