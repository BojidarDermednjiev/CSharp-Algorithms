using System;
using System.Collections.Generic;
class StartUp
{
    static void Main()
    {
        int trades = int.Parse(Console.ReadLine());
        Dictionary<string, List<string>> tradeRules = new Dictionary<string, List<string>>();

        for (int currentTrade = 0; currentTrade < trades; currentTrade++)
        {
            string[] pair = Console.ReadLine().Split(" - ");
            string asset1 = pair[0];
            string asset2 = pair[1];

            if (!tradeRules.ContainsKey(asset1))
                tradeRules[asset1] = new List<string>();

            tradeRules[asset1].Add(asset2);

            if (!tradeRules.ContainsKey(asset2))
                tradeRules[asset2] = new List<string>();

            tradeRules[asset2].Add(asset1);
        }

        string[] request = Console.ReadLine().Split(" -> ");
        string source = request[0];
        string target = request[1];

        int minSwaps = FindMinSwaps(tradeRules, source, target);
        Console.WriteLine(minSwaps == int.MaxValue ? -1 : minSwaps);
    }

    static int FindMinSwaps(Dictionary<string, List<string>> tradeRules, string source, string target)
    {
        Queue<string> queue = new Queue<string>();
        HashSet<string> visited = new HashSet<string>();
        Dictionary<string, int> swaps = new Dictionary<string, int>();

        queue.Enqueue(source);
        swaps[source] = 0;

        while (queue.Count > 0)
        {
            string current = queue.Dequeue();

            if (current == target)
                return swaps[current];

            visited.Add(current);

            if (tradeRules.ContainsKey(current))
                foreach (string asset in tradeRules[current])
                {
                    if (!visited.Contains(asset))
                        queue.Enqueue(asset);
                    swaps[asset] = swaps[current] + 1;
                }
        }

        return int.MaxValue;
    }
}