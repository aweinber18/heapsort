using System;
using System.Collections.Generic;

public class TreeHeapsorter<T> where T : IComparable<T>
{
    private Node<T> head;
    private Node<T> current;
    public TreeHeapsorter(T[] array)
    {
        head = new Node<T>(array[0]);

        for (int i = 1; i < array.Length; i++)
        {
            head.Add(array, i);
        }

        TreePrinter<T>.PrintTree(head, array.Length);
    }


    public void BuildMaxHeap()
    {
        current = head;
    }

    public void Sort()
    {
        SwapToBottom();
    }

    private void SwapToBottom()
    {
        current = head;
        if (ChildInBounds())
        {
            while (current.Value.CompareTo(current.PeekLeft()) <= 0 || current.Value.CompareTo(current.PeekRight()) <= 0)
            {
                if (current.PeekLeft().CompareTo(current.PeekRight()) >= 0)
                {
                    current.SwapLeft();
                    current = current.Left;
                }
                else
                {
                    current.SwapRight();
                    current = current.Right;
                }
                if (! ChildInBounds()) break;
            }
        }
    }
    private bool ChildInBounds()
    {
        return current.Left != null;
    }

}
