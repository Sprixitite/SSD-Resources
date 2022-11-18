using System;

namespace Mod1_3BonusTask3 {

    class Program {

        static void Main(string[] args) {

            for (int i = 0; i < 12; i++) {

                for (int j = 0; j < 7; j++) {
                    Console.Write((j+1) + " ");
                }

                Console.Write("\t\t" + (i+1) + "\n");

            }

        }

    }
}
