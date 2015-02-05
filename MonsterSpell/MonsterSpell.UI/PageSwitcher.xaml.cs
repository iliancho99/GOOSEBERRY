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
            var loginPage = new LoginPage((page) => this.Navigate(page));
            this.Navigate(loginPage);
        }
    }
}
