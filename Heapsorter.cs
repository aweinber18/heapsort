using System;
using System.Collections.Generic;

public class Heapsorter<T> where T : IComparable<T>
{
    T[] array;
    int placeholder = 0;
    private int end;

    public Heapsorter(T[] list)
    {
        array = new T[list.Length];
        for (int i = 0; i < list.Length; i++)
            array[i] = list[i];
        end = array.Length - 1;
        TreePrinter<T>.PrintTree(array);
    }

    public T[] Sort()
    {
        TreePrinter<T>.PrintTree(array);
        BuildMaxHeap();
        TreePrinter<T>.PrintTree(array);
        end = array.Length - 1;
        for (int i = 0; i < array.Length - 2; i++)
        {
            placeholder = 0;
            ExtractLast();
            if (ChildInBounds(0))
                SwapToBottom();
        }
        return array;
    }

    private void BuildMaxHeap()
    {
        end = array.Length;
        for (int i = array.Length - 1; i >= 0; i--)
        {
            placeholder = i;
            if (ChildInBounds(0))
            {
                SwapToBottom();
            }
        }
    }

    private void SwapToBottom()
    {
        while (array[placeholder].CompareTo(PeekLeft()) <= 0 || array[placeholder].CompareTo(PeekRight()) <= 0)
        {
            if (PeekLeft().CompareTo(PeekRight()) >= 0)
            {
                SwapLeft();
                TraverseLeft();
            }
            else if (PeekRight().CompareTo(PeekLeft()) > 0)
            {
                SwapRight();
                TraverseRight();
            }
            if (! ChildInBounds(0)) break;
        }        
    }


    private T PeekRight()
    {
        return array[placeholder * 2 + 2];
    }

    private T PeekLeft()
    {
        return array[placeholder * 2 + 1];
    }

    private void SwapRight()
    {
        int right = placeholder * 2 + 2;
        Swap(placeholder, right);
    }

    private void SwapLeft()
    {
        int left = placeholder * 2 + 1;
        Swap(placeholder, left);
    }

    private void TraverseRight()
    {
        placeholder = placeholder * 2 + 2;
    }

    private void TraverseLeft()
    {
        placeholder = placeholder * 2 + 1;
    }

    private void ExtractLast()
    {
        TreePrinter<T>.PrintTree(array);
        Swap(0, end--);
        TreePrinter<T>.PrintTree(array);
    }

    private void Swap(int i, int j)
    {
        T temp = array[i]; 
        array[i] = array[j]; 
        array[j] = temp;
    }

    private bool InBounds()
    {
        return placeholder < end;
    }
    private bool ChildInBounds(int oneIfRightChild)
    {
        return placeholder >= 0 && placeholder * 2 + 1 + oneIfRightChild < end;
    }



}
