using System;

namespace Mod6Task6 {

    class Program {
        public static void Main(string[] args) {

            Student rory = new Student("Rory");

        
            Console.WriteLine("Exams present: ");

            for (int i=0; true; i++) {
                try {
                    Console.WriteLine("\tExam " + (i+1) + ": " + rory.score_is_set(i));
                } catch {
                    break;
                }
            }

            Console.WriteLine("Adding exam data...");

            rory[0] = 35;
            rory[1] = 45;
            rory[2] = 20;

            Console.WriteLine("Added exam data, performing presence check...");

            Console.WriteLine("Exams present: ");

            for (int i=0; true; i++) {
                try {
                    Console.WriteLine("\tExam " + (i+1) + ": " + rory.score_is_set(i));
                } catch {
                    break;
                }
            }

            Console.WriteLine("Name: " + rory.name);
            Console.WriteLine("Total Score: " + rory.total_score);
            Console.WriteLine("Average Score: " + rory.average_score);

            Console.WriteLine("Removing exam data...");

            rory.remove(1);

            Console.WriteLine("Removed exam data, performing presence check...");

            Console.WriteLine("Exams present: ");

            for (int i=0; true; i++) {
                try {
                    Console.WriteLine("\tExam " + (i+1) + ": " + rory.score_is_set(i));
                } catch {
                    break;
                }
            }

        }
    }

}