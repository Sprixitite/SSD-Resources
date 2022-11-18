using System;

namespace Mod4Task8
{
    class Program
    {
        static void Main(string[] args) {

            int[,] my_multi_dimensional_array = new int[3, 4] {
                {
                    1, 2, 3, 4
                },
                {
                    1, 1, 1, 1
                },
                {
                    2, 2, 2, 2
                }
            };

            int rows = my_multi_dimensional_array.GetLength(0);
            int columns = my_multi_dimensional_array.GetLength(1);
            for (int i = 0; i < rows; i++) { 
                for (int j = 0; j < columns; j++) {
                    if (i < rows-1 || j < columns-1) {
                        Console.Write(my_multi_dimensional_array[i, j] + ", ");
                    } else {
                        Console.Write(my_multi_dimensional_array[i, j]);
                    }
                    
                }
                Console.Write("\n");
                
            }

        }
    }
}
