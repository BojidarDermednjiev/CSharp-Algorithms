namespace ConsoleApp1
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            var trainArrivalTimes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => float.Parse(x)).OrderBy(x => x).ToArray();
            var trainDepartureTimes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => float.Parse(x)).OrderBy(x => x).ToArray();
            Console.WriteLine(CalLineOfTains(trainArrivalTimes, trainDepartureTimes));
        }
        private static int CalLineOfTains(float[] trainArrivalTimes, float[] trainDepartureTimes)
        {
            var totalPlatforms = default(int);
            var platforms = default(int);
            var arrivalIndex = default(int);
            var departureIndex = default(int);
            while (arrivalIndex < trainArrivalTimes.Length)
            {
                var arrivalTime = trainArrivalTimes[arrivalIndex];
                var departureTime = trainDepartureTimes[departureIndex];
                if (arrivalTime < departureTime)
                {
                    platforms++;
                    arrivalIndex++;
                    totalPlatforms = Math.Max(platforms, totalPlatforms);
                }
                else
                {
                    departureIndex++;
                    platforms--;

                }
            }
            return totalPlatforms;
        }
    }
}
