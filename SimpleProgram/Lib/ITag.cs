using SimpleProgram.Lib.Archives;

namespace SimpleProgram.Lib
{
    public interface ITag
    {
        Archive Archive { get; set; }
        string ArchiveTagId { get; set; }
        string TagId { get; set; }
        string TagName { get; set; }
        TimeSeries GetTimeSeries();
    }
}