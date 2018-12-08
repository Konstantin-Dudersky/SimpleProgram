using System;

namespace SimpleProgram.Lib
{
    public class SimpleProgramChannelBase : IComparable<SimpleProgramChannelBase>
    {
        public string ChannelName { get; }
        public bool IsDisabled { get; }
        public virtual bool IsConnected { get; protected set; }
        protected NLog.Logger Logger { get; }

        protected SimpleProgramChannelBase(string channelName, bool isDisabled)
        {
            ChannelName = channelName;
            IsDisabled = isDisabled;

            Logger = NLog.LogManager.GetLogger(channelName);
        }

        public int CompareTo(SimpleProgramChannelBase other)
        {
            return string.Compare(ChannelName, other.ChannelName, StringComparison.Ordinal);
        }
    }
}