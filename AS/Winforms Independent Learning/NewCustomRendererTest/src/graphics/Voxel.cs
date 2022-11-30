using System;

namespace Engine.Graphics {

    public class Voxel {

        public Voxel(uint _ID, ) {
            
        }

        public uint ID {
            get;
            private set;
        }

        public enum IndependenceLevel {
            INDEPENDENT,
            FAMILY_DEPENDENT,
            DEPENDENT,
        }

        public IndependenceLevel independent {
            get;
            protected set;
        }

        public System.Drawing.Image tex {
            get;
            protected set;
        }

        public Func<Vector3, bool> collision_func {
            get;
            protected set;
        }

    }
    
}