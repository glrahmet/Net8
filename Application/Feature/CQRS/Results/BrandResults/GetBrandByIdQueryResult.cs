using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feature.CQRS.Results.BrandResults
{
    public class GetBrandByIdQueryResult : BrandBaseClass
    {
        public int Id { get; set; }
    }
}
