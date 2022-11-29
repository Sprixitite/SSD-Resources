using System;

namespace Task2 {

    public class Movie {

        public Movie(
            string _name,
            string _director,
            string _prim_actor_1,
            float _running_time,
            uint _year,
            MovieRating _rating
        ) {
            name = _name;
            director = _director;
            prim_actor_1 = _prim_actor_1;
            prim_actor_2 = null;
            running_time = _running_time;
            year = _year;
            rating = _rating;
        }

        public Movie(
            string _name,
            string _director,
            string _prim_actor_1,
            string? _prim_actor_2,
            float _running_time,
            uint _year,
            MovieRating _rating
        ) {
            name = _name;
            director = _director;
            prim_actor_1 = _prim_actor_1;
            prim_actor_2 = _prim_actor_2;
            running_time = _running_time;
            year = _year;
            rating = _rating;
        }

        public enum MovieRating : byte {

            HOW_DID_YOU_EVEN_GET_THIS_WHAT_THE_HELL = 255,

            // I would give both of these the same value but then they're near indistinguishable
            U = 0,
            PG = 1,

            TWELVE = 12,
            FIFTEEN = 15,
            EIGHTEEN = 18

        }

        public string name {
            get;
            private set;
        }
        public string director {
            get;
            private set;
        }

        public string prim_actor_1 {
            get;
            private set;
        }

        #nullable enable

        public string? prim_actor_2 {
            get;
            private set;
        }

        #nullable disable

        public float running_time {
            get;
            private set;
        }

        public uint year {
            get;
            private set;
        }

        public MovieRating rating {
            get;
            private set;
        }

        public bool contains_actor(string actor) {
            return (actor == prim_actor_1) || (actor == prim_actor_2);
        }

        public bool age_allowed(byte age) {
            return (age >= ((byte)rating));
        }

    }

}