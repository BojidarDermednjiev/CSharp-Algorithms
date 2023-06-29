namespace _01._Fibonacci
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        private static Dictionary<int, long> cache = new Dictionary<int, long>();
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(CalcFib(number));
        }

        private static long CalcFib(int number)
        {
            if (cache.ContainsKey(number))
                return cache[number];
            if (number < 2)
                return number;
            var result = CalcFib(number - 1) + CalcFib(number - 2);
            cache[number] = result;
            return result;
        }
    }
}