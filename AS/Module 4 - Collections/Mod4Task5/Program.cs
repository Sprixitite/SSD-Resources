using System;

namespace Mod4Task5
{
    class Program
    {

        static char[] AskQuestion(string question) { 
            while (true) {
                Console.Write(question);
                try {
                    return Console.ReadLine().ToCharArray();
                } catch {
                    Console.WriteLine("\n\x1b[41mThe provided \"" + typeof(char).Name + "\" was not valid, please try again!\x1b[0m");
                }
            }
        }

        static void Main(string[] args)
        {
            string[] studentNames = new string[6];

            for (int i = 0; i < 6; i++)
            {
                char[] studentName = AskQuestion("Enter student \"" + (i+1) + "\"\'s name: ");

                Array.Reverse(studentName);

                studentNames[i] = new string(studentName);
            }

            foreach (string studentName in studentNames)
            {
                Console.WriteLine(studentName + ",");
            }
        }
    }
}
