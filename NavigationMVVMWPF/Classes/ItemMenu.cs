using FontAwesome.Sharp;

namespace NavigationMVVMWPF.Classes
{
    public class ItemMenu
    {
        public ItemMenu(string header, List<SubItem> subItems, IconChar icon)
        {
            Header = header;
            SubItems = subItems;
            Icon = icon;
        }
        public ItemMenu(string header, string screen, IconChar icon)
        {
            Header = header;
            Screen = screen;
            Icon = icon;
        }
        public ItemMenu(string header, IconChar icon)
        {
            Header= header;
            Icon = icon;
        }

        public string Header { get; private set; }
        public IconChar Icon { get; private set; }
        public List<SubItem> SubItems { get; private set; }
        public string Screen { get; private set; }
    }
}
