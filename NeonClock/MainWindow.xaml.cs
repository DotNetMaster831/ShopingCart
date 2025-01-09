using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace NeonClock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private DispatcherTimer _timer;
        private string _previousTime;

        public MainWindow()
        {
            InitializeComponent();
            StartClock();
        }

        private void StartClock()
        {
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(1000) //Update every second
            };
            _timer.Tick += UpdateTime;
            _timer.Start();

            _previousTime = DateTime.Now.ToString("hh:mm:ss tt");
            UpdateTime(null, null);

        }

        private void UpdateTime(object sender, EventArgs e)
        {
            string currentTime = DateTime.Now.ToString("hh:mm:ss tt");

            AnimateIfChanged(HoursText, _previousTime.Substring(0, 2), currentTime.Substring(0, 2)); //Hours
            AnimateIfChanged(MinutesText, _previousTime.Substring(3, 2), currentTime.Substring(3, 2)); //Minutes
            AnimateIfChanged(SecondsText, _previousTime.Substring(6, 2), currentTime.Substring(6, 2)); //Seconds
            AnimateIfChanged(MerdianText, _previousTime.Substring(9, 2), currentTime.Substring(9, 2)); //Meridian

            _previousTime = currentTime;
        }

        private void AnimateIfChanged(TextBlock textBlock, string oldValue, string newValue)
        {
            //Flip out Animation
            if(oldValue != newValue)
            {
                DoubleAnimation flipout = new DoubleAnimation
                {
                    From = 1,
                    To = 0,
                    Duration = TimeSpan.FromMilliseconds(150)
                };

                flipout.Completed += (s, _) =>
                {
                    //updated text
                    textBlock.Text = newValue;

                    //Flip in animation
                    DoubleAnimation flipIn = new DoubleAnimation
                    {
                        From = 0,
                        To = 1,
                        Duration = TimeSpan.FromMilliseconds(150)
                    };
                    textBlock.RenderTransform.BeginAnimation(ScaleTransform.ScaleYProperty, flipIn);
                };
                textBlock.RenderTransform.BeginAnimation(ScaleTransform.ScaleYProperty, flipout);
            }
            else
            {
                //No change just update text
                textBlock.Text = newValue;
            }
        }
    }
}
