using System;
using Blazor.App.Pages;
using SimpleProgramBlazorLib;

namespace Blazor.App.Services
{
    public sealed class CascadingValueClass : CascadingValueClassBase
    {
        public DateTimeRange DateTimeRange { get; } = new DateTimeRange();

        public CascadingValueClass()
        {
            DateTimeRange.Refresh += OnUpdate;
        }
        
    }
}