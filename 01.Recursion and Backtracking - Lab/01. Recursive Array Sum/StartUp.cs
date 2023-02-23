namespace _01._Recursive_Array_Sum
{
    using System;
    using System.Linq;

    public class STartUp
    {
        static void Main()
        {
            var arrayFromConsole = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            Console.WriteLine(GetSum(arrayFromConsole, default(int)));
        }

        private static int GetSum(int[] readInputFromConsole, int index)
        {
            if (index >= readInputFromConsole.Length)
                return 0;
            return readInputFromConsole[index] + GetSum(readInputFromConsole, ++index);
        }
    }
}
