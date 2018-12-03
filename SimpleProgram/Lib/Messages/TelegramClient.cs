using System;
using NLog;
using SimpleProgram.Lib.OpcUa;
using Telegram.Bot;

namespace SimpleProgram.Lib.Messages
{
    public class TelegramClient : SimpleProgramChannelBase
    {
        private readonly TelegramBotClient _bot;
        
        public TelegramClient(string channelName, string token) : base(channelName)
        {
            try
            {
                _bot = new TelegramBotClient(token);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Ошибка при создании канала Telegram");
            }
        }

        internal async void SendTextMessageAsync(string chatId, string text)
        {
            try
            {
                await _bot.SendTextMessageAsync(chatId, text);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Ошибка отправки сообщения Telegram");
            }
        }
    }
}