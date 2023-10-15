using System;

public class TreePrinter<T>
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
            else if (level == 0) spacing -= 10;

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
}
