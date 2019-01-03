using System;

namespace SimpleProgram.Lib.Messages
{
    public class MsgChannelTelegram
    {
        private readonly string _chatId;
        private readonly TelegramClient _client;
        private string _text;

        public MsgChannelTelegram(TelegramClient client, string chatId)
        {
            _chatId = chatId;
            _client = client;
        }

        internal void SetText(string text)
        {
            _text = text;
        }

        public void OnNewMessage(object sender, EventArgs e)
        {
            _client.SendTextMessageAsync(_chatId, _text);
        }
        
        
    }
}