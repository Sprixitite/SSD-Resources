using System;

namespace Mod4Task2 {
    class Program {
        static void Main(string[] args) {

            int array_size = 10;

            int[] my_funky_int_array_that_is_stored_on_the_stack_and_not_the_heap = new int[array_size];

            for (int i=0; i<array_size; i++) {
                my_funky_int_array_that_is_stored_on_the_stack_and_not_the_heap[i] = i;
            }

            for (int i=0; i<my_funky_int_array_that_is_stored_on_the_stack_and_not_the_heap.Length; i++) {
                Console.WriteLine("The element at position \"" + i + "\" = \"" + my_funky_int_array_that_is_stored_on_the_stack_and_not_the_heap[i] + "\"");
            }

        }
    }
}
