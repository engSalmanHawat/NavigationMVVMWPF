using FontAwesome.Sharp;

namespace NavigationMVVMWPF.Classes
{
    public class SubItem
    {
        public SubItem(string name, string screen, IconChar icon)
        {
            Name = name;
            Screen = screen;
            Icon = icon;
        }
        public string Name { get; private set; }
        public string Screen { get; private set; }
        public IconChar Icon { get; private set; }
    }
}
