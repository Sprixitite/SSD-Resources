using System;

namespace Mod8Task1 {

    public class Sculpture : Art {

        public Sculpture(string artist, uint ID, string name, float price, string material, float height, float width)
            : base(artist, ID, name, price)
        {
            sculpt_material = material;
            sculpt_height = height;
            sculpt_width = width;
        }

        public string sculpt_material {
            get;
            private set;
        }

        public float sculpt_height {
            get;
            private set;
        }

        public float sculpt_width {
            get;
            private set;
        }

        public override string derived_stringrep() {
            string sculpt_string = "Sculpture:\n";
            sculpt_string += "\tMaterial:   " + sculpt_material + "\n";
            sculpt_string += "\tDimensions: ( width: " + sculpt_width + "m, height: " + sculpt_height + "m )\n";
            return sculpt_string;
        }

    }

}