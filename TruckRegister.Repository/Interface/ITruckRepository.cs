using System;
using System.Threading.Tasks;
using TruckRegister.Entities;

namespace TruckRegister.Repository.Interface
{
    public interface ITruckRepository
    {
        Task Save(Truck model);
        Task<Truck> GetById(Guid id);
        Task Update(Truck model);
        Task Delete(Truck model);
    }
}
