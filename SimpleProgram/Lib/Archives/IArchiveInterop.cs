using System;

namespace SimpleProgram.Lib.Archives
{
    internal interface IArchiveInterop
    {
        TimeSeries GetTimeSeries(string name, DateTime dateTimeFrom, DateTime dateTimeTo,
            double lessThen, double moreThen);
        object[] GetEntities(string name, DateTime begin, DateTime end, double lessThen, double moreThen);

        double Increment(string name, DateTime begin, DateTime end);
    }
}