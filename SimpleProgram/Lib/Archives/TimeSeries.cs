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
            Add(new TimeValue(time, value));
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

        public void RemoveAt(int index)
        {
            TimeValues.RemoveAt(index);
        }

        public void RemoveLast()
        {
            TimeValues.RemoveAt(Count - 1);
        }
    }

    public static class TimeSeriesExtension
    {
        public static TimeSeries IncreaseCountByPeriod(this TimeSeries ts, int seconds)
        {
//            if (ts.TimeValues.Count == 0)
//                return new TimeSeries();
//
//            var newTs = new TimeSeries();
//
//            var val = from tsTemp in ts.TimeValues
//                group tsTemp by new DateTime(
//                    period >= ByPeriod.Year ? tsTemp.Time.Year : 0,
//                    period >= ByPeriod.Month ? tsTemp.Time.Month : 1,
//                    period >= ByPeriod.Day ? tsTemp.Time.Day : 1,
//                    period >= ByPeriod.Hour ? tsTemp.Time.Hour : 0,
//                    period >= ByPeriod.Minute ? tsTemp.Time.Minute : 0,
//                    period >= ByPeriod.Second ? tsTemp.Time.Second : 0)
//                into g
//                select new TimeValue(g.Key, g.FirstOrDefault()?.Value);
//
//            newTs.AddRange(val.ToList());
//
//            for (var i = 1; i < newTs.Count; i++)
//                if (newTs[i - 1].Value != null && newTs[i].Value != null)
//                    newTs[i - 1].Value = newTs[i].Value - newTs[i - 1].Value;
//
//            newTs[newTs.Count - 1].Value =
//                ts[ts.Count - 1].Value - newTs[newTs.Count - 1].Value;


            // ---------------------------------------------------------
            var dict = GetDateTimeRange(ts.TimeValues[0].Time, ts.TimeValues[ts.Count - 1].Time, seconds);

            var j = 0;
            var endTime = dict.ElementAt(0).Key;
            foreach (var timeValue in ts.TimeValues)
            {
                while (timeValue.Time > endTime)
                    endTime = dict.ElementAt(++j).Key;
                dict.ElementAt(j - 1).Value.Add(timeValue.Value);
            }
            
            // начальные значения
            var newTs1 = new TimeSeries();

            foreach (var d in dict)
            {
                newTs1.Add(d.Key, d.Value.FirstOrDefault());
            }
            newTs1.RemoveLast();
            
            for (var i = 1; i < newTs1.Count; i++)
                if (newTs1[i - 1].Value != null && newTs1[i].Value != null)
                    newTs1[i - 1].Value = newTs1[i].Value - newTs1[i - 1].Value;

            newTs1[newTs1.Count - 1].Value =
                ts[ts.Count - 1].Value - newTs1[newTs1.Count - 1].Value;

            return newTs1;
        }

        private static Dictionary<DateTime, List<double?>> GetDateTimeRange(DateTime begin, DateTime end,
            int secondsAdd)
        {
            var list = new Dictionary<DateTime, List<double?>>();
            var tempDt = begin;

            const int secInMinute = 60;
            const int secInHour = 60 * secInMinute;
            const int secInDay = 24 * secInHour;

            // по дням
            if (secondsAdd >= secInDay && secondsAdd < 60 * 60 * 24 * 28)
            {
                var newDay = tempDt.Day * secInDay / secondsAdd * secondsAdd / secInDay;
                newDay = Math.Max(newDay, 1);
                tempDt = new DateTime(tempDt.Year, tempDt.Month, newDay, 0, 0, 0);
            }

            // по часам
            if (secondsAdd >= secInHour && secondsAdd < secInDay)
            {
                var newHour = tempDt.Hour * secInHour / secondsAdd * secondsAdd / secInHour;
                tempDt = new DateTime(tempDt.Year, tempDt.Month, tempDt.Day, newHour, 0, 0);
            }

            // по минутам
            if (secondsAdd >= secInMinute && secondsAdd < secInHour)
            {
                var newMinute = tempDt.Minute * secInMinute / secondsAdd * secondsAdd / secInMinute;
                tempDt = new DateTime(tempDt.Year, tempDt.Month, tempDt.Day, tempDt.Hour, newMinute, 0);
            }

            while (tempDt < end)
            {
                list[tempDt] = new List<double?>();
                tempDt = tempDt.AddSeconds(secondsAdd);
            }

            list[tempDt] = new List<double?>(); // добавляем еще один в конец словаря

            return list;
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