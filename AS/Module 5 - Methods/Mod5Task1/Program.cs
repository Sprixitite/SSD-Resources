using System;

namespace Mod5Task1
{
    class Program
    {

        static T AskQuestion<T>(string question)
        {

            while (true)
            {

                Console.Write(question);
                try
                {
                    return (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                }
                catch
                {
                    Console.WriteLine("\n\x1b[41mThe provided \"" + typeof(T).Name + "\" was not valid, please try again!\x1b[0m");
                }

            }

        }

        static void Main(string[] args) {

            float[] numbers = new float[3];
            for (int i=0; i<3; i++) {
                numbers[i] = AskQuestion<float>("Enter number " + (i+1) + ": ");
            }

            float avg = 0.0f;
            float sum = 0.0f;

            // Using unsafe is totally unnecessary for this question
            // Just doing it for fun
            unsafe {
                get_avg_and_sum(numbers, &avg, &sum);
            }

            Console.WriteLine("\nAverage: " + avg + "\nSum: " + sum);

        }

        static unsafe void get_avg_and_sum<T>(T[] to_avg, T* avg, T* sum)
            where T : unmanaged
        {
            // Method being generic is just syntax sugar
            // We actually cast to dynamic so we can add/divide
            dynamic tmp_sum = 0;
            foreach (T num in to_avg) {
                tmp_sum += num;
            }
            *avg = tmp_sum / to_avg.Length;
            *sum = tmp_sum;
        }

    }
}
