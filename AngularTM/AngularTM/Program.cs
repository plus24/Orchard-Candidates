using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularTM
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter time in hh:mm:ss format or enter for current time (Escape to exit):");
            do
            {
                var data = Console.ReadLine();
                TimeSpan givenTime;

                if (!TimeSpan.TryParseExact(data, "hh\\:mm\\:ss", System.Globalization.CultureInfo.InvariantCulture, out givenTime))
                {
                    givenTime = DateTime.Now.TimeOfDay;
                    Console.WriteLine(givenTime.ToString("hh\\:mm\\:ss"));
                }
                double angleDiff = GetAngleBetweenClockHands(givenTime);
                Console.WriteLine("{0} degrees", angleDiff);

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        private static double GetAngleBetweenClockHands(TimeSpan givenTime)
        {
            double hoursDeg = (givenTime.Hours * 30) + ((double)(givenTime.Minutes * 30) / 60);
            double minutesDeg = givenTime.Minutes * 6;
            double angleDiff = Math.Abs(hoursDeg - minutesDeg);
            if (angleDiff > 180) angleDiff = 360 - angleDiff;
            return angleDiff;
        }
    }
}
