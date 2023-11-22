using Application.Feature.CQRS.Results.CarResults;
using Application.Interfaces;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feature.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler
    {

        private readonly IRepository<Car> _repository;

        public GetCarWithBrandQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarWithBrandQueryResult>> Handle()
        {


            var values = await _repository.GetAllByFilterAsync(null, o => o.Include("Brand"));


            if (values != null)
            {
                return values.Select(x => new GetCarWithBrandQueryResult
                {
                    BrandName = x.Brand.BrandName,
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
                return new List<GetCarWithBrandQueryResult>();
        }
    }
}
