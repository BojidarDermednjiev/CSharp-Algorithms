namespace _02._Socks
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            var left = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            var right = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            var lcs = new int[left.Length + 1, right.Length + 1];
            for (int row = 1; row < lcs.GetLength(0); row++)
            {
                for (int col = 1; col < lcs.GetLength(1); col++)
                {
                    if (left[row - 1] == right[col - 1])
                        lcs[row, col] = lcs[row - 1, col - 1] + 1;
                    else
                        lcs[row, col] = Math.Max(lcs[row, col - 1], lcs[row - 1, col]);
                }
            }
            Console.WriteLine(lcs[left.Length, right.Length]);
        }
    }
}