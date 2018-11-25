using System;

namespace SimpleProgramBlazorLib
{
    public class CascadingValueClassBase
    {
        public event Action Update;
        public DateTimeRange DateTimeRange { get; } = new DateTimeRange();

        public CascadingValueClassBase()
        {
            DateTimeRange.Refresh += OnUpdate;
        }
        
        protected void OnUpdate()
        {
            Update?.Invoke();
        }
    }
}