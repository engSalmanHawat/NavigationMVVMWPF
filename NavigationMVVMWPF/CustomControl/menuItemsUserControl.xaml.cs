using NavigationMVVMWPF.Classes;
using System;
using System.Collections.Generic;
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

namespace NavigationMVVMWPF.CustomControl
{
    /// <summary>
    /// Interaction logic for menuItemsUserControl.xaml
    /// </summary>
    public partial class menuItemsUserControl : UserControl
    {
        MainWindow _context;
        public menuItemsUserControl(ItemMenu itemMenu, MainWindow context)
        {
            InitializeComponent();

            _context = context;

            ExpanderMenu.Visibility = itemMenu.SubItems == null ? Visibility.Collapsed : Visibility.Visible;
            ListViewItemMenu.Visibility = itemMenu.SubItems == null ? Visibility.Visible : Visibility.Collapsed;

            this.DataContext = itemMenu;
        }


        private async void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _context.SwitchScreen(((SubItem)((ListView)sender).SelectedItem));
        }
        private void ListViewItemMenu_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem listBoxItem = (ListBoxItem)sender;
            var d = (ItemMenu)listBoxItem.DataContext;
            SubItem sub = new SubItem(d.Header, d.Screen, d.Icon);
            if (sub.Name.Contains("Exit")) _context.ExitFromProgramMethod();
            else _context.SwitchScreen(sub);
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
                _context.SwitchScreen((SubItem)item.DataContext);
        }
    }
}
