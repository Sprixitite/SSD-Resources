using System;

namespace Mod5Task2
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

        static void Main(string[] args) {
            string ni_nsn = AskQuestion<string>("Enter NSN: ");

            bool valid = valid_ni_nsn(ni_nsn, out string reason);

            switch (valid) {
                case true:
                    Console.WriteLine("NSN is valid! ");
                    break;
                case false:
                    Console.WriteLine("NSN is invalid! Reason:\n" + reason);
                    break;
            }

        }

        static bool valid_ni_nsn(string nsn, out string invalid_reason) {

            invalid_reason = "";

            if (nsn.Length != 9) { invalid_reason = "Wrong length."; return false; }

            for (int i=0;i<nsn.Length;i++) {

                char c = nsn[i];

                bool is_number = (c >= 48 && c <= 57);
                bool is_letter = (c >= 65 && c <= 90) || (c >= 97 && c <= 122);

                bool should_be_letter = (i < 2) || (i > 7);

                if (!( ( should_be_letter && is_letter ) || (!should_be_letter && is_number) )) {
                    if (should_be_letter) {
                        invalid_reason = "Character " + (i + 1) + " should be a letter.";
                    } else {
                        invalid_reason = "Character " + (i + 1) + " should be a number.";
                    }
                    return false;
                }

            }

            return true;

        }

    }
}
