using MonsterSpell.Core;
using MonsterSpell.Core.Characters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using MonsterSpell.Core.Characters.Warrior;

namespace MonsterSpell.UI
{
    /// <summary>
    /// Interaction logic for CharacterCreationPage.xaml
    /// </summary>
    public partial class CharacterCreationPage : Page
    {
        public CharacterCreationPage()
        {
            InitializeComponent();
        }

        private void OnCreateCharacterClicked(object sender, RoutedEventArgs e)
        {
            var random = new Random();
            GameEngine.Player.AddCharacter(new Warrior(this.UserNameInput.Text, random.Next(0, int.MaxValue).ToString()));
            (Application.Current.MainWindow as NavigationWindow).Navigate(new UserPage());
        }

    }
}
