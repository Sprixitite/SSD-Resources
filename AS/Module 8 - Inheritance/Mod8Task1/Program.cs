using System;

namespace Mod8Task1 {

    public class Program {

        public static void Main(string[] args) {

            Rect my_rectangle = new Rect(2, 2);
            Tri my_triangle = new Tri(2, 2);

            print_dimensions_and_area(my_rectangle);
            Console.Write("\n");
            print_dimensions_and_area(my_triangle);

        }

        public static void print_dimensions_and_area(Shape s) {

            s.print_dimensions();
            Console.WriteLine("Area: " + s.calculate_area());

        }

    }

}