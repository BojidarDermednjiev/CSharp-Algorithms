namespace _05._School_Teams
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main()
        {
            var girls = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            var girlsCombination = new string[3];
            var girlsCombinations = new List<string[]>();
            GenCombination(default(int), default(int), girls, girlsCombination, girlsCombinations);
            var boys = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            var boysCombination = new string[2];
            var boysCombinations = new List<string[]>();
            GenCombination(default(int), default(int), boys, boysCombination, boysCombinations);
            PrintFinalCombination(girlsCombinations, boysCombinations);
        }
        private static void GenCombination(int index, int start, string[] elements, string[] combination, List<string[]> combinations)
        {
            if (index >= combination.Length)
            {
                combinations.Add(combination.ToArray());
                return;
            }
            for (int currentElement = start; currentElement < elements.Length; currentElement++)
            {
                combination[index] = elements[currentElement];
                GenCombination(index + 1, currentElement + 1, elements, combination, combinations);
            }
        }
        private static void PrintFinalCombination(List<string[]> girlsCombinations, List<string[]> boysCombinations)
        {
            foreach (var girls in girlsCombinations)
                foreach (var boys in boysCombinations)
                    Console.WriteLine($"{string.Join(", ", girls)}, {string.Join(", ", boys)}");
        }
    }
}
