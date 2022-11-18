using System;

namespace Module1_3BonusTask2 {
    class Program {

        // Function to automatically validate input for an arbitrary type
        // Yes, I know I could put these in a shared project, but then you'd not know what these are
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

        // Overload of above with a bounds check, but a more constrained generic type
        static T AskQuestion<T>(string question, T bounds_min, T bounds_max)
            where T : IComparable<T>
        {

            while (true) {

                Console.Write(question);
                try {
                    T ret_val = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                    if (ret_val.CompareTo((T)bounds_max) > 0 || ret_val.CompareTo((T)bounds_min) < 0) {
                        continue;
                    }
                    return ret_val;
                } catch {
                    Console.WriteLine("\n\x1b[41mThe provided \"" + typeof(T).Name + "\" was not valid, please try again!\x1b[0m");
                }

            }

        }

        static void Main(string[] args) {

            for (int i=0; i<3; i++) {
                string candidate_name = AskQuestion<string>("Enter candidate " + (i + 1) + "'s name: ");
                int exam_score = AskQuestion<int>("Enter candidate " + (i + 1) + "'s exam score: ", 1, 50);
                int coursework_score = AskQuestion<int>("Enter candidate " + (i + 1) + "'s coursework score: ", 1, 50);
                Console.WriteLine(candidate_name + "'s total score was: " + (exam_score + coursework_score) + "\n");
            }

        }

    }
}
