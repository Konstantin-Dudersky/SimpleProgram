using System;

namespace SimpleProgramBlazorLib
{
    public class CascadingValueClassBase
    {
        public event Action Update;

        protected void OnUpdate()
        {
            Update?.Invoke();
        }
    }
}