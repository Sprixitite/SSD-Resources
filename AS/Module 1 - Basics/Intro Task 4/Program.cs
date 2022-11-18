using System;

namespace Task_4
{
    class Program
    {

        static void ProgramA() {

            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();

            Console.WriteLine("\n Enter age: ");
            int age = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Hi " + name + " who I inexplicably have to tell them how old they are...\nYou're " + age + " by the way...");

        }

        static void ProgramB() {

            Console.WriteLine("Enter number 1: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nEnter number 2: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nTotal: " + (num1 + num2));

        }

        static void ProgramC() {

            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();

            int score = 0;
            bool int_valid = false;
            while (!int_valid) {
                Console.WriteLine("\nEnter score (0-40): ");
                score = Convert.ToInt16(Console.ReadLine());
                
                if ( (score < 0) || (score > 40) ) {
                    Console.WriteLine("\nScore must be between 0 and 40.");
                    int_valid = false;
                }

                int_valid = true;

            }

            Console.WriteLine("\n" + name + "\'s score: " + ((float)score / 40.0f) * 100.0f + "%");

        }

        static void ProgramD() {

            float avg = 0.0f;
            float[] times = new float[3];
            
            for (int i = 0; i<3; i++) {
                Console.WriteLine("Enter time \"" + i + "\" (in seconds): ");
                float time = float.Parse(Console.ReadLine());
                times[i] = time;
                avg += time;
                Console.Write("\n");
            }

            avg /= times.Length;

            Console.WriteLine("Average time for competitor: " + avg);

        }

        static void ProgramE() {

            Console.WriteLine("Enter ft in height: ");
            int ft = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nEnter inches in height: ");
            int inches = Convert.ToInt32(Console.ReadLine());

            int total_inches = (ft * 12) + inches;

            Console.WriteLine("\n Size in metres: " + total_inches * 0.0254f);

        }

        static void Main(string[] args) {

            bool exit = false;
            while (!exit) {

                Console.Clear();

                Console.WriteLine("┌──────────────────────────────┐");
                Console.WriteLine("│ ___  ___                     │");
                Console.WriteLine("│ |  \\/  |                     │");
                Console.WriteLine("│ | .  . |  ___  _ __   _   _  │");
                Console.WriteLine("│ | |\\/| | / _ \\| '_ \\ | | | | │");
                Console.WriteLine("│ | |  | ||  __/| | | || |_| | │");
                Console.WriteLine("│ \\_|  |_/ \\___||_| |_| \\__,_| │");
                Console.WriteLine("│                              │");
                Console.WriteLine("├──────────────────────────────┘");

                Console.WriteLine("│ Input sub-task you'd wish to see. (A-E, anything outside of that range will exit.) ");
                Console.Write("│ ");

                char[] line = Console.ReadLine().ToCharArray();
                char subtask = (char)line.GetValue(line.Length-1);

                switch (subtask) {

                    case 'A':
                    case 'a':
                        Console.Clear();
                        ProgramA();
                        break;

                    case 'B':
                    case 'b':
                        Console.Clear();
                        ProgramB();
                        break;

                    case 'C':
                    case 'c':
                        Console.Clear();
                        ProgramC();
                        break;

                    case 'D':
                    case 'd':
                        Console.Clear();
                        ProgramD();
                        break;

                    case 'E':
                    case 'e':
                        Console.Clear();
                        ProgramE();
                        break;

                    default:
                        Console.WriteLine("No valid task selected, exiting...");
                        exit = true;
                        break;

                }

                if (!exit) {
                    Console.WriteLine("\nSub-program ended, press any key to continue");
                    Console.ReadKey();
                }

            }

            

        }
    }
}
