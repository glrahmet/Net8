using Application.Feature.CQRS.Queries.AboutQuries;
using Application.Feature.CQRS.Queries.BannerQueries;
using Application.Feature.CQRS.Results.AboutResults;
using Application.Feature.CQRS.Results.BannerResults;
using Application.Interfaces;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feature.CQRS.Handlers.BannerHandlers
{
    public class GetBannerByIdQueryHandler
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerByIdQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery getBannerByIdQuery)
        {
            var values = await _repository.GetFirstByFilterAsync(p=>p.Id==getBannerByIdQuery.Id);
            if (values != null)
            {
                return new GetBannerByIdQueryResult
                {
                    Description = values.Description,
                    Id = values.Id,
                    Title = values.Title,
                    VideoDescription = values.VideoDescription,
                    VideoUrl = values.VideoUrl
                };
            }
            else
                return new GetBannerByIdQueryResult();
        }
    }
}
