using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Diagnostics;
using System.Windows;

namespace WpfApp1.FlashCardApp
{
    internal class FlashCardOperations
    {
        public FlashCard? flashCard = new();
        public int totalFlashCardsCountForToday = 0;
        public FlashCardOperations ()
        {
            int tfccft = 0;
            flashCard = Get(out tfccft);
            totalFlashCardsCountForToday = tfccft;
        }

        public FlashCard? Get(out int total)
        {
            long todayLong = CommonFunctions.DateTimeToLong(DateTime.Today);
            List<FlashCard> forTodayList = new();
            using (SQLiteConnection conn = new(App.dbPath))
            {
                try
                {
                    conn.CreateTable<FlashCard>();
                    forTodayList = (from fcc in conn.Table<FlashCard>()
                              where todayLong >= fcc.NextDay
                              select fcc).ToList();
                } catch (Exception ex)
                {
                    Trace.TraceError(ex.ToString());
                }
            }
            total = forTodayList.Count;
            if (total == 0)
            {
                Trace.WriteLine("bad news is herex");
            }
            if (total > 0)
            {
                var todayRowFromDb = forTodayList[0];
                return todayRowFromDb;
            }
            else return null;
        }
        public string GetQuestion ()
        {
            if (flashCard is null) return "error in GetQuestion";
            else return flashCard.Question!.ToString();
        }
        public string GetAnswer()
        {
            if (flashCard is null) return "error in GetAnswer";
            else return flashCard.Answer!.ToString();
        }
        public static List<DateStepStatus>? GetTimeLine(FlashCard flashCard)
        {
            if (flashCard is null) return null;
            else return TimeLineFunctions.decodeTimeLine(flashCard.TimeLine!);
        }
        public List<DateStepStatus>? GetTimeLine()
        {
            if (flashCard is null) return null;
            else return TimeLineFunctions.decodeTimeLine(flashCard.TimeLine!);
        }
        // page button operations:
        public void ImplementRightAnswerFlashCardToDb (List<DateStepStatus> timeLine) // this should be in DbFunctions
        {
            if (timeLine is null)
            {
                throw new Exception("timeline null in RightAnswerToDb");
            }
            string timeLineAfterSuccess = TimeLineFunctions.OperationOnTimeLine_success(timeLine, out DateTime nextDay);
            flashCard!.TimeLine = timeLineAfterSuccess;
            flashCard!.NextDay = CommonFunctions.DateTimeToLong(nextDay);
            DbFunctions.RightAnswerToDb(flashCard);
        }
        public void ImplementWrongAnswerFlashCardToDb(List<DateStepStatus> timeLine)
        {
            if (timeLine is null)
            {
                throw new Exception("timeline null in WrongAnswerToDb");
            }
            string timeLineAfterFail = TimeLineFunctions.OperationOnTimeLine_fail(timeLine, out DateTime nextDay);
            flashCard!.TimeLine = timeLineAfterFail;
            flashCard!.NextDay = CommonFunctions.DateTimeToLong(nextDay);
            DbFunctions.WrongAnswerToDb(flashCard);
        }
    }
}
