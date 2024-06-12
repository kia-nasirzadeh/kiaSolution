using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Globalization;
using System.Diagnostics;
using System.Text.RegularExpressions;

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
            string dtToReturn = dtDateTime.ToString();
            if (persian)
            {
                PersianCalendar persianCalendar = new PersianCalendar();
                DateTime gregorianDate = dtDateTime;
                dtToReturn = string.Format("{0:0000}/{1:00}/{2:00}", persianCalendar.GetYear(gregorianDate), persianCalendar.GetMonth(gregorianDate), persianCalendar.GetDayOfMonth(gregorianDate));
            }
            return dtToReturn;
        }
        public static void GetText_openLinks (string text)
        {
            var matches = App.regex.Matches(text);
            bool firstIteration = true;
            foreach (Match match in matches)
            {
                var matchedString = match.ToString();
                Regex regex = new(@"\w+[\%\+\=\-\:\/.\,\;\?\#\w]*");
                var matchess = regex.Matches(matchedString);
                var link = matchess[0].ToString();
                link = "\"" + link + "\"";
                //MessageBox.Show(link);
                var process = new Process();
                string linkToOpen = @"/C chrome " + link;
                if (firstIteration)
                {
                    linkToOpen = @"/C chrome " + link + " --new-window";
                    firstIteration = false;
                }
                var startInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = linkToOpen,
                    UseShellExecute = false,
                };
                process.StartInfo = startInfo;
                process.Start();
            }
        }
    }
}
