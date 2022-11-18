using System;

namespace Mod2Task7
{
    class Program
    {
        static T AskQuestion<T>(string question)  {

            while (true)
            {

                Console.Write(question);
                try
                {
                    return (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                }
                catch
                {
                    Console.WriteLine("\n\x1b[32;41mThe provided \"" + typeof(T).FullName + "\" was not valid, please try again!\x1b[0m");
                }

            }

        }

        static void Main(string[] args) {

            bool inputs_valid = false;
            int num_items = 0;
            int single = 0;
            while (!inputs_valid) {
                num_items = AskQuestion<int>("Enter the number of items: ");

                if (num_items < 0) {
                    Console.WriteLine("\x1b[41mWhy did you input a negative value are you okay??\x1b[0m");
                    continue;
                } else if (num_items == 0) {
                    Console.WriteLine("\n\x1b[41mIf cooking nothing:\n1) Good Luck\n2) Cook for 0 seconds\x1b[0m");
                    continue;
                }

                single = AskQuestion<int>("Enter the single item heating time (in seconds): ");

                try {
                    Console.WriteLine("\n\x1b[42mHeating time: " + CalculateHeatingTime(num_items, single) + "\x1b[0m");
                    inputs_valid = true;
                } catch {
                    Console.WriteLine("\x1b[41mThe number of items and heating time must both be integers.\n\x1b[41mThe number of items must be within the range 1-3");
                }

            }

        }

        static double CalculateHeatingTime(int num_items, int single_heat_time) { 
            switch (num_items) {
                case 1:
                    return single_heat_time;
                case 2:
                    return ((double)single_heat_time) * 1.5d;
                case 3:
                    return ((double)single_heat_time) * 2.0d;
                case > 3:
                    Console.WriteLine("\x1b[41mNot recommended. \x1b[0m");
                    throw new System.Exception();
                default:
                    
                    throw new System.Exception();
            }
        }

    }
}
