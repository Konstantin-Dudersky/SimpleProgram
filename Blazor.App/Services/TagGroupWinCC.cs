using SimpleProgram.Lib;
using SimpleProgram.Lib.OpcUa;
using SimpleProgram.Lib.Tag;

namespace Blazor.App.Services
{
    public class TagGroupWinCC : TagGroupBase
    {
        public Tag<double> testReal = new Tag<double>
        {
            ChannelOpcUaClient = new TagChannelOpcUaClient(Data.OpcWinCC, @"ns=1;s=v|Data_log_1\testReal", 1000, true)
        };

    }
}