using System;
using System.Windows.Controls;

namespace MonsterSpell.UI
{
    /// <summary>
    /// Interaction logic for GamePlayPage.xaml
    /// </summary>
    public partial class GamePlayPage : Page
    {
        private Action<Page> Navigate = null;

        public GamePlayPage(Action<Page> Navigate)
        {
            this.Navigate = Navigate;
            InitializeComponent();
        }
    }
}
