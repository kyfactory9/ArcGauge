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
using System.Windows.Threading;

namespace GaugeDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowModel model;

        public MainWindow()
        {
            InitializeComponent();

            model = this.Resources["model"] as MainWindowModel;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            model.Max = 100;
            model.Min = -100;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Random rnd_value = new Random();
            int temp = rnd_value.Next(-1000, 1000);
            model.Value = temp * 0.1;

            Random rnd_setting = new Random();
            int temp2 = rnd_setting.Next(0, 1000);
            model.SettingValue = temp2 * 0.1;
        }
    }
}
