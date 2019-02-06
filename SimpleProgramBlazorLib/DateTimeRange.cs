using System;
using NodaTime;
using NodaTime.Extensions;
using NodaTime.Text;

namespace SimpleProgramBlazorLib
{
    public class DateTimeRange
    {
        public DateTimeRange()
        {
            End = SystemClock.Instance.InZone(DateTimeZoneProviders.Tzdb[Zone]).GetCurrentLocalDateTime();
            Begin = End.Minus(Period.FromMonths(1));
        }

        public LocalDateTime Begin { get; private set; }
        public LocalDateTime End { get; private set; }
        public event Action Refresh;
        private string Zone { get; } = "Europe/Minsk";

        private void OnRefresh()
        {
            Refresh?.Invoke();
        }

        public void ParseBeginAndEnd(ParseResult<LocalDateTime> begin, ParseResult<LocalDateTime> end)
        {
            //Begin = begin.Success ? begin.Value : ZonedDateTime. .FromDateTime(DateTime.MinValue);
            End = end.Success ? end.Value : LocalDateTime.FromDateTime(DateTime.MaxValue);

            OnRefresh();
        }
    }
}