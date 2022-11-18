using System;

namespace Mod5Task3
{
    class Program
    {
        static T AskQuestion<T>(string question)
        {

            while (true)
            {

                Console.Write(question);
                try
                {
                    return (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                }
                catch
                {
                    Console.WriteLine("\n\x1b[41mThe provided \"" + typeof(T).Name + "\" was not valid, please try again!\x1b[0m");
                }

            }

        }

        static T AskQuestion<T>(string question, T bounds_min, T bounds_max)
            where T : IComparable<T>
        {

            while (true)
            {

                Console.Write(question);
                try
                {
                    T ret_val = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                    if (ret_val.CompareTo((T)bounds_max) > 0 || ret_val.CompareTo((T)bounds_min) < 0)
                    {
                        Console.WriteLine("\n\x1b[41mInput must be between the range of " + bounds_min + "-" + bounds_max + ", please try again!\x1b[0m");
                        continue;
                    }
                    return ret_val;
                }
                catch
                {
                    Console.WriteLine("\n\x1b[41mThe provided \"" + typeof(T).Name + "\" was not valid, please try again!\x1b[0m");
                }

            }

        }

        static void Main(string[] args)
        {
            int hours_worked = AskQuestion<int>("Enter hours worked: ", 0, 50);

            int wage_lower = 12 * System.Math.Min(hours_worked, 35);
            int wage_higher = 18 * System.Math.Max(hours_worked - 35, 0);

            Console.WriteLine("Wage: £" + (wage_lower + wage_higher));

        }
    }
}
