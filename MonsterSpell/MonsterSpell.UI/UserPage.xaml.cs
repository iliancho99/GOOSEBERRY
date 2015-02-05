using MonsterSpell.Core.DBModels;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Documents;

namespace MonsterSpell.UI
{
    /// <summary>
    /// Interaction logic for UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        private Action<Page> Navigate = null;

        public UserPage(Action<Page> Navigate)
        {
            this.Navigate = Navigate;
            InitializeComponent();
            this.CharactersListBox.SelectionChanged += (sender, args) =>
            {
                var listView = sender as ListView;
                var gamePlayPage = new GamePlayPage(this.Navigate);
                this.Navigate(gamePlayPage);
            };

            LoadCharacters();
        }

        private void LoadCharacters()
        {
            List<User> items = new List<User>();
            items.Add(new User("qwe", "qwe"));
            items.Add(new User("qwe", "rwer"));
            items.Add(new User("qwe", "fdsfsdf"));
            CharactersListBox.ItemsSource = items;
        }
    }
}
