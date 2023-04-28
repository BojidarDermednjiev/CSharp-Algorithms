namespace _03._Variations_without_Repetition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static int number;
        private static HashSet<string> elements;
        private static string[] vatiations;
        private static bool[] used;
        static void Main()
        {
            GetInfo();
            Variations(0);
        }
        private static void GetInfo()
        {
            elements = new HashSet<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray());
            number = int.Parse(Console.ReadLine());
            vatiations = new string[number];
            used = new bool[elements.Count];
        }
        private static void Variations(int index)
        {
            if (index >= vatiations.Length)
                Console.WriteLine(IO());
            else
            {
                for (int currentIndex = 0; currentIndex < elements.Count; currentIndex++)
                    if (!used[currentIndex])
                    {
                        used[currentIndex] = true;
                        var element = elements.ToArray()[currentIndex];
                        vatiations[index] = element;
                        Variations(index + 1);
                        used[currentIndex] = false;
                    }
            }
        }
        private static string IO()
            => String.Join(" ", vatiations);
    }
}
