using SimpleProgram.Lib;
using SimpleProgram.Lib.OpcUa;
using SimpleProgram.Lib.Tag;

namespace Blazor.App.Services
{
    public class TGOpcItems : TagGroupBase
    {
        public Tag<double> testOpcWithWrite = new Tag<double>
        {
            ChannelOpcUaClient =
                new TagChannelOpcUaClient(Data.OpcClient, "ns=2;s=Demo.Static.Scalar.Double", 1000, false)
        };

        public Tag<double> testTagOpc = new Tag<double>
        {
            ChannelOpcUaClient =
                new TagChannelOpcUaClient(Data.OpcClient, "ns=2;s=Demo.Dynamic.Scalar.Double", 1000, false)
        };

        public Tag<int> testTagOpcInt = new Tag<int>
        {
            ChannelOpcUaClient =
                new TagChannelOpcUaClient(Data.OpcClient, "ns=2;s=Demo.Dynamic.Scalar.Int32", 1000, false)
        };
    }
}