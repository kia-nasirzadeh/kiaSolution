using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SQLite;
using System.Globalization;
using Newtonsoft.Json;
using System.Diagnostics;

namespace WpfApp1.FlashCardApp
{
    public class DbFunctions
    {
        static int PageSize = 100;
        static int Page = 1;
        static bool SelectionChangedEnable = true;
        public static TableManager TableManagerWindow;
        static FlashCard? selectedFlashCard;
        // CRUD:
        public static void CreateQuestion ()
        {
            
            using (SQLiteConnection conn = new(App.dbPath))
            {
                string timeLine_string = TimeLineFunctions.InitATimeLine(out DateTime nextDay);
                List<DateStepStatus> timeLine = TimeLineFunctions.decodeTimeLine(timeLine_string);
                long nextDayLong = CommonFunctions.DateTimeToLong(nextDay);
                string jsonedTimeLine = JsonConvert.SerializeObject(timeLine);
                try
                {
                    conn.CreateTable<FlashCard>();
                    FlashCard flashCard = new FlashCard()
                    {
                        Question = TableManagerWindow.questionBox.Text,
                        Answer = TableManagerWindow.answerBox.Text,
                        TimeLine = jsonedTimeLine,
                        NextDay = nextDayLong,
                        DateModified = CommonFunctions.DateTimeToLong(DateTime.Now)
                    };
                    Trace.WriteLine(nextDay.ToString());
                    conn.Insert(flashCard);
                } catch (SQLiteException e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            Paginate();
        }
        public FlashCard ReadQuestion ()
        {
            using (SQLiteConnection conn = new(App.dbPath))
            {
                conn.CreateTable<FlashCard>();
                var flashCard = (from fc in conn.Table<FlashCard>()
                                 where fc.Id == 6
                                 select fc).FirstOrDefault();
                return flashCard;
            }
        }
        public static void UpdateQuestion ()
        {
            if (!IfSelectedFlashCardExists()) return;
            selectedFlashCard!.Question = TableManagerWindow.questionBox.Text;
            selectedFlashCard.Answer = TableManagerWindow.answerBox.Text;
            using (SQLiteConnection conn = new(App.dbPath))
            {
                try
                {
                    conn.CreateTable<FlashCard>();
                    conn.Update(selectedFlashCard);
                } catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            TableManagerWindow.questionsListView.Items.Refresh();
        }
        public static void DeleteQuestion ()
        {
            if (!IfSelectedFlashCardExists()) return;
            using (SQLiteConnection conn = new(App.dbPath))
            {
                try
                {
                    conn.CreateTable<FlashCard>();
                    conn.Delete(selectedFlashCard);
                }
                catch (SQLiteException e)
                {
                    MessageBox.Show(e.ToString());
                }
                Paginate();
            }
        }
        // Pagination:
        public static void Paginate ()
        {
            using (SQLiteConnection conn = new(App.dbPath))
            {
                try
                {
                    conn.CreateTable<FlashCard> ();
                    var flashCards = (from fcs in conn.Table<FlashCard>()
                                      .OrderByDescending(fcs => fcs.DateModified)
                                      .Skip((Page - 1) * PageSize)
                                      .Take(PageSize)
                                      select fcs).ToList();
                    SelectionChangedEnable = false;
                    TableManagerWindow.questionsListView.ItemsSource = flashCards;
                    SelectionChangedEnable = true;
                } catch (SQLiteException e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
        }
        public static void ASCButton_Click ()
        {
            using (SQLiteConnection conn = new(App.dbPath))
            {
                try
                {
                    conn.CreateTable<FlashCard>();
                    var flashCards = (from fcs in conn.Table<FlashCard>()
                                      .OrderBy(fcs => fcs.DateModified)
                                      .Skip((Page - 1) * PageSize)
                                      .Take(PageSize)
                                      select fcs).ToList();
                    SelectionChangedEnable = false;
                    TableManagerWindow.questionsListView.ItemsSource = flashCards;
                    SelectionChangedEnable = true;
                }
                catch (SQLiteException err)
                {
                    MessageBox.Show(err.ToString());
                }
            }
        }
        public static void DESCButton_Click ()
        {
            using (SQLiteConnection conn = new(App.dbPath))
            {
                try
                {
                    conn.CreateTable<FlashCard>();
                    var flashCards = (from fcs in conn.Table<FlashCard>()
                                      .OrderByDescending(fcs => fcs.DateModified)
                                      .Skip((Page - 1) * PageSize)
                                      .Take(PageSize)
                                      select fcs).ToList();
                    SelectionChangedEnable = false;
                    TableManagerWindow.questionsListView.ItemsSource = flashCards;
                    SelectionChangedEnable = true;
                }
                catch (SQLiteException err)
                {
                    MessageBox.Show(err.ToString());
                }
            }
        }
        public static void TableManagerSelectionChanged (object sender,RoutedEventArgs e)
        {
            selectedFlashCard = (FlashCard)TableManagerWindow.questionsListView.SelectedItem;
            if (!IfSelectedFlashCardExists()) return;
            TableManagerWindow.questionBox.Text = selectedFlashCard.Question;
            TableManagerWindow.answerBox.Text = selectedFlashCard.Answer;
        }
        static bool IfSelectedFlashCardExists ()
        {
            if (SelectionChangedEnable)
            {
                if (selectedFlashCard == null)
                {
                    MessageBox.Show("error: no selected flashCard");
                    return false;
                }
                else return true;
            }
            else
            {
                return false;
            }
        }
        // page button operations:
        public static void RightAnswerToDb(FlashCard flashCard) // this should be in DbFunctions
        {
            using (SQLiteConnection conn = new(App.dbPath))
            {
                try
                {
                    conn.CreateTable<FlashCard>();
                    conn.Update(flashCard);
                }
                catch (SQLiteException e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
        public static void WrongAnswerToDb(FlashCard flashCard)
        {
            using (SQLiteConnection conn = new(App.dbPath))
            {
                try
                {
                    conn.CreateTable<FlashCard>();
                    conn.Update(flashCard);
                }
                catch (SQLiteException e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
    }
}
