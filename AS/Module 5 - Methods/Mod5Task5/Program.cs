using System;
using System.Linq;
using System.Collections.Generic;

// Totally went overboard on this, I know lol
// Could definitely have handled the ansi escape codes in a more brief way
// Probably could've had a singleton with a bunch of const members but whatever
// It *works*, long-winded-ly, but it works

namespace Mod5Task5
{
    class Program
    {

        enum EscapeCode
        {

            // Cursor
            C_UP = 'A',
            C_DOWN = 'B',
            C_FORWARD = 'C',
            C_BACKWARD = 'D',
            C_NEXT_LINE = 'E',
            C_PREV_LINE = 'F',
            C_HORIZONTAL_POSITION = 'G',
            C_POSITION = 'H',
            C_SAVE_POS = 's',
            C_RESTORE_POS = 'u',

            // Display
            D_ERASE = 'J',
            D_ERASE_LINE = 'K',
            D_SCROLL_UP = 'S',
            D_SCROLL_DOWN = 'T',
            D_GRAPHICS_SET = 'm',

            // Fake escape codes for convenience:
            C_HIDE = '\'',
            C_SHOW = '\\',
            D_ALT_BUFFER = '#',
            D_MAIN_BUFFER = '~',
            D_GRAPHICS_RESET = '@',
            D_GRAPHICS_CLEAR = '/'

        }

        // Only contains most commonly supported ANSI graphics codes
        enum GraphicsCode
        {
            RESET = 0,
            NONE = 0,
            BOLD = 1,
            ITALIC = 3,
            UNDERLINE = 4,
            INVERT = 7,
            BLACK = 30,
            RED = 31,
            GREEN = 32,
            YELLOW = 33,
            BLUE = 34,
            MAGENTA = 35,
            CYAN = 36,
            WHITE = 37,

            // Fake, used for modifying colours, e.g: set_colour(BACKGROUND, BLACK)
            FOREGROUND = int.MaxValue - 1,
            BACKGROUND = int.MaxValue,
        }

        static string[] ansi_fmt(EscapeCode e, params GraphicsCode[] args)
        {

            List<string> escapes = new List<string>();

            GraphicsCode prev_gc = GraphicsCode.RESET;

            switch (e)
            {
                case EscapeCode.D_GRAPHICS_SET:
                    break;
                case EscapeCode.D_GRAPHICS_RESET:
                    escapes.Add("\x1b[0m");
                    break;
                default:
                    throw new Exception("Called ansi_escape() with EscapeCode other than \"D_GRAPHICS_SET\" or \"D_GRAPHICS_RESET\"!");
            }

            foreach (GraphicsCode gc in args)
            {

                int gc_int = (int)gc;

                switch (gc)
                {
                    case GraphicsCode.BLACK:
                    case GraphicsCode.RED:
                    case GraphicsCode.GREEN:
                    case GraphicsCode.YELLOW:
                    case GraphicsCode.BLUE:
                    case GraphicsCode.MAGENTA:
                    case GraphicsCode.CYAN:
                    case GraphicsCode.WHITE:
                        switch (prev_gc)
                        {
                            case GraphicsCode.FOREGROUND:
                                break;
                            case GraphicsCode.BACKGROUND:
                                gc_int += 10;
                                break;
                            default:
                                throw new Exception("Tried to change terminal colour without specification of FOREGROUND or BACKGROUND GraphicsCode first!");
                        }
                        break;
                    case GraphicsCode.FOREGROUND:
                    case GraphicsCode.BACKGROUND:
                        prev_gc = gc;
                        continue;
                }

                escapes.Add("\x1b[" + gc_int.ToString() + "m");

            }

            return escapes.ToArray();

        }

        static string ansi_escape(params Object[] args)
        {

            string escape = "";

            for (int i = 0; i < args.Length;)
            {
                EscapeCode esc = (EscapeCode)args[i];
                switch (esc)
                {
                    case EscapeCode.C_POSITION:
                        escape += "\x1b[" + (int)args[i + 1] + ';' + (int)args[i + 2] + (char)esc;
                        i += 3;
                        break;

                    case EscapeCode.C_SAVE_POS:
                    case EscapeCode.C_RESTORE_POS:
                        escape += "\x1b[" + (char)esc;
                        i++;
                        break;

                    case EscapeCode.C_SHOW:
                        escape += "\x1b[25h";
                        i++;
                        break;

                    case EscapeCode.C_HIDE:
                        escape += "\x1b[25l";
                        i++;
                        break;

                    case EscapeCode.D_GRAPHICS_RESET:
                        escape += "\x1b[0m";
                        i++;
                        break;

                    case EscapeCode.D_GRAPHICS_CLEAR:
                        escape += "\x1b[2J";
                        i++;
                        break;

                    case EscapeCode.D_MAIN_BUFFER:
                        escape += "\x1b[?1049l";
                        i++;
                        break;

                    case EscapeCode.D_ALT_BUFFER:
                        escape += "\x1b[?1049h";
                        i++;
                        break;

                    default:
                        escape += "\x1b[" + (int)args[i + 1] + (char)esc;
                        i += 2;
                        break;
                }
            }

            return escape;

        }

        static T ask_question<T>(string question, GraphicsCode colour = GraphicsCode.WHITE)
        {

            while (true)
            {

                Console.Write(ansi_fmt(EscapeCode.D_GRAPHICS_SET, GraphicsCode.FOREGROUND, colour)[0] + question + ansi_fmt(EscapeCode.D_GRAPHICS_SET, GraphicsCode.FOREGROUND, GraphicsCode.WHITE)[0]);
                try
                {
                    return (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                }
                catch
                {
                    Console.WriteLine("\n{0}The provided \"" + typeof(T).Name + "\" was not valid, please try again!{1}",
                                      ansi_fmt(EscapeCode.D_GRAPHICS_SET, GraphicsCode.BACKGROUND, GraphicsCode.RED, GraphicsCode.RESET)
                                     );
                }

            }

        }

        static T ask_question<T>(string question, T bounds_min, T bounds_max, GraphicsCode colour = GraphicsCode.WHITE)
            where T : IComparable<T>
        {

            while (true)
            {

                Console.Write(ansi_fmt(EscapeCode.D_GRAPHICS_SET, GraphicsCode.FOREGROUND, colour)[0] + question + ansi_fmt(EscapeCode.D_GRAPHICS_SET, GraphicsCode.FOREGROUND, GraphicsCode.WHITE)[0]);
                try
                {
                    T ret_val = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                    if (ret_val.CompareTo((T)bounds_max) > 0 || ret_val.CompareTo((T)bounds_min) < 0)
                    {
                        Console.WriteLine("\n{0}Input must be between the range of " + bounds_min + "-" + bounds_max + ", please try again!{1}",
                                          ansi_fmt(EscapeCode.D_GRAPHICS_SET, GraphicsCode.BACKGROUND, GraphicsCode.RED, GraphicsCode.RESET)
                                         );
                        continue;
                    }
                    return ret_val;
                }
                catch
                {
                    Console.WriteLine("\n{0}The provided \"" + typeof(T).Name + "\" was not valid, please try again!{1}",
                                      ansi_fmt(EscapeCode.D_GRAPHICS_SET, GraphicsCode.BACKGROUND, GraphicsCode.RED, GraphicsCode.RESET)
                                     );
                }

            }

        }

        struct Patient
        {

            public Patient(bool auto_query, GraphicsCode colour = GraphicsCode.WHITE)
            {
                switch (auto_query)
                {
                    case true:
                        name = ask_question<string>("Enter patient name: ", colour);
                        age = ask_question<int>("Enter " + name + "\'s age: ", 0, 150, colour);
                        weight = ask_question<float>("Enter " + name + "\'s weight: ", 0.0f, 635.0f, colour);
                        height = ask_question<float>("Enter " + name + "\'s height: ", 0.0f, 2.32f, colour);
                        break;
                    case false:
                        name = "";
                        age = -1;
                        weight = -1.0f;
                        height = -1.0f;
                        break;
                }
            }

            public Patient(string n, int a, float w, float h)
            {
                name = n;
                age = a;
                weight = w;
                height = h;
            }

            public static readonly Patient none = new Patient(
                string.Empty,
                int.MinValue,
                float.MinValue,
                float.MinValue
            );

            public override string ToString()
            {
                string heading = string.Join("", ansi_fmt(EscapeCode.D_GRAPHICS_SET, GraphicsCode.BOLD, GraphicsCode.ITALIC, GraphicsCode.UNDERLINE));
                string green_text = string.Join("", ansi_fmt(EscapeCode.D_GRAPHICS_SET, GraphicsCode.FOREGROUND, GraphicsCode.GREEN));
                string red_text = string.Join("", ansi_fmt(EscapeCode.D_GRAPHICS_SET, GraphicsCode.FOREGROUND, GraphicsCode.RED));
                string reset = string.Join("", ansi_fmt(EscapeCode.D_GRAPHICS_RESET));
                return heading + "RECORD:" + reset + "\n" +
                        "Name:   " + name + "\n" +
                        "Age:    " + age + "\n" +
                        "Weight: " + weight + "kg\n" +
                        "Height: " + height + "m\n\n" +
                        heading + "STATUS:" + reset + "\n" +
                        "Obese:  " + (obese ? red_text : green_text) + obese + reset + "\n" +
                        "BMI:    " + bmi;
            }

            public float bmi
            {
                get => weight / (height * height);
            }

            public bool obese
            {
                get => (bmi > 30 || (bmi > 27 && age < 40));
            }

            public string name
            {
                get;
                private set;
            }

            public int age
            {
                get;
                private set;
            }

            public float weight
            {
                get;
                private set;
            }

            public float height
            {
                get;
                private set;
            }
        }

        static J option_list<T, J>(T[] aliases, J[] values, GraphicsCode col = GraphicsCode.GREEN)
        {

            int selection = 0;
            bool enter_pressed = false;

            Console.Write(ansi_escape(EscapeCode.C_SAVE_POS));
            Console.CursorVisible = false;

            while (!enter_pressed)
            {

                Console.Write(ansi_escape(EscapeCode.C_RESTORE_POS));

                string[] text_fmt = ansi_fmt(EscapeCode.D_GRAPHICS_SET, GraphicsCode.FOREGROUND, col, GraphicsCode.RESET);

                for (int i = 0; i < aliases.Length; i++)
                {

                    T alias = aliases[i];

                    Console.Write((i == selection) ? "{0} -> {1}│ " : "    │ ", text_fmt);
                    Console.WriteLine("{0}" + alias + "{1}", text_fmt);
                }

                ConsoleKeyInfo intercepted = Console.ReadKey(true);

                switch (intercepted.Key)
                {
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        enter_pressed = true;
                        break;
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        selection--;
                        selection = ((selection < 0) ? values.Length - 1 : selection);
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        selection++;
                        selection = ((selection > (values.Length - 1)) ? 0 : selection);
                        break;
                }

            }

            Console.CursorVisible = true;

            return values[selection];

        }

        enum MenuOpt
        {
            NEW_PATIENT,
            VIEW_DETAILS,
            EXIT
        }

        static Dictionary<string, Patient> patients = new Dictionary<string, Patient>();

        static void add_patient()
        {

            string funky_text = string.Join("", ansi_fmt(EscapeCode.D_GRAPHICS_SET, GraphicsCode.FOREGROUND, GraphicsCode.MAGENTA));
            string reset_text = string.Join("", ansi_fmt(EscapeCode.D_GRAPHICS_RESET));

            Console.Write(funky_text);

            Console.WriteLine("  █████╗ ██████╗ ██████╗     ██████╗  █████╗ ████████╗██╗███████╗███╗   ██╗████████╗      ");
            Console.WriteLine(" ██╔══██╗██╔══██╗██╔══██╗    ██╔══██╗██╔══██╗╚══██╔══╝██║██╔════╝████╗  ██║╚══██╔══╝      ");
            Console.WriteLine(" ███████║██║  ██║██║  ██║    ██████╔╝███████║   ██║   ██║█████╗  ██╔██╗ ██║   ██║         ");
            Console.WriteLine(" ██╔══██║██║  ██║██║  ██║    ██╔═══╝ ██╔══██║   ██║   ██║██╔══╝  ██║╚██╗██║   ██║         ");
            Console.WriteLine(" ██║  ██║██████╔╝██████╔╝    ██║     ██║  ██║   ██║   ██║███████╗██║ ╚████║   ██║██╗██╗██╗");
            Console.WriteLine(" ╚═╝  ╚═╝╚═════╝ ╚═════╝     ╚═╝     ╚═╝  ╚═╝   ╚═╝   ╚═╝╚══════╝╚═╝  ╚═══╝   ╚═╝╚═╝╚═╝╚═╝\n");

            Patient p = new Patient(true, GraphicsCode.MAGENTA);
            patients.Add(p.name, p);

            Console.Write(reset_text);

        }

        static void view_details()
        {
            string clear_screen = ansi_escape(EscapeCode.D_GRAPHICS_CLEAR);
            string spooky_text = string.Join("", ansi_fmt(EscapeCode.D_GRAPHICS_SET, GraphicsCode.FOREGROUND, GraphicsCode.YELLOW));
            string reset_text = string.Join("", ansi_fmt(EscapeCode.D_GRAPHICS_RESET));
            string top_left = ansi_escape(EscapeCode.C_POSITION, 0, 0);

            if (patients.Count == 0) return;

            Console.Write(spooky_text);

            Console.WriteLine("  ▄▀▀▀▀▄  ▄▀▀█▄▄▄▄  ▄▀▀▀▀▄      ▄▀▀█▄▄▄▄  ▄▀▄▄▄▄   ▄▀▀▀█▀▀▄      ▄▀▀▄▀▀▀▄  ▄▀▀█▄   ▄▀▀▀█▀▀▄  ▄▀▀█▀▄    ▄▀▀█▄▄▄▄  ▄▀▀▄ ▀▄  ▄▀▀▀█▀▀▄ ");
            Console.WriteLine(" █ █   ▐ ▐  ▄▀   ▐ █    █      ▐  ▄▀   ▐ █ █    ▌ █    █  ▐     █   █   █ ▐ ▄▀ ▀▄ █    █  ▐ █   █  █  ▐  ▄▀   ▐ █  █ █ █ █    █  ▐ ");
            Console.WriteLine("    ▀▄     █▄▄▄▄▄  ▐    █        █▄▄▄▄▄  ▐ █      ▐   █         ▐  █▀▀▀▀    █▄▄▄█ ▐   █     ▐   █  ▐    █▄▄▄▄▄  ▐  █  ▀█ ▐   █     ");
            Console.WriteLine(" ▀▄   █    █    ▌      █         █    ▌    █         █             █       ▄▀   █    █          █       █    ▌    █   █     █      ");
            Console.WriteLine("  █▀▀▀    ▄▀▄▄▄▄     ▄▀▄▄▄▄▄▄▀  ▄▀▄▄▄▄    ▄▀▄▄▄▄▀  ▄▀            ▄▀       █   ▄▀   ▄▀        ▄▀▀▀▀▀▄   ▄▀▄▄▄▄   ▄▀   █    ▄▀       ");
            Console.WriteLine("  ▐       █    ▐     █          █    ▐   █     ▐  █             █         ▐   ▐   █         █       █  █    ▐   █    ▐   █         ");
            Console.WriteLine("          ▐          ▐          ▐        ▐        ▐             ▐                 ▐         ▐       ▐  ▐        ▐        ▐         \n");

            Console.Write(reset_text);

            string[] options = new string[patients.Count + 1];
            patients.Keys.ToArray().CopyTo(options, 0);
            options[options.Length - 1] = "Exit";

            Patient[] values = new Patient[patients.Count + 1];
            patients.Values.ToArray().CopyTo(values, 0);
            values[values.Length - 1] = Patient.none;

            Patient patient = option_list<string, Patient>(
                options,
                values,
                GraphicsCode.YELLOW
            );

            if (patient.Equals(Patient.none)) return;

            Console.CursorVisible = false;

            Console.Write(clear_screen + top_left);
            Console.WriteLine(patient);
            Console.WriteLine("\nPress any key to return to main menu...");
            Console.ReadKey();

            Console.CursorVisible = true;

        }

        static void main_menu()
        {

            string green_text = string.Join("", ansi_fmt(EscapeCode.D_GRAPHICS_SET, GraphicsCode.FOREGROUND, GraphicsCode.GREEN));
            string reset_text = string.Join("", ansi_fmt(EscapeCode.D_GRAPHICS_RESET));
            string clear_screen = ansi_escape(EscapeCode.D_GRAPHICS_CLEAR);
            string top_left = ansi_escape(EscapeCode.C_POSITION, 0, 0);

            bool exiting = false;
            while (!exiting)
            {

                Console.Write(clear_screen + top_left + green_text);

                Console.WriteLine(" /\\\\\\\\            /\\\\\\\\                                               /\\\\\\\\            /\\\\\\\\                                                             /\\\\\\         Copyright: Idiot, 1997");
                Console.WriteLine(" \\/\\\\\\\\\\\\        /\\\\\\\\\\\\                                              \\/\\\\\\\\\\\\        /\\\\\\\\\\\\                                                            \\///\\\\\\");
                Console.WriteLine("  \\/\\\\\\//\\\\\\    /\\\\\\//\\\\\\                 /\\\\\\                         \\/\\\\\\//\\\\\\    /\\\\\\//\\\\\\                                                              \\//\\\\\\");
                Console.WriteLine("   \\/\\\\\\\\///\\\\\\/\\\\\\/ \\/\\\\\\  /\\\\\\\\\\\\\\\\\\    \\///   /\\\\/\\\\\\\\\\\\             \\/\\\\\\\\///\\\\\\/\\\\\\/ \\/\\\\\\     /\\\\\\\\\\\\\\\\   /\\\\/\\\\\\\\\\\\    /\\\\\\    /\\\\\\                    \\//\\\\\\");
                Console.WriteLine("    \\/\\\\\\  \\///\\\\\\/   \\/\\\\\\ \\////////\\\\\\    /\\\\\\ \\/\\\\\\////\\\\\\            \\/\\\\\\  \\///\\\\\\/   \\/\\\\\\   /\\\\\\/////\\\\\\ \\/\\\\\\////\\\\\\  \\/\\\\\\   \\/\\\\\\            /\\\\\\     \\/\\\\\\");
                Console.WriteLine("     \\/\\\\\\    \\///     \\/\\\\\\   /\\\\\\\\\\\\\\\\\\\\  \\/\\\\\\ \\/\\\\\\  \\//\\\\\\           \\/\\\\\\    \\///     \\/\\\\\\  /\\\\\\\\\\\\\\\\\\\\\\  \\/\\\\\\  \\//\\\\\\ \\/\\\\\\   \\/\\\\\\           \\///      /\\\\\\");
                Console.WriteLine("      \\/\\\\\\             \\/\\\\\\  /\\\\\\/////\\\\\\  \\/\\\\\\ \\/\\\\\\   \\/\\\\\\           \\/\\\\\\             \\/\\\\\\ \\//\\\\///////   \\/\\\\\\   \\/\\\\\\ \\/\\\\\\   \\/\\\\\\                    /\\\\\\");
                Console.WriteLine("       \\/\\\\\\             \\/\\\\\\ \\//\\\\\\\\\\\\\\\\/\\\\ \\/\\\\\\ \\/\\\\\\   \\/\\\\\\           \\/\\\\\\             \\/\\\\\\  \\//\\\\\\\\\\\\\\\\\\\\ \\/\\\\\\   \\/\\\\\\ \\//\\\\\\\\\\\\\\\\\\             /\\\\\\  /\\\\\\/");
                Console.WriteLine("        \\///              \\///   \\////////\\//  \\///  \\///    \\///            \\///              \\///    \\//////////  \\///    \\///   \\/////////             \\///  \\///\n" + reset_text);

                MenuOpt menu_opt = option_list<string, MenuOpt>(
                    new[] { "Add Patient", "View Patient Details", "Exit" },
                    new[] { MenuOpt.NEW_PATIENT, MenuOpt.VIEW_DETAILS, MenuOpt.EXIT }
                );

                Console.Write(clear_screen + top_left);

                switch (menu_opt)
                {
                    case MenuOpt.NEW_PATIENT:
                        add_patient();
                        break;
                    case MenuOpt.VIEW_DETAILS:
                        view_details();
                        break;
                    case MenuOpt.EXIT:
                        exiting = true;
                        break;
                }

            }

        }

        static void Main(string[] args)
        {

            main_menu();

        }
    }
}