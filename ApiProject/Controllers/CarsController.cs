using Application.Feature.CQRS.Commands.BannerCommand;
using Application.Feature.CQRS.Commands.CarCommand;
using Application.Feature.CQRS.Handlers.BannerHandlers;
using Application.Feature.CQRS.Handlers.CarHandlers;
using Application.Feature.CQRS.Queries.BannerQueries;
using Application.Feature.CQRS.Queries.CarQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CarsController : ControllerBase
    {
        private readonly CreateCarCommandHandler _createCarCommandHandler;
        private readonly GetCarByIdCommandHandler _getCarByIdCommandHandler;
        private readonly GetCarCommandHandler _getCarCommandHandler;

        private readonly UpdateCarCommandHandler _updateCarCommandHandler;
        private readonly RemoveCarCommandHandler _removeCarCommandHandler;

        private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler;
        public CarsController(CreateCarCommandHandler createCarCommandHandler, GetCarCommandHandler getCarCommandHandler, UpdateCarCommandHandler updateCarCommandHandler, RemoveCarCommandHandler removeCarCommandHandler, GetCarByIdCommandHandler getBannerByIdQueryHandler, GetCarWithBrandQueryHandler getCarWithBrandQueryHandler)
        {
            _createCarCommandHandler = createCarCommandHandler;
            _getCarCommandHandler = getCarCommandHandler;
            _updateCarCommandHandler = updateCarCommandHandler;
            _removeCarCommandHandler = removeCarCommandHandler;
            _getCarByIdCommandHandler = getBannerByIdQueryHandler;
            _getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> CarList()
        {
            var values = await _getCarCommandHandler.Handle();
            return Ok(values);
        }

        [HttpGet]
        public async Task<IActionResult> CarById(int id)
        {
            var values = await _getCarByIdCommandHandler.Handle(new GetCarByIdQuery(id));
            return Ok(values);
        }


        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommand command)
        {
            await _createCarCommandHandler.Handle(command);
            return Ok("Bilgi Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCar(RemoveCarCommand command)
        {
            await _removeCarCommandHandler.Handle(command);
            return Ok("Bilgi Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateCarCommand command)
        {
            await _updateCarCommandHandler.Handle(command);
            return Ok("Bilgi Güncellendi");
        }
        [HttpGet]
        public async Task<IActionResult> GetCarWithBrand()
        {
            var values = await _getCarWithBrandQueryHandler.Handle();
            return Ok(values);
        }
    }
}
