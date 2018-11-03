using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace SimpleProgram.Lib.Archives
{
    public class Heatmap
    {
        public List<string> X { get; } = new List<string>();
        public List<DateTime> Y { get; } = new List<DateTime>();
        public List<List<double?>> Z { get; } = new List<List<double?>>();

        public List<string> YToString => Y.Select(t => t.ToString("yyyy-MM-dd HH:mm:ss")).ToList();

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public void AddYZ(DateTime dt, List<double?> values)
        {
            Y.Add(dt);
            Z.Add(values);
        }

        public void AddX(string x)
        {
            X.Add(x);
        }

        public override string ToString()
        {
            var str = new StringBuilder();
            str.AppendLine("x:");
            foreach (var time in Y) str.AppendLine(time.ToString("yyyy-MM-dd HH:mm:ss"));
            str.AppendLine("-----------");
            str.AppendLine("z:");
            foreach (var values in Z)
            {
                foreach (var d in values) str.Append($"{d:f1} \t");

                str.AppendLine("----");
            }

            return str.ToString();
        }
    }
}