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

namespace WpfBinaryResourcesApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public List<BitmapImage> ImageCollection = new List<BitmapImage>();
        private int _currentImage = 0;
        private bool useBinaryResource = true;


        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (useBinaryResource)
            {
                ImageCollection.Add(new BitmapImage(new Uri(@"\Images\Mouse trap.PNG", UriKind.Relative)));
                ImageCollection.Add(new BitmapImage(new Uri(@"\Images\asp vs asp core.PNG", UriKind.Relative)));
                ImageCollection.Add(new BitmapImage(new Uri(@"\Images\dotnet echo sysstem.PNG", UriKind.Relative)));
                ImageCollection.Add(new BitmapImage(new Uri(@"\Images\dotnet app choices.PNG", UriKind.Relative)));
            }
            else
            {
                var path = Environment.CurrentDirectory + @"\Images";

                ImageCollection.Add(new BitmapImage(new Uri($@"{path}\Mouse trap.PNG")));
                ImageCollection.Add(new BitmapImage(new Uri($@"{path}\asp vs asp core.PNG")));
                ImageCollection.Add(new BitmapImage(new Uri($@"{path}\dotnet echo sysstem.PNG")));
                ImageCollection.Add(new BitmapImage(new Uri($@"{path}\dotnet app choices.PNG")));
            }
            imageHolder.Source = ImageCollection[_currentImage];
        }

        private void btnNextImage_Click(object sender, RoutedEventArgs e)
        {
            var numberOfImages = ImageCollection.Count - 1;
            _currentImage = _currentImage < numberOfImages ? ++_currentImage : 0;
            imageHolder.Source = ImageCollection[_currentImage];
        }

        private void btnPreviousImage_Click(object sender, RoutedEventArgs e)
        {
            var numberOfImages = ImageCollection.Count - 1;
            _currentImage = _currentImage > 0 ? --_currentImage : numberOfImages;
            imageHolder.Source = ImageCollection[_currentImage];

        }
    }
}
