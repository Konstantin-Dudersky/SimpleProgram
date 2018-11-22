using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleProgram.Lib.Archives
{
    public class Scatter
    {
        public List<double> X { get; }
        public List<double> Y { get; }

        public Scatter(TimeSeries tsX, TimeSeries tsY)
        {
            X = new List<double>();
            Y = new List<double>();
            
            var times = new TimeSeries();
            times.AddTimes(tsX.Times);
            times.AddTimes(tsY.Times);

            foreach (var time in times.Times)
            {
                if (tsX[time] == null || tsY[time] == null) continue;
                
                X.Add(tsX[time].Value);
                Y.Add(tsY[time].Value);
            }
        }

        public string ToCsv(string separator = ";")
        {
            var str = new StringBuilder();

            for (var i = 0; i < X.Count; i++)
            {
                str.AppendLine($"{X[i]}{separator}{Y[i]}");
            }

            return str.ToString();
        }
    }
}