using System;
using System.Collections.Generic;

class Cell
{
    public int Row { get; set; }
    public int Col { get; set; }
    public int Fertility { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        int gridSize = int.Parse(Console.ReadLine());
        List<List<Cell>> grid = new List<List<Cell>>();

        // Read the grid elements
        for (int i = 0; i < gridSize; i++)
        {
            string[] rowElements = Console.ReadLine().Split(' ');
            List<Cell> row = new List<Cell>();

            for (int j = 0; j < gridSize; j++)
            {
                int fertility = int.Parse(rowElements[j]);
                Cell cell = new Cell { Row = i, Col = j, Fertility = fertility };
                row.Add(cell);
            }

            grid.Add(row);
        }

        // Read the contaminated cells
        string[] contaminatedCells = Console.ReadLine().Split(' ');
        HashSet<string> contaminatedSet = new HashSet<string>(contaminatedCells);

        int maxFertility = FindMaxFertility(grid, contaminatedSet, gridSize);

        Console.WriteLine($"Max total fertility: {maxFertility}");
        Console.WriteLine($"Best path: {FindBestPath(grid, gridSize)}");
    }

    static int FindMaxFertility(List<List<Cell>> grid, HashSet<string> contaminatedSet, int gridSize)
    {
        int[,] dp = new int[gridSize, gridSize];

        // Initialize the first row and first column
        dp[0, 0] = grid[0][0].Fertility;
        for (int i = 1; i < gridSize; i++)
        {
            // If a cell is contaminated, set its fertility to 0
            dp[0, i] = dp[0, i - 1] + (contaminatedSet.Contains($"0,{i}") ? 0 : grid[0][i].Fertility);
            dp[i, 0] = dp[i - 1, 0] + (contaminatedSet.Contains($"{i},0") ? 0 : grid[i][0].Fertility);
        }

        // Compute the maximum fertility for each cell
        for (int i = 1; i < gridSize; i++)
        {
            for (int j = 1; j < gridSize; j++)
            {
                if (contaminatedSet.Contains($"{i},{j}"))
                {
                    dp[i, j] = 0;
                }
                else
                {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]) + grid[i][j].Fertility;
                }
            }
        }

        return dp[gridSize - 1, gridSize - 1];
    }

    static string FindBestPath(List<List<Cell>> grid, int gridSize)
    {
        int i = gridSize - 1;
        int j = gridSize - 1;
        string path = $"({i}, {j})";

        while (i > 0 || j > 0)
        {
            if (i > 0 && j > 0 && grid[i - 1][j].Fertility > grid[i][j - 1].Fertility)
            {
                i--;
            }
            else if (i > 0 && j > 0 && grid[i - 1][j].Fertility < grid[i][j - 1].Fertility)
            {
                j--;
            }
            else if (i > 0)
            {
                i--;
            }
            else
            {
                j--;
            }

            path = $"({i}, {j}) " + path;
        }

        return "[" + path + "]";
    }
}