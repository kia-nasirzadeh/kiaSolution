using System;
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

namespace WpfApp1.FlashCardApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Main : Window
    {
        string question;
        string answer;
        string total;
        string? lastFlashCard;
        List<DateStepStatus>? timeLine;
        List<DateStepStatus> timeLineToShow;
        FlashCardOperations? fco;
        public Main ()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            xbody.Loaded += StartApp;
            xbody.Loaded += HandleEvents;
            InitThisPageFlashCard();
        }
        void StartApp(object sender, RoutedEventArgs e)
        {
            //// say hello:
            //MessageBox.Show("hello");
            // set focuse:
            answerBox.Focus();
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
        void HandleKeyPressingEvents (object sender, KeyEventArgs e)
        {
            switch (e.Key.ToString())
            {
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
            }
        }
        void HandleClickingEvents (object sender, RoutedEventArgs e)
        {
            Button SenderAsButton = (Button)sender;
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
            }
        }
        private void ManageFlashCard()
        {
            FlashCardEdit flashCardEditWindow = new(fco.flashCard!);
            flashCardEditWindow.Show();
        }
        private void FailedAnswer()
        {
            string stringifiedFlashCard = JsonConvert.SerializeObject(fco.flashCard!);
            lastFlashCard = stringifiedFlashCard;
            fco.ImplementWrongAnswerFlashCardToDb(timeLine!);
            InitThisPageFlashCard();
        }
        private void AnsweredRight()
        {
            string stringifiedFlashCard = JsonConvert.SerializeObject(fco.flashCard!);
            lastFlashCard = stringifiedFlashCard;
            fco.ImplementRightAnswerFlashCardToDb(timeLine!);
            InitThisPageFlashCard();
        }
        private void ShowAnswer()
        {
            dbAnswerBox.Text = answer;
        }
        //
        private void InitThisPageFlashCard ()
        {
            fco = new();
            timeLine = fco.GetTimeLine();
            question = fco.GetQuestion();
            if (question == "error in GetQuestion")
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
            answerBox.Text = "";
            questionBox.Content = question;
            userControlsTimeLine.FlashCard = fco.flashCard;
            answer = fco.GetAnswer();
            total = (string)fco.totalFlashCardsCountForToday.ToString();
            remainingQuestionLabel.Content = $"{total} :تعداد فلش کارد های باقی مانده امروز";
        }
        private void InitEmptyFlashCard ()
        {
            EmptyMain emptyMain = new();
            emptyMain.Show();
            Close();
        }
        private void undo_Click (object sender, RoutedEventArgs e)
        {
            FlashCard? lastFlashCard_ = (FlashCard)JsonConvert.DeserializeObject<FlashCard>(lastFlashCard!);
            fco.flashCard = lastFlashCard_;
            if (lastFlashCard_ == null)
            {
                MessageBox.Show("there is nothing to undo in");
                return;
            }
            question = lastFlashCard_.Question!.ToString();
            FlashCard fc = lastFlashCard_;
            if (fc == null)
            {
                MessageBox.Show("this is wrong !, no lastflashcard here :(");
                return;
            }
            answerBox.Text = "";
            questionBox.Content = question;
            userControlsTimeLine.FlashCard = lastFlashCard_;
            answer = lastFlashCard_.Answer!.ToString();
            total = (string)fco.totalFlashCardsCountForToday.ToString();
            remainingQuestionLabel.Content = $"{total} :تعداد فلش کارد های باقی مانده امروز";
        }
    }
    
}
