namespace _02._Chainalysis
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class StartUp
    {
        private static List<Tuple<string, string, int>> transactions;
        static void Main()
        {
            int numberOfTransaction = int.Parse(Console.ReadLine());
            transactions = new List<Tuple<string, string, int>>();
            FillBTransactions(numberOfTransaction);
            int groups = FindGroups();
            Console.WriteLine(groups);
        }
        private static void FillBTransactions(int numberOfTransaction)
        {
            for (int currentTrans = 0; currentTrans < numberOfTransaction; currentTrans++)
            {
                string[] transaction = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string sender = transaction.First();
                string receiver = transaction[1];
                int amount = int.Parse(transaction.Last());
                transactions.Add(new Tuple<string, string, int>(sender, receiver, amount));
            }
        }
        static int FindGroups()
        {
            Dictionary<string, string> parents = new Dictionary<string, string>();

            foreach (var transaction in transactions)
            {
                string sender = transaction.Item1;
                string receiver = transaction.Item2;

                if (!parents.ContainsKey(sender))
                    parents[sender] = sender;

                if (!parents.ContainsKey(receiver))
                    parents[receiver] = receiver;

                string senderParent = FindParent(sender, parents);
                string receiverParent = FindParent(receiver, parents);

                if (senderParent != receiverParent)
                    parents[receiverParent] = senderParent;
            }

            int groups = default;

            foreach (var parent in parents)
                if (parent.Key == parent.Value)
                    groups++;

            return groups;
        }

        static string FindParent(string node, Dictionary<string, string> parents)
        {
            if (parents[node] != node)
                parents[node] = FindParent(parents[node], parents);

            return parents[node];
        }
    }
}
