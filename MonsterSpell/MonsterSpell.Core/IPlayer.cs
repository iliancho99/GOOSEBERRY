using MonsterSpell.Core.Characters;

namespace MonsterSpell.Core
{
    public interface IPlayer
    {
        string ID { get; set; }
        string NickName { get; set; }
        ICharacter[] Characters { get; }
        void AddCharacter(ICharacter character);
        void DeleteCharacter(ICharacter character);
    }
}
