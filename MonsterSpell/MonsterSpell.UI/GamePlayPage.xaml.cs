using MonsterSpell.Core.Characters;
using System;
using System.Windows.Controls;

namespace MonsterSpell.UI
{
    /// <summary>
    /// Interaction logic for GamePlayPage.xaml
    /// </summary>
    public partial class GamePlayPage : Page
    {
        private ICharacter currentCharacter = null;

        public GamePlayPage(ICharacter character)
        {
            InitializeComponent();

            if (character == null)
            {
                throw new ArgumentNullException("Character cannot be null!");
            }
        }
    }
}
