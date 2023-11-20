using Application.Feature.CQRS.Commands.BannerCommand;
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
    public class CreateBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;
        public CreateBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBrandCommad command)
        {
            await _repository.CreateAsync(new Brand
            {
                BrandName = command.BrandName,
                Cars = command.Cars
            });
        }
    }
}
