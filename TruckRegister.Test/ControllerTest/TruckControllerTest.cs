using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TruckRegister.Services.Dtos;
using TruckRegister.Services.Interface;
using TruckRegister.WebApi.Controllers;
using Xunit;

namespace TruckRegister.Test.ControllerTest
{
    public class TruckControllerTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public TruckControllerTest()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        #region Post

        [Fact]
        public async Task Post_Truck_Return_Status_Code_200()
        {
            var truckServiceMock = new Mock<ITruckService>();
            truckServiceMock.Setup(t => t.Save(It.IsAny<TruckDto>()))
                .ReturnsAsync(new ReturnDto { Error = false, Message = Messages.Messages.TruckAdd, Success = true });

            var _contextMock = new Mock<HttpContext>();

            //Arrange
            var requestDto = new TruckDto
            {
                ModelDescription = Entities.Enums.EnumModel.FH,
                YearOfModel = DateTime.Now.Year
            };

            //Act
            var truckController = new TrucksRegistrationController(truckServiceMock.Object);

            truckController.ControllerContext.HttpContext = _contextMock.Object;
            var actionResult = await truckController.PostAsync(requestDto);

            //Assert
            var viewResult = Assert.IsType<OkObjectResult>(actionResult);
            Assert.Equal(Messages.Messages.TruckAdd, viewResult.Value);
        }

        [Fact]
        public async Task Post_Truck_Return_Status_Code_400()
        {
            //Arrange
            var truckServiceMock = new Mock<ITruckService>();
            truckServiceMock.Setup(t => t.Save(It.IsAny<TruckDto>()))
                .ReturnsAsync(new ReturnDto { Error = true, Message = Messages.Messages.ModelDateInvalid, Success = false });

            var _contextMock = new Mock<HttpContext>();
            var requestDto = new TruckDto();
          
            //Act
            var truckController = new TrucksRegistrationController(truckServiceMock.Object);

            truckController.ControllerContext.HttpContext = _contextMock.Object;
            var actionResult = await truckController.PostAsync(requestDto);

            //Assert
            var viewResult = Assert.IsType<BadRequestObjectResult>(actionResult);
            Assert.Equal(Messages.Messages.ModelDateInvalid, viewResult.Value);
        }

        [Fact]
        public async Task Post_Truck_Return_Status_Code_500()
        {
            //Arrange
            var truckServiceMock = new Mock<ITruckService>();
            truckServiceMock.Setup(t => t.Save(It.IsAny<TruckDto>()))
                .ThrowsAsync(new Exception("Invalid problem"));

            var _contextMock = new Mock<HttpContext>();
            var requestDto = new TruckDto();

            //Act
            var truckController = new TrucksRegistrationController(truckServiceMock.Object);

            truckController.ControllerContext.HttpContext = _contextMock.Object;
            var actionResult = await truckController.PostAsync(requestDto);

            //Assert
            ObjectResult objectResponse = Assert.IsType<ObjectResult>(actionResult);
            Assert.Equal(500, objectResponse.StatusCode);
        }

        #endregion

        #region Put

        [Fact]
        public async Task Put_Truck_Return_Status_Code_200()
        {
            var truckServiceMock = new Mock<ITruckService>();
            truckServiceMock.Setup(t => t.Update(It.IsAny<Guid>(),It.IsAny<TruckDto>()))
                .ReturnsAsync(new ReturnDto { Error = false, Message = Messages.Messages.TruckAdd, Success = true });

            var _contextMock = new Mock<HttpContext>();

            //Arrange
            var requestDto = new TruckDto
            {
                ModelDescription = Entities.Enums.EnumModel.FH,
                YearOfModel = DateTime.Now.Year
            };

            //Act
            var truckController = new TrucksRegistrationController(truckServiceMock.Object);

            truckController.ControllerContext.HttpContext = _contextMock.Object;
            var actionResult = await truckController.Put(Guid.NewGuid(),requestDto);

            //Assert
            var viewResult = Assert.IsType<OkObjectResult>(actionResult);
            Assert.Equal(Messages.Messages.TruckAdd, viewResult.Value);
        }

        [Fact]
        public async Task Put_Truck_Return_Status_Code_400()
        {
            //Arrange
            var truckServiceMock = new Mock<ITruckService>();
            truckServiceMock.Setup(t => t.Update(It.IsAny<Guid>(), It.IsAny<TruckDto>()))
                .ReturnsAsync(new ReturnDto { Error = true, Message = Messages.Messages.ModelDateInvalid, Success = false });

            var _contextMock = new Mock<HttpContext>();
            var requestDto = new TruckDto();

            //Act
            var truckController = new TrucksRegistrationController(truckServiceMock.Object);

            truckController.ControllerContext.HttpContext = _contextMock.Object;
            var actionResult = await truckController.Put(Guid.NewGuid(), requestDto);

            //Assert
            var viewResult = Assert.IsType<BadRequestObjectResult>(actionResult);
            Assert.Equal(Messages.Messages.ModelDateInvalid, viewResult.Value);
        }

        [Fact]
        public async Task Put_Truck_Return_Status_Code_500()
        {
            //Arrange
            var truckServiceMock = new Mock<ITruckService>();
            truckServiceMock.Setup(t => t.Update(It.IsAny<Guid>(), It.IsAny<TruckDto>()))
                .ThrowsAsync(new Exception("Invalid problem"));

            var _contextMock = new Mock<HttpContext>();
            var requestDto = new TruckDto();

            //Act
            var truckController = new TrucksRegistrationController(truckServiceMock.Object);

            truckController.ControllerContext.HttpContext = _contextMock.Object;
            var actionResult = await truckController.Put(Guid.NewGuid(), requestDto);

            //Assert
            ObjectResult objectResponse = Assert.IsType<ObjectResult>(actionResult);
            Assert.Equal(500, objectResponse.StatusCode);
        }

        #endregion

        #region Delete

        [Fact]
        public async Task Delete_Truck_Return_Status_Code_200()
        {
            var truckServiceMock = new Mock<ITruckService>();
            truckServiceMock.Setup(t => t.Delete(It.IsAny<Guid>()))
                .ReturnsAsync(new ReturnDto { Error = false, Message = Messages.Messages.TruckAdd, Success = true });

            var _contextMock = new Mock<HttpContext>();

            //Arrange
            var requestDto = new TruckDto
            {
                ModelDescription = Entities.Enums.EnumModel.FH,
                YearOfModel = DateTime.Now.Year
            };

            //Act
            var truckController = new TrucksRegistrationController(truckServiceMock.Object);

            truckController.ControllerContext.HttpContext = _contextMock.Object;
            var actionResult = await truckController.Delete(Guid.NewGuid());

            //Assert
            var viewResult = Assert.IsType<OkObjectResult>(actionResult);
            Assert.Equal(Messages.Messages.TruckAdd, viewResult.Value);
        }

        [Fact]
        public async Task Delete_Truck_Return_Status_Code_400()
        {
            //Arrange
            var truckServiceMock = new Mock<ITruckService>();
            truckServiceMock.Setup(t => t.Delete(It.IsAny<Guid>()))
                .ReturnsAsync(new ReturnDto { Error = true, Message = Messages.Messages.ModelDateInvalid, Success = false });

            var _contextMock = new Mock<HttpContext>();
            var requestDto = new TruckDto();

            //Act
            var truckController = new TrucksRegistrationController(truckServiceMock.Object);

            truckController.ControllerContext.HttpContext = _contextMock.Object;
            var actionResult = await truckController.Delete(Guid.NewGuid());

            //Assert
            var viewResult = Assert.IsType<BadRequestObjectResult>(actionResult);
            Assert.Equal(Messages.Messages.ModelDateInvalid, viewResult.Value);
        }

        [Fact]
        public async Task Delete_Truck_Return_Status_Code_500()
        {
            //Arrange
            var truckServiceMock = new Mock<ITruckService>();
            truckServiceMock.Setup(t => t.Delete(It.IsAny<Guid>()))
                .ThrowsAsync(new Exception("Invalid problem"));

            var _contextMock = new Mock<HttpContext>();
            var requestDto = new TruckDto();

            //Act
            var truckController = new TrucksRegistrationController(truckServiceMock.Object);

            truckController.ControllerContext.HttpContext = _contextMock.Object;
            var actionResult = await truckController.Delete(Guid.NewGuid());

            //Assert
            ObjectResult objectResponse = Assert.IsType<ObjectResult>(actionResult);
            Assert.Equal(500, objectResponse.StatusCode);
        }

        #endregion
    }
}
