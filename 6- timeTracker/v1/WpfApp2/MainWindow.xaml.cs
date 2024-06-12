using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }
    }

    public partial class ViewModel : ObservableObject
    {
        public ISeries[] Series { get; set; } =
        {
            new ColumnSeries<double>
            {
                Values = new double[] { 3, 10, 5, 3, 7, 3, 8, 3, 2.5, 5, 2, 19, 6, 2, 8, 3, 10, 5, 3, 7, 3, 8, 3, 2.5, 5, 2, 19, 6, 2, 8,3, 10, 5, 3, 7, 3, 8, 3, 2.5, 5, 2, 19, 6, 2, 8,3, 10, 5, 3, 7, 3, 8, 3, 2.5, 5, 2, 19, 6, 2, 8,3, 10, 5, 3, 7, 3, 8, 3, 2.5, 5, 2, 19, 6, 2, 8.56 },
                Fill = new SolidColorPaint(SKColors.White),
                DataLabelsPaint = new SolidColorPaint(SKColors.White),
            }
        };

        public Axis[] YAxes { get; set; } =
        {
            new Axis {
                MinLimit = 0, 
                MaxLimit = 24,
                ForceStepToMin = true,
                MinStep = 1,
                Position = LiveChartsCore.Measure.AxisPosition.End
            }
        };

        public Axis[] XAxes { get; set; } =
        {
            new Axis
            {
                MaxLimit = 20,
                LabelsRotation = 90,
                ForceStepToMin = true,
                MinStep = 1,
                Labels = new[] { "1402/1/1", "1402/1/1", "1402/1/1", "1402/1/1", "1402/1/1", "1402/1/1", "1402/1/1", "1402/1/1", "1402/1/1", "1402/1/1", "1402/1/1", "1402/1/1", "1402/1/1" }
            }
        };

        public ObservableCollection<RectangularSection> Sections { get; set; }
           = new ObservableCollection<RectangularSection>
           {
                new() {
                    // creates a section
                    Xi = -10,   //Unable to pass DateTime here
                    Xj = 1000000,
                    Fill = new LiveChartsCore.SkiaSharpView.Painting.SolidColorPaint(SKColors.Black)
                },
           };
    }
}