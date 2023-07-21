using System;
using System.Collections.Generic;

namespace WordSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            // Read the letters in the grid
            char[,] grid = new char[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                string row = Console.ReadLine();
                for (int j = 0; j < cols; j++)
                {
                    grid[i, j] = row[j];
                }
            }

            // Read the words
            string wordsStr = Console.ReadLine();
            string[] words = wordsStr.Split(' ');

            // Find all possible words in the grid
            List<string> foundWords = FindWords(grid, words);

            // Print the result
            foreach (string word in foundWords)
            {
                Console.WriteLine(word);
            }
        }

        static List<string> FindWords(char[,] grid, string[] words)
        {
            List<string> foundWords = new List<string>();

            // Iterate through each word
            foreach (string word in words)
            {
                // Loop through each cell in the grid
                for (int i = 0; i < grid.GetLength(0); i++)
                {
                    for (int j = 0; j < grid.GetLength(1); j++)
                    {
                        // If the current cell contains the first letter of the word, check if the word can be formed starting from this cell
                        if (grid[i, j] == word[0])
                        {
                            if (HasWord(grid, word, i, j, 0))
                            {
                                foundWords.Add(word);
                                break;
                            }
                        }
                    }
                }
            }

            return foundWords;
        }

        static bool HasWord(char[,] grid, string word, int row, int col, int index)
        {
            // Base cases: if the current index is out of bounds or if the current cell does not match the corresponding letter in the word
            if (row < 0 || row >= grid.GetLength(0) || col < 0 || col >= grid.GetLength(1) || grid[row, col] != word[index])
            {
                return false;
            }

            // If we have reached the last letter of the word, return true
            if (index == word.Length - 1)
            {
                return true;
            }

            // Mark the current cell as visited
            char original = grid[row, col];
            grid[row, col] = '#';

            // Recursively check the neighbors of the current cell for the next letter in the word
            bool result = HasWord(grid, word, row - 1, col, index + 1) || // Up
                          HasWord(grid, word, row + 1, col, index + 1) || // Down
                          HasWord(grid, word, row, col - 1, index + 1) || // Left
                          HasWord(grid, word, row, col + 1, index + 1) || // Right
                          HasWord(grid, word, row - 1, col - 1, index + 1) || // Upper left
                          HasWord(grid, word, row - 1, col + 1, index + 1) || // Upper right
                          HasWord(grid, word, row + 1, col - 1, index + 1) || // Lower left
                          HasWord(grid, word, row + 1, col + 1, index + 1); // Lower right

            // Reset the current cell to its original value
            grid[row, col] = original;

            return result;
        }
    }
}