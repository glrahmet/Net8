using Application.Feature.CQRS.Commands.AboutCommand;
using Application.Interfaces;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feature.CQRS.Handlers.AboutHandlers
{
    public class UpdateAboutCommandHandler
    {
        private readonly IRepository<About> _repository;

        public UpdateAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAboutCommand updateAboutCommand)
        {
            var value = await _repository.GetByIdAsync(updateAboutCommand.Id);
            if (value != null)
            {
                value.Description = updateAboutCommand.Description;
                value.ImageUrl = updateAboutCommand.ImageUrl;
                value.Title = updateAboutCommand.Title;
                await _repository.Update(value);
            }
        }
    }
}
