using Application.Feature.CQRS.Queries.CarQueries;
using Application.Feature.CQRS.Results.BrandResults;
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
    public class GetCarByIdCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarByIdCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery getCarByIdQuery)
        {
            var values = await _repository.GetFirstByFilterAsync(p => p.Id == getCarByIdQuery.Id);

            if (values != null)
            {
                return new GetCarByIdQueryResult
                {
                    CarPricings = values.CarPricings,
                    CarFeatures = values.CarFeatures,
                    CarDescriptions = values.CarDescriptions,
                    BrandId = values.BrandId,
                    Brand = values.Brand,
                    BigImageUrl = values.BigImageUrl,
                    CoverImageModel = values.CoverImageModel,
                    Fuel = values.Fuel,
                    Id = values.Id,
                    Km = values.Km,
                    Lungage = values.Lungage,
                    Model = values.Model,
                    Seat = values.Seat,
                    TransMission = values.TransMission
                };
            }
            else
                return new GetCarByIdQueryResult { };
        }
    }
}
