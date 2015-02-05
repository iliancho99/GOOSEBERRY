using MonsterSpell.Core;
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
            this.Navigate(new UserPage(this.Navigate));
            //HandleRequest(GameEngine.Register, () => OnNavigation(null));
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            this.Navigate(new UserPage(this.Navigate));
            //HandleRequest(GameEngine.Login, () => OnNavigation(null));
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
