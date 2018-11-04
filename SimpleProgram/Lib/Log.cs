using System;
using System.Text;

namespace SimpleProgram.Lib
{
    public class Log
    {
        private readonly StringBuilder _sb;

        public Log(int maxCapacity = 100)
        {
            _sb = new StringBuilder(16, maxCapacity);
        }

        public void Append(string str)
        {
            try
            {
                _sb.Append(str);
            }
            catch (ArgumentOutOfRangeException e)
            {
                _sb.Remove(0, str.Length);
                Append(str);
            }
        }

        public override string ToString()
        {
            return _sb.ToString();
        }
    }
}