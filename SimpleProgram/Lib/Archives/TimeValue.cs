using System;

namespace SimpleProgram.Lib.Archives
{
    public class TimeValue : IComparable
    {
        public double? Value { get; set; }
        public DateTime Time { get; set; }

        public TimeValue(double? value, DateTime time)
        {
            Value = value;
            Time = time;
        }

        public override string ToString()
        {
            return $"{Time.ToString()} \t{Value}";
        }

        public int CompareTo(object obj)
        {
        }
    }
}