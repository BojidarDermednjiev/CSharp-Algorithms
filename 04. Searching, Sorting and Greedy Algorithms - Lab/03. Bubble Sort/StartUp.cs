namespace _03._Bubble_Sort
{
    using System;
    using System.Linq;
    public class StartUp
    {
        static void Main()
        {
            var readArrayFromConsole = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            BubbleSort(readArrayFromConsole);
            Console.WriteLine(string.Join(" ", readArrayFromConsole));
        }
        private static void BubbleSort(int[] array)
        {
            var sortedCount = default(int);
            var isSorted = false;
            while (!isSorted)
            {
                isSorted = true;
                for (int index = 1; index < array.Length - sortedCount; index++)
                {
                    var number = index - 1;
                    if (array[number] > array[index])
                    {
                        Swap(array, number, index);
                        isSorted = false;
                    }
                }
                sortedCount++;
            }
        }
        private static void Swap(int[] array, int first, int second)
          => (array[first], array[second]) = (array[second], array[first]);
    }
}
