using System;

namespace PropertiesExample {

    public class Program {

        public static void Main(string[] args) {

            // Basic property example
            Person person_1 = new Person();
            Console.Write("Give name: ");
            person_1.name = Console.ReadLine();
            Console.WriteLine("Name: " + person_1.name);

            // Example of creating an array of class Person
            // This works without the initialisation list too, I just included it for brevity
            Person[] people = new Person[5] {
                new Person(),
                new Person(),
                new Person(),
                new Person(),
                new Person(),
            };

            // Example of setting properties of class in array because it is totally definitely for real needed
            people[0].age = 16;
            people[0].name = "Rory";
            people[0].gender = Person.Gender.MALE;

            // Can be made without initialisation list as specified above
            Person[] second_group_of_people =  new Person[7];

            // You can assign existing instances to an array too
            Person p0 = new Person();
            second_group_of_people[0] = p0;

            for(int i=1;i<7;i++) {
                Person new_person = new Person();
                Console.Write("Give name: ");
                new_person.name = Console.ReadLine();
                bool age_success = false;
                while (!age_success) {
                    try {
                        Console.Write("Give age: ");
                        new_person.age = int.Parse(Console.ReadLine());
                        age_success = true;
                    } catch {}
                }
                second_group_of_people[i] = new_person;
            }

            int j = 1;
            foreach (Person p in second_group_of_people) {

                Console.WriteLine("Person " + j + ":");
                Console.WriteLine("\tName:   " + p.name);
                Console.WriteLine("\tAge:    " + p.age);
                Console.WriteLine("\tGender: " + p.gender + "\n");
                j++;

            }

        }

        public static float mean_age(Person[] people) {
            int total = 0;
            foreach (Person p in people) { total += p.age; }
            return (float)total / (float)people.Length;
        }

    }

}