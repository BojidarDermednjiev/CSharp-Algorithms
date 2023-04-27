namespace _06._Merge_Sort
{
    using System;
    using System.Linq;
    public class StartUp
    {
        static void Main()
        {
            var readArrayFromConsole = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            var sorted = MergeSort(readArrayFromConsole);
            Console.WriteLine(string.Join(" ", sorted));
        }
        private static int[] MergeSort(int[] array)
        {
            if (array.Length <= 1)
                return array; 
            var left = array.Take(array.Length / 2).ToArray();
            var right = array.Skip(array.Length / 2).ToArray();
            return Merge(MergeSort(left), MergeSort(right));
        }
        private static int[] Merge(int[] left, int[] right)
        {
            var merged = new int[left.Length + right.Length];
            var mergedIdx = default(int);
            var leftIdx = default(int);
            var rightIdx = default(int);
            while (leftIdx < left.Length && rightIdx < right.Length)
            {
                if (left[leftIdx] < right[rightIdx])
                    merged[mergedIdx++] = left[leftIdx++];
                else
                    merged[mergedIdx++] = right[rightIdx++];
            }
            for (int index = leftIdx; index < left.Length; index++)
            {
                merged[mergedIdx++] = left[index];
            }
            for (int index = rightIdx; index < right.Length; index++)
            {
                merged[mergedIdx++] = right[index];
            }
            return merged;
        }
    }
}
