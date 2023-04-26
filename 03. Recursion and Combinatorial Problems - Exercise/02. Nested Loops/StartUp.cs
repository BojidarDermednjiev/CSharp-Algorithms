namespace _02._Nested_Loops
{
    using System;
    public class StartUp
    {
        private static int[] elements;
        static void Main()
        {
            var readNumberFromConsole = int.Parse(Console.ReadLine());
            elements = new int[readNumberFromConsole];
            GetVectors(default);
        }

        private static void GetVectors(int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
                return;
            }
            for (int currentElement = 1; currentElement <= elements.Length; currentElement++)
            {
                elements[index] = currentElement;
                GetVectors(index + 1);
            }
        }
    }
}
