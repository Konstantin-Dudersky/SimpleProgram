using System;
using SimpleProgram.Lib.Tag;

namespace SimpleProgram.Lib.Messages
{
    public class Message
    {
        private readonly string _text;
        protected double Value;
        public bool Isactive { get; protected set; }

        protected event EventHandler Activated;

        protected Message(string text = "Message")
        {
            _text = text;
        }
        
        public virtual void OnNewValueToChannel(object sender, TagExchangeWithChannelArgs eventArgs)
        {
            Value = Convert.ToDouble(eventArgs.Value);
        }

        #region Telegram

        private MsgChannelTelegram _msgChannelTelegram;
        public MsgChannelTelegram MsgChannelTelegram
        {
            get => _msgChannelTelegram;
            set
            {
                _msgChannelTelegram = value;
                _msgChannelTelegram.SetText(_text);
                Activated += _msgChannelTelegram.OnNewMessage;
            }
        }
        
        #endregion

        protected void OnActivated()
        {
            Activated?.Invoke(this, EventArgs.Empty);
        }
    }
}