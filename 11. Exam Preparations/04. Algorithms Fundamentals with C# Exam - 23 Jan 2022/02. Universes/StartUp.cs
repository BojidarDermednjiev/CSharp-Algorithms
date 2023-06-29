namespace _02._Universes
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        private static Dictionary<string, List<string>> planets;
        private static HashSet<string> visited;
        static void Main()
        {
            int numberOfInputLines = int.Parse(Console.ReadLine());

            planets = new Dictionary<string, List<string>>();

            for (int currentLine = 0; currentLine < numberOfInputLines; currentLine++)
            {
                string[] line = Console.ReadLine().Split(" - ");
                string from = line[0];
                string to = line[1];

                if (planets.ContainsKey(from))
                    planets[from].Add(to);
                else
                    planets[from] = new List<string> { to };

                if (planets.ContainsKey(to))
                    planets[to].Add(from);
                else
                    planets[to] = new List<string> { from };
            }

            visited = new HashSet<string>();
            int universeCount = default(int);

            foreach (string planet in planets.Keys)
                if (!visited.Contains(planet))
                {
                    DFS(planet, visited);
                    universeCount++;
                }

            Console.WriteLine(universeCount);
        }

        static void DFS(string planet, HashSet<string> visited)
        {
            visited.Add(planet);
            foreach (string neighborPlanet in planets[planet])
                if (!visited.Contains(neighborPlanet))
                    DFS(neighborPlanet, visited);
        }
    }
}