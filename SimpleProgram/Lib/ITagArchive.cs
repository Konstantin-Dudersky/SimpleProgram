using SimpleProgram.Lib.Archives;

namespace SimpleProgram.Lib
{
    public interface ITagArchive
    {
        Archive Archive { get; set; }
        string ArchiveTagName { get; set; }
        string TagName { get; set; }
    }
}