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
                var numberForCampare = array[index - 1];
                var currentNumber = array[index];
                while (index >= 0 && numberForCampare > currentNumber)
                {
                    Swap(array, index, index - 1);
                    index--;
                }
            }
        }
        private static void Swap(int[] array, int first, int second)
        => (array[first], array[second]) = (array[second], array[first]);
    }
}
