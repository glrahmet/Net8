using Application.Feature.CQRS.Commands.BrandCommand;
using Application.Interfaces;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feature.CQRS.Handlers.BrandHandlers
{
    public class UpdateBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;

        public UpdateBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBrandCommand updateBrandCommand)
        {
            var values = await _repository.GetFirstByFilterAsync(p => p.Id == updateBrandCommand.Id);

            if (values != null)
            {
                values.BrandName = updateBrandCommand.BrandName;
                values.Cars = updateBrandCommand.Cars;
                _repository.Update(values);
            }
        }
    }
}
