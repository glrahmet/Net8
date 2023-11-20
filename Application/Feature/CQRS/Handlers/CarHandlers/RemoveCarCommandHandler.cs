using Application.Feature.CQRS.Commands.CarCommand;
using Application.Interfaces;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feature.CQRS.Handlers.CarHandlers
{
    public class RemoveCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public RemoveCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveCarCommand removeCarCommand)
        {
            var values = await _repository.GetByIdAsync(removeCarCommand.Id);
            if (values != null)
            {
                await _repository.Delete(values); 
            }
        }
    }
}
