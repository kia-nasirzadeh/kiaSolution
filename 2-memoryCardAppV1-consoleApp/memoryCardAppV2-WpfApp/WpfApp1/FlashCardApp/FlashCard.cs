using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Newtonsoft.Json;
using System.Globalization;
using System.Windows;
using System.Diagnostics;

namespace WpfApp1.FlashCardApp
{
    [Table("FlashCards")]
    public class FlashCard
    {
        [Column("ID"), PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Column("Question"), NotNull]
        public string? Question { get; set; }
        [Column("Answer"), NotNull]
        public string? Answer { get; set; }
        [Column("TimeLine"), NotNull]
        public string? TimeLine { get; set; }
        [Column("NextDay")]
        public long NextDay { get; set; }
        [Column("DateModified")]
        public long DateModified { get; set; }
        [Ignore]
        public string DateModifiedToShow
        {
            get
            {
                string stringedDateTime = CommonFunctions.UnixLongToStringifiedDateTime(DateModified, true);
                string myDateTime = stringedDateTime.Split(' ')[0];
                return myDateTime;
            }
        }
        [Ignore]
        public List<StringStepStatus>? TimeLineToShow_Persian
        {
            get
            {
                List<StringStepStatus>? timeLine = JsonConvert.DeserializeObject<List<StringStepStatus>>(TimeLine!);
                if (timeLine is not null)
                {
                    PersianCalendar persianCalendar = new PersianCalendar();
                    for (int i = 0; i < timeLine.Count; i++)
                    {
                        if (timeLine[i] is not null)
                        {
                            string gregorianDate = timeLine[i].dateTime;
                            DateTime gregorianDateTime = Convert.ToDateTime(gregorianDate);
                            timeLine[i].dateTime = $"{persianCalendar.GetYear(gregorianDateTime)}-{persianCalendar.GetMonth(gregorianDateTime)}-{persianCalendar.GetDayOfMonth(gregorianDateTime)}";
                        }
                    }
                    return timeLine;
                }
                else return null;
            }
        }
    }
}
