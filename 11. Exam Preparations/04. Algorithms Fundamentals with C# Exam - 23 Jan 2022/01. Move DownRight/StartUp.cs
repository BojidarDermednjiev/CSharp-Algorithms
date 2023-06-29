namespace _01._Move_Down_Right
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main()
        {
            //int rows = Convert.ToInt32(Console.ReadLine());
            //int cols = Convert.ToInt32(Console.ReadLine());

            //long[,] dp = new long[rows, cols];

            //for (int row = 1; row < rows; row++)
            //    dp[row, 0] = 1;

            //for (int col = 1; col < cols; col++)
            //    dp[0, col] = 1;

            //for (int row = 1; row < rows; row++)
            //    for (int col = 1; col < cols; col++)
            //        dp[row, col] = dp[row - 1, col] + dp[row, col - 1];

            //Console.WriteLine($"{dp[rows - 1, cols - 1]}");

            int rows = Convert.ToInt32(Console.ReadLine());
            int cols = Convert.ToInt32(Console.ReadLine());

            long[][] paths = new long[rows][];

            for (int row = 0; row < rows; row++)
                paths[row] = new long[cols];

            for (int row = 0; row < rows; row++)
                paths[row][0] = 1;

            for (int col = 0; col < cols; col++)
                paths[0][col] = 1;

            for (int row = 1; row < rows; row++)
                for (int col = 1; col < cols; col++)
                    paths[row][col] = paths[row - 1][col] + paths[row][col - 1];

            Console.WriteLine($"{paths[^1][^1]}");
        }

    }
}
