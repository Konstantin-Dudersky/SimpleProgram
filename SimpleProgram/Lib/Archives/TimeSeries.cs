using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleProgram.Lib.Archives
{
    public class TimeSeries : IEnumerable<object>
    {
        public List<TimeValue> TimeValues { get; } = new List<TimeValue>();

        public List<double?> Values => TimeValues.Select(x => x.Value).ToList();
        public List<DateTime> Times => TimeValues.Select(x => x.Time).ToList();
        public int Count => TimeValues.Count;

        public TimeValue this[int index]
        {
            get => TimeValues[index];
            set => TimeValues[index] = value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<object> GetEnumerator()
        {
            return TimeValues.GetEnumerator();
        }

        public void Add(TimeValue timeValue)
        {
            TimeValues.Add(timeValue);
        }

        public void Add(DateTime time, double? value)
        {
            Add(new TimeValue(value, time));
        }

        public void AddRange(IEnumerable<TimeValue> timeValues)
        {
            TimeValues.AddRange(timeValues);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var tv in TimeValues) builder.AppendLine(tv.ToString());
            return builder.ToString();
        }
    }

    public static class TimeSeriesExtension
    {
        public static TimeSeries IncreaseCountByPeriod(this TimeSeries ts, ByPeriod period)
        {
            if (ts.TimeValues.Count == 0)
                return new TimeSeries();

            var newTs = new TimeSeries();

            var val = from tsTemp in ts.TimeValues
                group tsTemp by new DateTime(
                    period >= ByPeriod.Year ? tsTemp.Time.Year : 0,
                    period >= ByPeriod.Month ? tsTemp.Time.Month : 1,
                    period >= ByPeriod.Day ? tsTemp.Time.Day : 1,
                    period >= ByPeriod.Hour ? tsTemp.Time.Hour : 0,
                    period >= ByPeriod.Minute ? tsTemp.Time.Minute : 0,
                    period >= ByPeriod.Second ? tsTemp.Time.Second : 0)
                into g
                select new TimeValue(g.FirstOrDefault()?.Value, g.Key);

            newTs.AddRange(val.ToList());

            for (var i = 1; i < newTs.Count; i++)
                if (newTs[i - 1].Value != null && newTs[i].Value != null)
                    newTs[i - 1].Value = newTs[i].Value - newTs[i - 1].Value;

            newTs[newTs.Count - 1].Value =
                ts[ts.Count - 1].Value - newTs[newTs.Count - 1].Value;

            return newTs;
        }
    }

    public enum ByPeriod
    {
        Year,
        Month,
        Day,
        Hour,
        Minute,
        Second
    }
}