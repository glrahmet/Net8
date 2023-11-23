using Application.Feature.Mediator.Queries;
using Application.Feature.Mediator.Results;
using Application.Interfaces;
using Domain.Entites;
using MediatR;

namespace Application.Feature.Mediator.Handlers.FeatureHandlers
{
    public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQueries, List<GetFeatureQueryResult>>
    {
        private readonly IRepository<Features> _repository;
        public GetFeatureQueryHandler(IRepository<Features> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQueries request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetFeatureQueryResult
            {
                FeatureId = x.FeatureId,
                FeatureName = x.FeatureName
            }).ToList();
        }
    }
}
