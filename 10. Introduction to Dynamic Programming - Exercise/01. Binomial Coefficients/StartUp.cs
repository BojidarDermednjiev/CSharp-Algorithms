namespace _01._Binomial_Coefficients
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        private static Dictionary<string, long> cache = new Dictionary<string, long>();
        static void Main()
        {
            var row = int.Parse(Console.ReadLine());
            var col = int.Parse(Console.ReadLine());
            Console.WriteLine(GetBinom(row, col));
        }
        private static long GetBinom(int row, int col)
        {
            if (col == 0 || col == row)
                return 1;
            var key = $"{row}-{col}";
            if (cache.ContainsKey(key))
                return cache[key];
            var result = GetBinom(row - 1, col - 1) + GetBinom(row - 1, col);
            cache[key] = result;
            return result;
        }
    }
}