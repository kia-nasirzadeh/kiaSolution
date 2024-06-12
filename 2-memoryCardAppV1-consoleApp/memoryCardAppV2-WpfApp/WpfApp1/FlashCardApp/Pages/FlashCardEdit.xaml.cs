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
        TableManager tableManagerWindow;
        public FlashCardEdit(FlashCard fc, TableManager motherTableManager)
        {
            InitializeComponent();
            flashCard = fc;
            WindowState = WindowState.Maximized;
            questionLabel.Text = fc.Question;
            answerLabel.Text = fc.Answer;
            TimeLineFunctions.LogTimeLineOnOutput(TimeLineFunctions.decodeTimeLine(fc.TimeLine));
            userControlsTimeLine.FlashCard = fc;
            tableManagerWindow = motherTableManager;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            string? currentTimeLine = userControlsTimeLine.FlashCard.TimeLine;

            using (SQLiteConnection conn = new(App.dbPath))
            {
                try
                {
                    conn.CreateTable<FlashCard>();
                    flashCard = userControlsTimeLine.FlashCard;
                    flashCard.Question = questionLabel.Text;
                    flashCard.Answer = answerLabel.Text;
                    conn.Update(flashCard);
                    MessageBox.Show("changes saved successfuly", "system info message", MessageBoxButton.OK, MessageBoxImage.Information);
                    tableManagerWindow.Paginate();
                    this.Close();
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
