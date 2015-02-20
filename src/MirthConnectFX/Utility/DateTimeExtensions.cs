using System;
using MirthConnectFX.Model;

namespace MirthConnectFX.Utility
{
    public static class DateTimeExtensions
    {
        public static MirthDateTime ToMirthDateTime(this DateTime source, string timezone)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            var result = new MirthDateTime
            {
                Time = Convert.ToUInt64((source - epoch).TotalMilliseconds),
                Timezone = timezone
            };

            return result;
        }
    }
}