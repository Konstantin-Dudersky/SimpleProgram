using System;
using SimpleProgram.Lib.Tag;

namespace SimpleProgram.Lib.Messages
{
    public class MessageLimitMonitor : Message
    {
        private readonly MessageLimitMonitorType _limitMonitorType;
        private readonly double _limit;
        private readonly double _hysteresys;

        public MessageLimitMonitor(string text, MessageLimitMonitorType limitMonitorType, 
            double limit, double hysteresys) : base(text)
        {
            _limitMonitorType = limitMonitorType;
            _limit = limit;
            _hysteresys = hysteresys;
        }
        
        public override void OnNewValueToChannel(object sender, TagExchangeWithChannelArgs eventArgs)
        {
            base.OnNewValueToChannel(sender, eventArgs);

            if (!Isactive)
            {
                switch (_limitMonitorType)
                {
                    case MessageLimitMonitorType.GreateThen:
                        if (Value > _limit)
                        {
                            Isactive = true;
                            OnActivated();
                        }
                        break;
                    case MessageLimitMonitorType.GreateOrEqual:
                        break;
                    case MessageLimitMonitorType.LessThen:
                        break;
                    case MessageLimitMonitorType.LessOrEqual:
                        break;
                    case MessageLimitMonitorType.Equal:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                switch (_limitMonitorType)
                {
                    case MessageLimitMonitorType.GreateThen:
                        if (Value < _limit - _hysteresys)
                            Isactive = false;
                        break;
                    case MessageLimitMonitorType.GreateOrEqual:
                        break;
                    case MessageLimitMonitorType.LessThen:
                        break;
                    case MessageLimitMonitorType.LessOrEqual:
                        break;
                    case MessageLimitMonitorType.Equal:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }

    public enum MessageLimitMonitorType
    {
        GreateThen,
        GreateOrEqual,
        LessThen,
        LessOrEqual,
        Equal
    }
}