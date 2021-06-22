using System;
using System.Threading.Tasks;
using TruckRegister.Entities;
using TruckRegister.Repository.Interface;
using TruckRegister.Services.Dtos;
using TruckRegister.Services.Interface;

namespace TruckRegister.Services
{
    public class TruckService : ITruckService
    {
        private readonly ITruckRepository _truckRepository;

        public TruckService(ITruckRepository truckRepository)
        {
            _truckRepository = truckRepository;
        }

        public async Task<ReturnDto> Delete(Guid id)
        {
            var returnDto = new ReturnDto();
            try
            {
                var model = await _truckRepository.GetById(id);
                if (model is not null)
                {
                    await _truckRepository.Delete(model);
                    return returnDto.AddSuccess(Messages.Messages.TruckDeleted);
                }
                return returnDto.AddError(Messages.Messages.TruckIdNotFound);
            }
            catch (Exception ex)
            {
                return returnDto.AddError(ex.Message);
            }
        }

        public async Task<ReturnDto> Save(TruckDto truckInformation)
        {
            var returnDto = new ReturnDto();
            try
            {
                var model = new Truck().AddTruck();
                model.AddModelTruck(truckInformation.YearOfModel, truckInformation.ModelDescription);
                await _truckRepository.Save(model);

                return returnDto.AddSuccess(Messages.Messages.TruckAdd);
            }
            catch (Exception ex)
            {
                return returnDto.AddError(ex.Message);
            }
        }

        public async Task<ReturnDto> Update(Guid id, TruckDto truckInformation)
        {
            var returnDto = new ReturnDto();
            try
            {
                var model = await _truckRepository.GetById(id);
                if (model is not null)
                {
                    model.ChangeInformationsTruck(truckInformation.YearOfModel, truckInformation.ModelDescription);
                    await _truckRepository.Update(model);
                    return returnDto.AddSuccess(Messages.Messages.TruckAdd);
                }
                return returnDto.AddError(Messages.Messages.TruckIdNotFound);
            }
            catch (Exception ex)
            {
                return returnDto.AddError(ex.Message);
            }
        }
    }
}
