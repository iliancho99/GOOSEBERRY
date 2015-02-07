using MonsterSpell.Core;
using MonsterSpell.Core.DBModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Documents;

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

            LoadCharacters();
        }

        private void LoadCharacters()
        {
            //Debug.Assert(GameEngine.Player != null);
            //CharactersListBox.ItemsSource = GameEngine.Player.Characters;
        }

        private void SwitchToCreateCharacterPage(object sender, System.Windows.RoutedEventArgs e)
        {
            //this.Navigate(new CharacterCreationPage(() => this.Navigate(this)));
        }
    }
}
