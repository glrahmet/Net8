using Application.Feature.CQRS.Commands.BannerCommand;
using Application.Interfaces;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feature.CQRS.Handlers.BrandHandlers
{
    public class RemoveBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;

        public RemoveBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveBannerCommand removeBannerCommand)
        {
            var values = await _repository.GetByIdAsync(removeBannerCommand.Id);
            if (values != null)
            {
                await _repository.Delete(values);
            }
        }
    }
}
