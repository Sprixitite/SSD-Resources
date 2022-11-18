using System;

namespace Mod1_3BonusTask1
{
    class Program {
        static void Main(string[] args) {

            print_string_chars("Fortnite gaming xD");

        }

        static void print_string_chars(string print) { 
            foreach( char c in print ) {
                Console.WriteLine(c.ToString().ToUpper());
            }
        }
    }
}
