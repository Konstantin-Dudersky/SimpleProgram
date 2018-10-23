using System;
using System.Globalization;

namespace SimpleProgram.Lib.Archives
{
    public class TimeValue : IComparable
    {
        public TimeValue(DateTime time, double? value)
        {
            Time = time;
            Value = value;
        }

        public double? Value { get; set; }
        public DateTime Time { get; set; }

        public int CompareTo(object obj)
        {
//            var compareTime = (Time.CompareTo(((TimeValue) obj).Time));
//            if (compareTime != 0)
//                return compareTime;
//            else
//            {
//                if (Value == null)
//            }
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{Time.ToString(CultureInfo.InvariantCulture)} \t{Value}";
        }
    }
}