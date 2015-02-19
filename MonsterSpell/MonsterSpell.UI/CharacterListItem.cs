using MonsterSpell.Core.Characters;
using System;
using System.Drawing;
using System.Linq;

namespace MonsterSpell.UI
{
    public class CharacterListItem
    {
        public CharacterListItem(ICharacter character, string imagePath)
        {
            if (character == null || string.IsNullOrEmpty(imagePath))
            {
                throw new ArgumentNullException("Please enter non null values!");
            }

            this.Character = character;
            this.ImagePath = imagePath;
        }
        public ICharacter Character { get; set; }

        public string ImagePath { get; set; }

        public override int GetHashCode()
        {
            int sum = this.Character.Id.Sum<char>(x => (int)Char.GetNumericValue(x));
            return sum;
        }
    }
}
