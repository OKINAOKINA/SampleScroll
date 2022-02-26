using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace WpfCSharpSandbox
{
    public static class Extention
    {
        public static void AddFrame(this ThicknessKeyFrameCollection keyFrames, double place, double second)
        {
            keyFrames.Add(new SplineThicknessKeyFrame(new Thickness(place, 0, 0, 0), KeyTime.FromTimeSpan(TimeSpan.FromSeconds(second))));
        }
    }

    public partial class MainWindow : Window
    {

        double _Rate = 1;
        double _Duration = 0.15;
        //int _Resolution = 10;

        string _Text1 = "Component\nBehavior";
        string _Text2 = "Mesh\nAIMap";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Move(bool next)
        {
            var anim = new ThicknessAnimation
            {
                From = new Thickness(0, 0, 0, 0),
                To = new Thickness(C.ActualWidth * _Rate * (next ? 1 : -1), 0, 0, 0),
                Duration = TimeSpan.FromSeconds(_Duration),
            };

            var animation = new ThicknessAnimation
            {
                From = new Thickness(C.ActualWidth * _Rate * (next ? -1 : 1), 0, 0, 0),
                To = new Thickness(0, 0, 0, 0),
                Duration = TimeSpan.FromSeconds(_Duration),
            };

            anim.Completed += (s, e) =>
            {
                TextChanger();
                obj.BeginAnimation(MarginProperty, animation);
            };
            obj.BeginAnimation(MarginProperty, anim);
        }

        private void MoveKeyFrame(bool next)
        {
            var anim = new ThicknessAnimationUsingKeyFrames();
            var to = C.ActualWidth * _Rate * (next ? 1 : -1);
            anim.KeyFrames.AddFrame(0, 0);
            anim.KeyFrames.AddFrame(to * 0.25, _Duration * 0.5);
            anim.KeyFrames.AddFrame(to * 0.5, _Duration * 0.75);
            anim.KeyFrames.AddFrame(to, _Duration);

            var animation = new ThicknessAnimationUsingKeyFrames();
            var from = C.ActualWidth * _Rate * (next ? -1 : 1);
            animation.KeyFrames.AddFrame(from, 0);
            animation.KeyFrames.AddFrame(from * 0.5, _Duration * 0.25);
            animation.KeyFrames.AddFrame(from * 0.25, _Duration * 0.5);
            animation.KeyFrames.AddFrame(0, _Duration);

            anim.Completed += (s, e) =>
            {
                TextChanger();
                obj.BeginAnimation(MarginProperty, animation);
            };
            obj.BeginAnimation(MarginProperty, anim);
        }

        private void NextMove()
        {
            //RenderTargetBitmap rtb = new RenderTargetBitmap((int)obj.ActualWidth * _Resolution, (int)obj.ActualHeight * _Resolution, 96 * _Resolution, 96 * _Resolution, PixelFormats.Pbgra32);
            //rtb.Render(obj);

            //img.Source = rtb;
            //img.Visibility = Visibility.Visible;
            
            var animation = new ThicknessAnimation
            {
                From = new Thickness(-C.ActualWidth * _Rate, 0, 0, 0),
                To = new Thickness(0, 0, 0, 0),
                Duration = TimeSpan.FromSeconds(_Duration),
            };
            //animation.Completed += (s, e) =>
            //{
            //    rtb= null;
            //    img.Source = null;
            //    img.Visibility = Visibility.Collapsed;
            //};
            TextChanger();
            obj.BeginAnimation(MarginProperty, animation);
        }

        private void PreviousMove()
        {
            //RenderTargetBitmap rtb = new RenderTargetBitmap((int)obj.ActualWidth * _Resolution, (int)obj.ActualHeight * _Resolution, 96 * _Resolution, 96 * _Resolution, PixelFormats.Pbgra32);
            //rtb.Render(obj);

            //img.Source = rtb;
            //img.Visibility = Visibility.Visible;

            var animation = new ThicknessAnimation
            {
                From = new Thickness(C.ActualWidth * _Rate, 0, 0, 0),
                To = new Thickness(0, 0, 0, 0),
                Duration = TimeSpan.FromSeconds(_Duration),
            };
            //animation.Completed += (s, e) =>
            //{
            //    rtb = null;
            //    img.Source = null;
            //    img.Visibility = Visibility.Collapsed;
            //};
            TextChanger();
            obj.BeginAnimation(MarginProperty, animation);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MoveKeyFrame(false);
            //PreviousMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MoveKeyFrame(true);
            //NextMove();
        }

        private void TextChanger()
        {
            if (obj.Text == _Text1)
            {
                obj.Text = _Text2;
            }
            else
            {
                obj.Text = _Text1;
            }

        }
    }
}