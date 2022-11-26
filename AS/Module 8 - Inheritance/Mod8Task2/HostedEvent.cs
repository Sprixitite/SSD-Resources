using System;

namespace Mod8Task2 {

    public class HostedEvent : Event {

        public string description {
            get;
            protected set;
        }

        public string venue {
            get;
            protected set;
        }

        public float venue_charge_pp {
            get;
            protected set;
        }

        public float ticket_charge {
            get;
            protected set;
        }

        public int attendees {
            get;
            protected set;
        }

        public float donation {
            get;
            protected set;
        }

    }

}