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
using WpfApp1.FlashCardApp;

namespace KiaSolution.FlashCardApp.Pages
{
    /// <summary>
    /// Interaction logic for ChangeDb.xaml
    /// </summary>
    public partial class ChangeDb : Window
    {
        public ChangeDb()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }

        private void Button_shorts_Click(object sender, RoutedEventArgs e)
        {
            WpfApp1.FlashCardApp.TableManager tbl_manager_window = new();
            tbl_manager_window.Show();
            this.Close();
        }        
        private void Button_projects_Click(object sender, RoutedEventArgs e)
        {
            App.dbPath = App.dbPath_projects;
            WpfApp1.FlashCardApp.TableManager tbl_manager_window = new();
            tbl_manager_window.Show();
            this.Close();
        }
    }
}
