namespace _00.LinearSearch
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            var readArraFromConsole = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            var searchingElement = int.Parse(Console.ReadLine());
            Console.WriteLine(LinearSearch(readArraFromConsole, searchingElement));
        }

        private static int LinearSearch(int[] array, int searchingElement)
        {
            for (int currentIndex = 0; currentIndex < array.Length; currentIndex++)
                if (array[currentIndex] == searchingElement)
                    return currentIndex;
            return -1;
        }
    }
}
