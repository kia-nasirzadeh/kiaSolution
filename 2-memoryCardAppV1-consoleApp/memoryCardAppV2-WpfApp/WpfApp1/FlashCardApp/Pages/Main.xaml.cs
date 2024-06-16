using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using SQLite;
using Newtonsoft.Json;
using System.Windows.Threading;
using System.ComponentModel;
using System.Threading;
using System.Text.RegularExpressions;

namespace WpfApp1.FlashCardApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Main : Window
    {
        DispatcherTimer timer = new();
        int timerSeconds = 60;
        string question;
        string answer;
        string total;
        string qaToCopy;
        string qaToCopyForWrongsFile;
        string? lastFlashCard = null;
        string lastAnswerStatus = "undefined";
        bool instantiatedFromTableManager = false;
        bool fullscreen = false;
        public bool noFlashCardForToday = false;
        List<DateStepStatus>? timeLine;
        List<DateStepStatus> timeLineToShow;
        FlashCardOperations? fco;
        public Main (bool instantiatedFromTableManager = false)
        {
            InitializeComponent();
            if (instantiatedFromTableManager) this.instantiatedFromTableManager = true;
            WindowState = WindowState.Maximized;
            //var workArea = SystemParameters.WorkArea;
            //xbody.Left = 0;
            //xbody.Top = 0;
            //xbody.Width = workArea.Width;
            //xbody.Height = workArea.Height;

            xbody.Loaded += StartApp;
            xbody.Loaded += HandleEvents;
            InitThisPageFlashCard();
        }
        void StartApp(object sender, RoutedEventArgs e)
        {
            //// say hello:
            //MessageBox.Show("hello");
            // set focuse:
            timer.Interval = TimeSpan.FromSeconds(1);

            timer.Tick += (object s, EventArgs e) =>
            {
                int currenttime = Int32.Parse(timerLabel.Content.ToString()!);
                //MessageBox.Show($"1:{currenttime}");
                currenttime = currenttime - 1;
                //MessageBox.Show($"2:{currenttime}");
                timerLabel.Content = currenttime.ToString();
                if (currenttime < 0)
                {
                    EndTimer();
                    timer.Stop();
                }
            };
        }
        void HandleEvents (object sender, RoutedEventArgs e)
        {
            // handle clickingn:
            IEnumerable<Button> allBtns = UiCommonClasses.FindAllVisualChilds<Button>(xbody);
            foreach (Button btn in allBtns)
            {
                btn.Click += HandleClickingEvents;
            }
            // handle key pressing:
            xbody.KeyUp += HandleKeyPressingEvents;
        }
        public void ShowAnswerShortcut(Object sender, ExecutedRoutedEventArgs e)
        {
            ShowAnswer();
        }
        public void RightAnswerShortcut(Object sender, ExecutedRoutedEventArgs e)
        {
            AnsweredRight();
        }
        public void WrongAnswerShortcut(Object sender, ExecutedRoutedEventArgs e)
        {
            FailedAnswer();
        }
        void HandleKeyPressingEvents (object sender, KeyEventArgs e)
        {
            //if (e.ke)
            //{
            //    MessageBox.Show("My message");
            //}
            switch (e.Key.ToString())
            {
                case "NumPad0":
                    Skip();
                    break;
                case "NumPad1":
                    ShowAnswer();
                    break;
                case "NumPad2":
                    AnsweredRight();
                    break;
                case "NumPad3":
                    FailedAnswer();
                    break;
                case "NumPad4":
                    ManageFlashCard();
                    break;
                case "tableManagerBtn":
                    TableManager tableManagerWindow = new();
                    tableManagerWindow.Show();
                    break;
                case "NumPad5":
                    OkCopyFunc();
                    break;
                case "NumPad6":
                    latest_Click();
                    break;
                case "NumPad9":
                    ToggleFullScreen();
                    break;
            }
        }
        void HandleClickingEvents (object sender, RoutedEventArgs e)
        {
            Button SenderAsButton = (Button)sender;
            //MessageBox.Show(SenderAsButton.Name);
            switch (SenderAsButton.Name)
            {
                case "showBtn":
                    ShowAnswer();
                    break;
                case "answeredBtn":
                    AnsweredRight();
                    break;
                case "failedBtn":
                    FailedAnswer();
                    break;
                case "manageBtn":
                    ManageFlashCard();
                    break;
                case "undo_btn":
                    undo_Click();
                    break;
                case "latest_btn":
                    latest_Click();
                    break;
                case "skipBtn":
                    Skip();
                    break;
            }
        }
        void ToggleFullScreen()
        {
            WindowState = WindowState.Normal;
            if (fullscreen) // already in fullscreen mode, go out
            {
                WindowState = WindowState.Maximized;
                xbody.WindowStyle = WindowStyle.SingleBorderWindow;
                buttons.Visibility = Visibility.Visible;
                timelinePanel.Visibility = Visibility.Visible;
                topRightPanel.Visibility = Visibility.Visible;
                topLeftPanel.Visibility = Visibility.Visible;
                mainGridRow1.Height = new GridLength(1, GridUnitType.Star);
                mainGridRow2.Height = new GridLength(14, GridUnitType.Star);
                mainGridRow3.Height = new GridLength(1, GridUnitType.Star);
                mainGridRow4.Height = new GridLength(2, GridUnitType.Star);
                fullscreen = false;
            } else // already in normal mode, go fullscreen
            {
                xbody.WindowStyle = WindowStyle.None;
                WindowState = WindowState.Maximized;
                buttons.Visibility = Visibility.Hidden;
                timelinePanel.Visibility = Visibility.Hidden;
                topRightPanel.Visibility = Visibility.Hidden;
                topLeftPanel.Visibility = Visibility.Hidden;
                mainGridRow1.Height = new GridLength(0, GridUnitType.Star);
                mainGridRow2.Height = new GridLength(1, GridUnitType.Star);
                mainGridRow3.Height = new GridLength(0, GridUnitType.Star);
                mainGridRow4.Height = new GridLength(0, GridUnitType.Star);
                fullscreen = true;
            }
        }
        private void ManageFlashCard()
        {
            FlashCardEdit flashCardEditWindow = new(fco.flashCard!, new TableManager());
            flashCardEditWindow.Show();
        }
        private void FailedAnswer()
        {
            // add wrong q&a to wongs.txt --start section
            AppendToWrongsFile(qaToCopyForWrongsFile);
            // --end section
            string stringifiedFlashCard = JsonConvert.SerializeObject(fco.flashCard!);
            lastFlashCard = stringifiedFlashCard;
            fco.ImplementWrongAnswerFlashCardToDb(timeLine!);
            lastAnswerStatus = "prev:" + Environment.NewLine + "❌";
            InitThisPageFlashCard();
        }
        public void AppendToWrongsFile(string textToWrite)
        {
            string filePath = App.appRootPath + "wrongs.txt";
            using (StreamWriter writer = new StreamWriter(filePath, true)) // Set append mode to true
            {
                writer.WriteLine(textToWrite);
            }
        }
        void ChangeLayoutMode(string mode)
        {
            if (mode == "reading")
            {
                mainGridColumn2.Width = new System.Windows.GridLength(2, GridUnitType.Star);
                mainGridColumn3.Width = new System.Windows.GridLength(4, GridUnitType.Star);
            } else // asking
            {
                mainGridColumn2.Width = new System.Windows.GridLength(1.7, GridUnitType.Star);
                mainGridColumn2.Width = new System.Windows.GridLength(1.7, GridUnitType.Star);
                mainGridColumn3.Width = new System.Windows.GridLength(1, GridUnitType.Star);
            }
        }
        private void AnsweredRight()
        {
            string stringifiedFlashCard = JsonConvert.SerializeObject(fco.flashCard!);
            lastFlashCard = stringifiedFlashCard;
            fco.ImplementRightAnswerFlashCardToDb(timeLine!);
            lastAnswerStatus = "prev:" + Environment.NewLine + "✔️";
            InitThisPageFlashCard();
        }
        private void Skip()
        {
            string stringifiedFlashCard = JsonConvert.SerializeObject(fco.flashCard!);
            lastFlashCard = stringifiedFlashCard;
            fco.ImplementSkipedFlashCardToDb(timeLine!);
            lastAnswerStatus = "prev:" + Environment.NewLine + "⏳";
            InitThisPageFlashCard();
        }
        private void ShowAnswer()
        {
            ChangeLayoutMode("reading");
            dbAnswerBox.FontFamily = new FontFamily("Segoe UI");
            dbAnswerBox.FontSize = 20;
            if (answer.Contains("~[[")) CommonFunctions.GetText_openLinks(answer);
            if (answer.Contains("~mono"))
            {
                dbAnswerBox.FontFamily = new FontFamily("Lucida Console");
                dbAnswerBox.FontSize = 12;
                answer = answer.Remove(answer.IndexOf("~mono"), answer.IndexOf("~mono") + 5);
            }
            dbAnswerBox.Text = answer;
        }
        //
        private void ImplementAFlashCardOnPage (FlashCardOperations fcoo)
        {
            ChangeLayoutMode("asking");
            lastAnswerLabel.Content = lastAnswerStatus;
            timeLine = fcoo.GetTimeLine();
            question = fcoo.GetQuestion();
            if (question == "flash card is null")
            {
                InitEmptyFlashCard();
                return;
            }
            FlashCard fc = fco.flashCard!;
            if (fc == null)
            {
                MessageBox.Show("this is wrong ! :(");
                return;
            }
            questionBox.Text = question;
            if (question.Contains("~[[")) CommonFunctions.GetText_openLinks(question);
            answerBox.Text = "";
            dbAnswerBox.Text = "";
            userControlsTimeLine.FlashCard = fco.flashCard;
            answer = fco.GetAnswer();
            qaToCopy = question + "\n╟╟────────────────────────────────────────╢╢\n╟╟────────────────────────────────────────╢╢\n" + answer;
            qaToCopyForWrongsFile = question + "\n╟+-+-+-+-+-+-+-+-+-+-+-╢\n" + answer + "\n╟╟—————————————————————————————╢╢\n╟╟—————————————————————————————╢╢\n";

            var totalRemainingFlashCards = fco.totalFlashCardsCountForToday;
            total = (string)totalRemainingFlashCards.ToString();
            var estimatedTotalTime_hour = Math.Floor(totalRemainingFlashCards / (float)60);
            var estimatedTotalTime_decimal = totalRemainingFlashCards / (float)60 - Math.Floor(totalRemainingFlashCards / (float)60);
            var estimatedTotalTime_min = Math.Round(estimatedTotalTime_decimal * 60);
            var estimatedEndingTime = DateTime.Now.AddMinutes(estimatedTotalTime_hour * 60 + estimatedTotalTime_min).ToString("HH:mm");
            remainingQuestionLabel.Content = "~" + estimatedTotalTime_hour.ToString() + " h " + estimatedTotalTime_min + " min ▬ ending in " + estimatedEndingTime + " ▬ " + total;
            var tbl = new TextBlock();
            tbl.Inlines.Add(new Run("~") { });
            tbl.Inlines.Add(new Run(estimatedTotalTime_hour.ToString()) { FontWeight = FontWeights.Bold });
            tbl.Inlines.Add(new Run("h:") { FontWeight = FontWeights.Bold });
            tbl.Inlines.Add(new Run(estimatedTotalTime_min.ToString()) { FontWeight = FontWeights.Bold });
            tbl.Inlines.Add(new Run("min ") { FontWeight = FontWeights.Bold });
            tbl.Inlines.Add(new Run("| ending in ") { });
            tbl.Inlines.Add(new Run(estimatedEndingTime) { FontWeight = FontWeights.Bold, Foreground = Brushes.DarkBlue, FontSize = 18 });
            tbl.Inlines.Add(new Run(" | ") { });
            tbl.Inlines.Add(new Run(total) { FontWeight = FontWeights.Bold });
            tbl.Inlines.Add(new Run(" :تعداد فلش کارد های باقی مانده امروز") { });
            remainingQuestionLabel.Content = tbl;
            timer.Stop();
            StartTimer();
            answerBox.Focus();
        }
        private void OkCopyFunc ()
        {
            Clipboard.SetText(qaToCopy);
        }
        private void InitThisPageFlashCard () // undo should act like initThisPageFlashCard just with different flashcard!
        {
            fco = new(null);
            ImplementAFlashCardOnPage(fco);
        }
        private void InitEmptyFlashCard ()
        {
            noFlashCardForToday = true;
            EmptyMain emptyMain = new();
            emptyMain.Show();
            if (!instantiatedFromTableManager) Close();
        }
        private void undo_Click ()
        {
            if (lastFlashCard == null)
            {
                MessageBox.Show("nothing to undo");
                return;
            }
            FlashCard? lastFlashCard_ = JsonConvert.DeserializeObject<FlashCard>(lastFlashCard!)!;
            fco = new FlashCardOperations(lastFlashCard_);
            ImplementAFlashCardOnPage(fco);
        }
        private void latest_Click ()
        {
            if (lastFlashCard == null)
            {
                MessageBox.Show("you have no latest flashcard");
                return;
            }
            FlashCard? lastFlashCard_ = (FlashCard)JsonConvert.DeserializeObject<FlashCard>(lastFlashCard!)!; //this is not edited flashcard after last answer
            int lastFlashCardId = lastFlashCard_.Id;
            FlashCard lastFlashCard_editedVersion = DbFunctions.GetFlashCardById(lastFlashCardId);
            FlashCardEdit flashCardEditWindow = new(lastFlashCard_editedVersion, new TableManager());
            flashCardEditWindow.Show();
        }
        // timer functions
        private void StartTimer ()
        {
            timerLabel.Background = Brushes.Lime;
            timerLabel.Foreground = Brushes.Black;
            timerLabel.Content = timerSeconds;
            timer.Start();
        }
        private void EndTimer ()
        {
            timerLabel.Background = Brushes.Red;
            timerLabel.Foreground = Brushes.DarkRed;
            timerLabel.Content = "0";
        }
    }
    
}
