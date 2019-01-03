using System;

namespace SimpleProgram.Channels
{
    public class ChannelBase : IComparable<ChannelBase>
    {
        public string ChannelName { get; }
        public bool IsDisabled { get; }
        public virtual bool IsConnected { get; protected set; }
        protected NLog.Logger Logger { get; }

        protected ChannelBase(string channelName, bool isDisabled)
        {
            ChannelName = channelName;
            IsDisabled = isDisabled;

            Logger = NLog.LogManager.GetLogger(channelName);
        }

        public int CompareTo(ChannelBase other)
        {
            return string.Compare(ChannelName, other.ChannelName, StringComparison.Ordinal);
        }
    }
}