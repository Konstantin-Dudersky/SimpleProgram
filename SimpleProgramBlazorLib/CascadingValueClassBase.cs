using System;
using System.Collections.Generic;
using System.Threading;
using SimpleProgram.Lib.Tag;

namespace SimpleProgramBlazorLib
{
    public class CascadingValueClassBase
    {
        public SortedDictionary<string, ITag> TagDict { get; }
        public event Action Update;
        public event Action CyclicUpdate;
        
        public DateTimeRange DateTimeRange { get; } = new DateTimeRange();

        // ReSharper disable once NotAccessedField.Local
        private Timer _timer;

        protected CascadingValueClassBase(SortedDictionary<string, ITag> tagDict)
        {
            TagDict = tagDict;
            _timer = new Timer((obj) => OnCyclicUpdate(), null, 5000, 5000);
            DateTimeRange.Refresh += OnUpdate;
        }
        
        protected void OnUpdate()
        {
            Update?.Invoke();
        }

        protected virtual void OnCyclicUpdate()
        {
            CyclicUpdate?.Invoke();
        }
    }
}