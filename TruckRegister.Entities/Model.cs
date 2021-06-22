using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TruckRegister.Entities.Enums;

namespace TruckRegister.Entities
{
    public class Model
    {
        public Model()
        {

        }

        public Guid Id { get; private set; }

        [Column(TypeName = "nvarchar(250)")]
        public EnumModel ModelDescription { get; private set; }
        public int YearOfModel { get; private set; }
        public virtual ICollection<Truck> Trucks { get; private set; }
        private static DateTime DateActual { get; set; } = DateTime.Now;

        public Model(int yearModel, EnumModel modelDescription)
        {
            Id = Guid.NewGuid();
            YearOfModel = yearModel;
            ModelDescription = modelDescription;

            ValidDate(yearModel);
        }

        internal void ChangeModel(int yearModel, EnumModel modelDescription)
        {
            YearOfModel = yearModel;
            ModelDescription = modelDescription;

            ValidDate(yearModel);
        }

        private static void ValidDate(int yearModel)
        {
            if ((!yearModel.Equals(DateActual.Year))
                && (!yearModel.Equals(DateActual.AddYears(1).Year)))
            {
                throw new ValidationException(Messages.Messages.ModelDateInvalid);
            }
        }
    }
}
