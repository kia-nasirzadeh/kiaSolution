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
using SQLite;

namespace WpfApp1.FlashCardApp
{
    /// <summary>
    /// Interaction logic for FlashCardEdit.xaml
    /// </summary>
    public partial class FlashCardEdit : Window
    {
        FlashCard flashCard = new();
        public FlashCardEdit(FlashCard fc)
        {
            InitializeComponent();
            flashCard = fc;
            WindowState = WindowState.Maximized;
            questionLabel.Content = fc.Question;
            answerLabel.Content = fc.Answer;
            TimeLineFunctions.LogTimeLineOnOutput(TimeLineFunctions.decodeTimeLine(fc.TimeLine));
            userControlsTimeLine.FlashCard = fc;

        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            string? currentTimeLine = userControlsTimeLine.FlashCard.TimeLine;

            using (SQLiteConnection conn = new(App.dbPath))
            {
                try
                {
                    conn.CreateTable<FlashCard>();
                    conn.Update(userControlsTimeLine.FlashCard);
                    MessageBox.Show("changes saved successfuly", "system info message", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
