using System;

namespace Intro {

    public class Rect : Shape {

        public Rect(float w, float h) {
            width = w;
            height = h;
        }

        public override float calculate_area() {
            return width*height;
        }

    }

}