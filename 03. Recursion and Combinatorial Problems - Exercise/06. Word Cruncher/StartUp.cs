﻿namespace _06._Word_Cruncher
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        private static string target;
        private static Dictionary<int, List<string>> wordsByIndex;
        private static Dictionary<string, int> wordsCount;
        private static LinkedList<string> usedWords;
        static void Main()
        {
            var readWordsFromConsole = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            target = Console.ReadLine();
            wordsByIndex = new Dictionary<int, List<string>>();
            wordsCount = new Dictionary<string, int>();
            usedWords = new LinkedList<string>();
            foreach (var word in readWordsFromConsole)
            {
                var index = target.IndexOf(word);
                if (index == -1)
                    continue;
                if (wordsCount.ContainsKey(word))
                {
                    wordsCount[word]++;
                    continue;
                }
                wordsCount[word] = 1;
                while (index != -1)
                {
                    if (!wordsByIndex.ContainsKey(index))
                        wordsByIndex[index] = new List<string>();
                    wordsByIndex[index].Add(word);
                    index = target.IndexOf(word, index + 1);
                }
            }
            GenSolutions(default(int));
        }
        private static void GenSolutions(int index)
        {
            if (index == target.Length)
            {
                Console.WriteLine(string.Join(" ", usedWords));
                return;
            }
            if (!wordsByIndex.ContainsKey(index))
                return;
            foreach (var word in wordsByIndex[index])
            {
                if (wordsCount[word] == 0)
                    continue;
                wordsCount[word] -= 1;
                usedWords.AddLast(word);
                GenSolutions(index + word.Length);
                wordsCount[word] += 1;
                usedWords.RemoveLast();
            }
        }
    }
}
