namespace _01._Permutations_without_Repetition
{
    using System;
    public class StartUp
    {
        private static string[] elements;
        static void Main()
        {
            GetInfo();
            Permute(0);
        }
        private static void GetInfo()
        {
            elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        }
        private static void Permute(int index)
        {
            if (index >= elements.Length)
            {
                IO();
                return;
            }
            Permute(index + 1);
            for (int currentIndex = index + 1; currentIndex < elements.Length; currentIndex++)
            {
                Swap(index, currentIndex);
                Permute(index + 1);
                Swap(index, currentIndex);
            }
        }
        private static void Swap(int first, int second)
        {
            (elements[first], elements[second]) = (elements[second], elements[first]);
        }
        private static void IO()
        {
            Console.WriteLine(String.Join(" ", elements));
        }
    }
}
