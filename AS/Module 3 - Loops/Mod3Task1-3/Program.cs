using System;

namespace Mod3Task1 {
    class Program {

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
            
            Console.WriteLine("7pm Rory making a half-baked menu so he can condense tasks 1-3 into the one project here");
            Console.WriteLine("If you notice any differences between them, that's a \x1b[1;31mbad\x1b[0m thing...");

            Console.WriteLine("\n| Select loop type: ");
            Console.Write("| 1, For Loop\n| 2, While Loop\n| 3, Do while Loop\n| ");

            int response = 0;
            while (true) {

                response = AskQuestion<int>("");

                if ((response > 0) && (response < 4)) {
                    break;
                }

                // REALLY pushing my luck with this escape code
                // "\x1b[2k" clears the line
                // "\x1b[1G| " resets the line to "| "
                Console.Write("\x1b[2K\x1b[1G| ");

            }

            int sum = 0;
            double average = 0.0d;
            int upper_bound = AskQuestion<int>("Enter upper limit for calculation: ");

            int i = 0;
            switch (response) {

                case 1:
                    for (int j=0; j<upper_bound; j++) {
                        sum += (j+1);
                    }
                    break;

                case 2:
                    while (i < upper_bound) {
                        sum += (i+1);
                        i++;
                    }
                    break;

                case 3:
                    do {
                        sum += (i+1);
                        i++;
                    } while (i < upper_bound);
                    break;

            }

            average /= upper_bound;

            Console.WriteLine("Sum of the numbers between \"1\" and \"" + upper_bound + "\" is: \"" + sum + "\"");
            Console.WriteLine("Average of the numbers between \"1\" and \"" + upper_bound + "\" is: \"" + average + "\"");

        }
    }
}
