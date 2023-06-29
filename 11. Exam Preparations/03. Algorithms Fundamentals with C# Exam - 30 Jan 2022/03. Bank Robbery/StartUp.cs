namespace _03._Bank_Robbery
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class StartUp
    {
        private static int[] presents = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
        static void Main()
        {
            var robbery = FindAllSums(presents);
            var total = presents.Sum();
            var moneyForPerson = total / 2;
            var firstPerson = FindSubset(robbery, moneyForPerson);
            var joshBoxes = firstPerson.OrderBy(x => x).ToArray();
            var prakashBoxes = presents.Except(joshBoxes).OrderBy(x => x);
            Print(joshBoxes, prakashBoxes);
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
        private static List<int> FindSubset(Dictionary<int, int> robbery, int target)
        {
            var subset = new List<int>();
            while (target > 0)
            {
                var element = robbery[target];
                subset.Add(element);
                target -= element;
            }
            return subset;
        }
        private static void Print(int[] joshBoxes, IOrderedEnumerable<int> prakashBoxes)
            => Console.WriteLine(string.Join(' ', joshBoxes) + Environment.NewLine + string.Join(' ', prakashBoxes));
    }
}