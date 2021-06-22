using Bogus;
using System;
using TruckRegister.Entities;
using TruckRegister.Entities.Enums;
using TruckRegister.Services.Dtos;

namespace TruckRegister.Test.Fixture
{
    public class TruckFixture
    {
        public TruckDto TruckDto =>
          new Faker<TruckDto>()
              .RuleFor(t => t.ModelDescription, EnumModel.FH)
              .RuleFor(t => t.YearOfModel, f => DateTime.Now.Year)
              .Generate();

        public Truck Truck =>
          new Faker<Truck>()
              .RuleFor(t => t.Id, Guid.NewGuid())
              .RuleFor(t => t.YearOfManufacture, f => DateTime.Now.Year)
              .RuleFor(t => t.ModelTruck, ModelTruck)
              .Generate();

        public Model ModelTruck =>
          new Faker<Model>()
              .RuleFor(t =>t.Id, Guid.NewGuid())
              .RuleFor(t => t.ModelDescription, EnumModel.FH)
              .RuleFor(t => t.YearOfModel, f => DateTime.Now.Year)
              .Generate();
    }
}
