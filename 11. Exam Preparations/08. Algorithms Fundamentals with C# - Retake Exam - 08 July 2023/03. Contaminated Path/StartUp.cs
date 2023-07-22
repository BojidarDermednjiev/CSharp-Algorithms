using System;
using System.Collections.Generic;
class StartUp
{
    static void Main()
    {
        int gridSize = int.Parse(Console.ReadLine());
        List<List<Cell>> grid = new List<List<Cell>>();

        for (int row = 0; row < gridSize; row++)
        {
            string[] rowElements = Console.ReadLine().Split(' ');
            List<Cell> rows = new List<Cell>();

            for (int col = 0; col < gridSize; col++)
            {
                int fertility = int.Parse(rowElements[col]);
                Cell cell = new Cell { Row = row, Col = col, Fertility = fertility };
                rows.Add(cell);
            }

            grid.Add(rows);
        }

        string[] contaminatedCells = Console.ReadLine().Split(' ');
        HashSet<string> contaminatedSet = new HashSet<string>(contaminatedCells);

        int maxFertility = FindMaxFertility(grid, contaminatedSet, gridSize);

        Console.WriteLine($"Max total fertility: {maxFertility}");
        Console.WriteLine($"Best path: {FindBestPath(grid, gridSize)}");
    }

    static int FindMaxFertility(List<List<Cell>> grid, HashSet<string> contaminatedSet, int gridSize)
    {
        int[,] dp = new int[gridSize, gridSize];

        dp[0, 0] = grid[0][0].Fertility;
        for (int row = 1; row < gridSize; row++)
        {
            dp[0, row] = dp[0, row - 1] + (contaminatedSet.Contains($"0,{row}") ? 0 : grid[0][row].Fertility);
            dp[row, 0] = dp[row - 1, 0] + (contaminatedSet.Contains($"{row},0") ? 0 : grid[row][0].Fertility);
        }

        for (int row = 1; row < gridSize; row++)
        {
            for (int col = 1; col < gridSize; col++)
            {
                if (contaminatedSet.Contains($"{row},{col}"))
                {
                    dp[row, col] = 0;
                }
                else
                {
                    dp[row, col] = Math.Max(dp[row - 1, col], dp[row, col - 1]) + grid[row][col].Fertility;
                }
            }
        }

        return dp[gridSize - 1, gridSize - 1];
    }

    static string FindBestPath(List<List<Cell>> grid, int gridSize)
    {
        int row = gridSize - 1;
        int col = gridSize - 1;
        string path = $"({row}, {col})";

        while (row > 0 || col > 0)
        {
            if (row > 0 && col > 0 && grid[row - 1][col].Fertility > grid[row][col - 1].Fertility)
            {
                row--;
            }
            else if (row > 0 && col > 0 && grid[row - 1][col].Fertility < grid[row][col - 1].Fertility)
            {
                col--;
            }
            else if (row > 0)
            {
                row--;
            }
            else
            {
                col--;
            }

            path = $"({row}, {col}) " + path;
        }

        return "[" + path + "]";
    }
    class Cell
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int Fertility { get; set; }
    }
}