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
        public DateTime Time { get; }

        public int CompareTo(object obj)
        {
            return Time.CompareTo(((TimeValue) obj).Time);
        }

        public override string ToString()
        {
            return $"{Time.ToString(CultureInfo.InvariantCulture)} \t{Value}";
        }
    }
}