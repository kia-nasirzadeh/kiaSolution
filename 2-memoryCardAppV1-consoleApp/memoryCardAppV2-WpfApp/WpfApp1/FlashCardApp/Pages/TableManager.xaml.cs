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
                    break;
                case "update":
                    DbFunctions.UpdateQuestion();
                    break;
                case "delete":
                    DbFunctions.DeleteQuestion();
                    break;
                case "ASCButton":
                    DbFunctions.ASCButton_Click();
                    break;
                case "DESCButton":
                    DbFunctions.DESCButton_Click();
                    break;

            }
        }
        // declare partial methods:
        public void EditBtnClicked(object sender, RoutedEventArgs e)
        {
            var boundData = (FlashCard)((Button)sender).DataContext;
            FlashCardEdit fce = new(boundData);
            fce.Show();
        }
        void TableManagerSelectionChanged(object sender, RoutedEventArgs e)
        {
            DbFunctions.TableManagerSelectionChanged(sender, e);
        }


    }
}
