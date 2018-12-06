using System;
using System.Threading;

namespace SimpleProgramBlazorLib
{
    public class CascadingValueClassBase
    {
        public event Action Update;
        public event Action CyclicUpdate;
        
        public DateTimeRange DateTimeRange { get; } = new DateTimeRange();

        private Timer _timer;

        public CascadingValueClassBase()
        {
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