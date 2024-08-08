using NavigationMVVMWPF.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace NavigationMVVMWPF.Windows
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ImageSource ImageUriProperty { get; set; }

        public ImageSource ImageUri
        {
            get { return ImageUriProperty; }
            set { ImageUriProperty = value; OnPropertyChanged(nameof(ImageUriProperty)); }
        }

       

        public MainWindowViewModel()
        {
            ImageUri = new BitmapImage(new Uri("pack://application:,,,/Assest/jaib.png"));
        }
    }
}
