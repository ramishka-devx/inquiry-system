using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackUrRequest.SortAlgs
{
    internal class QuickSort
    {

        public LinkedList Sort(LinkedList complaints, int choice)
        {
            if (complaints?.Head == null)
                return complaints;

            Node head = complaints.Head;
            Node tail = GetTail(head);
            QuickSortRec(head, tail, choice);
            return complaints;
        }


        private Node GetTail(Node node)
        {
            while (node != null && node.Next != null)
            {
                node = node.Next;
            }
            return node;
        }

        private void QuickSortRec(Node start, Node end, int choice)
        {

            if (start == null || start == end || start == end.Next)
                return;


            Node pivot = Partition(start, end, choice);


            Node pivotPrev = GetPivotPrev(start, pivot);
            if (pivotPrev != null)
            {
                QuickSortRec(start, pivotPrev, choice);
            }

            QuickSortRec(pivot.Next, end, choice);
        }


        private Node GetPivotPrev(Node start, Node pivot)
        {
            Node current = start;
            Node prev = null;
            while (current != null && current != pivot)
            {
                prev = current;
                current = current.Next;
            }
            return prev;
        }

        private Node Partition(Node start, Node end, int choice)
        {

            Complaint pivotData = end.Data;
            Node pIndex = start;
            Node current = start;

            while (current != end)
            {
                bool condition = false;
                if (choice == 1)
                {
                    if (current.Data.Priority < pivotData.Priority)
                        condition = true;
                }
                else if (choice == 2)
                {
                    if (current.Data.ComplaintID < pivotData.ComplaintID)
                        condition = true;
                }

                if (condition)
                {

                    Complaint temp = current.Data;
                    current.Data = pIndex.Data;
                    pIndex.Data = temp;
                    pIndex = pIndex.Next;
                }
                current = current.Next;
            }

            Complaint temp2 = pIndex.Data;
            pIndex.Data = end.Data;
            end.Data = temp2;

            return pIndex;
        }
    }
}
