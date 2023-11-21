using Application.Feature.CQRS.Queries.BannerQueries;
using Application.Feature.CQRS.Queries.BrandQueries;
using Application.Feature.CQRS.Results.AboutResults;
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
    public class GetBrandByIdCommandHandler
    {
        private readonly IRepository<Brand> _repository;

        public GetBrandByIdCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery getBrandByIdQuery)
        {
            var values = await _repository.GetFirstByFilterAsync(p => p.Id == getBrandByIdQuery.Id);
            if (values != null)
            {
                return new GetBrandByIdQueryResult
                {
                    BrandName = values.BrandName,
                    Cars = values.Cars,
                    Id = values.Id,
                };
            }
            else
                return new GetBrandByIdQueryResult { };
        }
    }
}
