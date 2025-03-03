using TrackUrRequest;

internal class InsertionSort
{
    public void Sort(LinkedList complaints, int choice)
    {
        if (complaints.Head == null || complaints.Head.Next == null)
            return;

        Node sorted = null;
        Node current = complaints.Head;


        while (current != null)
        {
            Node next = current.Next;
            sorted = SortedInsert(sorted, current, choice);
            current = next;
        }

        Node sortedCurrent = sorted;
        Node originalCurrent = complaints.Head;
        while (sortedCurrent != null)
        {
            originalCurrent.Data = sortedCurrent.Data;
            sortedCurrent = sortedCurrent.Next;
            originalCurrent = originalCurrent.Next;
        }
    }

    private Node SortedInsert(Node sorted, Node newNode, int choice)
    {
        newNode.Next = null;

        if (sorted == null || Compare(sorted.Data, newNode.Data, choice) > 0)
        {
            newNode.Next = sorted;
            return newNode;
        }

        Node current = sorted;
        while (current.Next != null && Compare(current.Next.Data, newNode.Data, choice) <= 0)
        {
            current = current.Next;
        }

        newNode.Next = current.Next;
        current.Next = newNode;

        return sorted;
    }

    private int Compare(Complaint a, Complaint b, int choice)
    {
        return choice switch
        {
            1 => a.Priority.CompareTo(b.Priority),
            2 => a.ComplaintID.CompareTo(b.ComplaintID),
            _ => 0
        };
    }
}
