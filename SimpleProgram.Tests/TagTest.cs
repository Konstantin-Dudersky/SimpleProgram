using System;
using SimpleProgram.Lib;
using Xunit;

namespace SimpleProgram.Tests
{
    public class TagTest
    {
        [Fact]
        public void SetGet()
        {
            // double
            const double value = 10.0;
            var tag = new Tag<double>();
            tag.SetValue(value);

            Assert.True(tag.GetValue<bool>());
            Assert.Equal(Convert.ToByte(value), tag.GetValue<byte>());
            Assert.Equal(Convert.ToDouble(value), tag.GetValue<double>());
            Assert.Equal(Convert.ToInt16(value), tag.GetValue<short>());
            Assert.Equal(Convert.ToInt32(value), tag.GetValue<int>());
            Assert.Equal(Convert.ToInt64(value), tag.GetValue<long>());
            Assert.Equal(Convert.ToSingle(value), tag.GetValue<float>());
            
            tag = new Tag<double>();
            Assert.Equal(0, tag.GetValue<double>());
            Assert.Equal(0, tag.GetValue<int>());
            Assert.False(tag.GetValue<bool>());
        }
    }
}