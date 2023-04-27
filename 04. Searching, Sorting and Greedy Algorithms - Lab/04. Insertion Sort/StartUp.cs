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
                var number = index;
                while (number > 0 && array[number - 1] > array[number])
                {
                    Swap(array, number, number - 1);
                    number--;
                }
            }
        }
        private static void Swap(int[] array, int first, int second)
        => (array[first], array[second]) = (array[second], array[first]);
    }
}
