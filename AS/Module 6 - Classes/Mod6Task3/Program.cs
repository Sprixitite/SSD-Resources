using System;

namespace Mod6Task3 {
    class Program {
        static void Main(string[] args) {
            Square the_square = new Square(4);
            Console.WriteLine("Square area: " + the_square.area);
            the_square.grow();
            Console.WriteLine("Square area: " + the_square.area);
            Console.ReadKey();
        }
    }
}