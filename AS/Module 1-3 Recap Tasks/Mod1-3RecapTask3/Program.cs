using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace Mod1_3BonusTask3 {

    static class EnumExtensionMethods {
        public static string GetEnumDescription(this Enum e) {
            var descriptionAttribute = e.GetType().GetMember(e.ToString())[0]
                .GetCustomAttributes(typeof(DescriptionAttribute), inherit: false)[0] 
                as DescriptionAttribute;

            return descriptionAttribute.Description;
        }
    }

    class Program {
        
        private struct User {

            public User(string _username, string _password, string _first_name) {
                username = _username; password = _password; first_name = _first_name;
            }

            public bool Authenticate(string uname, string pword) {
                return ( username == uname && password == pword );
            }

            public string first_name {
                get;
                private set;
            }

            public string username {
                get;
                private set;
            }

            private string password;

        }

        static List<User> users = new List<User> {
            new User("Shrek69420", "ShrekSwampKartBestGame", "Shrek"),
            new User("GabeN@valvesoftware.com", "Password0", "Gabe"),
            new User("Illicit substances and C++", "My username uses spaces", "C++"),
            new User("I am", "an idiot", "Idiot")
        };

        // Description tags are used later for printing status
        enum AuthStatus {
            [Description("\x1b[37;42mSuccess\x1b[0m")]
            SUCCESS,

            [Description("\x1b[37;41mIncorrect Password\x1b[0m")]
            PASSWORD_INCORRECT,
            
            [Description("\x1b[37;41mUser Does Not Exist\x1b[0m")]
            NO_USER,

            [Description("\x1b[37;41mRory sucks at this :P\x1b[0m")]
            NOT_SET
        }

        static void Main(string[] args) {

            AuthStatus status = AuthStatus.NOT_SET;
            int login_attempts = 3;
            for (int i=0; i<login_attempts; i++) {

                // Clear whole terminal -> set cursor XY to top left
                Console.Write("\x1b[2J\x1b[1;1H");

                // Print the login prompt
                // It's a mess, I'm aware
                // All of these escape codes are just font styling lol
                Console.WriteLine("\x1b[34m┌─────────────────────────────────────────┬─────────────────────────┐\x1b[0m");
                Console.WriteLine("\x1b[34m│\x1b[1;3;36m Login:\x1b[0m                                  \x1b[34m│\x1b[3;5;6;36m Michaelsoft Binbows 9.0 \x1b[0;34m│\x1b[0m");
                Console.WriteLine("\x1b[34m│                                         ├─────────────────────────┴────────────┐\x1b[0m");
                Console.WriteLine("\x1b[34m│\x1b[3;36m Username:\x1b[0;34m _____________________________ │ \x1b[0;36mStatus: \x1b[0;45mUndetermined\x1b[0;34m                 │\x1b[0m");
                Console.WriteLine("\x1b[34m│\x1b[3;36m Password:\x1b[0;34m _____________________________ │                                      │\x1b[0m");
                Console.WriteLine("\x1b[34m└─────────────────────────────────────────┴──────────────────────────────────────┘\x1b[0m");

                // Back up 3 lines -> set cursor X to cell 13
                Console.Write("\x1b[3F\x1b[13G");

                string username = read_input(29);

                // Go down a line -> reset cursor X to cell 13
                Console.Write("\x1b[1E\x1b[13G");

                // Our text entry field is 29 characters long
                // Replace all inputted characters with asterisks because we're taking a password
                string password = read_input(29, '*');

                User user = new User("", "", "If you see this, this is bad...");

                foreach ( User u in users ) {
                    
                    if (u.username == username) {
                        if (u.Authenticate(username, password)) {
                            status = AuthStatus.SUCCESS;
                            user = u;
                            break;
                        } else {
                            // There can only be one user with any username
                            // Thus we don't need to keep iterating
                            status = AuthStatus.PASSWORD_INCORRECT;
                            break;
                        }
                    } else if (u.Equals(users[users.Count-1])) {
                        // We're on the last user, change status to NO_USER
                        status = AuthStatus.NO_USER;
                    }

                }

                // Go up a line -> set font colour to light blue -> set cursor X to cell 45 -> print "Status:             " -> set cursor X to cell 53
                Console.Write("\x1b[1F\x1b[36m\x1b[45GStatus:             \x1b[53G" + status.GetEnumDescription());

                if (status == AuthStatus.SUCCESS) {
                    // Go down a line -> set cursor X to cell 45
                    Console.Write("\x1b[1E\x1b[45GHello, " + user.first_name + "!");
                    // Go down two lines -> set cursor X to cell 1 -> disable all font effects -> reveal cursor
                    Console.Write("\x1b[2E\x1b[1G\x1b[0m\x1b[?25h");
                    break;
                } else {
                    // Go down a line -> hide cursor -> italicise text & set colour to dark blue -> set cursor X to cell 45
                    Console.Write("\x1b[1E\x1b[?25l\x1b[3;34m\x1b[45GPress any key to try again.");
                    Console.ReadKey(true);
                    // Reveal cursor
                    Console.Write("\x1b[?25h\n");
                }

            }

        }

        static string read_input(int input_cap, char? hider = null) {

            bool use_char_hider = !(hider == null);

            string input = "";
            while (true) {

                ConsoleKeyInfo new_key = Console.ReadKey(true);
                
                char key_char = new_key.KeyChar;

                switch (new_key.Key) {

                    // This "when" constraint (and the next one)
                    // both prevent cases where we return/modify an empty string
                    case ConsoleKey.Backspace when input.Length > 0:
                        input = input.Substring(0, input.Length-1);

                        // Change text to dark blue -> move back a cell -> print "_" -> move back a cell -> reset font
                        Console.Write("\x1b[34m\x1b[1D_\x1b[1D\x1b[0m");
                        break;

                    case ConsoleKey.Enter when input.Length > 0:
                        return input;

                }

                // Any operation past this point requires we have space left on the prompt
                // Skip to the next iteration of the loop
                if (!(input.Length < input_cap)) continue;

                if ((int)key_char >= 32 && (int)key_char <= 126) {

                    input += key_char;

                    // Because of how CMD works, writing to a previously written cell works fine!
                    // We pass true to ReadKey() just to avoid non-valid characters auto-printing
                    if (use_char_hider) {
                        // "(hider ?? '?')" is just to make the compiler happy
                        // If this code executes we KNOW hider != null
                        Console.Write("\x1b[36;4m" + (hider ?? '?') + "\x1b[0m");
                    } else {
                        Console.Write("\x1b[36;4m" + key_char + "\x1b[0m");
                    }
                    

                }

            }
        }

    }
}
