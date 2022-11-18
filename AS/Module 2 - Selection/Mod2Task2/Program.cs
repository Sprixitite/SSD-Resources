using System;
using System.Collections.Generic;

namespace Mod2Task1
{
    class Program {

        static void WriteRainbow(string text, bool is_background = false, bool newline_end = true) {

            int col = 0;

            int offset = 31;
            if (is_background)
                offset = 41;

            foreach (char next in text.ToCharArray()) {
                col = col % 6;
                Console.Write( ("\x1b["+(col+offset) + "m") + next);
                col++;
            }

            Console.WriteLine("\x1b[0m");

            if (newline_end) {
                Console.Write("\n");
            }

        }

        static void Main(string[] args) {

            bool input_validated = false;
            int the_number = 0;

            while (!input_validated) {
                Console.WriteLine("\n\x1b[0mEnter the day of the week (as an integer): ");
                try {
                    the_number = Convert.ToInt32(Console.ReadLine());
                    if (the_number > 0 && the_number < 8) {
                        input_validated = true;
                    }
                } catch {
                    WriteRainbow("\nWell this is embarrassing... Do you know what a number is?");
                }
            }

            switch (the_number) {
                case 1:
                    Console.WriteLine("Monday");
                    break;
                case 2:
                    Console.WriteLine("Tuesday");
                    break;
                case 3:
                    Console.WriteLine("Wednesday");
                    break;
                case 4:
                    Console.WriteLine("Thursday");
                    break;
                case 5:
                    Console.WriteLine("Friday");
                    break;
                case 6:
                case 7:
                    Console.WriteLine("Weekend");
                    break;
                default:
                    Console.WriteLine("\x1b[41;97mInputted number was not within range 1-7\x1b[0m");
                    break;
            }
            
            // 12:13am Rory Reporting:
            // This VM sucks
            // I am glad this is over
            // I am now going to lose a game of cs_office and hit the sack
            // Thank you and goodnight

        }
    }
}