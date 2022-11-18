using System;

namespace TrackingTest2 {

    class Program {

        public static void Main(string[] args) {

            Console.WriteLine(binary_search(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}, 5));

        }

        public static bool binary_search(int[] sorted_nums, int search_item) {

            int last_pos = sorted_nums.Length-1;
            int differentiator = (int)MathF.Ceiling((sorted_nums.Length-1)/2.0f);
            int less_or_more = -1;
            bool found = false;
            bool unfindable = false;

            while (!found && !unfindable) {

                int new_pos;

                if (less_or_more == -1) {
                    new_pos = last_pos - differentiator;
                } else {
                    new_pos = last_pos + differentiator;
                }

                Console.WriteLine(sorted_nums[new_pos]);

                if (sorted_nums[new_pos] > search_item) {
                    less_or_more = -1;
                } else if (sorted_nums[new_pos] < search_item) {
                    less_or_more = 1;
                }

                if (sorted_nums[new_pos] == search_item) {
                    found = true;
                }  else if (new_pos == 0 && less_or_more == -1) {
                    Console.WriteLine("Not in list, too low");
                    unfindable = true;
                } else if (new_pos == sorted_nums.Length-1 && less_or_more == 1) {
                    Console.WriteLine("Not in list, too high");
                    unfindable = true;
                } else if (sorted_nums[new_pos] > search_item && sorted_nums[new_pos-1] < search_item) {
                    unfindable = true;
                } else if (sorted_nums[new_pos] < search_item && sorted_nums[new_pos+1] > search_item) {
                    unfindable = true;
                }

                differentiator = differentiator/2;
                if (differentiator == 0) differentiator = 1;
                last_pos = new_pos;

            }

            return found;

        }

    }

}