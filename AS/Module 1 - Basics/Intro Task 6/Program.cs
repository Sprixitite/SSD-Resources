using System;

namespace Intro_Task_6
{
    class Program
    {

        // Use double for increased precision in comparison to float
        static void PrintDetails(string title, string ISBN, string author, double cost) {

            Console.WriteLine("\nBook Details:");
            Console.WriteLine("────────────────");
            Console.WriteLine("Title: " + title);
            Console.WriteLine("Author: " + author);
            Console.WriteLine("ISBN: " + ISBN);
            Console.WriteLine("Cose: " + cost);
        
        }

        static T AskQuestion<T>(string question) {

            Console.Write(question);
            return (T)Convert.ChangeType(Console.ReadLine(), typeof(T));

        }

        static void Main(string[] args) {

            string title = AskQuestion<string>("Enter Title: ");
            string author = AskQuestion<string>("Enter Author: ");
            string ISBN = AskQuestion<string>("Enter ISBN: ");
            double cost = AskQuestion<double>("Enter Cost: ");

            PrintDetails(title, ISBN, author, cost);

        }
    }
}
