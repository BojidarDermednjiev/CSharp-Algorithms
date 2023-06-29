namespace _02._Move_DownOrRight
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());
            var matrix = new int[rows, cols];
            FillMatrix(matrix);
            var dp = new int[rows, cols];
            dp[0, 0] = matrix[0, 0];
            for (int col = 1; col < cols; col++)
                dp[0, col] = dp[0, col - 1] + matrix[0, col];
            for (int r = 1; r < rows; r++)
                dp[r, 0] = dp[r - 1, 0] + matrix[r, 0];
            for (int r = 1; r < rows; r++)
            {
                for (int col = 1; col < cols; col++)
                {
                    var upper = dp[r - 1, col];
                    var left = dp[r, col - 1];

                    dp[r, col] = Math.Max(upper, left) + matrix[r, col];
                }
            }
            var path = new Stack<string>();
            var row = rows - 1;
            var colum = cols - 1;

            while (row > 0 && colum > 0)
            {
                path.Push($"[{row}, {colum}]");
                var upper = dp[row - 1, colum];
                var left = dp[row, colum - 1];
                if (upper > left)
                    row--;
                else
                    colum--;
            }
            while (row > 0)
            {
                path.Push($"[{row}, {colum}]");
                row--;
            }
            while (colum > 0)
            {
                path.Push($"[{row}, {colum}]");
                colum--;
            }
            path.Push($"[{row}, {colum}]");
            Console.WriteLine(string.Join(" ", path));
        }

        private static void FillMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var inputLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                    matrix[row, col] = inputLine[col];
            }
        }
    }
}