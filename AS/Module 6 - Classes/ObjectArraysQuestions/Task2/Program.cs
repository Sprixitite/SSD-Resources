using System;
using System.Collections.Generic;

namespace Task2 {

    public class Program {

        private static Movie[] movies;

        public enum MenuOption {
            THIS_OPTION_SHOULD_BE_IMPOSSIBLE,
            ENTER_MOVIES,
            SHOW_ALLOWED,
            WITH_ACTOR,
            EXIT
        }

        public static MenuOption menu_go_brr() {

            bool option_valid = false;

            MenuOption selected = MenuOption.THIS_OPTION_SHOULD_BE_IMPOSSIBLE;

            while (true) {
                Console.WriteLine("Menu\n\t1) Enter movies\n\t2) Show movies allowed for age\n\t3) Show movies with actor(s)\n\t4) Exit");
                try {
                    
                    switch (int.Parse(Console.ReadLine())) {
                        case 1:
                            return MenuOption.ENTER_MOVIES;
                        case 2:
                            return MenuOption.SHOW_ALLOWED;
                        case 3:
                            return MenuOption.WITH_ACTOR;
                        case 4:
                            return MenuOption.EXIT;
                        default:
                            throw new Exception();
                    }
                } catch {
                    Console.WriteLine("Menu Option invalid, please try again!");
                }
            }

            

        }

        private static Func<string, Type, object> prompt_str = (string prompt, Type to) => {
            while (true) {
                Console.Write(prompt);
                try {
                    return Convert.ChangeType(Console.ReadLine(), to); 
                } catch {
                    Console.WriteLine("\tThe inputted " + to.Name + " was invalid, please try again!");
                }
            }
        };

        public static void enter_movie_details() {

            for (int i=0; i<movies.Length; i++) {

                string name = (string)prompt_str("Enter name: ", typeof(string));
                string director = (string)prompt_str("Enter director: ", typeof(string));
                string prim_actor_1 = (string)prompt_str("Enter the first actor: ", typeof(string));
                string? prim_actor_2 = null;

                bool has_second_actor = false;
                bool second_actor_valid = false;

                while (!second_actor_valid) {

                    string second_actor_in = ((string)(prompt_str("Do you want to add a second actor? (Y/n) ", typeof(string)))).ToLower();

                    has_second_actor = (second_actor_in == "y") || (second_actor_in == "yes");
                    second_actor_valid = (second_actor_in == "y") || (second_actor_in == "yes") || (second_actor_in == "n") || (second_actor_in == "no");

                }

                if (has_second_actor) {
                    prim_actor_2 = (string)prompt_str("Enter the second actor: ", typeof(string));
                }

                float running_time = (float)prompt_str("Enter the running time (seconds) ", typeof(float));
                uint year = (uint)prompt_str("Enter the release year: ", typeof(uint));

                Movie.MovieRating rating = Movie.MovieRating.HOW_DID_YOU_EVEN_GET_THIS_WHAT_THE_HELL;
                bool rating_valid = false;

                while (!rating_valid) {

                    string rating_str = ((string)prompt_str("Enter rating (U/PG/12/15/18) ", typeof(string))).ToUpper();

                    try {
                        rating = (Movie.MovieRating)Enum.Parse(typeof(Movie.MovieRating), rating_str);
                        rating_valid = true;
                    } catch {
                        continue;
                    }

                }

                movies[i] = new Movie(name, director, prim_actor_1, prim_actor_2, running_time, year, rating);

                Console.Write("\nMovie listing added!\n");

            }

        }

        public static Movie[] movies_allowed_for_age(byte age) {

            List<Movie> allowed = new List<Movie>();

            foreach (Movie movie in movies) {

                if (movie.age_allowed(age)) {
                    allowed.Add(movie);
                }

            }

            return allowed.ToArray();

        }

        public static Movie[] movies_with_actors(string actor1, string? actor2 = null) {

            List<Movie> with_actors = new List<Movie>();

            foreach (Movie movie in movies) {

                if (movie.contains_actor(actor1)) {

                    if (actor2 is not null) {

                        if (movie.contains_actor(actor2)) {
                            with_actors.Add(movie);
                        }

                    } else {
                        with_actors.Add(movie);
                    }

                }

            }

            return with_actors.ToArray();

        }

        public static void Main(string[] args) {

            movies = new Movie[3];

            bool exit = false;

            while (!exit) {

                MenuOption mo = menu_go_brr();

                switch (mo) {
                    case MenuOption.ENTER_MOVIES:
                        enter_movie_details();
                        break;
                    case MenuOption.SHOW_ALLOWED:
                        bool valid = false;
                        byte age = 0;
                        while (!valid) {
                            try {
                                age = (byte)prompt_str("Enter age: ", typeof(byte));
                                valid = true;
                            } catch { continue; }
                        }
                        foreach(Movie movie in movies_allowed_for_age(age)) {
                            Console.WriteLine(movie.name);
                        }
                        break;
                    case MenuOption.WITH_ACTOR:
                        while (true) {
                            try {
                                string prim_actor_1 = (string)prompt_str("Enter the first actor: ", typeof(string));
                                string? prim_actor_2 = null;

                                bool has_second_actor = false;
                                bool second_actor_valid = false;

                                while (!second_actor_valid) {

                                    string second_actor_in = ((string)(prompt_str("Do you want to add a second actor? (Y/n) ", typeof(string)))).ToLower();

                                    has_second_actor = (second_actor_in == "y") || (second_actor_in == "yes");
                                    second_actor_valid = (second_actor_in == "y") || (second_actor_in == "yes") || (second_actor_in == "n") || (second_actor_in == "no");

                                }

                                if (has_second_actor) {
                                    prim_actor_2 = (string)prompt_str("Enter the second actor: ", typeof(string));
                                }
                                foreach(Movie movie in movies_with_actors(prim_actor_1, prim_actor_2)) {
                                    Console.WriteLine(movie.name);
                                }
                                break;
                            } catch {
                                continue;
                            }

                        }
                        break;
                        
                    case MenuOption.EXIT:
                        exit = true;
                        break;
                }

            }

        }

    }

}