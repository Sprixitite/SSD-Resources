using System;

namespace Animals {

    public class Program {

        public static void Main(string[] args) {

            Cat my_cat = new Cat(3, "Globular Protein", 12);

            Dog my_dog = new Dog(4, "Dixie", 1000);

            Console.WriteLine(my_cat);
            Console.WriteLine(my_dog);

        }

    }

}