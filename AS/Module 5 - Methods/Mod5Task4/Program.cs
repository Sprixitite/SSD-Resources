using System;
using System.Collections.Generic;

namespace Mod5Task4
{
    class Program
    {
        enum Month {
            January,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }

        static int days(Month m, in bool is_leap) { 
            switch (m) {

                case Month.February:
                    return ( 28 + ( is_leap ? 1 : 0 ) );

                case Month.April:
                case Month.June:
                case Month.September:
                case Month.November:
                    return 30;

                default:
                    return 31;

            }
        }

        // This should work with the above as the constraint is more specific
        // WHY
        static T AskQuestion<T>(string question, bool list_all_possible = true)
            where T : struct, Enum
        {

            while (true)
            {

                Console.Write(question);

                if (list_all_possible) {
                    Console.Write("(");
                    T[] enums = (T[])Enum.GetValues(typeof(T));
                    for (int i = 0; i < enums.Length; i++)
                    {
                        Console.Write("\x1b[" + ((i % 6) + 31) + "m" + enums[i].ToString() + "\x1b[0m" + ((i == enums.Length - 1) ? "" : "/"));
                    }
                    Console.Write(") ");
                }
                
                if (Enum.TryParse<T>(Console.ReadLine(), true, out T result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("\n\x1b[41mThe provided \"" + typeof(T).Name + "\" was not valid, please try again!\x1b[0m\n");
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
            Month month = AskQuestion<Month>("Enter month: ", false);

            // We use the bounded variant with Min/MaxValue
            // This is because C# wasn't distinguishing between
            // the more specialized/less specialized AskQuestion
            // for enums and the one for other types
            // This language is stupid.
            int year = AskQuestion<int>("Enter year: ", int.MinValue, int.MaxValue);

            bool leap_year = (year % 4) == 0;

            Console.WriteLine("There were " + days(month, leap_year) + " days in " + month.ToString());

        }
    }
}
