using MonsterSpell.Core;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MonsterSpell.UI
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private Action<Page> Navigate = null;

        public LoginPage(Action<Page> Navigate)
        {
            InitializeComponent();
            this.Navigate = Navigate;
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            HandleRequest(GameEngine.Register, () =>
            {
                this.Navigate(new UserPage(this.Navigate));
            });
        }

        private async void HandleRequest(Func<string, string, Task> func, Action action)
        {
            try
            {
                ValidateInput();
                string username = this.usernameInput.Text;
                string password = this.passwordInput.Text;
                try
                {
                    await func(username, password);
                    action();
                }
                catch (ClientException ex)
                {
                    MessageBox.Show(ex.Message);
                    action();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            HandleRequest(GameEngine.Login, () =>
                {
                    this.Navigate(new UserPage(this.Navigate));
                });
        }

        private void HandleRequest(Task action, Action callback)
        {
            
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
