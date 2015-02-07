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

            // Load the values from CharacterType enum
            // We can add images for different types
            this.classListView.ItemsSource = Enum.GetNames(typeof(CharacterType));
        }

        private void OnCreateCharacterClicked(object sender, RoutedEventArgs e)
        {
            // TODO : Create character in the current player with the selected class
            // Page listview contains information for the selected class
            // Return to the previous page
            (Application.Current.MainWindow as NavigationWindow).GoBack();
        }
    }
}
