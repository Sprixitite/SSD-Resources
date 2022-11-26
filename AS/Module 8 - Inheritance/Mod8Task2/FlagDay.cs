using System;
using System.Collections.Generic;

namespace Mod8Task2 {

    public class FlagDay : Event {

        private List<float> box_amts = new List<float>();

        public float this[uint i] {
            get => box_amts[i];
            set => box_amts[i] = value;
        }

    }

}