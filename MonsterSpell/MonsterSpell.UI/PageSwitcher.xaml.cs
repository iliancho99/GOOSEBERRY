 using System;
using System.Windows.Navigation;

namespace MonsterSpell.UI
{
    /// <summary>
    /// Interaction logic for PageSwitcher.xaml
    /// </summary>
    public partial class PageSwitcher : NavigationWindow
    {
        public PageSwitcher()
        {
            InitializeComponent();
            this.ShowsNavigationUI = false;
        }

        private void OnWindowLoaded(object sender, EventArgs args)
        {
            this.Navigate(new LoginPage());
        }
    }
}
