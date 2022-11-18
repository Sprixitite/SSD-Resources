using System;

namespace InClassMultiDimArraysTask
{
    class Program
    {

        enum Days { 
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }

        static T AskQuestion<T>(string question) {

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

            float[,] temp_readings = new float[7, 2];

            int i = 0;
            int row = 0;
            int column = 0;
            foreach (float temp in temp_readings) {
                row = i / temp_readings.GetLength(1);
                column = i % temp_readings.GetLength(1);
                temp_readings[row, column] = AskQuestion<float>("Enter temperature reading \"" + (column + 1) + "\" for " + ((Days)row).ToString() + ": ");

                i++;
            }

            Console.WriteLine("Week average: " + week_average(temp_readings));
            Console.WriteLine("Highest temperature: " + highest_temp(temp_readings));
            Console.WriteLine("Lowest temperature: " + lowest_temp(temp_readings));
            Console.WriteLine("Day average: " + day_avg(temp_readings, 0));
            Console.WriteLine("Reading average: " + reading_avg(temp_readings, 1));

        }

        static float week_average(float[,] temps) {

            float avg = 0.0f;
            foreach (float temp in temps) {
                avg += temp;
            }

            return avg/temps.Length;
        }

        static float highest_temp(float[,] temps) {

            float highest = 0.0f;
            foreach (float temp in temps) {
                highest = Math.Max(highest, temp);
            }

            return highest;
        }

        static float lowest_temp(float[,] temps) {

            float lowest = 0.0f;
            foreach (float temp in temps) {
                lowest = Math.Min(lowest, temp);
            }

            return lowest;
        }

        static float day_avg(float[,] temps, int day) {

            float avg = 0.0f;
            for (int i = 0; i < temps.GetLength(1); i++) {
                avg += temps[day, i];
            }

            return avg/temps.GetLength(1);
        }

        static float reading_avg(float[,] temps, int reading) {

            float avg = 0.0f;
            for (int i = 0; i < temps.GetLength(0); i++) {
                avg += temps[i, reading];
            }

            return avg/temps.GetLength(0);
        }

    }
}
