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
using System.Windows.Shapes;
using WpfApp1;

namespace WpfApp1.FlashCardApp
{
    /// <summary>
    /// Interaction logic for TableManager.xaml
    /// </summary>
    public partial class TableManager : Window
    {
        public TableManager()
        {
            InitializeComponent();
            DbFunctions.TableManagerWindow = this;
            WindowState = WindowState.Maximized;
            xbody.Loaded += (s, e) => { questionBox.Focus(); };
            xbody.Loaded += HandleEvents;
            DbFunctions.Paginate();
            // set up question box direction from app settings:
            bool qbOldDir = KiaSolution.AppSettings.AppSettings.GetAppSettings("FlashCardApp", "questionBoxDir");
            if (qbOldDir) questionBox.FlowDirection = FlowDirection.LeftToRight;
            else questionBox.FlowDirection = FlowDirection.RightToLeft;
            // set up answer box direction from app settings:
            bool abOldDir = KiaSolution.AppSettings.AppSettings.GetAppSettings("FlashCardApp", "answerBoxDir");
            if (abOldDir) answerBox.FlowDirection = FlowDirection.LeftToRight;
            else answerBox.FlowDirection = FlowDirection.RightToLeft;
        }
        void HandleEvents (object sender, RoutedEventArgs e)
        {
            // handle clicking events:
            IEnumerable<Button> allBtns = UiCommonClasses.FindAllVisualChilds<Button>(xbody);
            foreach (Button button in allBtns)
            {
                button.Click += HandleClickingEvents;
            }
            // handle pressing events:
        }
        void HandleClickingEvents (object sender, RoutedEventArgs e)
        {
            Button senderToButton = (Button)sender;
            switch (senderToButton.Name)
            {
                case "save":
                    DbFunctions.CreateQuestion();
                    questionBox.Focus();
                    questionBox.Text = "";
                    answerBox.Text = "";
                    break;
                case "update":
                    DbFunctions.UpdateQuestion();
                    questionBox.Focus();
                    questionBox.Text = "";
                    answerBox.Text = "";
                    break;
                case "delete":
                    DbFunctions.DeleteQuestion();
                    questionBox.Focus();
                    questionBox.Text = "";
                    answerBox.Text = "";
                    break;
                case "ASCButton":
                    DbFunctions.ASCButton_Click();
                    break;
                case "DESCButton":
                    DbFunctions.DESCButton_Click();
                    break;
                case "qbDirBtn":
                    qbChangeDir();
                    break;
                case "abDirBtn":
                    abChangeDir();
                    break;
            }
        }
        // declare partial methods:
        public void EditBtnClicked(object sender, RoutedEventArgs e)
        {
            var boundData = (FlashCard)((Button)sender).DataContext;
            FlashCardEdit fce = new(boundData, this);
            fce.Show();
        }
        void TableManagerSelectionChanged(object sender, RoutedEventArgs e)
        {
            DbFunctions.TableManagerSelectionChanged(sender, e);
        }
        void qbChangeDir ()
        {
            bool oldDir = KiaSolution.AppSettings.AppSettings.GetAppSettings("FlashCardApp", "questionBoxDir");
            if (oldDir) questionBox.FlowDirection = FlowDirection.RightToLeft;
            else questionBox.FlowDirection = FlowDirection.LeftToRight;
            KiaSolution.AppSettings.AppSettings.ChangeAppSettings_qbDir();
            questionBox.Focus();
        }
        void abChangeDir ()
        {
            bool oldDir = KiaSolution.AppSettings.AppSettings.GetAppSettings("FlashCardApp", "answerBoxDir");
            if (oldDir) answerBox.FlowDirection = FlowDirection.RightToLeft;
            else answerBox.FlowDirection = FlowDirection.LeftToRight;
            KiaSolution.AppSettings.AppSettings.ChangeAppSettings_abDir();
            answerBox.Focus();
        }
        public void Paginate ()
        {
            DbFunctions.Paginate();
        }
    }
}
