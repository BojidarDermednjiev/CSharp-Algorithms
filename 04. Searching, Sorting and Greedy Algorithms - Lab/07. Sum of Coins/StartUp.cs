namespace _07._Sum_of_Coins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            var coins = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).OrderByDescending(x => x));
            var taget = int.Parse(Console.ReadLine());
            var selectedCoins = new Dictionary<int, int>();
            var totalCount = default(int);
            while (taget > 0 && coins.Count > 0)
            {
                var currentCoin = coins.Dequeue();
                var count = taget / currentCoin;
                if (count == 0)
                    continue;
                selectedCoins[currentCoin] = count;
                totalCount += count;
                taget %= currentCoin;
            }
            if (taget == 0)
            {
                Console.WriteLine($"Number of coins to take: {totalCount}");
                foreach (var coin in selectedCoins)
                    Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
            }
            else
                Console.WriteLine("Error");
        }
    }
}
