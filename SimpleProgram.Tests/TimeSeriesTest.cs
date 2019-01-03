using System;
using SimpleProgram.Lib.Archives;
using Xunit;

namespace SimpleProgram.Tests
{
    public class TimeSeriesTest
    {
        private readonly TimeSeries _ts = new TimeSeries
        {
            {new DateTime(2000, 1, 1, 0, 0, 0), 0},
            {new DateTime(2000, 1, 1, 0, 1, 0), 1},
            {new DateTime(2000, 1, 1, 0, 2, 0), 2},
            {new DateTime(2000, 1, 1, 1, 0, 0), 0},
            {new DateTime(2000, 1, 1, 3, 0, 0), 15},
            {new DateTime(2000, 1, 1, 3, 1, 0), -1},
        };

        [Fact]
        public void PeriodInSecondsTest()
        {
            var ts = new TimeSeries
            {
                {new DateTime(2000, 1, 1, 0, 0, 0), 1},
                {new DateTime(2000, 1, 1, 1, 0, 0), 2},
                {new DateTime(2000, 1, 1, 1, 1, 0), 3},
            };

            var periodExp = 3600;
            var periodAct = ts.PeriodInSeconds;
            
            Assert.Equal(periodExp, periodAct);
        }

        [Fact]
        public void ValuesTest()
        {
            
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
                {new DateTime(2000, 1, 1, 3, 0, 0), 4},
                {new DateTime(2000, 1, 1, 4, 0, 0), 0},
                {new DateTime(2000, 1, 2, 0, 0, 0), 5},

            };
            
            var tsMinus = new TimeSeries
            {
                {new DateTime(2000, 1, 1, 0, 0, 0), -2},
                {new DateTime(2000, 1, 1, 1, 0, 0), 0},
                {new DateTime(2000, 1, 1, 2, 0, 0), 2},
                {new DateTime(2000, 1, 1, 3, 0, 0), 4},
                {new DateTime(2000, 1, 1, 4, 0, 0), 0},
                {new DateTime(2000, 1, 2, 0, 0, 0), 5},
            };

            var tsMultiplication = new TimeSeries
            {
                {new DateTime(2000, 1, 1, 0, 0, 0), 3},
                {new DateTime(2000, 1, 1, 1, 0, 0), 4},
                {new DateTime(2000, 1, 1, 2, 0, 0), 3},
                {new DateTime(2000, 1, 1, 3, 0, 0), 4},
                {new DateTime(2000, 1, 1, 4, 0, 0), 0},
                {new DateTime(2000, 1, 2, 0, 0, 0), 0},
            };
            
            var tsDivision = new TimeSeries
            {
                {new DateTime(2000, 1, 1, 0, 0, 0), 1/3.0},
                {new DateTime(2000, 1, 1, 1, 0, 0), 1},
                {new DateTime(2000, 1, 1, 2, 0, 0), 3},
                {new DateTime(2000, 1, 1, 3, 0, 0), 4},
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
            var newTs = ts.Simplify(SimplifyType.Increment, 3600).Trim();
            Assert.Equal(new TimeSeries(), newTs);
        }

        [Fact]
        public void SimplifyIncrementTest()
        {
            var ts = new TimeSeries
            {
                {new DateTime(2000, 1, 1, 0, 0, 0), 0},
                {new DateTime(2000, 1, 1, 1, 0, 0), 1},
                {new DateTime(2000, 1, 1, 2, 0, 0), 2},
                {new DateTime(2000, 1, 1, 4, 0, 0), 4},
                {new DateTime(2000, 1, 1, 5, 0, 0), 5},
                {new DateTime(2000, 1, 1, 5, 1, 0), 5.1},
            };

            var newTsExp = new TimeSeries
            {
                {new DateTime(2000, 1, 1, 0, 0, 0), 1},
                {new DateTime(2000, 1, 1, 1, 0, 0), 1},
                {new DateTime(2000, 1, 1, 2, 0, 0), null},
                {new DateTime(2000, 1, 1, 3, 0, 0), null},
                {new DateTime(2000, 1, 1, 4, 0, 0), 1},
            };
            
            var newTsAct = ts.Simplify(SimplifyType.Increment, 3600).Trim();
            
            Assert.Equal(newTsExp, newTsAct);
        }

        [Fact]
        public void SimplifyAverageTest()
        {
            var ts = new TimeSeries
            {
                {new DateTime(2000, 1, 1, 0, 0, 0), 0},
                {new DateTime(2000, 1, 1, 0, 1, 0), 1},
                {new DateTime(2000, 1, 1, 0, 2, 0), 2},
                {new DateTime(2000, 1, 1, 1, 0, 0), 0},
                {new DateTime(2000, 1, 1, 3, 0, 0), 15},
            };
            
            var newTsExp = new TimeSeries
            {
                {new DateTime(2000, 1, 1, 0, 0, 0), 1},
                {new DateTime(2000, 1, 1, 1, 0, 0), 0},
                {new DateTime(2000, 1, 1, 2, 0, 0), null},
                {new DateTime(2000, 1, 1, 3, 0, 0), 15},
            };
            
            var newTsAct = ts.Simplify(SimplifyType.Average, 3600).Trim();
            
            Assert.Equal(newTsExp, newTsAct);
        }

        [Fact]
        public void SimplifyMinTest()
        {
            var newTsExp = new TimeSeries
            {
                {new DateTime(2000, 1, 1, 0, 0, 0), 0},
                {new DateTime(2000, 1, 1, 1, 0, 0), 0},
                {new DateTime(2000, 1, 1, 2, 0, 0), null},
                {new DateTime(2000, 1, 1, 3, 0, 0), -1},
            };
            
            var newTsAct = _ts.Simplify(SimplifyType.Min, 3600).Trim();
            
            Assert.Equal(newTsExp, newTsAct);
        }

        [Fact]
        public void SimplifyMaxTest()
        {
            var newTsExp = new TimeSeries
            {
                {new DateTime(2000, 1, 1, 0, 0, 0), 2},
                {new DateTime(2000, 1, 1, 1, 0, 0), 0},
                {new DateTime(2000, 1, 1, 2, 0, 0), null},
                {new DateTime(2000, 1, 1, 3, 0, 0), 15},
            };
            
            var newTsAct = _ts.Simplify(SimplifyType.Max, 3600).Trim();
            
            Assert.Equal(newTsExp, newTsAct);
        }

        [Fact]
        public void SimplifyLastTest()
        {
            var newTsExp = new TimeSeries
            {
                {new DateTime(2000, 1, 1, 0, 0, 0), 2},
                {new DateTime(2000, 1, 1, 1, 0, 0), 0},
                {new DateTime(2000, 1, 1, 2, 0, 0), null},
                {new DateTime(2000, 1, 1, 3, 0, 0), -1},
            };
            
            var newTsAct = _ts.Simplify(SimplifyType.Last, 3600).Trim();
            
            Assert.Equal(newTsExp, newTsAct);
        }
        
        [Fact]
        public void SimplifyFirstTest()
        {
            var newTsExp = new TimeSeries
            {
                {new DateTime(2000, 1, 1, 0, 0, 0), 0},
                {new DateTime(2000, 1, 1, 1, 0, 0), 0},
                {new DateTime(2000, 1, 1, 2, 0, 0), null},
                {new DateTime(2000, 1, 1, 3, 0, 0), 15},
            };
            
            var newTsAct = _ts.Simplify(SimplifyType.First, 3600).Trim();
            
            Assert.Equal(newTsExp, newTsAct);
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