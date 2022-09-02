using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Globalization;
using System.Diagnostics;

namespace WpfApp1
{
    internal class CommonFunctions
    {
        public static long DateTimeToLong (DateTime dt)
        {
            long unixDateTime = ((DateTimeOffset)dt).ToUnixTimeSeconds();
            return unixDateTime;
        }
        public static string UnixLongToStringifiedDateTime (long dt, bool persian = false)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(dt).ToLocalTime();
            if (persian)
            {
                PersianCalendar persianCalendar = new PersianCalendar();
                DateTime gregorianDate = dtDateTime;
                dtDateTime = new DateTime(persianCalendar.GetYear(gregorianDate), persianCalendar.GetMonth(gregorianDate), persianCalendar.GetDayOfMonth(gregorianDate));
            }
            return dtDateTime.ToString();
        }
    }
}
