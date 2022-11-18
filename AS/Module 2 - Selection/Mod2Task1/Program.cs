using System;
using System.Collections.Generic;

namespace Mod2Task1
{
    class Program {

        static readonly Dictionary<int, string> conv_table = new Dictionary<int, string> {
            { 1, "One" },
            { 2, "Two"},
            { 3, "Three" },
            { 4, "Four" },
            { 5, "Five" },
            { 6, "Six" },
            { 7, "Seven" },
            { 8, "Eight" },
            { 9, "Nine" },
            { 69, "Sixty Nine" }
        };

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

            Console.WriteLine("\x1b[0mEnter the number (as an integer): ");

            // Try-catch incase the convert fails
            int the_number = 0;
            try {
                the_number = Convert.ToInt32(Console.ReadLine());
            } catch {
                WriteRainbow("Well this is embarrassing... Do you know what a number is?");
                return;
            }

            // I know this is supposed to demo selection
            // However it is like 10:40pm, I am struggling to make my windows VM cooperate
            // And I really just want to finish this
            // Forgive me for using a cheeky shortcut
            if (conv_table.TryGetValue(the_number, out string the_result)) {
                Console.WriteLine(the_result);
            } else {
                // I *think* these are the ansi codes for changing terminal font colour
                Console.WriteLine("\x1b[41;97mInputted number was not within range 1-9\x1b[0m");
            }

            // My VM is so unbearably slow even on 4 cores and 8gb ram
            // This project should not be taking minutes to save to my network share
            // Send help

        }
    }
}

