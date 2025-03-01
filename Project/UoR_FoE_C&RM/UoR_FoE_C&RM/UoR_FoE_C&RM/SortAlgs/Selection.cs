using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackUrRequest.SortAlgs
{
    internal class Selection
    {
        public LinkedList Sort(LinkedList complaints, int choice)
        {
            if (choice == 1)
            {
                Node? current = complaints.Head;
                while (current != null)
                {
                    Node? min = current;
                    Node? r = current.Next;
                    while (r != null)
                    {
                        if (min.Data.Priority > r.Data.Priority)
                        {
                            min = r;
                        }
                        r = r.Next;
                    }
                    Complaint temp = current.Data;
                    current.Data = min.Data;
                    min.Data = temp;
                    current = current.Next;
                }


            }
            else if (choice == 2)
            {
                Node? current = complaints.Head;
                while (current != null)
                {
                    Node? min = current;
                    Node? r = current.Next;
                    while (r != null)
                    {
                        if (min.Data.ComplaintID > r.Data.ComplaintID)
                        {
                            min = r;
                        }
                        r = r.Next;
                    }
                    Complaint temp = current.Data;
                    current.Data = min.Data;
                    min.Data = temp;
                    current = current.Next;
                }

            }
            return complaints;

        }
    }
}
