using System;
using System.Collections.Generic;

namespace ObjectArraysTask1 {
    class Program {

        static List<Student> student_db = new List<Student>();

        public static bool menu_time() {

            Console.WriteLine("│ Menu:");
            Console.WriteLine("│ \t1) Add candidates");
            Console.WriteLine("│ \t2) Calculate average score");
            Console.WriteLine("│ \t3) Retrieve specific candidate's mark + grade");
            Console.WriteLine("│ \t4) Alter specific candidate's mark");
            Console.WriteLine("│ \t5) Exit");

            Console.Write("│\n│ ");
            int input;
            try {input = int.Parse(Console.ReadLine());} catch { return false; }
            
            Console.WriteLine("│");

            switch (input) {

                case 1: {
                    Console.Write("│ Number of candidates you will be entering: ");
                    int candidates_adding;
                    try { candidates_adding = int.Parse(Console.ReadLine()); } catch { Console.WriteLine("\nThat number of candidates was invalid, press any key to return to menu..."); Console.ReadKey(); return false; }
                    for (int i=0; i<candidates_adding; i++) {
                        Console.Write("│ Enter student name: ");
                        string name = Console.ReadLine();
                        Console.Write("│ Enter student score: ");
                        int score;
                        try { score = int.Parse(Console.ReadLine()); } catch { Console.WriteLine("\nThat score was invalid, press any key to retry..."); Console.ReadKey(true); i--; continue; }
                        try { student_db.Add(new Student(name, score)); } catch { Console.WriteLine("\nScore was not within valid range, press any key to retry..."); Console.ReadKey(true); i--; continue; }
                    } }
                    return false;

                case 2:
                    int total = 0;
                    foreach (Student st in student_db) {
                        total += st.score;
                    }
                    Console.WriteLine("│ Average is: " + (float)total/(float)student_db.Count);
                    Console.WriteLine("Press any key to reset this menu...");
                    Console.ReadKey();
                    return false;

                case 3: {
                    Console.Write("│ Enter candidate name: ");
                    string candidate_name = Console.ReadLine();
                    foreach (Student s in student_db) {
                        if (s.name == candidate_name) {
                            Console.WriteLine("│ Student mark: " + s.score);
                            Console.WriteLine("Press any key to reset this menu...");
                            Console.ReadKey();
                            return false;
                        }
                    }
                    Console.WriteLine("That student does not exist");
                    Console.WriteLine("Press any key to reset this menu...");
                    Console.ReadKey(); }
                    return false;

                case 4: {
                    Console.Write("│ Enter candidate name: ");
                    string candidate_name = Console.ReadLine();
                    Student student = null;
                    foreach (Student s in student_db) {
                        if (s.name == candidate_name) {
                            student = s;
                        }
                    }
                    if (student is null) { Console.WriteLine("That student does not exist"); Console.WriteLine("Press any key to reset this menu..."); Console.ReadKey(); return false; }
                    Console.WriteLine("│ Current mark: " + student.score);
                    Console.Write("│ Enter new mark: ");
                    try { student.score = int.Parse(Console.ReadLine()); } catch { Console.WriteLine("That score was invalid.\nPress any key to reset this menu..."); Console.ReadKey(); return false; }
                    return false;
                }

                case 5:
                    return true;

                default:
                    Console.WriteLine("That is not a valid option, please try again.");
                    Console.WriteLine("Press any key to continue...");
                    return false;

            }

        }

        public static void Main(string[] args) {

            while (!menu_time()) {}

        }

    }

}