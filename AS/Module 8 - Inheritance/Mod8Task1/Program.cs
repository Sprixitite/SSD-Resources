using System;

namespace Mod8Task1 {

    public class Program {

        public static void Main(string[] args) {

            AnonymousArtwork aa = new AnonymousArtwork("Ryan William Montgomery", 1, "The Guiltiest Gear", 1000000000);
            Sculpture s = new Sculpture("Samuel David Martin", 02, "Little Man, Big Mac", 5, "Beef", 0.2f, 0.25f);
            Painting p = new Painting("Rory James Cousins", 03, "Coffee Stain", -1, "Coffee", 5, 5);

            Console.WriteLine(aa.ToString());
            Console.WriteLine(s.ToString());
            Console.WriteLine(p.ToString());

        }

    }

}