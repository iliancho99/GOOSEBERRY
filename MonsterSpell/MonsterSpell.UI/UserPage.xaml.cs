﻿using MonsterSpell.Core;
using MonsterSpell.Core.DBModels;
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
