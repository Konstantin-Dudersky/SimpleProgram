using Microsoft.EntityFrameworkCore;

namespace SimpleProgram.Lib.Archives
{
    public interface IDatabase
    {
        string ArchiveName { get; set; }
        string ConnectionString { get; }
        Providers Provider { get; }

        DbContext GetDbContext();
    }
}