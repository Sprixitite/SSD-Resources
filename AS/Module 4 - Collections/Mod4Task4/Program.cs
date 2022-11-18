using System;

namespace Mod4Task4
{
    class Program
    {

        static T AskQuestion<T>(string question) {

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

        static void Main(string[] args)
        {

            string[] studentNames = new string[6];

            for (int i = 0; i < 6; i++) {
                studentNames[i] = AskQuestion<string>("Enter student \"" + (i + 1) + "\"\'s name: ");
            }

            foreach (string studentName in studentNames) {
                Console.WriteLine(studentName + ",");
            }

        }
    }
}
