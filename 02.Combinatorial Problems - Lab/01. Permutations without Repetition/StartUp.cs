namespace _01._Permutations_without_Repetition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static HashSet<string> elements;
        private static bool[] used;
        static void Main()
        {
            GetInfo();
            Permute(default(int));
        }
        private static void GetInfo()
        {
            elements = new HashSet<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            used = new bool[elements.Count];
        }
        private static void Permute(int index)
        {
            if (index >= elements.Count)
            {
                IO();
                return;
            }
            Permute(index + 1);
            for (int currentIndex = index + 1; currentIndex < elements.Count; currentIndex++)
            {
                if (!used[currentIndex])
                {
                    used[currentIndex] = true;
                    Swap(index, currentIndex);
                    Permute(index + 1);
                    Swap(index, currentIndex);
                    used[currentIndex] = false;
                }
            }
        }
        private static void Swap(int first, int second)
        {
            var elementsArray = elements.ToArray();
            (elementsArray[first], elementsArray[second]) = (elementsArray[second], elementsArray[first]);
            elements = new HashSet<string>(elementsArray);
        }

        private static void IO()
        {
            Console.WriteLine(String.Join(" ", elements));
        }
    }
}
