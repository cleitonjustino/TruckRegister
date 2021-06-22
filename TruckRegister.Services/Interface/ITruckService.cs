using System;
using System.Threading.Tasks;
using TruckRegister.Services.Dtos;

namespace TruckRegister.Services.Interface
{
    public interface ITruckService
    {
        Task<ReturnDto> Save(TruckDto truckInformation);
        Task<ReturnDto> Update(Guid id,  TruckDto truckInformation);
        Task<ReturnDto> Delete(Guid id);
    }
}
