using AutoLadDat.Models;
using WpfNotificationsApp.Models;

namespace WpfNotificationsApp.Helpers
{
    static class ModelTransformations
    {

        public static Inventory CarToInventory(Car car)
        {
            return new Inventory
            {
                CarId = car.CarId,
                Make = car.Make,
                Color = car.Color,
                PetName = car.PetName,
                IsChanged = false
            };
        }

        public static Car InventoryToCar(Inventory car)
        {
            return new Car
            {
                CarId = car.CarId,
                Make = car.Make,
                Color = car.Color,
                PetName = car.PetName
            };
        }

    }
}
