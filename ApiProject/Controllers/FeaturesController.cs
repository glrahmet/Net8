using Application.Feature.Mediator.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class FeaturesController : ControllerBase
    {
        public readonly IMediator _mediator;

        public FeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> FeatureList()
        {
            var values = _mediator.Send(new GetFeatureQueries());
            return Ok(values);
        }
    }
}
