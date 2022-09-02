using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Globalization;
using System.Windows;

namespace WpfApp1.FlashCardApp
{
    internal class TimeLineFunctions
    {
        public static void LogTimeLineOnOutput(List<DateStepStatus> timeLine)
        {
            if (timeLine == null)
            {
                MessageBox.Show("timeline null in LogTimeLineOnOutput");
            }
            timeLine.ForEach(i => {
                Trace.WriteLine("\t", i.dateTime.ToString());
                Trace.WriteLine("\t", i.stepStatus!.Step.ToString());
                Trace.WriteLine("\t", i.stepStatus.Status.ToString());
            });
        }
        static DateTime? FindLastStep(List<DateStepStatus> timeLine)
        {
            List<DateStepStatus> previousTimeLines = new();
            if (timeLine is null) return null;
            for (int i = 0; i < timeLine.Count; i++)
            {
                DateTime dateTime = timeLine[i].dateTime;
                if (DateTime.Today >= dateTime)
                {
                    previousTimeLines.Add(timeLine[i]);
                }
                else continue;
            }
            DateTime? LastStepDateTime = null;
            if (previousTimeLines.Count != 0)
            {
                LastStepDateTime = previousTimeLines.Max(i => i.dateTime);
            }
            return LastStepDateTime;
        }
        public static List<DateStepStatus> decodeTimeLine(string stringifiedTimeLine)
        {
            List<DateStepStatus>? timeLine = JsonConvert.DeserializeObject<List<DateStepStatus>>(stringifiedTimeLine);
            if (timeLine is not null)
            {
                return timeLine;
            }
            else
                throw new Exception("timeLine is null");
        }
        public static string CodeTimeLine(List<DateStepStatus> timeLine)
        {
            if (timeLine is not null)
            {
                string jsonedTimeLine = JsonConvert.SerializeObject(timeLine);
                return jsonedTimeLine;
            }
            else
                throw new Exception("timeline is empty");
        }
        public static string InitATimeLine(out DateTime nextDay)
        {
            nextDay = DateTime.Today.AddDays(1);
            List<DateStepStatus> timeLine = new();
            DateStepStatus dateStepStatus_1 = new DateStepStatus() { dateTime = DateTime.Today.AddDays(1), stepStatus = new StepStatus() { Step = 1, Status = Status.NotReached } };
            DateStepStatus dateStepStatus_2 = new DateStepStatus() { dateTime = DateTime.Today.AddDays(2), stepStatus = new StepStatus() { Step = 2, Status = Status.NotReached } };
            DateStepStatus dateStepStatus_4 = new DateStepStatus() { dateTime = DateTime.Today.AddDays(6), stepStatus = new StepStatus() { Step = 4, Status = Status.NotReached } };
            DateStepStatus dateStepStatus_8 = new DateStepStatus() { dateTime = DateTime.Today.AddDays(14), stepStatus = new StepStatus() { Step = 8, Status = Status.NotReached } };
            DateStepStatus dateStepStatus_16 = new DateStepStatus() { dateTime = DateTime.Today.AddDays(30), stepStatus = new StepStatus() { Step = 16, Status = Status.NotReached } };
            DateStepStatus dateStepStatus_32 = new DateStepStatus() { dateTime = DateTime.Today.AddDays(64), stepStatus = new StepStatus() { Step = 32, Status = Status.NotReached } };
            DateStepStatus dateStepStatus_64 = new DateStepStatus() { dateTime = DateTime.Today.AddDays(128), stepStatus = new StepStatus() { Step = 64, Status = Status.NotReached } };
            DateStepStatus dateStepStatus_128 = new DateStepStatus() { dateTime = DateTime.Today.AddDays(256), stepStatus = new StepStatus() { Step = 128, Status = Status.NotReached } };
            timeLine.AddRange(new List<DateStepStatus>()
            {
                dateStepStatus_1,
                dateStepStatus_2,
                dateStepStatus_4,
                dateStepStatus_8,
                dateStepStatus_16,
                dateStepStatus_32,
                dateStepStatus_64,
                dateStepStatus_128
            });
            var stringifiedTimeline = CodeTimeLine(timeLine);
            return stringifiedTimeline;
        }
        public static string OperationOnTimeLine_success(List<DateStepStatus> timeLine, out DateTime nextDay)
        {
            Trace.WriteLine("this is time line in success:");
            if (timeLine == null)
            {
                MessageBox.Show("null in OperationOnTimeLine_success :((");
            }
            LogTimeLineOnOutput(timeLine);
            nextDay = DateTime.MaxValue;
            DateTime? lastStepDateTime = FindLastStep(timeLine);
            if (lastStepDateTime is null) throw new Exception("lastStepDateTime is null - OperationOnTimeLine_success");
            for (int i = 0; i < timeLine.Count; i++)
            {
                DateTime dateTime = timeLine[i].dateTime;
                StepStatus? timeLine_i = timeLine[i].stepStatus;
                if (lastStepDateTime == dateTime)
                {
                    if (timeLine_i is not null)
                    {
                        timeLine_i.Status = Status.Succeed;
                        if (timeLine.ElementAtOrDefault(i + 1) is not null)
                        {
                            nextDay = timeLine[i + 1].dateTime;
                        }
                        else
                        {
                            nextDay = DateTime.UnixEpoch; // TODO: if we set it like this, converting DateTime to unix should works fine, but we should test this 
                        }
                    }
                }
                else if (lastStepDateTime > dateTime)
                {
                    if (timeLine_i is not null)
                    {
                        if (timeLine_i.Status == Status.NotReached) timeLine_i.Status = Status.Succeed;
                    }
                }
                else continue;
            }
            if (nextDay == DateTime.MaxValue) throw new Exception("next day have not been set right!");
            var stringifiedTimeline = CodeTimeLine(timeLine);
            return stringifiedTimeline;
        }
        public static string OperationOnTimeLine_fail(List<DateStepStatus> timeLine, out DateTime nextDay)
        {
            nextDay = DateTime.MaxValue;
            DateTime? lastStepDateTime = FindLastStep(timeLine);
            if (lastStepDateTime is null) throw new Exception("lastStepDateTime is null - OperationOnTimeLine_fail");
            for (int i = 0; i < timeLine.Count; i++)
            {
                DateTime dateTime = timeLine[i].dateTime;
                StepStatus? timeLine_i = timeLine[i].stepStatus;
                if (lastStepDateTime == dateTime)
                {
                    if (timeLine_i is not null)
                    {
                        timeLine_i.Status = Status.Failed;
                    }
                }
                else if (lastStepDateTime > dateTime)
                {
                    if (timeLine_i is not null)
                    {
                        if (timeLine_i.Status == Status.NotReached) timeLine_i.Status = Status.Absent;
                    }
                }
                else if (lastStepDateTime < dateTime)
                {
                    timeLine.RemoveAt(i);
                    i -= 1;
                }
            }

            DateStepStatus dateStepStatus_1 = new DateStepStatus() { dateTime = DateTime.Today.AddDays(1), stepStatus = new StepStatus() { Step = 1, Status = Status.NotReached } };
            DateStepStatus dateStepStatus_2 = new DateStepStatus() { dateTime = DateTime.Today.AddDays(2), stepStatus = new StepStatus() { Step = 2, Status = Status.NotReached } };
            DateStepStatus dateStepStatus_4 = new DateStepStatus() { dateTime = DateTime.Today.AddDays(6), stepStatus = new StepStatus() { Step = 4, Status = Status.NotReached } };
            DateStepStatus dateStepStatus_8 = new DateStepStatus() { dateTime = DateTime.Today.AddDays(14), stepStatus = new StepStatus() { Step = 8, Status = Status.NotReached } };
            DateStepStatus dateStepStatus_16 = new DateStepStatus() { dateTime = DateTime.Today.AddDays(30), stepStatus = new StepStatus() { Step = 16, Status = Status.NotReached } };
            DateStepStatus dateStepStatus_32 = new DateStepStatus() { dateTime = DateTime.Today.AddDays(64), stepStatus = new StepStatus() { Step = 32, Status = Status.NotReached } };
            DateStepStatus dateStepStatus_64 = new DateStepStatus() { dateTime = DateTime.Today.AddDays(128), stepStatus = new StepStatus() { Step = 64, Status = Status.NotReached } };
            DateStepStatus dateStepStatus_128 = new DateStepStatus() { dateTime = DateTime.Today.AddDays(256), stepStatus = new StepStatus() { Step = 128, Status = Status.NotReached } };
            timeLine.AddRange(new List<DateStepStatus>()
            {
                dateStepStatus_1,
                dateStepStatus_2,
                dateStepStatus_4,
                dateStepStatus_8,
                dateStepStatus_16,
                dateStepStatus_32,
                dateStepStatus_64,
                dateStepStatus_128
            });
            nextDay = dateStepStatus_1.dateTime;
            if (nextDay == DateTime.MaxValue) throw new Exception("next day have not been set right!");
            var stringifiedTimeline = CodeTimeLine(timeLine);
            return stringifiedTimeline;
        }
        public static string TimeLineToPersian(List<DateStepStatus> timeLine) {
            PersianCalendar persianCalendar = new PersianCalendar();
            if (timeLine is null) throw new Exception("timeline is null - TimeLineToPersian");
            for (int i = 0; i < timeLine.Count; i++)
            {
                if (timeLine[i] is not null)
                {
                    DateTime gregorianDate = timeLine[i].dateTime;
                    timeLine[i].dateTime = new DateTime(persianCalendar.GetYear(gregorianDate), persianCalendar.GetMonth(gregorianDate), persianCalendar.GetDayOfMonth(gregorianDate));
                }
            }
            var stringifiedTimeline = CodeTimeLine(timeLine);
            return stringifiedTimeline;
        }
        public static string TimeLineToGregorian(List<DateStepStatus> timeLine)
        {
            GregorianCalendar gregorianCalendar = new GregorianCalendar();
            PersianCalendar persianCalendar = new PersianCalendar();
            if (timeLine is null) throw new Exception("timeLine is null - TimeLineToGregorian");
            for (int i = 0; i < timeLine.Count; i++)
            {
                if (timeLine[i] is not null)
                {
                    DateTime persianDate = timeLine[i].dateTime;
                    timeLine[i].dateTime = new DateTime(persianDate.Year, persianDate.Month, persianDate.Day, persianCalendar);
                }
            }
            var stringifiedTimeline = CodeTimeLine(timeLine);
            return stringifiedTimeline;
        }
        public static string OperationOnTimeLine_considerAbsentDays(List<DateStepStatus> timeLine)
        {
            DateTime? lastStepDateTime = FindLastStep(timeLine);
            for (int i = 0; i < timeLine.Count; i++)
            {
                DateTime dateTime = timeLine[i].dateTime;
                StepStatus? timeLine_i = timeLine[i].stepStatus;
                if (lastStepDateTime is not null && lastStepDateTime > dateTime)
                {
                    if (timeLine_i is not null)
                    {
                        if (timeLine_i.Status == Status.NotReached) timeLine_i.Status = Status.Absent;
                    }
                }
                else continue;
            }
            var stringifiedTimeline = CodeTimeLine(timeLine);
            return stringifiedTimeline;
        }
    }
}
