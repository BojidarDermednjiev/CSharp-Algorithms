namespace _08._Set_Cover
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main()
        {
            var universe = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToHashSet();
            var numberOfStes = int.Parse(Console.ReadLine());
            var sets = new List<int[]>();
            for (int currentSet = 0; currentSet < numberOfStes; currentSet++)
            {
                var set = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
                sets.Add(set);
            }
            var selectedSets = new List<int[]>();
            while (universe.Count > 0)
            {
                var set = sets.OrderByDescending(x => x.Count(x => universe.Contains(x))).FirstOrDefault();
                selectedSets.Add(set);
                sets.Remove(set);
                foreach (var element in set)
                    universe.Remove(element);
            }
            Console.WriteLine($"Sets to take ({selectedSets.Count}):");
            foreach (var set in selectedSets)
                Console.WriteLine(string.Join(", ", set));
        }
    }
}
