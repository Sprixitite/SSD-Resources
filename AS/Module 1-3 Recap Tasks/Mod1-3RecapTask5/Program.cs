using System;

namespace Mod1_3BonusTask3 {

    class Program {

        enum ShedSize {
            STANDARD,
            DELUXE
        }

        enum ShedStyle {
            SQUARE,
            RECTANGLE,
            IGLOO,
            CASTLE
        }

        static T AskQuestion<T>(string question)
            where T : struct, Enum
        {

            while (true) {

                Console.Write(question);
                if (Enum.TryParse<T>(Console.ReadLine(), true, out T result)) {
                    return result;
                } else {
                    Console.WriteLine("\n\x1b[41mThe provided \"" + typeof(T).Name + "\" was not valid, please try again!\x1b[0m\n");
                }

            }

        }

        static float get_cost(ShedSize size, ShedStyle style, out float before_vat) {

            float multiplier = 1.0f;

            if (size == ShedSize.DELUXE) multiplier += .5f;

            before_vat = 0.0f;
            switch (style) {

                case ShedStyle.SQUARE:
                    before_vat = 120.00f;
                    break;
                
                case ShedStyle.RECTANGLE:
                    before_vat = 139.99f;
                    break;

                case ShedStyle.IGLOO:
                    before_vat = 215.00f;
                    break;

                case ShedStyle.CASTLE:
                    before_vat = 349.99f;
                    break;

            }
            before_vat*=multiplier;

            return before_vat * 1.2f;

        }

        static void Main(string[] args) {

            ShedSize size = AskQuestion<ShedSize>(   "Select shed size  (\x1b[32mStandard\x1b[0m/\x1b[33mDeluxe\x1b[0m): ");
            ShedStyle style = AskQuestion<ShedStyle>("Select shed style (\x1b[32mSquare\x1b[0m/\x1b[33mRectangle\x1b[0m/\x1b[34mIgloo\x1b[0m/\x1b[35mCastle\x1b[0m): ");

            float final_cost = get_cost(size, style, out float before_vat);

            Console.WriteLine("\nCost before VAT: " + before_vat.ToString("C"));
            Console.WriteLine("Cost after VAT: " + final_cost.ToString("C"));

        }

    }
}
