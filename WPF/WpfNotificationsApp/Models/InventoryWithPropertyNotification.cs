using System.ComponentModel;

namespace WpfNotificationsApp.Models
{
    class InventoryWithPropertyNotification : INotifyPropertyChanged
    {
        public int CarId { get; set; }

        private string _make;
        public string Make
        {
            get => _make;
            set
            {
                if (value != _make)
                {
                    _make = value;
                    OnPropagationChanged(nameof(Make));
                }
            }
        }

        private string _color;
        public string Color
        {
            get => _color;
            set
            {
                if (value != _color)
                {
                    _color = value;
                    OnPropagationChanged(nameof(Color));
                }
            }
        }

        private string _petName;
        public string PetName
        {
            get => _petName;
            set
            {
                if (value != _petName)
                {
                    _petName = value;
                    OnPropagationChanged(nameof(PetName));
                }
            }
        }

        private bool _isChanged;
        public bool IsChanged
        {
            get => _isChanged;
            set
            {
                if (value != _isChanged)
                {
                    _isChanged = value;
                    OnPropagationChanged(nameof(IsChanged));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropagationChanged(string propertyName)
        {
            if (propertyName != nameof(IsChanged))
                IsChanged = true;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
