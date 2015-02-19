using MonsterSpell.Core;
using MonsterSpell.Core.Characters;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace MonsterSpell.UI
{
    /// <summary>
    /// Interaction logic for UserPage.xaml
    /// </summary>
    public partial class UserPage : System.Windows.Controls.Page
    {
        public const string DEFAULT_CHARACTER_IMAGE_SRC =
            "./Images/deffault_logo.png";

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

            var characters = GameEngine.Player.Characters.Select(x => CreateListItem(x));
            this.Characters = new ObservableCollection<CharacterListItem>(characters);
            CharactersListBox.ItemsSource = this.Characters;

            GameEngine.Player.OnCharacterAdded += character => EditList(character, true);
            GameEngine.Player.OnCharacterRemoved += character => EditList(character, false);
        }

        public ObservableCollection<CharacterListItem> Characters { get; private set; }

        private void EditList(ICharacter character, bool isAdded)
        {
            Debug.Assert(this.Characters != null,
                        "Characters list must not be null when user page is initialized");
            try
            {
                if (isAdded)
                {
                    this.Characters.Add(CreateListItem(character));
                }
                else
                {
                    var item = this.Characters.First(x => x.Character.Id == character.Id);
                    this.Characters.Remove(item);
                }
            }
            catch (InvalidOperationException)
            {
                // Ignore for now
            }
        }

        private CharacterListItem CreateListItem(ICharacter character)
        {
            string image = null;

            switch (character.Type)
            {
                case CharacterType.Mage:
                    image = @"..\..\Images\forest_guardian_by_artek92-d610d1r.jpg";
                    break;
                case CharacterType.Warrior:
                    image = @"..\..\Images\coniferous-forest.jpg";
                    break;
                default:
                    image = @DEFAULT_CHARACTER_IMAGE_SRC;
                    break;
            }

            var item = new CharacterListItem(character, image);
            return item;
        }

        private void OpenCharacterCreationPage(object sender, System.Windows.RoutedEventArgs e)
        {
            //(Application.Current.MainWindow as NavigationWindow).Navigate(new CharacterCreationPage());
            var random = new Random();
            GameEngine.Player.AddCharacter(new Warrior("NoName", random.Next(0, int.MaxValue).ToString()));
        }

        private void OnCharactersListBoxSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var character = ((sender as ListView).SelectedValue as CharacterListItem).Character;
            (Application.Current.MainWindow as NavigationWindow).Navigate(new GamePlayPage(character));
        }
    }
}
