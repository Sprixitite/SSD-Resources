using System;

namespace Mod4Task3
{
    class Program
    {

        static void Main(string[] args)
        {

            int sum = 0;
            int[] a = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            if (sum is not (1 or 2))

            foreach (int i in a) {
                sum += i;
            }

            Console.WriteLine(sum);

        }
    }
}
