using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using Forms = System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Forms;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing.Imaging;
using System.Windows.Shell;

namespace ttrack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            IntPtr windowHandle = new WindowInteropHelper(this).Handle;


            // old approach:
            Bitmap bmp = new(64, 32);
            RectangleF rectf = new RectangleF(0, 0, 64, 32);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.FillRectangle(System.Drawing.Brushes.Black, rectf);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.ScaleTransform(2, 1);
                g.DrawString("65", new System.Drawing.Font("Arial", 20), System.Drawing.Brushes.White, rectf,StringFormat.GenericTypographic);
                g.Flush();
            }

            BitmapImage bitmapImage = new BitmapImage();
            using (MemoryStream ms = new MemoryStream())
            {
                bmp.Save(ms, ImageFormat.Png); // Or any other supported format
                ms.Position = 0;
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = ms;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
            }
            ximg.Source = bitmapImage;



            // new approach:
            TaskbarItemInfo = new();
            TaskbarItemInfo.Overlay = bitmapImage;




            using (FileStream stream = File.OpenWrite("output.ico"))
            {
                System.Drawing.Icon.FromHandle(bmp.GetHicon()).Save(stream);
            }
            Forms.NotifyIcon notifyIcon = new Forms.NotifyIcon();
            notifyIcon.Icon = new System.Drawing.Icon("output.ico");
            notifyIcon.Visible = true;

        }
}
}