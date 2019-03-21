using System.ComponentModel;

namespace WpfNotificationsApp.Models
{
    public partial class Inventory : INotifyPropertyChanged
    {
        public int CarId { get; set; }
        public string Make { get; set; }
        public string Color { get; set; }
        public string PetName { get; set; }
        public bool IsChanged { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }

}
