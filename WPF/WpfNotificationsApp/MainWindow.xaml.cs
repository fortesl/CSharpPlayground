using System.Collections.ObjectModel;
using System.Windows;
using WpfNotificationsApp.Models;
using WpfNotificationsApp.ViewModels;
using WpfNotificationsApp.Cmds;

namespace WpfNotificationsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly ObservableCollection<Inventory> _cars = new ObservableCollection<Inventory>();
        public MainWindow()
        {
            InitializeComponent();

            Closing += (sender, e) =>
            {
                ViewModel.PersistChanges();
            };
        }

        public MainWindowViewModel ViewModel { get; set; } = new MainWindowViewModel();
        private RelayCommand _addCarCommand;
        public RelayCommand AddCarCommand => _addCarCommand ??
            (_addCarCommand = new RelayCommand(AddCar, CanAddCar));


        public void Reset_Click(object sender, RoutedEventArgs args)
        {
            cboCars.SelectedItem = null;
        }

        private bool CanAddCar()
        {
            return cboCars.SelectedItem == null && !string.IsNullOrEmpty(make.Text);
        }

        private void AddCar()
        {
            var newCar = new Inventory
            {
                CarId = ViewModel.Cars.Count + 1,
                Make = make.Text,
                Color = color.Text,
                PetName = petName.Text,
                IsChanged = false
            };
            ViewModel.AddCar(newCar);
            cboCars.SelectedItem = newCar;
        }

        

    }
}
