using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Zenith.Util
{
    public static class EventUtil
    {
        public static List<DateTime> GetDaysOfCurrentWeek()
        {
            DateTime startOfWeek = DateTime.Today.AddDays(
                ((int)(CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek + 1)) -
                (int)DateTime.Today.DayOfWeek);

            var result = Enumerable
              .Range(0, 7)
              .Select(i => startOfWeek
                 .AddDays(i)).ToList<DateTime>();
            return result;
            //var weekDays = result.Split(',');
            //List<DateTime> dates = new List<DateTime>();
            //foreach (var w in weekDays)
            //{
            //    dates.Add(Convert.ToDateTime(w));
            //}
            //return dates;
        }
        
    }
}