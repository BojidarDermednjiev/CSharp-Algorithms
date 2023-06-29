namespace Second
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            var expression = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => char.Parse(x))
                .ToArray();
            Console.WriteLine(ParseExpression(expression, default(int)));
        }

        private static int ParseExpression(char[] element, int index)
        {
            if (char.IsDigit(element[index]))
                return element[index] - '0';
            if (element[index] == 't')
                return ParseExpression(element, index + 2);
            var foundConditions = default(int);
            if (element[index] == 'f')
                for (int possition = index + 2; possition < element.Length; possition++)
                {
                    var currentSymbol = element[possition];
                    if (currentSymbol == '?')
                        foundConditions++;
                    else if (currentSymbol == ':')
                    {
                        foundConditions--;
                        if (foundConditions < 0)
                            return ParseExpression(element, possition + 1);
                    }

                }

            return -1;
        }
    }
}