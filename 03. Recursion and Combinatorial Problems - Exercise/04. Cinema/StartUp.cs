namespace _04._Cinema
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static List<string> nonStaticPeople;
        private static string[] people;
        private static bool[] locked;
        static void Main()
        {
            nonStaticPeople = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            people = new string[nonStaticPeople.Count];
            locked = new bool[nonStaticPeople.Count];
            string intputLine;
            while ((intputLine = Console.ReadLine()) != "generate")
            {
                var parts = intputLine.Split(" - ");
                var name = parts[0];
                var position = int.Parse(parts[1]) - 1;
                people[position] = name;
                locked[position] = true;
                nonStaticPeople.Remove(name);
            }
            Pemute(default(int));
        }
        private static void Pemute(int index)
        {
            if (index >= nonStaticPeople.Count)
            {
                PrintPermutation();
                return;
            }
            Pemute(index + 1);
            for (int currentGuy = index + 1; currentGuy < nonStaticPeople.Count; currentGuy++)
            {
                Swap(index, currentGuy);
                Pemute(index + 1);
                Swap(index, currentGuy);
            }
        }
        private static void Swap(int first, int second)
            => (nonStaticPeople[first], nonStaticPeople[second]) = (nonStaticPeople[second], nonStaticPeople[first]);
        private static void PrintPermutation()
        {
            var nonStaticIndex = default(int);
            for (int currentIndex = 0; currentIndex < people.Length; currentIndex++)
                if (!locked[currentIndex])
                    people[currentIndex] = nonStaticPeople[nonStaticIndex++];
            Console.WriteLine(string.Join(" ", people));
        }

    }
}
