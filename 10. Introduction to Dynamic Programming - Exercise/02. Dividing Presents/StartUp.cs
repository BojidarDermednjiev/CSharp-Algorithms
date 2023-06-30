namespace _02._Dividing_Presents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            var presents = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            var allSums = FindAllSums(presents);
            var totalSum = presents.Sum();
            var alanSum = totalSum / 2;
            while (true)
            {
                if (allSums.ContainsKey(alanSum))
                {
                    var alanPresents = FindSubset(allSums, alanSum);
                    var bobSum = totalSum - alanSum;
                        Console.WriteLine($"Difference: {bobSum - alanSum}");
                        Console.WriteLine($"Alan:{alanSum} Bob:{bobSum}");
                        Console.WriteLine($"Alan takes: {string.Join(" ", alanPresents)}");
                        Console.WriteLine(alanSum < bobSum ? $"Bob takes: {string.Join(" ", presents.Except(alanPresents))}" : $"Bob takes: {string.Join(" ", alanPresents)}");
                    break;
                }
                else
                    alanSum--;
            }
        }
        private static Dictionary<int, int> FindAllSums(int[] elements)
        {
            var sums = new Dictionary<int, int> { { 0, 0 } };
            foreach (var element in elements)
            {
                var currentSums = sums.Keys.ToArray();
                foreach (var sum in currentSums)
                {
                    var newSum = sum + element;
                    if (sums.ContainsKey(newSum))
                        continue;

                    sums.Add(newSum, element);
                }
            }
            return sums;
        }
        private static List<int> FindSubset(Dictionary<int, int> sums, int target)
        {
            var subset = new List<int>();
            while (target > 0)
            {
                var element = sums[target];
                subset.Add(element);
                target -= element;
            }
            return subset;
        }
    }
}