namespace _05._Paths_in_Labyrinth
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main()
        {
            char[,] labirint = GetInfo();
            FillMatrix(labirint);
            FindPaths(labirint, 0, 0, new List<string>(), string.Empty);
        }

        private static char[,] GetInfo()
        {
            int sizeOfMatrixRows = int.Parse(Console.ReadLine());
            int sizeOfMatrixCols = int.Parse(Console.ReadLine());
            var labirint = new char[sizeOfMatrixRows, sizeOfMatrixCols];
            return labirint;
        }

        private static void FillMatrix(char[,] labirint)
        {
            for (int row = 0; row < labirint.GetLength(0); row++)
            {
                var intputLineFromConsole = Console.ReadLine();
                for (int col = 0; col < labirint.GetLength(1); col++)
                    labirint[row, col] = intputLineFromConsole[col];
            }
        }

        private static void FindPaths(char[,] labirint, int row, int col, List<string> directions, string direction)
        {
            if (row < 0 || labirint.GetLength(0) <= row || col < 0 || labirint.GetLength(1) <= col)
                return;
            if (labirint[row, col] == '*' || labirint[row, col] == 'v')
                return;
            directions.Add(direction);
            if (labirint[row, col] == 'e')
            {
                IO(directions);
                directions.RemoveAt(directions.Count - 1);
                return;
            }
            labirint[row, col] = 'v';
            FindPaths(labirint, row - 1, col, directions, "U");
            FindPaths(labirint, row + 1, col, directions, "D");
            FindPaths(labirint, row, col - 1, directions, "L");
            FindPaths(labirint, row, col + 1, directions, "R");
            labirint[row, col] = '-';
            directions.RemoveAt(directions.Count - 1);
        }

        private static void IO(List<string> directions)
        {
            Console.WriteLine(string.Join(string.Empty, directions));
        }
    }
}
