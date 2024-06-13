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
        static DateTime? FindFurthestStep(List<DateStepStatus> timeLine)
        {
            // 1- find post times timeline
            DateTime? LastStepDateTime = null;
            List<DateStepStatus> postTimes_TimeLine = new();
            if (timeLine is null) return null;
            for (int i = 0; i < timeLine.Count; i++)
            {
                DateTime dateTime = timeLine[i].dateTime;
                if (DateTime.Today >= dateTime)
                {
                    postTimes_TimeLine.Add(timeLine[i]);
                }
                else continue;
            }
            if (postTimes_TimeLine.Count == 0) throw new Exception("no previous times timeLine");
            if (postTimes_TimeLine.Count == 1) return postTimes_TimeLine[0].dateTime; // we are in first day after building flashCard
            // 2- extract last success/Failed or first absent from today
            List<DateStepStatus> postTimesAbsents_timeline = postTimes_TimeLine.Where(c => c.stepStatus!.Status == Status.Absent).ToList();
            if (postTimesAbsents_timeline.Count == 0) return postTimes_TimeLine[postTimes_TimeLine.Count - 2].dateTime; // no absent days before, so current day step is max step
            DateTime? firstAbsentDay_dateTime = null;
            if (postTimesAbsents_timeline.Count > 0)
                firstAbsentDay_dateTime = postTimesAbsents_timeline.Min(i => i.dateTime); // we have no absent day
            for (int i = postTimes_TimeLine.Count - 1;i >= 0; i--)
            {
                DateStepStatus timelineItem = postTimes_TimeLine[i];
                if (timelineItem.stepStatus!.Status == Status.Failed || timelineItem.stepStatus!.Status == Status.Succeed)
                {
                    if (timelineItem.dateTime > firstAbsentDay_dateTime)
                    {
                        LastStepDateTime = timelineItem.dateTime;
                        return LastStepDateTime;
                    } else continue;
                }
            }
            if (firstAbsentDay_dateTime == null)
            {
                MessageBox.Show("we have errrrorr");
                MessageBox.Show(JsonConvert.SerializeObject(timeLine));
                MessageBox.Show(JsonConvert.SerializeObject(postTimesAbsents_timeline));
                throw new Exception("we have error"); // we can not be here at all! cause we should have absent or Succeed/Failed day in post times
            }
            LastStepDateTime = firstAbsentDay_dateTime;
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
        public static int FindMaximumStep (double spanDays)
        {
            if (spanDays == 0) return 1;
            List<int> steps = new List<int>() { 1, 2, 4, 8, 16, 32, 64, 128 };
            List<int> spansMinusSteps = new();
            for (int i = 0; i < steps.Count; i++)
            {
                int step = steps[i];
                if (spanDays - step >= 0)
                    spansMinusSteps.Add((int)spanDays - step);
            }
            int index = spansMinusSteps.Count - 1;
            if (index < 0) // we are in the end, timeline is done
            {
                return -1;
            }
            return steps[index];
        }
        public static string OperationOnTimeLine_success(List<DateStepStatus> timeLine, out DateTime nextDay)
        {
            if (timeLine == null)
            {
                MessageBox.Show("null in OperationOnTimeLine_success :((");
            }
            nextDay = DateTime.MaxValue;
            DateTime? furthestDateTime = FindFurthestStep(timeLine!);
            if (furthestDateTime is null) throw new Exception("lastStepDateTime is null - OperationOnTimeLine_success");
            var betweenDays = (DateTime.Today - (DateTime)furthestDateTime).TotalDays;
            int maxStep = FindMaximumStep(betweenDays);
            if (maxStep == -1) throw new Exception("flash card is wrongly opened, it ended and you should not be here");
            List<DateStepStatus> newTimeline = new(); // old timeline with only former DateStepStatus
            for (int i = 0; i < timeLine!.Count; i++)
            {
                DateTime dateTime = timeLine[i].dateTime;
                StepStatus? timeLine_i = timeLine[i].stepStatus;
                if (furthestDateTime >= dateTime && maxStep != 1) //keep it
                {
                    newTimeline.Add(timeLine[i]);
                }
            }
            List<DateStepStatus> rawStepsItems = new();
            List<int> rawSteps = new List<int> { 1, 2, 4, 8, 16, 32, 64, 128 };
            int index = rawSteps.FindIndex(a => a.ToString().Contains(maxStep.ToString()));
            for (int i = index; i < 8; i++)
            {
                if (i == index) // here is Today
                {
                    DateStepStatus dateStepStatus_ = new DateStepStatus() { dateTime = DateTime.Today, stepStatus = new StepStatus() { Step = rawSteps[i], Status = Status.Succeed } };
                    rawStepsItems.Add(dateStepStatus_);
                } else
                {
                    int daysToAdd = 0;
                    for (int j = index; j < i; j++) // here is next days
                    {
                        daysToAdd += rawSteps[j + 1];
                    }
                    DateStepStatus dateStepStatus_ = new DateStepStatus() { dateTime = DateTime.Today.AddDays(daysToAdd), stepStatus = new StepStatus() { Step = rawSteps[i], Status = Status.NotReached } };
                    rawStepsItems.Add(dateStepStatus_);
                }
            }
            for (int i = 0; i < rawStepsItems.Count; i++) // in loop vase ine ke nextDay peyda beshe va baghieye newTimeLine saakhte beshe
            {
                if (i == 0) rawStepsItems[i].stepStatus!.Status = Status.Succeed; // this seems that is happening twice
                if (i == 0 && rawStepsItems.Count == 1) nextDay = DateTime.UnixEpoch; // yek rooz moonde bood k oonm success shod pas dg tamoome
                if (i == 1) nextDay = rawStepsItems[i].dateTime; // nextDay ro baraye step e badi tarid mikonim
                newTimeline.Add(rawStepsItems[i]);
            }
            if (nextDay == DateTime.MaxValue) throw new Exception("next day have not been set right!");
            var _128Step = newTimeline[newTimeline.Count - 1].stepStatus.Step; // 128
            var _128Status = newTimeline[newTimeline.Count - 1].stepStatus.Status; // Succeed
            if (_128Step.ToString() == "128" && _128Status.ToString() == "Succeed") // we ended this fc
            {
                return "";
            } else
            {
                var stringifiedTimeline = CodeTimeLine(newTimeline);
                return stringifiedTimeline;
            }
        }
        public static string OperationOnTimeLine_skip(List<DateStepStatus> timeLine, out DateTime nextDay)
        {
            nextDay = DateTime.MaxValue;
            DateTime? lastStepDateTime = FindLastStep(timeLine);
            if (lastStepDateTime is null) throw new Exception("lastStepDateTime is null - OperationOnTimeLine_fail");
            for (int i = 0; i < timeLine.Count; i++)
            {
                DateTime dateTime = timeLine[i].dateTime;
                StepStatus? timeLine_i = timeLine[i].stepStatus;
                if (lastStepDateTime == dateTime) // today
                {
                    if (timeLine_i is not null)
                    {
                        timeLine_i.Status = Status.Absent;
                    }
                }
                else if (lastStepDateTime > dateTime) // former absent days
                {
                    if (timeLine_i is not null)
                    {
                        if (timeLine_i.Status == Status.NotReached) timeLine_i.Status = Status.Absent;
                    }
                }
            }

            
            nextDay = DateTime.Today.AddDays(1);
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
                if (lastStepDateTime == dateTime) // today
                {
                    if (timeLine_i is not null)
                    {
                        timeLine_i.Status = Status.Failed;
                    }
                }
                else if (lastStepDateTime > dateTime) // former absent days
                {
                    if (timeLine_i is not null)
                    {
                        if (timeLine_i.Status == Status.NotReached) timeLine_i.Status = Status.Absent;
                    }
                }
                else if (lastStepDateTime < dateTime) // coming days
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
            MessageBox.Show("we must not go into this function/ 15-bahman-1401/ we put this comment in case this func is needed in application otherwise we will remove this func later");
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
            MessageBox.Show("xpa-we must not go into this function/ 15-bahman-1401/ we put this comment in case this func is needed in application otherwise we will remove this func later");
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
