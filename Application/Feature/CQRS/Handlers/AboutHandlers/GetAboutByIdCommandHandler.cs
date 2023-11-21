using Application.Feature.CQRS.Queries.AboutQuries;
using Application.Feature.CQRS.Results.AboutResults;
using Application.Interfaces;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feature.CQRS.Handlers.AboutHandlers
{
    public class GetAboutByIdCommandHandler
    {
        public readonly IRepository<About> _repository;

        public GetAboutByIdCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery getAboutByIdQuery)
        {
            var values = await _repository.GetFirstByFilterAsync(p => p.Id == getAboutByIdQuery.Id);
            if (values != null)
            {
                return new GetAboutByIdQueryResult
                {
                    Id = values.Id,
                    Description = values.Description,
                    ImageUrl = values.ImageUrl,
                    Title = values.Title
                };
            }
            else
                return new GetAboutByIdQueryResult();
        }
    }
}
