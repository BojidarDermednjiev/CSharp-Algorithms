namespace _02._Time
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class StartUp
    {
        //private static int[][] lcs;
        static void Main()
        {
            var firstSequence = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            var secondSequence = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            var lcs = new int[firstSequence.Length + 1, secondSequence.Length + 1];
            for (int row = 1; row < lcs.GetLength(0); row++)
            {
                for (int col = 1; col < lcs.GetLength(1); col++)
                {
                    if (firstSequence[row - 1] == secondSequence[col - 1])
                        lcs[row, col] = lcs[row - 1, col - 1] + 1;
                    else
                        lcs[row, col] = Math.Max(lcs[row, col - 1], lcs[row - 1, col]);
                }
            }
            Stack<int> stack = new Stack<int>();
            int rows = firstSequence.Length;
            int cols = secondSequence.Length;
            while (rows > 0 && cols > 0)
            {
                if (firstSequence[rows - 1] == secondSequence[cols - 1])
                {
                    stack.Push(firstSequence[rows - 1]);
                    rows--;
                    cols--;
                }
                else if (lcs[rows, cols - 1] >= lcs[rows - 1, cols])
                {
                    cols--;
                }
                else
                {
                    rows--;
                }
            }
            Console.WriteLine(string.Join(" ", stack));
            Console.WriteLine(lcs[firstSequence.Length, secondSequence.Length]);
            //IntializeLCS(firstSequence, secondSequence);
            //Stack<int> stack = new Stack<int>();
            //int row = firstSequence.Length;
            //int col = secondSequence.Length;
            //while (row > 0 && col > 0)
            //{
            //    if (firstSequence[row - 1] == secondSequence[col - 1])
            //    {
            //        stack.Push(firstSequence[row - 1]);
            //        row--;
            //        col--;
            //    }
            //    else if (lcs[row][col -1] >= lcs[row - 1][col]) 
            //    {
            //        col--;
            //    }
            //    else
            //    {
            //        row--;
            //    }
            //}
            //Console.WriteLine(string.Join(" ", stack));
            //Console.WriteLine(lcs[^1][^1]);
        }

        //private static void IntializeLCS(int[] firstSequence, int[] secondSequence)
        //{
        //    lcs = new int[firstSequence.Length + 1][];
        //    for (int row = 0; row < lcs.Length; row++)
        //        lcs[row] = new int[secondSequence.Length + 1];
        //    for (int row = 1; row < lcs.Length; row++)
        //        for (int col = 1; col < lcs[row].Length; col++)
        //        {
        //            if (firstSequence[row - 1] == secondSequence[col - 1])
        //                lcs[row][col] = lcs[row - 1][col - 1] + 1;
        //            else
        //                lcs[row][col] = Math.Max(lcs[row][col - 1], lcs[row - 1][col]);
        //        }

        //}
    }
}