using Application.Feature.CQRS.Commands.CarCommand;
using Application.Interfaces;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feature.CQRS.Handlers.CarHandlers
{
    public class CreateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCarCommand createCarCommand)
        {
            await _repository.AddAsync(new Car
            {
                BigImageUrl = createCarCommand.BigImageUrl,
                Brand = createCarCommand.Brand,
                BrandId = createCarCommand.BrandId,
                CarDescriptions = createCarCommand.CarDescriptions,
                CarFeatures = createCarCommand.CarFeatures,
                CarPricings = createCarCommand.CarPricings,
                CoverImageModel = createCarCommand.CoverImageModel,
                Fuel = createCarCommand.Fuel,
                Km = createCarCommand.Km,
                Lungage = createCarCommand.Lungage,
                Model = createCarCommand.Model,
                Seat = createCarCommand.Seat,
                TransMission = createCarCommand.TransMission
            });            
        }
    }
}
