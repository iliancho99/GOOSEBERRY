using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace MonsterSpell.UI
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    /// 

    internal static class Extensions
    {
        public static void MoveTo(this Rectangle target, Point newPosition)
        {
            TranslateTransform transform = new TranslateTransform();
            target.RenderTransform = transform;
            DoubleAnimation topAnimation =
                new DoubleAnimation(target.Margin.Top, newPosition.Y, TimeSpan.FromSeconds(1));
            DoubleAnimation leftAnimation =
                new DoubleAnimation(target.Margin.Left, newPosition.X, TimeSpan.FromSeconds(1));

            transform.BeginAnimation(TranslateTransform.XProperty, leftAnimation);
            transform.BeginAnimation(TranslateTransform.YProperty, topAnimation);
        }
    }

    public partial class GameWindow : Window
    {
        public GameWindow()
        {
            InitializeComponent();

            this.MouseRightButtonUp += gameField_PreviewMouseRightButtonUp;

            this.KeyDown += GameWindow_KeyDown;
            this.KeyUp += GameWindow_KeyUp;
        }

        void gameField_PreviewMouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.element.MoveTo(e.GetPosition(this.gameField));
        }

        

        void GameWindow_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        void GameWindow_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            switch (e.Key)
            {
                case System.Windows.Input.Key.A:
                    break;
                case System.Windows.Input.Key.D:
                    break;
                case System.Windows.Input.Key.S:
                    break;
                case System.Windows.Input.Key.W:
                    break;
                default:
                    break;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.gameField.Width = this.ActualWidth;
            this.gameField.Height = this.ActualHeight;
        }
    }
}
