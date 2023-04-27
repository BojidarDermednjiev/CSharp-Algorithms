namespace _01._Binary_Search
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            var readArrayFromConsole = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).OrderBy(x => x).ToArray();
            var searchingElement = int.Parse(Console.ReadLine());
            Console.WriteLine(BinarySearch(readArrayFromConsole, searchingElement));
        }
        private static int BinarySearch(int[] array, int searchingElement)
        {
            int left = default;
            int right = array.Length - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (array[mid] == searchingElement)
                    return mid;
                if (searchingElement > array[mid])
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return -1;
        }
    }
}
