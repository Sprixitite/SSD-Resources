using System;

namespace TrackingTestTask
{

    class Program
    {

        struct SwimmerRecord {

            public enum Strokes {
                FRONT_CRAWL,
                BACK_STROKE
            }

            public static string stroke_name(Strokes s) { 
                switch (s) {
                    case Strokes.FRONT_CRAWL:
                        return "Front Crawl";
                    case Strokes.BACK_STROKE:
                        return "Back Stroke";
                    default:
                        return "Nice error rory, good job dingus";
                }
            }

            public SwimmerRecord(string _name, int times_per_stroke) {
                name = _name;
                times = new float[Enum.GetValues(typeof(Strokes)).Length, times_per_stroke];
            }

            public string name {
                get;
                private set;
            }

            private float[,] times;

            public float this[Strokes s, int t] {
                get => times[(int)s, t];
                set => times[(int)s, t] = value;
            }

        }

        public static T ask_question<T>(string prompt) {

            while (true) {

                Console.Write(prompt);
                try {
                    return (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                } catch {
                    Console.WriteLine("\n\n\x1b[41mInputted \"" + typeof(T).Name + "\" is invalid! Please try again!\x1b[0m");
                }

            }

        }

        static bool details_menu(SwimmerRecord[] swimmers, out SwimmerRecord selected_record) {

            int selected = 0;
            bool selection_finished = false;

            Console.CursorVisible = false;

            while (!selection_finished) {

                Console.Write("\x1b[2J\x1b[0;0H");

                for (int i = 0; i < swimmers.Length; i++) {
                    SwimmerRecord sw = swimmers[i];
                    bool is_selected = (i == selected);
                    Console.WriteLine((is_selected ? " -> |" : "    |") + sw.name);
                }

                Console.WriteLine(((selected == swimmers.Length) ? " -> |" : "    |") + "Exit");

                ConsoleKeyInfo input = Console.ReadKey();

                switch (input.Key) {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        selected--;
                        if (selected < 0) selected = swimmers.Length;
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        selected++;
                        if (selected > swimmers.Length) selected = 0;
                        break;
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        selection_finished = true;
                        break;
                }

            }

            Console.CursorVisible = true;

            selected_record = swimmers[0];
            if (selected == swimmers.Length) return true;

            selected_record = swimmers[selected];
            return false;

        }

        static void Main(string[] args) {

            const int swimmer_count = 3;
            const int times_per_stroke = 2;

            SwimmerRecord[] swimmers = new SwimmerRecord[swimmer_count];
            
            for (int i=0; i<swimmer_count; i++) {
                SwimmerRecord sr = new SwimmerRecord(ask_question<string>("Enter name of swimmer " + (i + 1) + ": "), times_per_stroke);
                
                foreach (SwimmerRecord.Strokes stroke in Enum.GetValues(typeof(SwimmerRecord.Strokes))) { 
                    for (int j=0; j<times_per_stroke; j++) {
                        sr[stroke, j] = ask_question<float>("Enter " + SwimmerRecord.stroke_name(stroke) + " time " + (j + 1) + ": ");
                    }
                }

                Console.Write("\n");

                swimmers[i] = sr;

            }

            bool exiting = false;
            while (!exiting) {
                exiting = details_menu(swimmers, out SwimmerRecord selected_record);
                if (!exiting) {
                    Console.CursorVisible = false;
                    Console.Write("\x1b[2J\x1b[0;0H");
                    Console.WriteLine("Times for: " + selected_record.name);
                    foreach (SwimmerRecord.Strokes stroke in Enum.GetValues(typeof(SwimmerRecord.Strokes)))
                    {
                        Console.WriteLine("\n" + SwimmerRecord.stroke_name(stroke) + ": ");
                        for (int i = 0; i < times_per_stroke; i++)
                        {
                            Console.WriteLine("Time " + i + ": " + selected_record[stroke, i]);
                        }
                    }
                    Console.WriteLine("\nPress any key to return to selection menu...");
                    Console.ReadKey();
                    Console.CursorVisible = true;
                }
            }

        }
    }
}
