namespace _01._Bitcoin_Miners
{
    using System;
    using System.Numerics;

    public class StartUp
    {
        static void Main()
        {
            int numberOfTransactions = int.Parse(Console.ReadLine());
            int numberOfPicks = int.Parse(Console.ReadLine());
            BigInteger binomalCoefficient = GetFactorial(numberOfTransactions) / (GetFactorial(numberOfPicks) * GetFactorial(numberOfTransactions - numberOfPicks));
            Console.WriteLine(binomalCoefficient);
        }
        private static BigInteger GetFactorial(int number)
        {
            if (number <= 1)
                return 1;
            return number * GetFactorial(--number);
        }
    }
}
