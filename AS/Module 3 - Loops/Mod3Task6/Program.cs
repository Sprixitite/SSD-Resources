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
            
            // I found out I have to do all of module 3 for homework
            // This is your rushed homework

            // Probably also massive problems because I can't test these on this machine :)
            // Dotnet version mismatch with the school computers and my home one, will be fixed whenever my laptop arrives

            Console.WriteLine("Welcome to random number guesser 9,864,375");
            //Console.WriteLine("ˢᵉʳᶦᵒᵘˢˡʸ ʷʰʸ ʰᵃᵛᵉ ʷᵉ ᵐᵃᵈᵉ ˢᵒ ᵐᵃⁿʸ ʳᵃⁿᵈᵒᵐ ⁿᵘᵐᵇᵉʳ ᵍᵘᵉˢˢᵉʳˢ");

            int points = 0;
            Random rand = new Random();

            // Rounds
            for (int i=0; i<4; i++) {

                bool print_points = true;
                switch (i) {
                    case 0:
                        Console.WriteLine("\n| \x1b[1;5;32mRound 1\x1b[0m");
                        print_points = false; // Don't need to print these on first iteration
                        break;
                    case 1:
                        Console.WriteLine("\n| \x1b[1;3;5;32mRound 2\x1b[0m");
                        break;
                    case 2:
                        Console.WriteLine("\n| \x1b[1;3;4;5;32mRound 3\x1b[0m");
                        break;
                    case 3:
                        Console.WriteLine("\n| \x1b[1;3;4;5;31mRound 4\x1b[0m");
                        System.Threading.Thread.Sleep(1000);
                        Console.WriteLine("\x1b[1F\x1b[2K| \x1b[1;4;9;32mRound 4\x1b[0m");
                        Console.WriteLine("\nNah, just kidding");
                        Console.WriteLine("\n| Final Points Total: " + points);
                        continue;
                }

                if (print_points) {
                    Console.WriteLine("| Current Points Total: " + points);
                }

                int random_target = rand.Next(1, 10);
                int random_guess = 0;

                int lives = 3;
                bool correct = false;

                while (lives > 0 && !correct) {

                    bool guess_valid = false;
                    while (!guess_valid) {

                        if (lives == 3) {
                            random_guess = AskQuestion<int>("| Enter a guess between 1 and 10: ");
                        } else {
                            random_guess = AskQuestion<int>("| The number is not \"" + random_guess + "\", try again! ");
                        }

                        if (random_guess < 11 && random_guess > 0) {
                            guess_valid = true;
                        }

                    }

                    if (random_guess == random_target) {
                        int points_earned = (10-(3*(-lives+3)));
                        points += points_earned;
                        Console.WriteLine("| Correct! Earned \"" + points_earned +"\"");
                        correct = true;
                    } else {
                        lives -= 1;
                    }

                    if (lives == 0 && !correct) {
                        Console.WriteLine("| Incorret, the number was: " + random_target);
                    }

                }

            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

        }
    }
}