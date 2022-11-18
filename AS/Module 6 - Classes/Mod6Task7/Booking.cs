using System;

namespace Mod6Task7 {

    public class Booking {

        public enum BookingType {
            STARTER_LESSONS = 50,
            CLIFF_CLIMB = 75,
            MOUNTAIN_CLIMB_TRIP = 125,
            EXPERT_CLIMBING_TOUR = 395
        }

        public Booking(int bn, string cn, BookingType bt, int ps) {
            booking_number = bn;
            client_name = cn;
            booking_type = bt;
            party_size = ps;
            owed = booking_cost;
            deposit_owed = owed*0.1f;
            if (bt > 1) {
                owed*=1.15f;
            }
        }

        public int booking_number {
            get;
            private get;
        }

        public string client_name {
            get;
            private get;
        }

        // Classes
        public BookingType booking_type {
            get;
            private set;
        }

        public DateTime booking_date {
            get;
            private set;
        }
        
        public int party_size {
            get;
            private set;
        }

        public void pay_deposit(float amt) {
            deposit_owed -= amt;
        }

        public void pay_owed(float amt) {
            owed -= amt;
        }

        public float total_owed() {
            return deposit_owed + owed;
        }

        public float deposit_owed {
            get;
            private set;
        }

        public float owed {
            get;
            private set;
        }

        public float booking_cost {
            get => (float)((int)booking_type)*party_size;
        }

    }

}