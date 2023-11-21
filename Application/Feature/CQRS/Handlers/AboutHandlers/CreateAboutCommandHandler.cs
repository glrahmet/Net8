using Application.Feature.CQRS.Commands.AboutCommand;
using Application.Interfaces;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feature.CQRS.Handlers.AboutHandlers
{
    public class CreateAboutCommandHandler
    {
        private readonly IRepository<About> _repository;

        public CreateAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAboutCommand createAboutCommand)
        {
            await _repository.AddAsync(new About
            {
                Title = createAboutCommand.Title,
                Description = createAboutCommand.Description,
                ImageUrl = createAboutCommand.ImageUrl
            });             
        }
    }
}
