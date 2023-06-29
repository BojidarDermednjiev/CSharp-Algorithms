namespace _03._Climbing
{
    using System;
    public class StartUp
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            int[,] matrix = new int[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                string[] input = Console.ReadLine().Split();
                for (int c = 0; c < cols; c++)
                    matrix[r, c] = int.Parse(input[c]);
            }

            int[,] pathMax = new int[rows, cols];
            pathMax[0, 0] = matrix[0, 0];

            for (int r = 1; r < rows; r++)
                pathMax[r, 0] = pathMax[r - 1, 0] + matrix[r, 0];

            for (int c = 1; c < cols; c++)
                pathMax[0, c] = pathMax[0, c - 1] + matrix[0, c];

            for (int r = 1; r < rows; r++)
                for (int c = 1; c < cols; c++)
                    pathMax[r, c] = Math.Max(pathMax[r - 1, c], pathMax[r, c - 1]) + matrix[r, c];

            int row = rows - 1;
            int col = cols - 1;
            string path = String.Empty;

            while (rows > 0 || col > 0)
            {
                path += matrix[rows, col] + " ";
                if (rows == 0)
                    col--;
                else if (col == 0)
                    rows--;
                else if (pathMax[rows - 1, col] > pathMax[rows, col - 1])
                    rows--;
                else
                    col--;
            }

            path += matrix[0, 0];

            Console.WriteLine(pathMax[rows - 1, cols - 1]);
            Console.WriteLine(string.Join(" ", path));
        }


    }
}