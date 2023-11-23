using Application.Feature.Mediator.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feature.Mediator.Queries
{
    public class GetFeatureQueries : IRequest<List<GetFeatureQueryResult>>
    {
    }
}
