using System;
using SimpleProgram.Lib.Archives;
using Xunit;

namespace SimpleProgram.Tests
{
    public class TimeSeriesTest
    {
//        [Fact]
//        public void Test1()
//        {
//            var input = new TimeSeries
//            {
//                {new DateTime(2018, 1, 1, 0, 0, 0), 1},
//                {new DateTime(2018, 1, 2, 0, 0, 0), 2},
//                {new DateTime(2018, 1, 3, 0, 0, 0), 3}
//            };
//
//            var output = input.IncreaseCountByPeriod(ByPeriod.Day);
//
//            var right = new TimeSeries
//            {
//                {new DateTime(2018, 1, 1, 0, 0, 0), 1},
//                {new DateTime(2018, 1, 2, 0, 0, 0), 1},
//                {new DateTime(2018, 1, 3, 0, 0, 0), 0}
//            };
//
//            Assert.Equal(right.TimeValues, output.TimeValues);
//        }

        [Fact]
        public void SortTest()
        {
            var ts1 = new TimeSeries 
            {
                {new DateTime(2000, 1, 1, 0, 1, 1), 10}, 
                {new DateTime(2000, 1, 1, 0, 0, 0), 10},
                {new DateTime(2000, 1, 1, 0, 0, 1), 10}
            };

            var ts2 = new TimeSeries
            {
                {new DateTime(2000, 1, 1, 0, 0, 0), 11}, 
                {new DateTime(2000, 1, 1, 0, 0, 1), 11},
                {new DateTime(2000, 1, 1, 0, 1, 1), 11}
            };

            ts1.Sort();
            
            Assert.Equal(ts2, ts1);
        }
    }
}