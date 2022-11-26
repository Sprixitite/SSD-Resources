using System;

namespace Mod8Task2 {

    public abstract class Event {

        public uint event_ID {
            get;
            protected set;
        }

        public DateTime event_date {
            get;
            protected set;
        }

        public string branch_name {
            get;
            protected set;
        }

        public DateTime start_time {
            get;
            protected set;
        }

        public DateTime end_time {
            get;
            protected set;
        }

    }

}