using MonsterSpell.Core;
using MonsterSpell.Core.Characters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace MonsterSpell.UI
{
    /// <summary>
    /// Interaction logic for GamePlayPage.xaml
    /// </summary>
    public partial class GamePlayPage : Page
    {
        public readonly string AssemblyPath = string.Empty;

        private ICharacter currentCharacter = null;

        public GamePlayPage(ICharacter character)
        {
            InitializeComponent();

            if (character == null)
            {
                throw new ArgumentNullException("Character cannot be null!");
            }

            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            AssemblyPath = Path.GetDirectoryName(path);

            this.currentCharacter = character;
            ShowCharacterImage(character);

            this.SpellsIcons = new ObservableCollection<SpellIcon>();

            for (int i = 0; i < currentCharacter.Spells.Length; i++)
            {
                var spell = currentCharacter.Spells[i];
                this.SpellsIcons.Add(new SpellIcon() { Name = spell.Name, Bitmap = CreateSpellIcon(spell), CoolDown = 0 });
            }

            this.SpellsContainer.ItemsSource = this.SpellsIcons;
        }

        internal ObservableCollection<SpellIcon> SpellsIcons { get; set; }

        private BitmapImage CreateSpellIcon(ISpell spell)
        {
            var image = new Bitmap(AssemblyPath + @"\..\..\Images\neo_redux_energy_type_icons_by_ilkcmp-d3innms.png");
            var cloneRect = new Rectangle();
            var format = image.PixelFormat;
            
            switch (spell.Name)
            {
                case "Brutal Axe":
                    cloneRect = new Rectangle(0, 0, 120, 120);
                    break;
                default:
                    break;
            }

            var cloneBitmap = image.Clone(cloneRect, format);
            using (MemoryStream memory = new MemoryStream())
            {
                cloneBitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.DecodePixelWidth = 50;
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                return bitmapImage;
            }
        }

        private void ShowCharacterImage(ICharacter character)
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            path = Path.GetDirectoryName(path);

            switch (character.Type)
            {
                case CharacterType.Mage:
                    this.characterImage.Source = new BitmapImage(new Uri(path + @"\..\..\Images\Mage.png"));
                    break;
                case CharacterType.Warrior:
                    this.characterImage.Source = new BitmapImage(new Uri(path + @"\..\..\Images\class-warrior.png"));
                    break;
                default:
                    this.characterImage.Source = new BitmapImage(new Uri(path + @"\..\..\Images\class-warrior.png"));
                    break;
            }
        }

        public string CurrentCharImagePath { get; private set; }

        private void Back(object sender, System.Windows.RoutedEventArgs e)
        {
            (Application.Current.MainWindow as NavigationWindow).GoBack();
        }

        private void SpellsContainer_SelectionChanged(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show(((sender as DataGrid).SelectedItem as SpellIcon).Name);
        }
    }
}
