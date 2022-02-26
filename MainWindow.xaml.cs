using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace WpfCSharpSandbox
{
    public partial class MainWindow : Window
    {

        double _Rate = 1;
        double _Duration = 0.1;

        string _Text1 = "WPFは、ユーザインタフェースとロジックを明確に区別する一貫したプログラミングモデルを提供する。 WPFアプリケーションはデスクトップで実行するだけでなくウェブブラウザ上で配置・実行することもできる（ただし類似技術のSilverlightとは違い、Windowsのみがターゲット環境となる）。 WPFによって、ユーザインタフェース、2Dおよび3Dオブジェクトの描画、ベクトルグラフィックス、ラスターグラフィックス、アニメーション、音声および動画の再生などといった表現手法を統一的に利用することができる。WPF以前のWindowsアプリケーション開発では、それらを実現するためにはGDI/GDI+、DirectX Graphics (Direct3D他)、DirectX Audio (DirectSound他)[3][4]、WindowsマルチメディアAPI、DirectShowといった個別のWindows APIを使って実装しなければならなかった。.NET Framework 3.0はWindows Vistaにプリインストールされており、Windows XP SP2およびWindows Server 2003でも利用できる。また、Windows 7には.NET Framework 3.5 SP1がプリインストールされている。WPFのバージョン番号は、それが含まれる.NET Frameworkのバージョンと同列に扱われることが多い。例えば.NET 3.0上で動作するものはWPF 3.0、.NET 3.5 / 3.5 SP1で機能拡張されたものはWPF 3.5、そして.NET 4で機能拡張されたものはWPF 4といった具合である。 なお、Windows 8には.NET 4.5が、Windows 8.1には.NET 4.5.1が、そしてWindows 10には.NET 4.6がプリインストールされており、WPF 4.5以降を標準的に利用できるが、逆に.NET 3.5以前のコンポーネントは標準で有効になっていないため、WPF 3.0 / 3.5アプリケーションを動作させるためには明示的なインストールが必要である[5]。";
        string _Text2 = "XAMLは.NET Framework 3.0以降のテクノロジーにおいて広範囲にわたって使われている。とりわけ、Windows Presentation Foundation (WPF) および Silverlightにおいてユーザーインターフェイス要素やデータバインディング、イベント処理、などを定義するために、また、Windows Workflow Foundation (WF) においてワークフローそのものを定義するために用いられる。なお、Windows 8およびWindows RTで利用できるWinRT APIを使用したWindowsストアアプリでは、.NETアプリケーションに限らずC++ネイティブアプリケーション[2]でもXAMLを使ってUIを構築することが可能となっている。後発のWindows 10にて対応したユニバーサルWindowsプラットフォーム (UWP) アプリもまたWinRTベースであり、XAMLを利用して開発する。クロスプラットフォームな.NETアプリケーション開発に利用可能なXamarin.Formsでは、UIの記述にXAMLを用いる。これらのXAMLを利用するテクノロジー間で、個別のXAML要素の互換性については確保されておらず、名称が違っていたり、サポートされていなかったりする要素もあるが、いずれのフレームワークもほぼ同じ要領で開発できることが大きな利点となる。マイクロソフト固有のXAMLは主にWindowsプラットフォームに特化したものだが、XAML Standardと呼ばれる標準化プロジェクトも立ち上げられている[3][4]。";
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NextMove()
        {
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)obj.ActualWidth, (int)obj.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            rtb.Render(obj);

            img.Source = rtb;
            img.Visibility = Visibility.Visible;
            
            var animation = new ThicknessAnimation
            {
                From = new Thickness(-C.ActualWidth * _Rate, 0, 0, 0),
                To = new Thickness(0, 0, 0, 0),
                Duration = TimeSpan.FromSeconds(_Duration),
            };
            animation.Completed += (s, e) =>
            {
                rtb= null;
                img.Source = null;
                img.Visibility = Visibility.Collapsed;
            };
            TextChanger();
            obj.BeginAnimation(MarginProperty, animation);
        }

        private void PreviousMove()
        {
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)obj.ActualWidth, (int)obj.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            rtb.Render(obj);

            img.Source = rtb;
            img.Visibility = Visibility.Visible;

            var animation = new ThicknessAnimation
            {
                From = new Thickness(C.ActualWidth * _Rate, 0, 0, 0),
                To = new Thickness(0, 0, 0, 0),
                Duration = TimeSpan.FromSeconds(_Duration),
            };
            animation.Completed += (s, e) =>
            {
                rtb = null;
                img.Source = null;
                img.Visibility = Visibility.Collapsed;
            };
            TextChanger();
            obj.BeginAnimation(MarginProperty, animation);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PreviousMove();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NextMove();
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