using TrackUrRequest;

public class Node
{
    public Complaint Data;
    public Node Next;   

    public Node(Complaint data)
    {
        Data = data;
        Next = null;
    }
}
