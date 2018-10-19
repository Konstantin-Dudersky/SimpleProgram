using SimpleProgram.Lib.Archives;
using System;


namespace SimpleProgram.Lib
{
    public class Tag<T> : ITag
    {
        private T _value;

        public Archive Archive { get; set; }
        public string ArchiveTagId { get; set; }
        public string TagId { get; set; }
        public string TagName { get; set; }

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                OnChange?.Invoke();
            }
        }

        public event Action OnChange;


        public TimeSeries GetTimeSeries()
        {
            return Archive.GetTimeSeries(ArchiveTagId);
        }
    }
}