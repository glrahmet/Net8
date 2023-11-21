using Application.Feature.CQRS.Commands.BannerCommand;
using Application.Interfaces;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feature.CQRS.Handlers.BannerHandlers
{
    public class RemoveBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public RemoveBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveBannerCommand removeBannerCommand)
        {
            var values = await _repository.GetFirstByFilterAsync(p => p.Id == removeBannerCommand.Id);

            if (values != null)
            {
                _repository.Remove(values);
            }
        }
    }
}
