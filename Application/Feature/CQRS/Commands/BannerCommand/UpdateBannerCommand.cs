using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feature.CQRS.Commands.BannerCommand
{
    public class UpdateBannerCommand : BannerBaseClass
    {
        public int Id { get; set; }
    }
}
