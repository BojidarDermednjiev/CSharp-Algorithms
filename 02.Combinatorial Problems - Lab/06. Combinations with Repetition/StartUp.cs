namespace _06._Combinations_with_Repetition
{
    using System;
    public class StartUp
    {
        private static string[] elements;
        private static int count;
        private static string[] conbinations;
        static void Main()
        {
            GetInfo();
        }
        private static void GetInfo()
        {
            elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            count = int.Parse(Console.ReadLine());
            conbinations = new string[count];
            GenCombinations(0, 0);
        }
        private static void GenCombinations(int index, int elementStartIndex)
        {
            if (index >= conbinations.Length)
                Console.WriteLine(IO());
            else
                for (int currentIndex = elementStartIndex; currentIndex < elements.Length; currentIndex++)
                {
                    conbinations[index] = elements[currentIndex];
                    GenCombinations(index + 1, currentIndex);
                }
        }
        private static string IO()
            => String.Join(" ", conbinations);
    }
}
