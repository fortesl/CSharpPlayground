using System.ComponentModel;

namespace WpfNotificationsApp.Models
{
    public partial class Inventory : IDataErrorInfo
    {
        private string _error;

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(CarId):
                        break;
                    case nameof(Make):
                        if (Make == "ModelT")
                        {
                            return "Too Old";
                        }
                        return CheckMakeAndColor();
                    case nameof(Color):
                        return CheckMakeAndColor();
                    case nameof(PetName):
                        break;
                }
                return string.Empty;
            }
        }

        public string Error => _error;

        internal string CheckMakeAndColor()
        {
            if (Make == "Chevy" && Color == "Pink")
            {
                return $"{Make}'s don't come in {Color}";
            }
            return string.Empty;
        }
        
    }
}
