namespace _04._Recursive_Factorial
{
    using System;
    public class StartUp
    {
        static void Main()
        {
            long readNumberFromConsole;
            GetInfo(out readNumberFromConsole);
            Console.WriteLine(Factorial(readNumberFromConsole));
        }
        private static void GetInfo(out long readNumberFromConsole)
        {
            readNumberFromConsole = int.Parse(Console.ReadLine());
        }
        private static long Factorial(long readNumberFromConsole)
        {
            if(readNumberFromConsole == 0)
                return 1;
            return readNumberFromConsole * Factorial(readNumberFromConsole - 1);
        }
    }
}
