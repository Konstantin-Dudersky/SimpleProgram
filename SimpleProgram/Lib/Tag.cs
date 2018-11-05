using System;
using System.ComponentModel;
using System.Globalization;
using SimpleProgram.Lib.Archives;

namespace SimpleProgram.Lib
{
    public sealed class Tag<T> : ITag
        where T : IConvertible
    {
        private T _value;

        public object Value
        {
            get => Convert.ChangeType(_value, typeof(T));
            set
            {
                _value = (T) Convert.ChangeType(value, typeof(object));
                OnChange?.Invoke();
            }
        }

        public ITag<TNew> Conv<TNew>() where TNew : IConvertible
        {
            return new TagLink<T, TNew>(this);
        }


        public Archive Archive { get; set; }
        public string ArchiveTagId { get; set; }
        public string TagId { get; set; }
        public string TagName { get; set; }


        public TimeSeries GetTimeSeries()
        {
            return Archive.GetTimeSeries(ArchiveTagId);
        }

        public T1 GetValue<T1>()
        {
            return (T1) Convert.ChangeType(_value, typeof(T1));
        }

        public void SetValue<T1>(T1 value)
        {
            _value = (T) Convert.ChangeType(value, typeof(T));
        }

        public string ValueString
        {
            get => _value.ToString(CultureInfo.InvariantCulture);
            set
            {
                T fromString;
                try
                {
                    fromString = (T) TypeDescriptor.GetConverter(typeof(T)).ConvertFromString(value);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    fromString = _value;
                }

                _value = fromString;
            }
        }

        public Type GenericType => typeof(T);
        public bool InputValid { get; } = true;


        public event Action OnChange;
    }
}