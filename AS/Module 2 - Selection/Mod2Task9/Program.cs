using System;
using System.Globalization;

namespace Mod2Task9 {
    class Program {

        static T AskQuestion<T>(string question) {

            while (true) {

                Console.Write(question);
                try {
                    return (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                } catch {
                    Console.WriteLine("\n\x1b[41mThe provided \"" + typeof(T).Name + "\" was not valid, please try again!\x1b[0m");
                }

            }

        }

        static bool AskQuestion(string question) {

            while (true) {
                Console.Write(question);
                try {
                    string response = Console.ReadLine();
                    
                    switch (response.ToLower()) {

                        case "yes":
                        case "y":
                            return true;

                        case "no":
                        case "n":
                            return false;

                        default:
                            return (bool)Convert.ChangeType(response, typeof(bool));

                    }
                } catch {
                    Console.WriteLine("\n\x1b[41mThe provided \"" + typeof(bool).Name + "\" was not valid, please try again!\x1b[0m");
                }
            }

        }

        static void Main(string[] args) {

            bool wanted = AskQuestion("Do you want to leave a tip? Enter \"y/yes/true\" or \"n/no/false\": ");

            if (!wanted) { Console.WriteLine("\n\x1b[45mYou do not wish to calculate a tip.\x1b[0m"); return;  }

            float bill = 0;

            while (!(bill > 0)) {
                bill = AskQuestion<float>("Enter the bill amount: ");

                if (bill < 0) {
                    Console.WriteLine("\n\x1b[41mThis restaurant doesn't pay it's customers...\x1b[0m");
                }

            }

            float tip_multiplier = 0.0f;
            if (bill > 20) {
                Console.WriteLine("\n\x1b[42mYour bill is greater than £20. A 20% tip is appropriate.\x1b[0m");
                tip_multiplier = 1.2f;
            } else if (bill < 20) {
                Console.WriteLine("\n\x1b[42mYour bill is less than £20. A 10% tip is appropriate.\x1b[0m");
                tip_multiplier = 1.1f;
            }

            Console.WriteLine("\n\x1b[42mYour new bill including tip is: \"" + (((float)bill)*tip_multiplier).ToString("C", new CultureInfo("en-GB")) + "\"\x1b[0m");

        }
    }
}
