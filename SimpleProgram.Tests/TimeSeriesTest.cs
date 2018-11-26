using System;
using SimpleProgram.Lib.Archives;
using Xunit;

namespace SimpleProgram.Tests
{
    public class TimeSeriesTest
    {

        [Fact]
        public void SortTest()
        {
            var ts1 = new TimeSeries 
            {
                {new DateTime(2000, 1, 1, 0, 1, 1), 3}, 
                {new DateTime(2000, 1, 1, 0, 0, 0), 1},
                {new DateTime(2000, 1, 1, 0, 0, 1), 2}
            };

            var ts2 = new TimeSeries
            {
                {new DateTime(2000, 1, 1, 0, 0, 0), 1}, 
                {new DateTime(2000, 1, 1, 0, 0, 1), 2},
                {new DateTime(2000, 1, 1, 0, 1, 1), 3}
            };

            Assert.Equal(ts2, ts1);
        }

        [Fact]
        public void OperatorTest()
        {
            var ts1 = new TimeSeries
            {
                {new DateTime(2000, 1, 1, 0, 0, 0), 1},
                {new DateTime(2000, 1, 1, 1, 0, 0), 2},
                {new DateTime(2000, 1, 1, 2, 0, 0), 3},
                {new DateTime(2000, 1, 1, 3, 0, 0), 4},
                {new DateTime(2000, 1, 2, 0, 0, 0), 5},
            };
            
            var ts2 = new TimeSeries
            {
                {new DateTime(2000, 1, 1, 0, 0, 0), 3},
                {new DateTime(2000, 1, 1, 1, 0, 0), 2},
                {new DateTime(2000, 1, 1, 2, 0, 0), 1},
                {new DateTime(2000, 1, 1, 4, 0, 0), 0},
                {new DateTime(2000, 1, 2, 0, 0, 0), 0},
            };

            var tsPlus = new TimeSeries
            {
                {new DateTime(2000, 1, 1, 0, 0, 0), 4},
                {new DateTime(2000, 1, 1, 1, 0, 0), 4},
                {new DateTime(2000, 1, 1, 2, 0, 0), 4},
                {new DateTime(2000, 1, 1, 3, 0, 0), null},
                {new DateTime(2000, 1, 1, 4, 0, 0), null},
                {new DateTime(2000, 1, 2, 0, 0, 0), 5},

            };
            
            var tsMinus = new TimeSeries
            {
                {new DateTime(2000, 1, 1, 0, 0, 0), -2},
                {new DateTime(2000, 1, 1, 1, 0, 0), 0},
                {new DateTime(2000, 1, 1, 2, 0, 0), 2},
                {new DateTime(2000, 1, 1, 3, 0, 0), null},
                {new DateTime(2000, 1, 1, 4, 0, 0), null},
                {new DateTime(2000, 1, 2, 0, 0, 0), 5},
            };

            var tsMultiplication = new TimeSeries
            {
                {new DateTime(2000, 1, 1, 0, 0, 0), 3},
                {new DateTime(2000, 1, 1, 1, 0, 0), 4},
                {new DateTime(2000, 1, 1, 2, 0, 0), 3},
                {new DateTime(2000, 1, 1, 3, 0, 0), null},
                {new DateTime(2000, 1, 1, 4, 0, 0), null},
                {new DateTime(2000, 1, 2, 0, 0, 0), 0},
            };
            
            var tsDivision = new TimeSeries
            {
                {new DateTime(2000, 1, 1, 0, 0, 0), 1/3.0},
                {new DateTime(2000, 1, 1, 1, 0, 0), 1},
                {new DateTime(2000, 1, 1, 2, 0, 0), 3},
                {new DateTime(2000, 1, 1, 3, 0, 0), null},
                {new DateTime(2000, 1, 1, 4, 0, 0), null},
                {new DateTime(2000, 1, 2, 0, 0, 0), null},
            };
            var tsDivisionTest = ts1 / ts2;
            
            Assert.Equal(tsPlus, ts1 + ts2);
            Assert.Equal(tsMinus, ts1 - ts2);
            Assert.Equal(tsMultiplication, ts1 * ts2);
            Assert.Equal(tsDivision, tsDivisionTest);
        }

        [Fact]
        public void SimplifyTest()
        {
            var ts = new TimeSeries
            {
                {new DateTime(1000, 1, 1, 0, 0, 0), 1}
            };
            
            // None
            Assert.Equal(ts, ts.Simplify(SimplifyType.None, 60));
            
            // Increment
            var newTs = ts.Simplify(SimplifyType.Increment, 3600);
            Assert.Equal(ts, newTs);
        }

        [Fact]
        public void RemoveTest()
        {
            var ts = new TimeSeries
            {
                {new DateTime(1000, 1, 1, 0, 0, 0), 1},
                {new DateTime(1000, 1, 2, 0, 0, 0), 1},
            };

            ts.Remove(new DateTime(1000, 1, 1, 0, 0, 0));
            var newTs = new TimeSeries
            {
                {new DateTime(1000, 1, 2, 0, 0, 0), 1},
            };

            Assert.Equal(newTs, ts);
        }

        [Fact]
        public void TrimTest()
        {
            var ts = new TimeSeries
            {
                {new DateTime(1000, 1, 1, 0, 0, 0), null},
                {new DateTime(1000, 1, 2, 0, 0, 0), null},
                {new DateTime(1000, 1, 3, 0, 0, 0), 1},
                {new DateTime(1000, 1, 4, 0, 0, 0), null},
                {new DateTime(1000, 1, 5, 0, 0, 0), 1},
                {new DateTime(1000, 1, 6, 0, 0, 0), 1},
                {new DateTime(1000, 1, 7, 0, 0, 0), null},
            };

            ts = ts.Trim();

            var newTs = new TimeSeries
            {
                {new DateTime(1000, 1, 3, 0, 0, 0), 1},
                {new DateTime(1000, 1, 4, 0, 0, 0), null},
                {new DateTime(1000, 1, 5, 0, 0, 0), 1},
                {new DateTime(1000, 1, 6, 0, 0, 0), 1},
            };
            
            Assert.Equal(newTs, ts);
        }
    }
}