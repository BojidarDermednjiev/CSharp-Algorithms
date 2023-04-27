namespace _02._Selection_Sort
{
    using System;
    using System.Linq;
    public class StartUp
    {
        static void Main()
        {
            var readArrayFromConsole = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            SelectionSort(readArrayFromConsole);
            Console.WriteLine(string.Join(" ", readArrayFromConsole));
        }

        private static void SelectionSort(int[] array)
        {
            for (int index = 0; index < array.Length; index++)
            {
                var min = index;
                for (int currentNumber = index + 1; currentNumber < array.Length; currentNumber++)
                    if (array[currentNumber] < array[min])
                        min = currentNumber;
                Swap(array, index, min);
            }
        }
        private static void Swap(int[] array, int first, int second)
            => (array[first], array[second]) = (array[second], array[first]);
    }
}
