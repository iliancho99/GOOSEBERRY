using MonsterSpell.Core.Characters;

namespace MonsterSpell.Core.Players
{
    public interface IPlayer
    {
        void CastSpell(ISpell spell);

        void OnAttacked(ISpell spell, IPlayer player, double damage);
    }
}
