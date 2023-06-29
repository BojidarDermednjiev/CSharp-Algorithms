namespace _03._Longest_Common_Subsequence
{
    using System;
    public class StartUp
    {
        static void Main()
        {
            var firstString = Console.ReadLine();
            var secondString = Console.ReadLine();
            var lcs = new int[firstString.Length + 1, secondString.Length + 1];
            for (int row = 1; row < lcs.GetLength(0); row++)
            {
                for (int col = 1; col < lcs.GetLength(1); col++)
                {
                    if (firstString[row - 1] == secondString[col - 1])
                        lcs[row, col] = lcs[row - 1, col - 1] + 1;
                    else
                        lcs[row, col] = Math.Max(lcs[row, col - 1], lcs[row - 1, col]);
                }
            }
            Console.WriteLine(lcs[firstString.Length, secondString.Length]);
        }
    }
}