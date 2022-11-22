using System;

namespace Mod8Task1 {

    public class Painting : Art {

        public Painting(string artist, uint ID, string name, float price, string medium, float length, float width)
            : base(artist, ID, name, price)
        {
            painting_medium = medium;
            painting_length = length;
            painting_width = width;
        }

        public float painting_across {
            get => MathF.Sqrt(MathF.Pow(painting_width, 2.0f)+MathF.Pow(painting_length, 2.0f));
        }

        public float painting_area {
            get => painting_length*painting_width;
        }

        public string painting_medium {
            get;
            private set;
        }

        public float painting_length {
            get;
            private set;
        }

        public float painting_width {
            get;
            private set;
        }

        public override string derived_stringrep() {
            string painting_string = "Painting:\n";
            painting_string += "\tAcross:     " + painting_across + "\n";
            painting_string += "\tArea:       " + painting_area + "\n";
            painting_string += "\tDimensions: ( width: " + painting_width + "cm, length: " + painting_length + "cm )\n";
            painting_string += "\tMedium:     " + painting_medium + "\n";
            return painting_string;
        }

    }

}