
using System.Windows.Media.Imaging;
namespace MonsterSpell.UI
{
    internal class SpellIcon
    {
        public string Name { get; set; }
        public BitmapImage Bitmap { get; set; }
        public int CoolDown { get; set; }
    }
}
