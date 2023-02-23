namespace _03._Generating_0_1_Vectors
{
    using System;
    public class StartUp
    {
        static void Main()
        {
            var readCapacityForArray = int.Parse(Console.ReadLine());
            var array = new int[readCapacityForArray];
            int index = default(int);
            Generation(array, index);
        }

        private static void Generation(int[] array, int index)
        {
            if (index >= array.Length)
            { 
                Console.WriteLine(string.Join(string.Empty, array));
                return;
            }
            
            for (int possition = 0; possition < 2; possition++)
            {
                array[index] = possition;
                Generation(array, index + 1);
            }
        }
    }
}
