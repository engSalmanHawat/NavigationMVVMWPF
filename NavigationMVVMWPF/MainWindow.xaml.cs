using FontAwesome.Sharp;
using NavigationMVVMWPF.Classes;
using NavigationMVVMWPF.CustomControl;
using NavigationMVVMWPF.Views;
using NavigationMVVMWPF.Windows;
using System;
using System.Windows;

namespace NavigationMVVMWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext=new MainWindowViewModel();
        }
        internal void SwitchScreen(object sender)
        {
            var sub = ((SubItem)sender);

            if (sub.Screen!=null)
                navigateToPage(sub.Screen);
        }
        private void navigateToPage(string Menu)
        {
            foreach (Window window in Application.Current.Windows)
                if (window.GetType() == typeof(MainWindow))
                    _mainFrame.Navigate(new Uri(string.Format("{0}{1}{2}", "Views/", Menu, ".xaml"), UriKind.RelativeOrAbsolute));
        }
        internal void ExitFromProgramMethod()
        {
            try
            {
                MessageBoxResult m = MessageBox.Show("are youe shure?", "Worninng!", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (m == MessageBoxResult.OK)
                    Application.Current.Shutdown();
                else return;
            }
            catch (Exception ex) { MessageBox.Show("معلومات الخطأ " + ex.Message); }

        }

        private void Navigation_MVVM_WPF_Loaded(object sender, RoutedEventArgs e)
        {
            var dashboard = new ItemMenu("Home", "HomeView", IconChar.Home );
            var Exit = new ItemMenu("Exit", IconChar.Outdent);

            var menuUsers = new List<SubItem>();
            menuUsers.Add(new SubItem("PermissionsView", "PermissionsView", IconChar.PeopleGroup));
            menuUsers.Add(new SubItem("UserView", "UserView", IconChar.Users));
            menuUsers.Add(new SubItem("LocationTrackingView", "LocationTrackingView", IconChar.Location));
            menuUsers.Add(new SubItem("LocationTrackingView", "LocationTrackingView", IconChar.StreetView));
            var itemUsers = new ItemMenu("Users", menuUsers, IconChar.ShoppingBasket);

            var menuFacility = new List<SubItem>();
            menuFacility.Add(new SubItem("FacilitiesView", "FacilitiesView", IconChar.Building));
            menuFacility.Add(new SubItem("FacilitiesTypesView", "FacilitiesTypesView", IconChar.Typo3));
            menuFacility.Add(new SubItem("ReadExcelFileView", "ReadExcelFileView", IconChar.Upload));
            var itemFacility = new ItemMenu("Facilities", menuFacility, IconChar.BuildingFlag);

            var menuPlaces = new List<SubItem>();
            menuPlaces.Add(new SubItem("CountriesView", "CountriesView", IconChar.Landmark));
            menuPlaces.Add(new SubItem("ProvincesView", "ProvincesView", IconChar.Earth));
            menuPlaces.Add(new SubItem("ModirehView", "ModirehView", IconChar.Earth));
            menuPlaces.Add(new SubItem("StreetsView", "StreetsView", IconChar.StreetView));
            var itemPlaces = new ItemMenu("Places", menuPlaces, IconChar.Earth);

            Menu.Children.Add(new menuItemsUserControl(dashboard, this));
            Menu.Children.Add(new menuItemsUserControl(itemUsers, this));
            Menu.Children.Add(new menuItemsUserControl(itemFacility, this));
            Menu.Children.Add(new menuItemsUserControl(itemPlaces, this));
            Menu.Children.Add(new menuItemsUserControl(Exit, this));
            
            _mainFrame.Navigate(new HomeView());
        }
    }
}