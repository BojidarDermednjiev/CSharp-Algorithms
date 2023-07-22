using System;
using System.Collections.Generic;

namespace WordSearch
{
    class Program
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            char[,] grid = new char[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                string row = Console.ReadLine();
                for (int j = 0; j < cols; j++)
                    grid[i, j] = row[j];
            }

            string wordsStr = Console.ReadLine();
            string[] words = wordsStr.Split(' ');

            List<string> foundWords = FindWords(grid, words);
            foreach (string word in foundWords)
                Console.WriteLine(word);
        }

        static List<string> FindWords(char[,] grid, string[] words)
        {
            List<string> foundWords = new List<string>();

            foreach (string word in words)
                for (int row = 0; row < grid.GetLength(0); row++)
                    for (int col = 0; col < grid.GetLength(1); col++)
                        if (grid[row, col] == word[0])
                            if (HasWord(grid, word, row, col, 0))
                            {
                                foundWords.Add(word);
                                break;
                            }

            return foundWords;
        }

        static bool HasWord(char[,] grid, string word, int row, int col, int index)
        {
            if (row < 0 || row >= grid.GetLength(0) || col < 0 || col >= grid.GetLength(1) || grid[row, col] != word[index])
                return false;

            if (index == word.Length - 1)
                return true;

            char original = grid[row, col];
            grid[row, col] = '#';

            bool result = HasWord(grid, word, row - 1, col, index + 1) || // Up
                          HasWord(grid, word, row + 1, col, index + 1) || // Down
                          HasWord(grid, word, row, col - 1, index + 1) || // Left
                          HasWord(grid, word, row, col + 1, index + 1) || // Right
                          HasWord(grid, word, row - 1, col - 1, index + 1) || // Upper left
                          HasWord(grid, word, row - 1, col + 1, index + 1) || // Upper right
                          HasWord(grid, word, row + 1, col - 1, index + 1) || // Lower left
                          HasWord(grid, word, row + 1, col + 1, index + 1); // Lower right

            grid[row, col] = original;

            return result;
        }
    }
}