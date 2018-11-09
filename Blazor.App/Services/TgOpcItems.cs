using SimpleProgram.Lib;
using SimpleProgram.Lib.OpcUa;
using SimpleProgram.Lib.Tag;

namespace Blazor.App.Services
{
    public class TgOpcItems : TagGroupBase
    {
        public Tag<double> testTagOpc = new Tag<double>
        {
            OpcUaClient = new TagOpcUaClient(Data.OpcClient, "ns=2;s=Demo.Dynamic.Scalar.Double", 1000),
        };

        public Tag<int> testTagOpcInt = new Tag<int>
        {
            OpcUaClient = new TagOpcUaClient(Data.OpcClient, "ns=2;s=Demo.Dynamic.Scalar.Int32", 1000),
        };

        public Tag<double> testOpcWithWrite = new Tag<double>
        {
            OpcUaClient = new TagOpcUaClient(Data.OpcClient, "ns=2;s=Demo.Static.Scalar.Double", 1000),
        };
    }
}