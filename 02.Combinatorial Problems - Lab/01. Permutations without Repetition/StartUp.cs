namespace _01._Permutations_without_Repetition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static HashSet<string> elements;
        private static bool[] used;
        private static string[] permute;
        static void Main()
        {
            GetInfo();
            Permute(default(int));
        }
        private static void GetInfo()
        {
            elements = new HashSet<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray());
            permute = new string[elements.Count];
            used = new bool[elements.Count];
        }
        private static void Permute(int index)
        {
            if (index >= permute.Length)
            {
                IO();
                return;
            }
            else
                for (int currentIndex = 0; currentIndex < elements.Count; currentIndex++)
                    if (!used[currentIndex])
                    {
                        used[currentIndex] = true;
                        var element = elements.ToArray()[currentIndex];
                        permute[index] = element;
                        Permute(index + 1);
                        used[currentIndex] = false;
                    }
        }
        private static void IO()
           => Console.WriteLine(String.Join(" ", permute));
    }
}
