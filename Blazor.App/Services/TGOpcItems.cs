using SimpleProgram.Lib;
using SimpleProgram.Lib.Tag;

namespace Blazor.App.Services
{
    public class TGOpcItems : TagGroupBase
    {
        public Tag<double> testOpcWithWrite = new Tag<double>();
        public Tag<double> testTagOpc = new Tag<double>();

        public Tag<int> testTagOpcInt = new Tag<int>();

        public TGOpcItems()
        {
            testTagOpc.ConfOpcUaClient(Data.OpcClient, "ns=2;s=Demo.Dynamic.Scalar.Double", 1000);
            testTagOpcInt.ConfOpcUaClient(Data.OpcClient, "ns=2;s=Demo.Dynamic.Scalar.Int32", 1000);
            testOpcWithWrite.ConfOpcUaClient(Data.OpcClient, "ns=2;s=Demo.Static.Scalar.Double", 1000);
        }
    }
}