using System;

namespace Mod3Task9
{
    class Program
    {
        static void Main(string[] args) {
            Console.WriteLine(ValidateBookCode("123456789X", out int sum));
            Console.WriteLine(sum);
        }
                
        static bool ValidateBookCode(string code, out int sum) {

            sum = 0;
            for (int i=0;i<code.Length;i++) {
                string current = code.Substring(i, 1);

                int current_as_num = 0;

                if (i == code.Length-1 && current.ToLower() == "x") {
                    current_as_num = 10;
                } else {
                    current_as_num = int.Parse(current);
                }

                sum += (current_as_num*(10-i));

            }

            return (sum % 11) == 0;

        }
    }
}
