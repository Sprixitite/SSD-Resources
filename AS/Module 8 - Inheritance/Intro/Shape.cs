using System;

namespace Intro {

    public abstract class Shape {

        public abstract float calculate_area();
        public virtual void print_dimensions() {
            Console.WriteLine("Width: " + width + "\nHeight: " + height);
        }

        protected float width;
        protected float height;

    }

}