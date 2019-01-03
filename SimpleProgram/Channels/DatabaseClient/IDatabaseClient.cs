using System;
using Microsoft.EntityFrameworkCore;

namespace SimpleProgram.Channels.DatabaseClient
{
    public interface IDatabaseClient
    {
        string ArchiveName { get; set; }
        string ConnectionString { get; }
        Providers Provider { get; }

        DbContext GetDbContext();

        void AddMonitoredItem(TagChannelDatabaseClient client, string id, int samplingInterval,
            EventHandler<ValueFromChannelArgs> eventHandler);
    }
}