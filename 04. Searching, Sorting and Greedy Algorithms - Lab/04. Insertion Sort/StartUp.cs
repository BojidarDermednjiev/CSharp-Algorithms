namespace _04._Insertion_Sort
{
    using System;
    using System.Linq;
    public class StartUp
    {
        static void Main()
        {
            var readArrayFromConsole = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            InsertionSort(readArrayFromConsole);
            Console.WriteLine(string.Join(" ", readArrayFromConsole));
        }
        private static void InsertionSort(int[] array)
        {
            for (int index = 1; index < array.Length; index++)
            {
                var firstNumber = array[index - 1];
                var secondNumber = array[index];
                while (index > 0 && firstNumber > secondNumber)
                {
                    Swap(array, index /* --> secondNumber */, index - 1 /* --> firstNumber*/);
                    index--;
                }
            }
        }
        private static void Swap(int[] array, int first, int second)
        => (array[first], array[second]) = (array[second], array[first]);
    }
}
