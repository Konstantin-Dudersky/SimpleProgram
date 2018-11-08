using System;
using SimpleProgram.Lib.Archives;
using Xunit;

namespace SimpleProgram.Tests
{
    public class TimeValueTest
    {
        [Fact]
        public void CompareToTest()
        {
            var tv1 = new TimeValue(new DateTime(2000, 1, 1, 0, 0, 0), 10);
            var tv2 = new TimeValue(new DateTime(2000, 1, 1, 0, 0, 0), 11);
            Assert.Equal(0, tv1.CompareTo(tv2));
            
            tv1 = new TimeValue(new DateTime(2000, 1, 1, 0, 0, 0), 10);
            tv2 = new TimeValue(new DateTime(2000, 1, 1, 0, 0, 1), 11);
            Assert.Equal(-1, tv1.CompareTo(tv2));
            
            tv1 = new TimeValue(new DateTime(2000, 1, 1, 0, 0, 1), 10);
            tv2 = new TimeValue(new DateTime(2000, 1, 1, 0, 0, 0), 11);
            Assert.Equal(1, tv1.CompareTo(tv2));
        }


    }
}