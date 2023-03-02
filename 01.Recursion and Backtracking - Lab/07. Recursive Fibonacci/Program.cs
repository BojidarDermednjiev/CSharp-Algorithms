namespace _07._Recursive_Fibonacci
{
    using System;
    public class Program
    {
        static void Main()
        {
            int inputFromConsole = int.Parse(Console.ReadLine());
            Console.WriteLine(GetFabonacci(inputFromConsole));
        }
        private static int GetFabonacci(int number)
        {
            if(number <= 1)
                return 1;
            return GetFabonacci(number - 1) + GetFabonacci(number - 2);
        }
    }
}
