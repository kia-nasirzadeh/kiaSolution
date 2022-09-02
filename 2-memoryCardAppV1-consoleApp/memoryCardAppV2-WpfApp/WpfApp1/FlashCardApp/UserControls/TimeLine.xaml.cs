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

namespace WpfApp1.FlashCardApp.UserControls
{
    /// <summary>
    /// Interaction logic for TimeLine.xaml
    /// </summary>
    public partial class TimeLine : UserControl
    {
        public TimeLine()
        {
            InitializeComponent();
            TotalConverter.mainTimeLine = this;
        }
        public FlashCard FlashCard
        {
            get { return (FlashCard)GetValue(FlashCardProperty); }
            set { SetValue(FlashCardProperty, value); }
        }
        public static readonly DependencyProperty FlashCardProperty =
            DependencyProperty.Register(
                "FlashCard",
                typeof(FlashCard),
                typeof(TimeLine),
                new PropertyMetadata(new FlashCard() { Id = 1, Answer = ":(", Question = ":(", TimeLine = ":(", NextDay = 0  }, SetListViewContents)
            );
        static void SetListViewContents (DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TimeLine timeLineDepObj = (TimeLine)d;
            FlashCard fc = (FlashCard)e.NewValue;
            string timeLine_string = TimeLineFunctions.OperationOnTimeLine_considerAbsentDays(FlashCardOperations.GetTimeLine(fc)!);
            List<DateStepStatus> timeLine = TimeLineFunctions.decodeTimeLine(timeLine_string);
            if (!PutChangedTimeLineIntoDataBase(fc.Question!, fc.Answer!, timeLine, fc.NextDay, fc)) MessageBox.Show("error in adding to database");
            List<DateStepStatus> timeLineToShow = fc.TimeLineToShow_Persian!;
            timeLineDepObj.timelineListView.ItemsSource = timeLineToShow;
        }
        static bool PutChangedTimeLineIntoDataBase (string question_, string answer_, List<DateStepStatus> timeLine_, long nextDay_, FlashCard fc_)
        {
            string jsonedTimeLine = JsonConvert.SerializeObject(timeLine_);
            fc_.Question = question_;
            fc_.Answer = answer_;
            fc_.TimeLine = jsonedTimeLine;
            fc_.NextDay = nextDay_;
            fc_.DateModified = CommonFunctions.DateTimeToLong(DateTime.Now);
            using (SQLiteConnection conn = new(App.dbPath))
            {
                try
                {
                    conn.CreateTable<FlashCard>();
                    conn.Update(fc_);
                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
            }
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = (ComboBox)sender;
            var boundData = (DateStepStatus)(comboBox).DataContext;
            ComboBoxItem comboAsTextblock = (ComboBoxItem)comboBox.SelectedItem;
            string? comboBoxItemText = comboAsTextblock.Content.ToString();
            Status currentStatus = boundData.stepStatus!.Status;
            Status requestedStatus = (Status)Enum.Parse(typeof(Status), comboBoxItemText!, true);
            if (currentStatus == requestedStatus) MessageBox.Show("you are already on this status !");
            else if (currentStatus == Status.NotReached) MessageBox.Show("you didn't even reach the date you want to change \nso you can't do it");
            else
            {
                var Result = MessageBox.Show("are you sure?", "system check", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (Result == MessageBoxResult.Yes)
                {
                    ((DateStepStatus)(comboBox).DataContext).stepStatus!.Status = requestedStatus;
                    timelineListView.Items.Refresh();
                    List<DateStepStatus>? changedTimeLineSource = (List<DateStepStatus>)timelineListView.ItemsSource; // this is with persian dates
                    changedTimeLineSource = TimeLineFunctions.decodeTimeLine(TimeLineFunctions.CodeTimeLine(changedTimeLineSource)!); // code & decode timeline to cut pass by reference
                    string stringifiedChangedTimeline = TimeLineFunctions.TimeLineToGregorian(changedTimeLineSource!);
                    FlashCard.TimeLine = stringifiedChangedTimeline;
                }
                else
                {
                    MessageBox.Show("it was no");
                }
            }
        }
    }
    public class TotalConverter : IMultiValueConverter
    {
        public static TimeLine? mainTimeLine;
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double totalWidth = System.Convert.ToDouble(values[0]);
            double timeLineCount = mainTimeLine!.timelineListView.Items.Count; // ToDo: Ooops :(
            return totalWidth / timeLineCount;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class DateTimeConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string timelineDateTime = values[0].ToString()!;
            string myDateTime = timelineDateTime.Split(' ')[0];
            return myDateTime;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
