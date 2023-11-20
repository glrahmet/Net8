using Application.Feature.CQRS.Results.BannerResults;
using Application.Feature.CQRS.Results.BrandResults;
using Application.Interfaces;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feature.CQRS.Handlers.BrandHandlers
{
    public class GetBrandCommandHandler
    {
        private IRepository<Brand> _repository;

        public GetBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBrandQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();

            return values.Select(x => new GetBrandQueryResult
            {
                Id = x.Id,
                BrandName = x.BrandName,
                Cars = x.Cars

            }).ToList();
        }
    }
}
