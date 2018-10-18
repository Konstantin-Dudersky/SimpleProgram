using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;

namespace SimpleProgram.Lib.Archives
{
    public class TimeSeries
    {
        public List<TimeValue> TimeValues { get; } = new List<TimeValue>();

        public List<double> Values => TimeValues.Select(x => (double)x.Value).ToList();
        public List<DateTime> Times => TimeValues.Select(x => x.Time).ToList();

        public void Add(TimeValue timeValue)
        {
            TimeValues.Add(timeValue);
        }

        public void AddRange(IEnumerable<TimeValue> timeValues)
        {
            TimeValues.AddRange(timeValues);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var tv in TimeValues)
            {
                builder.AppendLine(tv.ToString());
            }
            return builder.ToString();
        }
    }
}
