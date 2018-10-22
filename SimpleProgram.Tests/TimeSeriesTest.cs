using System;
using SimpleProgram.Lib.Archives;
using Xunit;

namespace SimpleProgram.Tests
{
    public class TimeSeriesTest
    {
        [Fact]
        public void Test1()
        {
            var input = new TimeSeries();
            input.Add(new DateTime(2018, 1, 1, 0, 0, 0), 1);
            input.Add(new DateTime(2018, 1, 2, 0, 0, 0), 2);
            input.Add(new DateTime(2018, 1, 3, 0, 0, 0), 3);
            
            var output = input.IncreaseCountByPeriod(ByPeriod.Day);
            
            var right = new TimeSeries();
            right.Add(new DateTime(2018, 1, 1, 0, 0, 0), 1);
            right.Add(new DateTime(2018, 1, 2, 0, 0, 0), 1);
            right.Add(new DateTime(2018, 1, 3, 0, 0, 0), 0);
            
            Assert.Equal(right.TimeValues[0], output.TimeValues[0]);
        }
    }
}