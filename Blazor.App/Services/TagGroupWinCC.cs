using SimpleProgram.Lib;
using SimpleProgram.Lib.OpcUa;
using SimpleProgram.Lib.Tag;

// ReSharper disable UnusedMember.Global
// ReSharper disable StringLiteralTypo
// ReSharper disable InconsistentNaming
// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable IdentifierTypo
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable RedundantArgumentDefaultValue

namespace Blazor.App.Services
{
    public class TagGroupWinCC : TagGroupBase
    {
        public Tag<double> testReal = new Tag<double>
        {
            ChannelOpcUaClient = new TagChannelOpcUaClient(Data.OpcWinCC, @"ns=1;s=v|Data_log_1\testReal", 1000, true)
        };
        
        public Tag<double> testInt = new Tag<double>
        {
            ChannelOpcUaClient = new TagChannelOpcUaClient(Data.OpcWinCC, @"ns=1;s=v|Data_log_1\testInt", 1000, true)
        };
    }
}