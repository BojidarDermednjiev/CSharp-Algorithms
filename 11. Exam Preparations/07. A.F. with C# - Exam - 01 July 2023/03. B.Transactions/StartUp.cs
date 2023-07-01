namespace _03._B.Transactions
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class StartUp
    {
        private static Dictionary<string, int> cache = new Dictionary<string, int>();
        static void Main()
        {
            var firstArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var secondArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int currentTx = 0; currentTx < secondArray.Length; currentTx++)
                cache[secondArray[currentTx]] = currentTx;

            int[] lookupTable = new int[firstArray.Length];
            int maxLength = default;
            int endIndex = -1;

            for (int row = 0; row < firstArray.Length; row++)
            {
                string transaction = firstArray[row];

                if (cache.ContainsKey(transaction))
                {
                    int currentLength = 1;
                    int index = cache[transaction];

                    for (int col = 0; col < row; col++)
                        if (lookupTable[col] + 1 > currentLength && index > cache[firstArray[col]])
                            currentLength = lookupTable[col] + 1;

                    lookupTable[row] = currentLength;

                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                        endIndex = row;
                    }
                }
            }

            List<string> bestSequence = new List<string>();
            for (int currentIndex = endIndex; currentIndex >= 0; currentIndex--)
                if (lookupTable[currentIndex] == maxLength && (currentIndex == 0 || lookupTable[currentIndex - 1] != maxLength))
                {
                    bestSequence.Add(firstArray[currentIndex]);
                    maxLength--;
                }

            bestSequence.Reverse();
            Console.WriteLine("[" + string.Join(" ", bestSequence.Intersect(secondArray)) + "]");

        }
    }
}
