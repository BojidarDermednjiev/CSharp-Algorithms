namespace _03._The_Story_Telling
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> passedNodes;
        static void Main()
        {
            ReadInput();
            passedNodes = new HashSet<string>();
            foreach (var node in graph.Keys)
                DFS(node);
            Console.WriteLine(string.Join(" ", passedNodes.Reverse()));
        }
        private static void ReadInput()
        {
            graph = new Dictionary<string, List<string>>();
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split("->", StringSplitOptions.RemoveEmptyEntries);
                string preStory = cmdArgs[0].Trim();
                if (!graph.ContainsKey(preStory))
                    graph[preStory] = new List<string>();
                if (cmdArgs.Length < 2)
                    continue;
                var postStories = cmdArgs[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                graph[preStory].AddRange(postStories);
            }
        }
        private static void DFS(string node)
        {
            if (passedNodes.Contains(node))
                return;
            foreach (var child in graph[node])
                DFS(child);
            passedNodes.Add(node);
        }
    }
}
