using MonsterSpell.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MonsterSpell.UI
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            HandleRequest(GameEngine.Register, () =>
            {
                MessageBox.Show("Registration successful!");
            });
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            HandleRequest(GameEngine.Login, () =>
            {
                Dispatcher.Invoke(() =>
                {
                    new GameWindow().Show();
                    this.Close();
                });
            });
        }

        private void HandleRequest(Action<string, string> action, Action callback)
        {
            try
            {
                ValidateInput();
                string username = this.usernameInput.Text;
                string password = this.passwordInput.Text;
                Task.Run(() =>
                {
                    try
                    {
                        action(username, password);
                        callback();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Please enter username and password!");
            }
        }

        private void ValidateInput()
        {
            if (string.IsNullOrEmpty(this.usernameInput.Text) ||
                string.IsNullOrEmpty(this.passwordInput.Text))
            {
                throw new InvalidOperationException();
            }
        }
    }
}