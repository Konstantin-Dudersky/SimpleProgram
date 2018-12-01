using System;
using Telegram.Bot;

namespace SimpleProgram.Lib.Messages
{
    public class TelegramClient
    {
        private readonly TelegramBotClient _bot;
        
        public TelegramClient(string token)
        {
            _bot = new TelegramBotClient(token);
//            var bot = new TelegramBotClient("611768794:AAE1RZMstPcBkrjIZq2h2pzwgK8qAKMR-yU");
        }

        internal async void SendTextMessageAsync(string chatId, string text)
        {
            var me = await _bot.SendTextMessageAsync(chatId, text);
        }
        
        
    }
}