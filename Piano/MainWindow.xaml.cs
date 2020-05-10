using System;
using System.Media;
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

        public MainWindow()
        {
            player = new SoundPlayer();

            InitializeComponent();
        }

        //Андрій, він твій
        private void buttonPlay_Click(object sender, RoutedEventArgs e)
        {

        }

        //Андрій, він твій
        private void buttonStartStop_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hi from Andriy");
            this.Background = Brushes.Red;
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

            sri = Application.GetResourceStream(new Uri("Sounds/soundKey" + numberKey + ".wav", UriKind.Relative));

            player.Stream = sri.Stream;
            player.Load();
            player.Play();
            player.Dispose();
        }
    }
}