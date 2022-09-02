using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Newtonsoft.Json;
using System.Globalization;
using System.Windows;

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
        public List<DateStepStatus>? TimeLineToShow_Persian
        {
            get
            {
                List<DateStepStatus>? timeLine = JsonConvert.DeserializeObject<List<DateStepStatus>>(TimeLine!);
                if (timeLine is not null)
                {
                    PersianCalendar persianCalendar = new PersianCalendar();
                    for (int i = 0; i < timeLine.Count; i++)
                    {
                        if (timeLine[i] is not null)
                        {
                            DateTime gregorianDate = timeLine[i].dateTime;
                            timeLine[i].dateTime = new DateTime(persianCalendar.GetYear(gregorianDate), persianCalendar.GetMonth(gregorianDate), persianCalendar.GetDayOfMonth(gregorianDate));
                        }
                    }
                    return timeLine;
                }
                else return null;
            }
        }
    }
}
