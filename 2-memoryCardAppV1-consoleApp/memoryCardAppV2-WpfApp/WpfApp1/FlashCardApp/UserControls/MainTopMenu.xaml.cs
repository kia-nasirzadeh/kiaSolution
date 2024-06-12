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
using System.Globalization;

namespace WpfApp1.FlashCardApp.UserControls
{
    /// <summary>
    /// Interaction logic for MainTopMenu.xaml
    /// </summary>
    public partial class MainTopMenu : UserControl
    {
        public MainTopMenu()
        {
            InitializeComponent();
            xbody.Loaded += HandleEvents;
            todayDate.Content = getTodayDate_persian();
        }
        void HandleEvents(object sender, RoutedEventArgs e)
        {
            // handle clickingn:
            IEnumerable<Button> allBtns = UiCommonClasses.FindAllVisualChilds<Button>(xbody);
            foreach (Button btn in allBtns)
            {
                btn.Click += HandleClickingEvents;
            }
        }
        void HandleClickingEvents(object sender, RoutedEventArgs e)
        {
            Button SenderAsButton = (Button)sender;
            switch (SenderAsButton.Name)
            {
                case "tableManagerBtn":
                    TableManager tableManagerWindow = new();
                    tableManagerWindow.Show();
                    break;
            }
        }
        string getTodayDate_persian ()
        {
            PersianCalendar pc = new ();
            string todayDate = pc.GetYear(DateTime.Today).ToString() + "/" + pc.GetMonth(DateTime.Today) + "/" + pc.GetDayOfMonth(DateTime.Today).ToString();
            string dayOfWeek = pc.GetDayOfWeek(DateTime.Today).ToString();
            switch (dayOfWeek)
            {
                case "Monday": dayOfWeek = "دوشنبه"; break;
                case "Tuesday": dayOfWeek = "سه شنبه"; break;
                case "Wednesday": dayOfWeek = "چهارشنبه"; break;
                case "Thursday": dayOfWeek = "پنج شنبه"; break;
                case "Friday": dayOfWeek = "جمعه"; break;
                case "Saturday": dayOfWeek = "شنبه"; break;
                case "Sunday": dayOfWeek = "یک شنبه"; break;
            }
            todayDate = $"امروز {dayOfWeek} {todayDate} است";
            return todayDate;
        }
    }
}