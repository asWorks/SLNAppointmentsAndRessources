using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class DivExtensions
    {
        /// <summary>
        /// Iso8601 weeks start on Monday. This returns 0 for Monday.
        /// </summary>
        public static int DayOffset(this DayOfWeek weekDay)
        {
            return ((int)weekDay + 6) % 7;
        }

        public static bool IstFeiertag(this DateTime date)
        {
            return date.DayOfWeek==DayOfWeek.Thursday;
        }

        /// <summary>
        /// Converts a date to a week number.
        /// ISO 8601 week 1 is the week that contains the first Thursday that year.
        /// </summary>
        public static int ToIso8601Weeknumber(this DateTime date)
        {
            var thursday = date.AddDays(3 - date.DayOfWeek.DayOffset());
            return (thursday.DayOfYear - 1) / 7 + 1;
        }

    }
}
