namespace _03._Sum_with_Unlimited_Coins
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            var target = int.Parse(Console.ReadLine());
            Console.WriteLine(CountOfSum(target, numbers));
        }

        private static int CountOfSum(int target, int[] numbers)
        {
            var sums = new int[target + 1];
            sums[0] = 1;
            foreach (var number in numbers)
            {
                for (int sum = number; sum <= target; sum++)
                    sums[sum] += sums[sum - number];

            }
            return sums[target];
        }
    }
}
