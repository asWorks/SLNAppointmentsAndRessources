using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class DateTimeServices
    {
        public static SortedList<int, DateTime> GetWeekForNumber(int number)
        {
            DateTime d = FromIso8601Weeknumber(number);
            SortedList<int, DateTime> buf = new SortedList<int, DateTime>();

            for (int i = 0; i < 5; i++)
            {
                buf.Add(i, d.AddDays(i));
            }



            return buf;
        }



        public static int GetWeekNumber()
        {
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return weekNum;
        }




        /// <summary>
        /// Converts a week number to a date.
        /// Note: Week 1 of a year may start in the previous year.
        /// ISO 8601 week 1 is the week that contains the first Thursday that year, so
        /// if December 28 is a Monday, December 31 is a Thursday,
        /// and week 1 starts January 4.
        /// If December 28 is a later day in the week, week 1 starts earlier.
        /// If December 28 is a Sunday, it is in the same week as Thursday January 1.
        /// </summary>
        public static DateTime FromIso8601Weeknumber(int weekNumber, int? year = null, DayOfWeek day = DayOfWeek.Monday)
        {
            var dec28 = new DateTime((year ?? DateTime.Today.Year) - 1, 12, 28);
            var monday = dec28.AddDays(7 * weekNumber - dec28.DayOfWeek.DayOffset());
            return monday.AddDays(day.DayOffset());
        }
    }

    }
