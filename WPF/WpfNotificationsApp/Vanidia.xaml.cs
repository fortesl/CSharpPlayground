using System.Windows;
using WpfNotificationsApp.Models;

namespace WpfNotificationsApp
{
    /// <summary>
    /// Interaction logic for Vanidia.xaml
    /// </summary>
    public partial class Vanidia : Window
    {
        public Vanidia()
        {
            InitializeComponent();

            var emp = new Employee();

            ObjecDataBinding.DataContext = emp.GetEmployee();

            EmployeeList.ItemsSource = emp.GetEmployees();
        }

        public bool IsItemSelected { get; set; } = false;
    }
}
