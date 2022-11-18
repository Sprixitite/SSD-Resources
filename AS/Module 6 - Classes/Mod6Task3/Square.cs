using System;

namespace Mod6Task3 {

    class Square {

        public float side_length {
            get;
            protected set;
        }

        public float area {
            get => side_length*side_length;
        }

        public Square(float length) {
            side_length = length;
        }

        public void grow() {
            side_length*=2;
        }

    }

}