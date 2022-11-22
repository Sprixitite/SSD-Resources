using System;

namespace Mod8Task1 {

    public abstract class Art {

        public Art(string artist, uint ID, string name, float price) {
            artwork_ID = ID;
            artwork_name = name;
            artwork_price = price;
            artwork_artist = artist;
        }

        public uint artwork_ID {
            get;
            protected set;
        }

        public string artwork_name {
            get;
            protected set;
        }

        public float artwork_price {
            get;
            protected set;
        }

        public string artwork_artist {
            get;
            protected set;
        }

        public override string ToString() {
            string base_str = "\n";
            base_str += "\tArtist: " + artwork_artist + "\n";
            base_str += "\tID:     " + artwork_ID + "\n";
            base_str += "\tName:   " + artwork_name + "\n";
            base_str += "\tPrice:  " + artwork_price + "\n";
            return this.derived_stringrep() + base_str;
        }

        public abstract string derived_stringrep();

    }

}