using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace MonsterSpell.UI
{
    internal static class Extensions
    {
        public static void MoveTo(this Rectangle target, Point newPosition)
        {
            TranslateTransform transform = new TranslateTransform();
            target.RenderTransform = transform;

            DoubleAnimation topAnimation =
                new DoubleAnimation(Canvas.GetTop(target), newPosition.Y, TimeSpan.FromSeconds(1));
            DoubleAnimation leftAnimation =
                new DoubleAnimation(Canvas.GetLeft(target), newPosition.X, TimeSpan.FromSeconds(1));
            //leftAnimation.Completed += (s, e) => Canvas.SetLeft(target, newPosition.X);

            transform.BeginAnimation(TranslateTransform.XProperty, leftAnimation);
            transform.BeginAnimation(TranslateTransform.YProperty, topAnimation);
        }
    }

    public partial class GameWindow : Window
    {
        public GameWindow()
        {
            InitializeComponent();

            this.MouseRightButtonUp += OnMouseRightButtonUp;
            this.KeyUp += GameWindowKeyUp;
        }

        private void OnMouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.element.MoveTo(e.GetPosition(this.gameField));
        }

        private void GameWindowKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
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

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            this.gameField.Width = this.ActualWidth;
            this.gameField.Height = this.ActualHeight;
        }
    }
}
