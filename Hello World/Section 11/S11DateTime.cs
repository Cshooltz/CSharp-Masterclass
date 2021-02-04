using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMasterClass
{
    class S11DateTime
    {
        static public void Main()
        {
            DateTime dateTime = new DateTime(2018,5,31);

            Console.WriteLine($"My birthday is {dateTime}");

            // Write today on screen
            Console.WriteLine("Today: " + DateTime.Today);
            // Write current time on screen.
            Console.WriteLine("Current Time: " + DateTime.Now);

            DateTime tomorrow = GetTomorrow();
            Console.WriteLine("Tomorrow will be the " + tomorrow);

            Console.WriteLine("The current day of the week is: " + DateTime.Today.DayOfWeek);
            Console.WriteLine("First day of 1999: " + GetFirstDayOfYear(1999).DayOfWeek);

            int days = DateTime.DaysInMonth(2000, 2);
            Console.WriteLine("Days in Feb 2000: " + days);
            days = DateTime.DaysInMonth(2001, 2);
            Console.WriteLine("Days in Feb 2001: " + days);
            days = DateTime.DaysInMonth(2004, 2);
            Console.WriteLine("Days in Feb 2004: " + days);

            DateTime now = DateTime.Now;
            Console.WriteLine("Minute: " + now.Minute);

            // display the time in this structure x o'clock y minutes and z seconds
            Console.WriteLine($"The time is {now.Hour} o'clock {now.Minute} minutes and {now.Second} seconds");

            Console.WriteLine("Write a date in this format: yyyy-mm-dd");
            string input = Console.ReadLine();
            if (DateTime.TryParse(input, out dateTime))
            {
                Console.WriteLine(dateTime);
                TimeSpan daysPassed = now.Subtract(dateTime);
                Console.WriteLine("Days passed since: " + daysPassed.Days);
            }
            else Console.WriteLine("Wrong input.");


            return;
        }

        static private DateTime GetTomorrow()
        {
            return DateTime.Today.AddDays(1);
        }

        static private DateTime GetFirstDayOfYear(int year)
        {
            return new DateTime(year, 1, 1);
        }
    }
}
