namespace _05._Combinations_without_Repetition
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        private static HashSet<string> elements;
        private static int count;
        private static string[] conbinations;
        static void Main()
        {
            GetInfo();
            GenCombinations(default(int), default(int));
        }
        private static void GetInfo()
        {
            elements = new HashSet<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            count = int.Parse(Console.ReadLine());
            conbinations = new string[count];
        }
        private static void GenCombinations(int index, int elementStartIndex)
        {
            if (index >= conbinations.Length)
                Console.WriteLine(IO());
            else
                for (int currentIndex = elementStartIndex; currentIndex < elements.Count; currentIndex++)
                {
                    var element = elements.ToArray()[currentIndex];
                    conbinations[index] = element;
                    GenCombinations(index + 1, currentIndex + 1);
                }
        }
        private static string IO()
            => String.Join(" ", conbinations);
    }
}
