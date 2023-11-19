using Application.Feature.CQRS.Commands.AboutCommand;
using Application.Feature.CQRS.Handlers.AboutHandlers;
using Application.Feature.CQRS.Queries.AboutQuries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AboutsController : ControllerBase
    {
        private readonly CreateAboutCommandHandler _createAboutCommandHandler;
        private readonly GetAboutQueryCommandHandler _getAboutQueryHandler;
        private readonly GetAboutByIdCommandHandler _getAboutByIdCommandHandler;

        private readonly UpdateAboutCommandHandler _updateAboutCommandHandler;
        private readonly RemoveAboutCommandHandler _removeAboutCommandHandler;
        public AboutsController(CreateAboutCommandHandler createAboutCommandHandler, GetAboutQueryCommandHandler getAboutQueryHandler, UpdateAboutCommandHandler updateAboutCommandHandler, RemoveAboutCommandHandler removeAboutCommandHandler, GetAboutByIdCommandHandler getAboutByIdCommandHandler)
        {
            _createAboutCommandHandler = createAboutCommandHandler;
            _getAboutQueryHandler = getAboutQueryHandler;
            _updateAboutCommandHandler = updateAboutCommandHandler;
            _removeAboutCommandHandler = removeAboutCommandHandler;
            _getAboutByIdCommandHandler = getAboutByIdCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var values = await _getAboutQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet]
        public async Task<IActionResult> AboutById(int id)
        {
            var values = await _getAboutByIdCommandHandler.Handle(new GetAboutByIdQuery(id));
            return Ok(values);
        }


        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutCommand command)
        {
              await _createAboutCommandHandler.Handle(command);
            return Ok("Bilgi Eklendi");
        } 

        [HttpDelete]
        public async Task<IActionResult> RemoveAbout(RemoveAboutCommand command)
        {
            await _removeAboutCommandHandler.Handle(command);
            return Ok("Bilgi Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand command)
        {
            await _updateAboutCommandHandler.Handle(command);
            return Ok("Bilgi Güncellendi");
        }
    }
}
