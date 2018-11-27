using System;
using System.Collections;

namespace SimpleProgram.Lib
{
    public class DateTimeExtension
    {
        public static IEnumerable EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
            {
                yield return day;
            }
        }
    }
}