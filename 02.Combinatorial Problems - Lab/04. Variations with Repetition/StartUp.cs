namespace _04._Variations_with_Repetition
{
    using System;
    public class StartUp
    {
        private static int number;
        private static string[] elements;
        private static string[] vatiations;
        static void Main()
        {
            GetInfo();
            Variations(0);
        }

        private static void GetInfo()
        {
            elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            number = int.Parse(Console.ReadLine());
            vatiations = new string[number];
        }
        private static void Variations(int index)
        {
            if (index >= vatiations.Length)
                Console.WriteLine(IO());
            else
                for (int currentIndex = 0; currentIndex < elements.Length; currentIndex++)
                {
                    vatiations[index] = elements[currentIndex];
                    Variations(index + 1);
                }
        }
        private static string IO()
            => String.Join(" ", vatiations);
    }
}
