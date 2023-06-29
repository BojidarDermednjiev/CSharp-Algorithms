namespace _04._Sum_with_Limited_Coins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class StartUp
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            var target = int.Parse(Console.ReadLine());
            Console.WriteLine(CountSum(numbers, target));
        }

        private static int CountSum(int[] numbers, int target)
        {
            int count = default(int);
            var result = new HashSet<int> { 0 };
            foreach (var number in numbers)
            {
                var newSums = new HashSet<int>();
                foreach (var sum in result)
                {
                    var newSum = sum + number;
                    if (newSum == target)
                        count++;
                    newSums.Add(newSum);
                }
                result.UnionWith(newSums);
            }
            return count;
        }
    }
}