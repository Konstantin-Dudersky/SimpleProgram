using System;

namespace Blazor.App.Pages
{
    public class DateTimeRange
    {
        public DateTime Begin { get; set; } = DateTime.Now.AddMonths(-1);
        public DateTime End { get; set; } = DateTime.Now;
        public event Action Refresh;

        public DateTimeRange()
        {
            Begin = new DateTime(Begin.Year, Begin.Month, Begin.Day, Begin.Hour, Begin.Minute, Begin.Second);
            End = new DateTime(End.Year, End.Month, End.Day, End.Hour, End.Minute, End.Second);
        }

        public void OnRefresh()
        {
            Refresh?.Invoke();
        }
    }
}