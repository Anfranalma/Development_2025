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

namespace WMNewBorn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool Playstate = false;
        bool Stopstate = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            Me.Play();
            Playstate = true;
            Stopstate = false;
        }

        private void StopBtn_Click(object sender, RoutedEventArgs e)
        {
            Me.Stop();
            Playstate = false;
            Stopstate = true;
        }

        private void PauseBtn_Click(object sender, RoutedEventArgs e)
        {

            
            if (Playstate == false)
            {
                Me.Play();
                Playstate = true;
            }
            else
            {
                Me.Pause();
                Playstate = false;
            }
        }

        private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Me.Volume = VolumeSlider.Value;
        }
    }
}
