using System;
using TruckRegister.Entities.Enums;

namespace TruckRegister.Entities
{
    public class Truck
    {
        public Truck()
        {
        }

        public Guid Id { get; set; }
        public int YearOfManufacture { get; set; }
        public Model ModelTruck { get; private set; }
        public Guid IdModel { get; private set; }

        public Truck AddTruck()
        {
            Id = Guid.NewGuid();
            YearOfManufacture = DateTime.Now.Year;
            return this;
        }

        public void ChangeInformationsTruck(int yearModel, EnumModel modelDescription)
        {
            ModelTruck.ChangeModel(yearModel, modelDescription);
        }

        public void AddModelTruck(int yearOfModel, EnumModel modelDescription)
        {
            ModelTruck = new Model(yearOfModel, modelDescription);
        }
    }
}
