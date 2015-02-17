using MonsterSpell.Core;
using MonsterSpell.Core.Characters;
using System.Diagnostics;
using System.Windows.Controls;

namespace MonsterSpell.UI
{
    /// <summary>
    /// Interaction logic for UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public UserPage()
        {
            InitializeComponent();

            this.CharactersListBox.SelectionChanged += (sender, args) =>
            {
                //var listView = sender as ListView;
                //var gamePlayPage = new GamePlayPage(this.Navigate);
                //this.Navigate(gamePlayPage);
            };

            Debug.Assert(GameEngine.Player != null);
            GameEngine.Player.OnCharacterAdded += character =>
                this.CharactersListBox.Items.Refresh();
            GameEngine.Player.OnCharacterRemoved += character =>
                this.CharactersListBox.Items.Refresh();
            CharactersListBox.ItemsSource = GameEngine.Player.Characters;
        }

        private void OpenCharacterCreationPage(object sender, System.Windows.RoutedEventArgs e)
        {
            //(Application.Current.MainWindow as NavigationWindow).Navigate(new CharacterCreationPage());
            GameEngine.Player.AddCharacter(new Warrior("NoName"));
        }
    }
}
