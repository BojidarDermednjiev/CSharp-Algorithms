namespace _03._Variations_without_Repetition
{
    using System;
    public class StartUp
    {
        private static int number;
        private static string[] elements;
        private static string[] vatiations;
        private static bool[] used;
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
            used = new bool[elements.Length];
        }
        private static void Variations(int index)
        {
            if (index >= vatiations.Length)
                Console.WriteLine(IO());
            else
            {
                for (int currentIndex = 0; currentIndex < elements.Length; currentIndex++)
                    if (!used[currentIndex])
                    {
                        used[currentIndex] = true;
                        vatiations[index] = elements[currentIndex];
                        Variations(index + 1);
                        used[currentIndex] = false;
                    }
            }
        }
        private static string IO()
            => String.Join(" ", vatiations);
    }
}
