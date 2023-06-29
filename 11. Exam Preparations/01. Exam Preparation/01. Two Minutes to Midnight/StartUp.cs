namespace _01._Two_Minutes_to_Midnight
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    public class StartUp
    {
        private static Dictionary<string, ulong> cache = new Dictionary<string, ulong>();
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            //BigInteger binomalCoefficient = GetFactorial(n) / (GetFactorial(k) * GetFactorial(n - k));
            Console.WriteLine(GetBinomalCoefficient(n, k));
        }

        private static ulong GetBinomalCoefficient(int row, int col)
        {
            if (col == 0 || col == row)
                return 1;
            var key = $"{row}-{col}";
            if (cache.ContainsKey(key))
                return cache[key];
            var result = GetBinomalCoefficient(row - 1, col - 1) + GetBinomalCoefficient(row - 1, col);
            cache[key] = result;
            return result;
        }

        // Easy way, but slow way
        private static BigInteger GetFactorial(int number)
        {
            if (number <= 1)
                return 1;
            return number * GetFactorial(--number);
        }
    }
}