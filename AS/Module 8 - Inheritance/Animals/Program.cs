using System;

namespace Animals {

    public class Program {

        public static void Main(string[] args) {

            Dog newDog=new Dog(9999999,"UNDEFINED ANOMALOUS ENTITY #37",50);

            System.Console.WriteLine(newDog.ToString());
            newDog.bark();
            Cat my_cat = new Cat(3, "Globular Protein", 12);

            Dog my_dog = new Dog(4, "Dixie", 1000);

            

            Console.WriteLine(my_cat);
            Console.WriteLine(my_dog);

            Animal[] animals = new Animal[] {
                my_cat,
                my_dog
            };

            foreach (Animal animal in animals) {

                if (animal.GetType() == typeof(Cat)) {
                    ((Cat)animal).Meow();
                } else if (animal.GetType() == typeof(Dog)) {
                    ((Dog)animal).bark();
                } else {
                    throw new NotImplementedException();
                }

            }

        }

    }

}