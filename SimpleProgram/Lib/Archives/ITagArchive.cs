namespace SimpleProgram.Lib.Archives
{
    public interface IDbContext
    {
        TimeSeries GetTimeSeries(string name);
    }
}