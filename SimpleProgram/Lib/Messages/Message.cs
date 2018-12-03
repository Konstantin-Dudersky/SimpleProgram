using System;
using SimpleProgram.Lib.Tag;

namespace SimpleProgram.Lib.Messages
{
    public class Message<T>
        where T : IComparable
    {
        private string _text;        
        public string Text { 
            get => _text;
            set
            {
                _text = value;
                _msgChannelTelegram?.SetText(_text);
            }
        }
        protected T Value;
        
        public bool IsActive { get; protected set; }
        protected bool IsFirstCall = true;

        protected event EventHandler Activated;

        protected Message(string text = "Message")
        {
            Text = text;
        }
        
        public virtual void OnNewValueToChannel(object sender, TagExchangeWithChannelArgs eventArgs)
        {
            Value = (T) Convert.ChangeType(eventArgs.Value, typeof(T));
        }
        
        protected void OnActivated()
        {
            if (!IsFirstCall)
                Activated?.Invoke(this, EventArgs.Empty);
        }
        
        #region Telegram

        private MsgChannelTelegram _msgChannelTelegram;
        public MsgChannelTelegram MsgChannelTelegram
        {
            get => _msgChannelTelegram;
            set
            {
                _msgChannelTelegram = value;
                _msgChannelTelegram.SetText(Text);
                Activated += _msgChannelTelegram.OnNewMessage;
            }
        }
        
        #endregion
    }
}