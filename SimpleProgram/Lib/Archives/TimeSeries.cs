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

        public void RemoveAt(int index)
        {
            TimeValues.RemoveAt(index);
        }

        public void RemoveLast()
        {
            TimeValues.RemoveAt(Count - 1);
        }

        public List<string> TimesToPlotly()
        {
            return Times.Select(t => t.ToString("yyyy-MM-dd HH:mm:ss")).ToList();
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var tv in TimeValues) builder.AppendLine(tv.ToString());
            return builder.ToString();
        }

        #region implements IEnumerable<object>

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<object> GetEnumerator()
        {
            return TimeValues.GetEnumerator();
        }

        #endregion
    }

    public static class TimeSeriesExtension
    {
        public static TimeSeries IncreaseCountByPeriod(this TimeSeries ts, int seconds)
        {
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
            var newTs = new TimeSeries();

            foreach (var d in dict)
                newTs.Add(d.Key, d.Value.FirstOrDefault());


            for (var i = 1; i < newTs.Count; i++)
                if (newTs[i].Value == null)
                    newTs[i - 1].Value = null;
                else if (newTs[i - 1].Value != null)
                    newTs[i - 1].Value = newTs[i].Value - newTs[i - 1].Value;
            newTs.RemoveLast();

            return newTs;
        }

        public static Heatmap ToHeatmap(this TimeSeries ts, ByPeriod xPeriod = ByPeriod.Day)
        {
            var heatmap = new Heatmap();

            if (ts.Times.Count < 2)
            {
                Console.WriteLine("Кол-во элементов для heatmap меньше 2");
                return new Heatmap();
            }

            var tshm = from t in ts.TimeValues
                group t by new DateTime(
                    t.Time.Year,
                    xPeriod >= ByPeriod.Month ? t.Time.Month : 1,
                    xPeriod >= ByPeriod.Day ? t.Time.Day : 1,
                    xPeriod >= ByPeriod.Hour ? t.Time.Hour : 0,
                    0,
                    0)
                into g
                select g;

            foreach (var t in tshm)
                heatmap.AddYZ(t.Key, t.Select(n => n.Value).ToList());

            // формируем ось х
            var begin = ts[0].Time;
            var end = begin;
            var format = "";

            switch (xPeriod)
            {
                case ByPeriod.Year:
                    break;

                case ByPeriod.Month:
                    end = begin.AddMonths(1);
                    format = "dd";
                    break;

                case ByPeriod.Day:
                    end = begin.AddDays(1);
                    format = "HH:mm";
                    break;

                case ByPeriod.Hour:
                    end = begin.AddHours(1);
                    format = "mm:ss";
                    break;

                case ByPeriod.Minute:
                    end = begin.AddMinutes(1);
                    format = "ss";
                    break;

                case ByPeriod.Second:
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            var x = new List<DateTime>();
            var seconds = (int) ts[1].Time.Subtract(ts[0].Time).TotalSeconds;

            while (begin < end)
            {
                x.Add(begin);
                begin = begin.AddSeconds(seconds);
            }

            foreach (var time in x)
                heatmap.AddX(time.ToString(format));

            return heatmap;
        }

        private static Dictionary<DateTime, List<double?>> GetDateTimeRange(DateTime begin, DateTime end,
            int secondsAdd)
        {
            var list = new Dictionary<DateTime, List<double?>>();
            var beginDt = begin;
            var endDt = end;

            switch (GetPeriod(secondsAdd))
            {
                case ByPeriod.Year:
                    break;

                case ByPeriod.Month:
                    break;

                case ByPeriod.Day:
                    beginDt = new DateTime(beginDt.Year, beginDt.Month, 1, 0, 0, 0);
                    endDt = new DateTime(endDt.Year, endDt.Month, DateTime.DaysInMonth(endDt.Year, endDt.Month),
                        0, 0, 0);
                    break;

                case ByPeriod.Hour:
                case ByPeriod.Minute:
                    beginDt = new DateTime(beginDt.Year, beginDt.Month, beginDt.Day, 0, 0, 0);
                    endDt = new DateTime(endDt.Year, endDt.Month, endDt.Day, 23, 0, 0);
                    break;

                case ByPeriod.Second:
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }


            while (beginDt <= endDt)
            {
                list[beginDt] = new List<double?>();
                beginDt = beginDt.AddSeconds(secondsAdd);
            }

            list[beginDt] = new List<double?>(); // добавляем еще один в конец словаря

            return list;
        }

        private static ByPeriod GetPeriod(int seconds)
        {
            const int secInMinute = 60;
            const int secInHour = 60 * secInMinute;
            const int secInDay = 24 * secInHour;

            // по дням
            if (seconds >= secInDay && seconds < secInDay * 28)
                return ByPeriod.Day;
            // по часам
            if (seconds >= secInHour && seconds < secInDay)
                return ByPeriod.Hour;
            // по минутам
            if (seconds >= secInMinute && seconds < secInHour)
                return ByPeriod.Minute;

            throw new Exception("Указано неправильное значение периода времени");
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