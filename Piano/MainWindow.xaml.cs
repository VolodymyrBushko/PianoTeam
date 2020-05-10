using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Resources;

namespace Piano
{
    public partial class MainWindow : Window
    {
        private SoundPlayer player = null;
        private StreamResourceInfo sri = null;
        private string numberKey = string.Empty;

        private bool ShouldWrite = false;
        List<RoutedEventArgs> list = null;

        public MainWindow()
        {
            player = new SoundPlayer();
            list = new List<RoutedEventArgs>();

            InitializeComponent();
        }

        private void buttonPlay_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"{list.Count}");
            Task.Run(() =>
            {
                foreach (var btn in list)
                {
                    button_Click(null, btn);
                    Thread.Sleep(500);
                }
            }); 
        }

        private void buttonStartStop_Click(object sender, RoutedEventArgs e)
        {
            if (ShouldWrite)
            {
                MessageBox.Show("recording off");
                ShouldWrite = false;
                this.buttonStartStop.Background = Brushes.Green;
            }
            else
            {
                MessageBox.Show("recording on");

                ShouldWrite = true;
                this.buttonStartStop.Background = Brushes.Red;
            }

        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            list.Clear();
            MessageBox.Show("List of sounds is empty!");
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            switch ((e.Source as Button).Name)
            {
                case "button1": numberKey = "1"; break;
                case "button2": numberKey = "2"; break;
                case "button3": numberKey = "3"; break;
                case "button4": numberKey = "4"; break;
                case "button5": numberKey = "5"; break;
                case "button6": numberKey = "6"; break;
                case "button7": numberKey = "7"; break;
            }
            if (ShouldWrite)
            {
                list.Add(e);
            }
            sri = Application.GetResourceStream(new Uri("Sounds/soundKey" + numberKey + ".wav", UriKind.Relative));

            player.Stream = sri.Stream;
            player.Load();
            player.Play();
            player.Dispose();
        }
    }
}