using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfNotificationsApp.Models
{
    class Employee : INotifyPropertyChanged
    { 
        private string _name;
        public string Name {
            get => _name;
            set {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        private string _title;
        public string Title {
            get => _title;
            set
            {
                if (value != _title)
                {
                    _title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        private bool _isChanged;
        public bool IsChanged {
            get => _isChanged;
            set
            {
                if (value != _isChanged)
                {
                    _isChanged = value;
                    OnPropertyChanged(nameof(IsChanged));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Employee GetEmployee() => new Employee
        {
            Name = "Liz",
            Title = "Geek"
        };

        public ObservableCollection<Employee> GetEmployees() => new ObservableCollection<Employee> {
                new Employee
                {
                    Name = "Luis",
                    Title = "Dad"
                },
                new Employee
                {
                    Name = "Trat",
                    Title = "Son"
                }
            };

        private void OnPropertyChanged(string propertyName)
        {
            if (nameof(propertyName) != nameof(IsChanged))
            {
                IsChanged = true;
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
