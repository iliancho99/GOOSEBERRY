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
            this.Navigate(new UserPage(this.Navigate));
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            this.Navigate(new UserPage(this.Navigate));
        }

        private void ValidateInput()
        {
            if (string.IsNullOrEmpty(this.usernameInput.Text) ||
                string.IsNullOrEmpty(this.passwordInput.Text))
            {
                throw new InvalidOperationException("Please enter username and password");
            }
        }
    }
}
