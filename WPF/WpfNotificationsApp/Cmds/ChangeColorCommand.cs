using System;
using System.Windows.Input;
using WpfNotificationsApp.Models;

namespace WpfNotificationsApp.Cmds
{
    class ChangeColorCommand : CommandBase
    {
        public override bool CanExecute(object parameter)
        {
            return (parameter as Inventory) != null;
        }

        public override void Execute(object parameter)
        {
            ((Inventory)parameter).Color = "Pink";
        }
    }
}
