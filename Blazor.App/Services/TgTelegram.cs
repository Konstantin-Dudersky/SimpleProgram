using System.Collections.Generic;
using SimpleProgram.Lib.Messages;
using SimpleProgram.Lib.Tag;

namespace Blazor.App.Services
{
    public class TgTelegram
    {
        public Tag<bool> Test = new Tag<bool>
        {
            Messages = new Dictionary<string, Message<bool>>
            {
                ["msg"] = new MessageLimitMonitor<bool>("Сообщение", MessageLimitMonitorType.Equal, true)
                {
                    MsgChannelTelegram = new MsgChannelTelegram(Data.SimpleProgramTelegramClient, "@SimpleProgramChannel")
                }
            }
        };

        public TgTelegram()
        {
            Test.Value = false;
        }
    }
}