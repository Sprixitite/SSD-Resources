using System;

namespace Animals {

    public class Cat : Animal {

        public Cat(uint age, string name, float jump_height)
            : base(age, name)
        {
            cat_jump_height = jump_height;
        }

        public float cat_jump_height {
            get;
            protected set;
        }

        public  void Meow() { Console.WriteLine("Meow"); }

        public override string ToString() {
            string cat_string = "Dog:\n";
            cat_string += base.ToString();
            cat_string += "\n\n";
            cat_string += "\tJump Height: " + cat_jump_height;
            return cat_string;
        }

    }

}