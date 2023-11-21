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
    public class RemoveAboutCommandHandler
    {
        private readonly IRepository<About> _repository;

        public RemoveAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveAboutCommand removeAboutCommand)
        {
            var value = await _repository.GetFirstByFilterAsync(p => p.Id == removeAboutCommand.Id);
            if (value != null)
            {
                _repository.Remove(value);
            }
        }
    }
}
