using System;

namespace Animals {

    public abstract class Animal {

        public Animal(uint age, string name) {
            animal_age = age;
            animal_name = name;
        }

        public uint animal_age {
            get;
            protected set;
        }

        public string animal_name {
            get;
            protected set;
        }

        public virtual void sleep() {
            Console.WriteLine("ZzzzzzzzzzZZZZZZZzzzzZZZZZZZZZ");
        }

        public virtual string ToString() {
            string base_str = "";
            base_str += "\tAge:  " + animal_age + "\n";
            base_str += "\tName: " + animal_name + "\n";
            return base_str;
        }

    }

}