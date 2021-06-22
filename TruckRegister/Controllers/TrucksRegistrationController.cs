using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TruckRegister.Services.Dtos;
using TruckRegister.Services.Interface;

namespace TruckRegister.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrucksRegistrationController : ControllerBase
    {
        private readonly ITruckService _truckService;

        public TrucksRegistrationController(ITruckService truckService)
        {
            _truckService = truckService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostAsync([FromBody] TruckDto truckInformation)
        {
            try
            {
                var result = await _truckService.Save(truckInformation);

                if (result.Error)
                {
                    return BadRequest(result.Message);
                }
                return Ok(result.Message);

            }
            catch (Exception ex)
            {
                return Problem(detail: ex.StackTrace, title: ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(Guid id, [FromBody] TruckDto truckInformation)
        {
            try
            {
                var result = await _truckService.Update(id, truckInformation);

                if (result.Error)
                {
                    return BadRequest(result.Message);
                }
                return Ok(result.Message);

            }
            catch (Exception ex)
            {
                return Problem(detail: ex.StackTrace, title: ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var result = await _truckService.Delete(id);

                if (result.Error)
                {
                    return BadRequest(result.Message);
                }
                return Ok(result.Message);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.StackTrace, title: ex.Message);
            }
        }
    }
}
