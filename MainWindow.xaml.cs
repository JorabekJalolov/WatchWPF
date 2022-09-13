using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WatchWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Timer timer = new Timer();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer.Elapsed += vaqt_ketdi;
            timer.Interval = 500;
            timer.Enabled = true;
        }

        private void vaqt_ketdi(object sender, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(() => 
            {                

            if (TimeTxt.Opacity == 1)
            {
                    TimeTxt.Opacity = 0.5;
            }
            else
            {
                    TimeTxt.Opacity = 1;
                getDate();
            }
            });
        }

        private void DargBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) this.DragMove();
            if (e.ClickCount == 2)
            {
                timer.Enabled = false;
                this.Close();
            }
        }
        private void getDate()
        {
            TimeTxt.Text = DateTime.Now.Hour + ":" + DateTime.Now.Minute;
            DayTxt.Text = DateTime.Now.DayOfWeek.ToString();
            DateTxt.Text = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
        }
    }
}
