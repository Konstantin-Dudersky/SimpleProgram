namespace SimpleProgram.Lib.OpcUa
{
    public class SimpleProgramChannelBase
    {
        private string ChannelName { get; }
        protected NLog.Logger Logger { get; }

        protected SimpleProgramChannelBase(string channelName)
        {
            ChannelName = channelName;
            
            Logger = NLog.LogManager.GetLogger(channelName);
        }
    }
}