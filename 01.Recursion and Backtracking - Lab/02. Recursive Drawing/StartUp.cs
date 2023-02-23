namespace _02._Recursive_Drawing
{
    using System;
    public class StartUp
    {
        static void Main()
        {
            int diapason = int.Parse(Console.ReadLine());
            Drawing(diapason);
        }

        private static void Drawing(int diapason)
        {
            if (diapason <= 0)
                return;
            Console.WriteLine(new string('*', diapason));
            Drawing(diapason - 1);
            Console.WriteLine(new string('#', diapason));
        }
    }
}
