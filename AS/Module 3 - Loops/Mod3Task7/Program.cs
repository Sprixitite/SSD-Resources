using System;

namespace Mod3Task1 {
    class Program {
        static void Main(string[] args) {
            
            for (int i=1; i<=100; i++) {

                if (((i % 4) == 0) && !((i % 5) == 0)) {
                    Console.WriteLine(i);
                }

            }

        }
    }
}
