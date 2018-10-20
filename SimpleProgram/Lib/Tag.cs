using System;
using SimpleProgram.Lib.Archives;

namespace SimpleProgram.Lib
{
    public class Tag<T> : ITag<T>
        where T : IConvertible
    {
        private T _value;

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
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
            return (T1) Convert.ChangeType(Value, typeof(T1));
        }

        public void SetValue<T1>(T1 value)
        {
            Value = (T) Convert.ChangeType(value, typeof(T));
        }

        public event Action OnChange;
        
        
    }
}