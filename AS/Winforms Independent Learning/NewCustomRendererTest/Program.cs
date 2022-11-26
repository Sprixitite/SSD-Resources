using System;

namespace SprixiumGraphics {

    public static class Program {



        public static void Main(string[] args) {
            Console.WriteLine(((uint)'A').ToString() + ((uint)'a').ToString());
            Vector v = new Vector();
            v.components = new float[5] { 0, 1, 2, 3, 4 };
            Console.WriteLine(v['x']);
            Console.WriteLine(v['y']);
            Console.WriteLine(v['z']);
            Console.WriteLine(v['w']);
            Console.WriteLine(v['a']);
        }

    }
    
}