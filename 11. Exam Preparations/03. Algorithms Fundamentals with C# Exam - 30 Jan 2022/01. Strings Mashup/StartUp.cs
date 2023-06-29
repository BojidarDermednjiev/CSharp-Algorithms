namespace _01._Strings_Mashup
{
    using System;
    using System.Linq;
    public class StartUp
    {
        private static string inputLine;
        private static string[] vatiations;
        static void Main()
        {
            inputLine = Console.ReadLine();
            inputLine = String.Concat(inputLine.OrderBy(x => x));
            int number = int.Parse(Console.ReadLine());
            vatiations = new string[number];
            Combination(default(int), default(int));
        }

        private static void Combination(int index, int number)
        {
            if (index >= vatiations.Length)
                Console.WriteLine(IO());
            else
                for (int possition = number; possition < inputLine.Length; possition++)
                {
                    vatiations[index] = inputLine[possition].ToString();
                    Combination(index + 1, possition);
                }
        }
        private static string IO()
            => String.Join("", vatiations);
    }
}
