using System;

namespace Mod8Task1 {

    // Used this because I wanted to keep the abstract base class
    // This is much more verbose/explicit anyways
    public class AnonymousArtwork : Art {

        public AnonymousArtwork(string artist, uint ID, string name, float price) : base(artist, ID, name, price) {}

        public override string derived_stringrep() {
            return "Art:";
        }

    }

}