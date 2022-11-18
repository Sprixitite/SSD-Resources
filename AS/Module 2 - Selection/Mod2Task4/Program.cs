using System;

namespace Mod2Task4
{
    class Program {

        static T AskQuestion<T>(string question) {

            while (true) {

                Console.Write(question);
                try {
                    return (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                } catch {
                    Console.WriteLine("\n\x1b[32;41mThe provided \"" + typeof(T).FullName + "\" was not valid, please try again!\x1b[0m");
                }
                
            }

        }

        static bool AskQuestion(string question) {

            while (true) {
                Console.Write(question); 
                try {
                    string response = Console.ReadLine();
                    if (response.ToLower() == "y") return true;
                    else if (response.ToLower() == "n") return false;
                    else
                    {
                        return (bool)Convert.ChangeType(response, typeof(bool));
                    }
                } catch {
                    Console.WriteLine("\n\x1b[32;41mThe provided \"" + typeof(bool).FullName + "\" was not valid, please try again!\x1b");
                }
            }

        }

        static void Main(string[] args) {

            bool has_legs = AskQuestion("Does the minibeast have legs? ");

            switch (has_legs) {

                case true:
                    bool six_legs = AskQuestion("Does the minibeast have 6 legs? ");
                    if (six_legs) {
                        Console.WriteLine("\n\x1b[42mThe minibeast is an insect. \x1b[0m");
                        break;
                    }
                    bool eight_legs = AskQuestion("Does the minibeast have 8 legs? ");
                    if (eight_legs) {
                        bool one_part = AskQuestion("Does the minibeast have only one body part? ");
                        if (one_part) {
                            Console.WriteLine("\n\x1b[42mThe minibeast is a \"Harvest man\". \x1b[0m");
                        } else {
                            Console.WriteLine("\n\x1b[42mThe minibeast is a Spider. \x1b[0m");
                        }
                    } else {
                        bool oval_body = AskQuestion("Does the minibeast have an oval body? ");
                        if (oval_body) {
                            Console.WriteLine("\n\x1b[42mThe minibeast is a woodlouse. \x1b[0m");
                        } else {
                            bool segment_based_legs = AskQuestion("Does the minibeast have one pair of legs for each segment of it's body? ");
                            if (segment_based_legs) {
                                Console.WriteLine("\n\x1b[42mThe minibeast is a centipede. \x1b[0m");
                            } else {
                                Console.WriteLine("\n\x1b[42mThe minibeast is a millipede. \x1b[0m");
                            }
                        }
                    }
                    break;

                case false:
                    bool has_segments = AskQuestion("Does the minibeast have sevaral parts? ");
                    if (has_segments) {
                        Console.WriteLine("\n\x1b[42mThe minibeast is a worm. \x1b[0m");
                        break;
                    }
                    bool has_shell = AskQuestion("Does the minibeast have a shell? ");
                    if (has_shell) {
                        Console.WriteLine("\n\x1b[42mThe minibeast is a snail. \x1b[0m");
                    } else {
                        Console.WriteLine("\n\x1b[42mThe minibeast is a slug. \x1b[0m");
                    }
                    break;
            
            }

            Console.WriteLine("\n\x1b[35mPress any key to exit...\x1b[0m");
            Console.ReadKey();

        }
    }
}
