using System;

namespace SprixiumGraphics {

    public abstract class Vector {

        private protected float[] components;

        public float this[char component] {
            get {
                uint idx;
                switch (Char.ToLower(component)) {
                    case 'x':
                        idx=0;
                        break;
                    case 'y':
                        idx=1;
                        break;
                    case 'z':
                        idx=2;
                        break;
                    case 'w':
                        idx=3;
                        break;
                    default:
                        idx = ((uint)component)-93;
                        break;
                }
                return components[idx];
            }
        }

        public float magnitude() {
            float total = 0.0f;
            foreach (float f in components) {
                total += MathF.Pow(f, 2.0f);
            }
            return total/components.Length;
        }

        public Vector unit() {
            return self/magnitude();
        }

    }

}