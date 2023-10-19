using System;

// Modified from ChatGpt
public class TreePrinter<T> where T : IComparable<T>
{
    public static void PrintTree(T[] array)
    {
        int levels = (int)Math.Ceiling(Math.Log2(array.Length));
        int maxElements = (int)Math.Pow(2, levels) - 1;

        int currentIndex = 0;
        for (int level = 0; level < levels; level++)
        {
            int elementsOnThisLevel = (int)Math.Pow(2, level);
            int spacing = (maxElements / elementsOnThisLevel);

            if (level > 1) spacing += 2;
            else if (level == 0) spacing -= 6;

            for (int i = 0; i < elementsOnThisLevel; i++)
            {
                if (currentIndex < array.Length)
                {
                    Console.Write(array[currentIndex].ToString().PadLeft(spacing));
                    currentIndex++;
                }
            }
            Console.WriteLine();
        }
    }

    public static void PrintTree(Node<T> node, int length)
    {
        IList<T> list = new List<T>();
        for (int i = 0; i < length; i++)
        {
            list.Add(node.GetNodeAt(i).Value);
        }
        T[] array = list.ToArray();
        PrintTree(array);
    }

    public static void PrintNode(Node<T> node)
    {
        if (node == null) return;

        Console.Write(node.Value.ToString() + "\t");
        PrintNode(node.Left); 
        PrintNode(node.Right);
    }
/*
    public static void SetNode(Node<T> node, IList<T> list, int i)
    {
        if (node == null) return;

        list.Add(node.Value);
        SetNode(node.Left, list, i++);
        SetNode(node.Right, list, i++);
    }*/
}
