using System;

namespace SimpleProgram.Lib.Archives
{
    public class TimeValue
    {
        public double? Value { get; }
        public DateTime Time { get; }

        public TimeValue(double? value, DateTime time)
        {
            Value = value;
            Time = time;
        }

        public override string ToString()
        {
            return $"{Time.ToString()} \t{Value}";
        }
    }
}