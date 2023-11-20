using Application.Feature.CQRS.Results.CarResults;
using Application.Interfaces;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feature.CQRS.Handlers.CarHandlers
{
    public class GetCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();

            if (values != null)
            {
                return values.Select(x => new GetCarQueryResult
                {
                    BigImageUrl = x.BigImageUrl,
                    Brand = x.Brand,
                    BrandId = x.BrandId,
                    CarDescriptions = x.CarDescriptions,
                    CarFeatures = x.CarFeatures,
                    CarPricings = x.CarPricings,
                    CoverImageModel = x.CoverImageModel,
                    Fuel = x.Fuel,
                    Id = x.Id,
                    Km = x.Km,
                    Lungage = x.Lungage,
                    Model = x.Model,
                    Seat = x.Seat,
                    TransMission = x.TransMission
                }).ToList();

            }
            else
                return new List<GetCarQueryResult>();
        }
    }
}
