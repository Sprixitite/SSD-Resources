using System;

namespace Mod8Task1 {

    public class Tri : Shape {

        public Tri(float w, float h) {
            width = w;
            height = h;
        }

        public override float calculate_area() {
            return (width*height)/2;
        }

    }

}