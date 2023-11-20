using Application.Feature.CQRS.Commands.AboutCommand;
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
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBannerCommand updateAboutCommand)
        {
            var values = await _repository.GetByIdAsync(updateAboutCommand.Id);

            if (values != null)
            {
                values.VideoUrl = updateAboutCommand.VideoUrl;
                values.Title = updateAboutCommand.Title;
                values.Description = updateAboutCommand.Description;
                values.VideoDescription = updateAboutCommand.VideoDescription;

                await _repository.Update(values);
            }
        }
    }
}
