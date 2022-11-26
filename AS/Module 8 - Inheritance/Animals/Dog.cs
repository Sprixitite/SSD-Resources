using System;

namespace Animals {

    public class Dog : Animal {

        public Dog(uint age, string name, float bark_volume)
            : base(age, name)
        {
            dog_bark_volume = bark_volume;
        }

        public float dog_bark_volume {
            get;
            protected set;
        }

        public void bark() {
            string bork="ARF";
            Console.WriteLine(bork*dog_bark_volume);
        }

        public override string ToString() {
            string dog_string = "Dog:\n";
            dog_string += base.ToString();
            dog_string += "\n\n";
            dog_string += "\tBark Volume: " + dog_bark_volume;
            return dog_string;
        }

    }

}