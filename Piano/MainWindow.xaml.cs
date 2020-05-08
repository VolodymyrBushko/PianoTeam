using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
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

namespace Piano
{
    public partial class MainWindow : Window
    {
        private List<string> sounds;
        private MediaPlayer mediaPlayer;

        public MainWindow()
        {
            InitializeComponent();
            InitializeSounds();
        }

        private void InitializeSounds()
        {
            sounds = new List<string>();
            mediaPlayer = new MediaPlayer();
            DirectoryInfo directory = new DirectoryInfo("Sounds");

            foreach (var file in directory.GetFiles())
                sounds.Add(file.FullName);
        }

        //Андрій, він твій
        private void buttonPlay_Click(object sender, RoutedEventArgs e)
        {

        }

        //Андрій, він твій
        private void buttonStartStop_Click(object sender, RoutedEventArgs e)
        {

        }


        //Він мій
        private void button_Click(object sender, RoutedEventArgs e)
        {
            switch ((e.Source as Button).Name)
            {
                case "button1": mediaPlayer.Open(new Uri(sounds[0])); break;
                case "button2": mediaPlayer.Open(new Uri(sounds[1])); break;
                case "button3": mediaPlayer.Open(new Uri(sounds[2])); break;
                case "button4": mediaPlayer.Open(new Uri(sounds[3])); break;
                case "button5": mediaPlayer.Open(new Uri(sounds[4])); break;
                case "button6": mediaPlayer.Open(new Uri(sounds[5])); break;
                case "button7": mediaPlayer.Open(new Uri(sounds[6])); break;
            }

            mediaPlayer.Play();
        }
    }
}