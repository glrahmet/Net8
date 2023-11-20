using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feature.CQRS.Results.CarResults
{
    public class GetCarWithBrandQueryResult : CarBaseClass
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
    }
}
