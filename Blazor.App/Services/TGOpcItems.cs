using SimpleProgram.Channels.OpcUaClient;
using SimpleProgram.Lib;
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
    public class TGOpcItems : TagGroupBase
    {
        public Tag<double> testOpcWithWrite = new Tag<double>
        {
            TagChannelOpcUaClient =
                new TagChannelOpcUaClient(Data.OpcClient, "ns=2;s=Demo.Static.Scalar.Double", 1000, false)
        };

        public Tag<double> testTagOpc = new Tag<double>
        {
            TagChannelOpcUaClient =
                new TagChannelOpcUaClient(Data.OpcClient, "ns=2;s=Demo.Dynamic.Scalar.Double", 1000, false)
        };

        public Tag<int> testTagOpcInt = new Tag<int>
        {
            TagChannelOpcUaClient =
                new TagChannelOpcUaClient(Data.OpcClient, "ns=2;s=Demo.Dynamic.Scalar.Int32", 1000, false)
        };

        public Tag<double> doubleWithHistory = new Tag<double>
        {
            TagChannelOpcUaClient =
                new TagChannelOpcUaClient(Data.OpcClient, "ns=2;s=Demo.History.DoubleWithHistory", 1000, true)
        };
    }
}