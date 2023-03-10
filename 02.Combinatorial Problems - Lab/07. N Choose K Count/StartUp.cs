namespace _07._N_Choose_K_Count
{
    using System;
    public class StartUp
    {
        private static int n;
        private static int k;
        static void Main()
        {
            GetInfo();
            IO();
        }
        private static void GetInfo()
        {
            n = int.Parse(Console.ReadLine());
            k = int.Parse(Console.ReadLine());
        }
        private static int GetBinom(int row, int col)
        {
            if (row <= 1 || col == 0 || col == row)
                return 1;
            return GetBinom(row - 1, col) + GetBinom(row - 1, col - 1);

        }
        private static void IO()
        {
            Console.WriteLine(GetBinom(n, k));
        }
    }
}
