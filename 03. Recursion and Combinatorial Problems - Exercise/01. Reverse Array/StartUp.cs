namespace _01._Reverse_Array
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            var inputArrayFromConsole = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            ReverseArray(inputArrayFromConsole, 0);
            Console.WriteLine(string.Join(" ", inputArrayFromConsole));
        }

        private static void ReverseArray(int[] elements, int index)
        {
            if (index == elements.Length / 2)
                return;
            (elements[index], elements[elements.Length - index - 1]) = (elements[elements.Length - index - 1], elements[index]);
            ReverseArray(elements, index + 1);
        }
    }
}
