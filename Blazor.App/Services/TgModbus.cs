// ReSharper disable UnusedMember.Global
// ReSharper disable StringLiteralTypo
// ReSharper disable InconsistentNaming
// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable IdentifierTypo
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable RedundantArgumentDefaultValue

using System;
using System.Collections.Generic;
using SimpleProgram.Channels.ModbusTcpClient;
using SimpleProgram.Lib;
using SimpleProgram.Lib.Messages;
using SimpleProgram.Lib.Tag;

namespace Blazor.App.Services
{
    public class TgModbus : TagGroupBase
    {
        public Tag<int> register0 = new Tag<int>
        {
            TagChannelModbusTcpClient = new TagChannelModbusTcpClient(Data.ModbusTcpClient, 0, 1000),
            Messages = new Dictionary<string, Message<int>>
            {
                ["123"] = new MessageLimitMonitor<int>("Лимит достигнут", MessageLimitMonitorType.GreaterThen, 100, 5)
                {
                    MsgChannelTelegram = new MsgChannelTelegram(Data.TelegramClient, "@saria_channel")
                }
            }
        };

        public Tag<int> register1 = new Tag<int>
        {
            TagChannelModbusTcpClient = new TagChannelModbusTcpClient(Data.ModbusTcpClient, 1, 5000),
        };

        public TgModbus()
        {
            Console.WriteLine(register0.Messages["123"].IsActive);
        }

    }
}