// ReSharper disable UnusedMember.Global
// ReSharper disable StringLiteralTypo
// ReSharper disable InconsistentNaming
// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable IdentifierTypo
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable RedundantArgumentDefaultValue

using SimpleProgram.Lib;
using SimpleProgram.Lib.Modbus;
using SimpleProgram.Lib.Tag;

namespace Blazor.App.Services
{
    public class TgModbus : TagGroupBase
    {
        public Tag<int> register0 = new Tag<int>
        {
            ChannelModbusTcpClient = new TagChannelModbusTcpClient(Data.ModbusTcpClient, 0, 1000),
        };
        
        public Tag<int> register1 = new Tag<int>
        {
            ChannelModbusTcpClient = new TagChannelModbusTcpClient(Data.ModbusTcpClient, 1, 5000),
        };
    }
}