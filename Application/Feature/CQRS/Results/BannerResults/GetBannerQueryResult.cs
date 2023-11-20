using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feature.CQRS.Results.BannerResults
{
    public class GetBannerQueryResult: BannerBaseClass
    {
        public int Id { get; set; }
    }
}
