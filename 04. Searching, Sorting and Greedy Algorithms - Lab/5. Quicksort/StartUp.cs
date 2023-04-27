namespace _5._Quicksort
{
    using System;
    using System.Linq;
    public class StartUp
    {
        static void Main()
        {
            var readArrayFromConsole = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            Quicksort(readArrayFromConsole, default(int), readArrayFromConsole.Length - 1);
            Console.WriteLine(string.Join(" ", readArrayFromConsole));
        }
        private static void Quicksort(int[] array, int start, int end)
        {
            if (start >= end)
                return;
            var pivot = start;
            var left = start + 1;
            var right = end;
            while (left <= right)
            {
                if (array[left] > array[pivot] && array[right] < array[pivot])
                    Swap(array, left, right);
                if (array[left] <= array[pivot])
                    left += 1;
                if (array[right] >= array[pivot])
                    right -= 1;

            }
            Swap(array, pivot, right);
            var isLeftSubArraySmaller = right - 1 - start < end - (right + 1);
            //Quicksort(array, start, right - 1);
            //Quicksort(array, start + 1, end);
            if (isLeftSubArraySmaller)
            {
                Quicksort(array, start, right - 1);
                Quicksort(array, start + 1, end);
            }
            else
            {
                Quicksort(array, right + 1, end);
                Quicksort(array, start, right - 1);
            }

        }
        private static void Swap(int[] array, int first, int second)
        => (array[first], array[second]) = (array[second], array[first]);
    }
}
