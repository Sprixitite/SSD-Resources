using System;

namespace Mod6Task7 {

    class Program {

        public static void Main(string[] args) {

            Booking my_booking = new Booking(0, "My Amazing Name", Booking.BookingType.EXPERT_CLIMBING_TOUR, 7);
            Console.WriteLine(my_booking.booking_cost);
            Console.WriteLine(my_booking.deposit_owed);
            Console.WriteLine(my_booking.total_owed());

        }

    }

}