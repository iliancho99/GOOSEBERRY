using MonsterSpell.Core;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace MonsterSpell.UI
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            // Simulate successful register
            (Application.Current.MainWindow as NavigationWindow).Navigate(new UserPage());
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            // Simulate successful login
            (Application.Current.MainWindow as NavigationWindow).Navigate(new UserPage());
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
