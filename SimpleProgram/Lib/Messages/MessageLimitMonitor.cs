using System;
using SimpleProgram.Lib.Tag;

namespace SimpleProgram.Lib.Messages
{
    public class MessageLimitMonitor<T> : Message<T>
        where T : IComparable
    {
        private readonly MessageLimitMonitorType _limitMonitorType;
        private readonly T _limit;

        private readonly T _limitMinusHyst;
        private readonly T _limitPlusHyst;

        public MessageLimitMonitor(string text, MessageLimitMonitorType limitMonitorType,
            T limit, T hysteresys = default) : base(text)
        {
            _limitMonitorType = limitMonitorType;
            _limit = limit;

            var limitD = (double) Convert.ChangeType(limit, typeof(double));
            var hysteresysD = (double) Convert.ChangeType(hysteresys, typeof(double));
            _limitMinusHyst = (T) Convert.ChangeType(limitD - hysteresysD, typeof(T));
            _limitPlusHyst = (T) Convert.ChangeType(limitD + hysteresysD, typeof(T));
        }

        public override void OnNewValueToChannel(object sender, TagExchangeWithChannelArgs eventArgs)
        {
            base.OnNewValueToChannel(sender, eventArgs);

            switch (_limitMonitorType)
            {
                case MessageLimitMonitorType.GreaterThen:
                    if (IsActive)
                    {
                        if (Value.CompareTo(_limitMinusHyst) < 0)
                            IsActive = false;
                    }
                    else
                    {
                        if (Value.CompareTo(_limit) > 0)
                        {
                            IsActive = true;
                            OnActivated();
                        }
                    }

                    break;
                case MessageLimitMonitorType.GreaterOrEqual:
                    if (IsActive)
                    {
                        if (Value.CompareTo(_limitMinusHyst) < 0)
                            IsActive = false;
                    }
                    else
                    {
                        if (Value.CompareTo(_limit) >= 0)
                        {
                            IsActive = true;
                            OnActivated();
                        }
                    }
                    break;
                case MessageLimitMonitorType.LessThen:
                    if (IsActive)
                    {
                        if (Value.CompareTo(_limitPlusHyst) > 0)
                            IsActive = false;
                    }
                    else
                    {
                        if (Value.CompareTo(_limit) < 0)
                        {
                            IsActive = true;
                            OnActivated();
                        }
                    }
                    
                    break;
                case MessageLimitMonitorType.LessOrEqual:
                    if (IsActive)
                    {
                        if (Value.CompareTo(_limitPlusHyst) > 0)
                            IsActive = false;
                    }
                    else
                    {
                        if (Value.CompareTo(_limit) <= 0)
                        {
                            IsActive = true;
                            OnActivated();
                        }
                    }
                    
                    break;
                case MessageLimitMonitorType.Equal:
                    if (IsActive)
                    {
                        if (Value.CompareTo(_limit) != 0)
                            IsActive = false;
                    }
                    else
                    {
                        if (Value.CompareTo(_limit) == 0)
                        {
                            IsActive = true;
                            OnActivated();
                        }
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            IsFirstCall = false;
        }
    }

    public enum MessageLimitMonitorType
    {
        GreaterThen,
        GreaterOrEqual,
        LessThen,
        LessOrEqual,
        Equal
    }
}