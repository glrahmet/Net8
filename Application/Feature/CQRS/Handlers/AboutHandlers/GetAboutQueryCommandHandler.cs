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
    /// <summary>
    /// Crud işlemleri
    /// </summary>
    public class GetAboutQueryCommandHandler
    {
        private readonly IRepository<About> _repository;

        public GetAboutQueryCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAboutQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAboutQueryResult
            {
                Id = x.Id,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Title = x.Title
            }).ToList();
        }
    }
}
