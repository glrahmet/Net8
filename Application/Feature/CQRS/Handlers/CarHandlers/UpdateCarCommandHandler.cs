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
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarCommand updateCarCommand)
        {
            var values = await _repository.GetByIdAsync(updateCarCommand.Id);
            if (values != null)
            {
                values.Fuel = updateCarCommand.Fuel;
                values.CarFeatures = updateCarCommand.CarFeatures;
                values.Brand = updateCarCommand.Brand;  
                values.BrandId = updateCarCommand.BrandId;  
                values.TransMission= updateCarCommand.TransMission; 
                values.CarPricings = updateCarCommand.CarPricings;
                values.BigImageUrl = updateCarCommand.BigImageUrl;
                values.CarDescriptions = updateCarCommand.CarDescriptions;
                values.CoverImageModel = updateCarCommand.CoverImageModel;
                values.Km=  updateCarCommand.Km;
                values.Lungage= updateCarCommand.Lungage;
                values.Model= updateCarCommand.Model;
                values.Seat=updateCarCommand.Seat;
                await _repository.Update(values);
            }
             
        }
    }
}
