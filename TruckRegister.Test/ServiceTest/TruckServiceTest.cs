using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckRegister.Repository.Interface;
using TruckRegister.Services;
using TruckRegister.Services.Dtos;
using TruckRegister.Test.Fixture;
using Xunit;

namespace TruckRegister.Test.ServiceTest
{
    public class TruckServiceTest : IClassFixture<TruckFixture>
    {
        private readonly TruckFixture _fixture;
        private TruckService _truckService;
        private readonly Mock<ITruckRepository> _repositoryTruck;

        public TruckServiceTest(TruckFixture fixture)
        {
            _fixture = fixture;
            _repositoryTruck = new Mock<ITruckRepository>();
        }

        private void InitialService() => _truckService = new TruckService(_repositoryTruck.Object);

        #region Save

        [Fact]
        public async Task Save_Truck_With_Values_Corrects_Returns_Sucess()
        {
            InitialService();
            var result = await _truckService.Save(_fixture.TruckDto);

            Assert.True(result.Success);
            Assert.Equal(Messages.Messages.TruckAdd, result.Message);
        }

        [Fact]
        public async Task Save_Truck_With_Values_InCorrects_Model_Date_Returns_Error()
        {
            InitialService();
            var fixture = _fixture.TruckDto;
            fixture.YearOfModel = DateTime.Now.Year - 10;
            var result = await _truckService.Save(fixture);
            //assert
            Assert.False(result.Success);
            Assert.Equal(Messages.Messages.ModelDateInvalid, result.Message);
        }

        #endregion

        #region Update

        [Fact]
        public async Task Update_Truck_With_Values_Corrects_Returns_Sucess()
        {
            InitialService();
            _repositoryTruck.Setup(t => t.GetById(It.IsAny<Guid>())).ReturnsAsync(_fixture.Truck);
            var result = await _truckService.Update(Guid.NewGuid(), _fixture.TruckDto);

            Assert.True(result.Success);
            Assert.Equal(Messages.Messages.TruckAdd, result.Message);
        }

        [Fact]
        public async Task Update_Truck_With_Values_InCorrects_Model_Date_Returns_Error()
        {
            InitialService();
            _repositoryTruck.Setup(t => t.GetById(It.IsAny<Guid>())).ReturnsAsync(_fixture.Truck);
            var fixture = _fixture.TruckDto;
            fixture.YearOfModel = DateTime.Now.Year - 10;
            var result = await _truckService.Update(Guid.NewGuid(), fixture);
            //assert
            Assert.False(result.Success);
            Assert.Equal(Messages.Messages.ModelDateInvalid, result.Message);
        }

        [Fact]
        public async Task Update_Truck_With_Id_Not_Found_Returns_Error()
        {
            InitialService();
            var result = await _truckService.Update(Guid.NewGuid(), _fixture.TruckDto);
            //assert
            Assert.False(result.Success);
            Assert.Equal(Messages.Messages.TruckIdNotFound, result.Message);
        }

        #endregion

        #region Delete

        [Fact]
        public async Task Delete_Truck_Returns_Sucess()
        {
            InitialService();
            _repositoryTruck.Setup(t => t.GetById(It.IsAny<Guid>())).ReturnsAsync(_fixture.Truck);
            var result = await _truckService.Delete(Guid.NewGuid());

            Assert.True(result.Success);
            Assert.Equal(Messages.Messages.TruckDeleted, result.Message);
        }

        [Fact]
        public async Task Delete_Truck_Returns_Error()
        {
            InitialService();
            var result = await _truckService.Delete(Guid.NewGuid());
            //assert
            Assert.False(result.Success);
            Assert.Equal(Messages.Messages.TruckIdNotFound, result.Message);
        }

        [Fact]
        public async Task Delete_Truck_Returns_Error_Excption()
        {
            InitialService();
            _repositoryTruck.Setup(t => t.GetById(It.IsAny<Guid>())).ThrowsAsync(new Exception("Error"));

            var result = await _truckService.Delete(Guid.NewGuid());
            //assert
            Assert.False(result.Success);
            Assert.Equal("Error", result.Message);
        }

        #endregion
    }
}
