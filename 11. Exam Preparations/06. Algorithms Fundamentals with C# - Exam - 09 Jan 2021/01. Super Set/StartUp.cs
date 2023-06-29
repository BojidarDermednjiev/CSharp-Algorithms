namespace _01._Super_Set
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static List<int>[] set;
        static void Main()
        {
            int[] input = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            List<List<int>> subsets = GetSubsets(input);
            foreach (List<int> subset in subsets)
                Console.WriteLine(string.Join(" ", subset));
        }

        private static List<List<int>> GetSubsets(int[] set)
        {
            return new List<List<int>>();
        }
    }
}