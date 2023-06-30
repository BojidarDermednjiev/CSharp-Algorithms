namespace _01._Super_Set
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class StartUp
    {
        private static HashSet<int> elements;
        private static int[] combinations;
        static void Main()
        {
            int[] input = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            elements = new HashSet<int>(input);
            combinations = new int[input.Length];
            for (int currentIndex = 0; currentIndex <= input.Length; currentIndex++)
                GenCombinations(default, default, currentIndex);
        }
        private static void GenCombinations(int index, int elementStartIndex, int length)
        {
            if (index >= length)
                Console.WriteLine(string.Join(" ", combinations.Take(length)));
            else
                for (int currentIndex = elementStartIndex; currentIndex < elements.Count; currentIndex++)
                {
                    var element = elements.ToArray()[currentIndex];
                    combinations[index] = element;
                    GenCombinations(index + 1, currentIndex + 1, length);
                }
        }
    }
}