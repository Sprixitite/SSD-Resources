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
            
            int n = AskQuestion<int>("Enter number: ");

            switch (n) {
                case < 2:
                    Console.WriteLine("1");
                    break;
                default:
                    for (int i=0; i<n; i++) {
                        Console.WriteLine((i+1)^2);
                    }
                    break;
            }

        }
    }
}