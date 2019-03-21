using AutoLadDat.DataOperations;
using AutoLadDat.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfNotificationsApp.Cmds;
using WpfNotificationsApp.Helpers;
using WpfNotificationsApp.Models;

namespace WpfNotificationsApp.ViewModels
{
    public class MainWindowViewModel
    {
        public IList<Inventory> Cars { get; set; } = new ObservableCollection<Inventory>();

        public MainWindowViewModel()
        {
            using (InventoryDal cars = (new InventoryDal()))
            {
                var allCars = cars.GetAllInventory();
                foreach (var car in allCars)
                {
                    Cars.Add(ModelTransformations.CarToInventory(car));
                }
            }
        }

        private ICommand _changeColorCommand;
        public ICommand ChangeColorCommand => _changeColorCommand ?? (_changeColorCommand = new ChangeColorCommand());

        private RelayCommand<Inventory> _deleteCarCommand = null;
        public RelayCommand<Inventory> DeleteCarCommand => _deleteCarCommand ??
              (_deleteCarCommand = new RelayCommand<Inventory>(DeleteCar, CanDeleteCar));

        private bool CanDeleteCar(Inventory car)
        {
            return car != null;
        }
        private void DeleteCar(Inventory car)
        {
            Cars.Remove(car);
            using (InventoryDal inventory = (new InventoryDal()))
            {
                try
                {
                    inventory.DeleteCar(car.CarId);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void PersistChanges()
        {
            using (InventoryDal inventory = (new InventoryDal()))
            {
                foreach (var car in Cars)
                {
                    if (car.IsChanged)
                    {
                        inventory.UpdateCar(ModelTransformations.InventoryToCar(car));
                    }
                }

            }
        }

        public void AddCar(Inventory newCar)
        {
            Cars.Add(newCar);
            using (InventoryDal inventory = (new InventoryDal()))
            {
                inventory.InsertAuto(ModelTransformations.InventoryToCar(newCar));
            }

        }
    }
}
