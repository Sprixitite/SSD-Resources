using System;
using System.Collections.Generic;

namespace Mod4Task7
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> values = new List<int>();

            int i = 0;
            bool valid_input = true;
            while (valid_input) {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int j)) {
                    values[i] = j;
                    i++;
                } else {
                    Console.WriteLine("Finished. ");
                    valid_input = false;
                }
            }

            foreach (int k in values) {
                Console.WriteLine(k);
            }

        }
    }
}
