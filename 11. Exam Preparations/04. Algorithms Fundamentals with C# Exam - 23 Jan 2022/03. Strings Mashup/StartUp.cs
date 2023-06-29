namespace _03._Strings_Mashup
{
    using System;
    public class StartUp
    {
        static void Main()
        {
            var inputLineFromConsole = Console.ReadLine();
            CombinationWithoutRep(inputLineFromConsole, string.Empty);
        }

        private static void CombinationWithoutRep(string inputLine, string output)
        {
            if (inputLine.Length == 0)
            {
                Console.WriteLine(output);
                return;
            }

            char currentChar = inputLine[0];

            if (Char.IsLetter(currentChar))
            {
                CombinationWithoutRep(inputLine.Substring(1), output + Char.ToUpper(currentChar));
                CombinationWithoutRep(inputLine.Substring(1), output + Char.ToLower(currentChar));
            }
            else
                CombinationWithoutRep(inputLine.Substring(1), output + currentChar);
        }
    }
}